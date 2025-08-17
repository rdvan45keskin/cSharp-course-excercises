using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AdoNetDemo_Database_
{
    //veritabanından veri çekme,güncelleme,silme vb şeyleri yapma
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=RIDVANKESKIN\SQLEXPRESS;initial catalog=ETrade;integrated security=true");

        public List<Product> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Products", _connection); //sorguyu bağlantıya yollama

            SqlDataReader reader = command.ExecuteReader();         //sonuç döndürme

            List<Product> products = new List<Product>();

            while (reader.Read()) 
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                products.Add(product);
            }

            reader.Close();
            _connection.Close();
            return products;
        }

        private void ConnectionControl() 
        {
            if (_connection.State == ConnectionState.Closed)       //bağlantı kapalıysa
            {
                _connection.Open();                              //bağlantıyı aç
            }
        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Insert into Products values (@name,@unitPrice,@stockAmount)", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();

            _connection.Close();
        }


        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Products set Name=@name,UnitPrice=@unitPrice,StockAmount=@stockAmount where Id=@id", _connection);
            command.Parameters.AddWithValue("@id", product.Id);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from Products where Id=@id", _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            _connection.Close();
        }




        /*public DataTable GetAll()
        {
            string connectionString = @"server=RIDVANKESKIN\SQLEXPRESS;initial catalog=ETrade;integrated security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            if (connection.State == ConnectionState.Closed)       //bağlantı kapalıysa
            {
                connection.Open();                              //bağlantıyı aç
            }
            string querry = ("Select * from Products");
            SqlCommand command = new SqlCommand(querry, connection); //sorguyu bağlantıya yollama

            SqlDataReader reader = command.ExecuteReader();         //sonuç döndürme

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            connection.Close();
            return dataTable;
        }
        */
    }
}
