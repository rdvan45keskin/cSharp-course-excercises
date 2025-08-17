using System;
using System.Text;
using System.Threading;

class Program
{
    static float A = 0, B = 0, C = 0;
    static int width = 160, height = 44;
    static float cubeWidth = 20;
    static int distanceFromCam = 100;
    static float K1 = 40;
    static float[] zBuffer = new float[160 * 44];
    static char[] buffer = new char[160 * 44];
    static float incrementSpeed = 0.6f;
    static float horizontalOffset;

    static float CalculateX(float i, float j, float k) =>
        j * (float)Math.Sin(A) * (float)Math.Sin(B) * (float)Math.Cos(C) -
        k * (float)Math.Cos(A) * (float)Math.Sin(B) * (float)Math.Cos(C) +
        j * (float)Math.Cos(A) * (float)Math.Sin(C) +
        k * (float)Math.Sin(A) * (float)Math.Sin(C) +
        i * (float)Math.Cos(B) * (float)Math.Cos(C);

    static float CalculateY(float i, float j, float k) =>
        j * (float)Math.Cos(A) * (float)Math.Cos(C) +
        k * (float)Math.Sin(A) * (float)Math.Cos(C) -
        j * (float)Math.Sin(A) * (float)Math.Sin(B) * (float)Math.Sin(C) +
        k * (float)Math.Cos(A) * (float)Math.Sin(B) * (float)Math.Sin(C) -
        i * (float)Math.Cos(B) * (float)Math.Sin(C);

    static float CalculateZ(float i, float j, float k) =>
        k * (float)Math.Cos(A) * (float)Math.Cos(B) -
        j * (float)Math.Sin(A) * (float)Math.Cos(B) +
        i * (float)Math.Sin(B);

    static void CalculateForSurface(float cubeX, float cubeY, float cubeZ, char ch)
    {
        float x = CalculateX(cubeX, cubeY, cubeZ);
        float y = CalculateY(cubeX, cubeY, cubeZ);
        float z = CalculateZ(cubeX, cubeY, cubeZ) + distanceFromCam;

        float ooz = 1 / z;

        int xp = (int)(width / 2 + horizontalOffset + K1 * ooz * x * 2);
        int yp = (int)(height / 2 + K1 * ooz * y);

        int idx = xp + yp * width;
        if (idx >= 0 && idx < width * height)
        {
            if (ooz > zBuffer[idx])
            {
                zBuffer[idx] = ooz;
                buffer[idx] = ch;
            }
        }
    }

    static void FillArray<T>(T[] array, T value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = value;
        }
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.SetWindowSize(width, height);
        Console.Clear();

        while (true)
        {
            FillArray(buffer, '.');
            FillArray(zBuffer, 0f);

            cubeWidth = 20;
            horizontalOffset = -2 * cubeWidth;

            // İlk küp
            for (float cubeX = -cubeWidth; cubeX < cubeWidth; cubeX += incrementSpeed)
            {
                for (float cubeY = -cubeWidth; cubeY < cubeWidth; cubeY += incrementSpeed)
                {
                    CalculateForSurface(cubeX, cubeY, -cubeWidth, '@');
                    CalculateForSurface(cubeWidth, cubeY, cubeX, '$');
                    CalculateForSurface(-cubeWidth, cubeY, -cubeX, '~');
                    CalculateForSurface(-cubeX, cubeY, cubeWidth, '#');
                    CalculateForSurface(cubeX, -cubeWidth, -cubeY, ';');
                    CalculateForSurface(cubeX, cubeWidth, cubeY, '+');
                }
            }

            Console.SetCursorPosition(0, 0); // İmleci en üst sol köşeye getir
            for (int k = 0; k < buffer.Length; k++)
            {
                if (k % width == 0)
                    Console.WriteLine(); // Yeni satıra geç
                Console.Write(buffer[k]);
            }

            A += 0.05f;
            B += 0.05f;
            C += 0.01f;

            Thread.Sleep(16); // 60 FPS için bekleme süresi (~16ms)
        }
    }
}
