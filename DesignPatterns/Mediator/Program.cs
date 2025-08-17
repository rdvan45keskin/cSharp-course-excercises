using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    //farklı birimlerden gelen bilgileri yönetme,yönlendirme
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher engin = new Teacher(mediator);
            engin.Name = "Engin";
            mediator.Teacher = engin;

            Student selo = new Student(mediator);
            selo.Name = "Selo";

            Student nicat = new Student(mediator);
            nicat.Name = "Nicat";

            mediator.Students = new List<Student> {selo,nicat };



            engin.SendNewImageUrl("image.jpg");
            engin.RecieveQuestion("is it true?", nicat);

            nicat.AskQuestion("Is it working?",nicat);

        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; internal set; }

        //CourseMember belirleme
        public Teacher(Mediator mediator) : base(mediator)
        {

        }

        //soru alma
        internal void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine($"Teacher recieved a question from {student.Name} and question is : {question}");
        }

        //image yollama
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine($"Teacher sent a new image : {url}");
            Mediator.UpdateImage(url);
        }

        //soru cevaplama
        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine($"Teacher answered {student.Name}'s question :  {answer}");
        }

    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public  string  Name { get; set; }
        internal void ReceiveImage(object url)
        {
            Console.WriteLine($"{Name} received image : {url}");
        }

        internal static void RecieveAnswer(string answer)
        {
            Console.WriteLine($"Student received answer : {answer}");
        }

        public void AskQuestion(string question,Student student)
        {
            Console.WriteLine($"{student.Name} sent a question : {question}");
            Mediator.SendQuestion(question,student);
        }


    }

    class Mediator
    {

        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        //resim yollama
        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question,student);
        }

        public void SendAnswer(string answer, Student student)
        {
            Student.RecieveAnswer(answer);
        }


    }
}
