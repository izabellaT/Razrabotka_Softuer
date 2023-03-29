using System;
using System.Data.SqlClient;

namespace SqlMinions
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection db = new SqlConnection
                (
                "Server=.;Database=master;Integrated Security=true"
                );

            db.Open();

            using(db)
            {
                SqlCommand command1 = new SqlCommand
                    (
                    "CREATE DATABASE MinionsOne", db
                    );
                command1.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand
                    (
                    "USE MinionsOne", db
                    );
                command2.ExecuteNonQuery();

                SqlCommand command3 = new SqlCommand
                    (
                    "CREATE TABLE minions(id INT, name VARCHAR(50), age INT)", db
                    );
                command3.ExecuteNonQuery();

                SqlCommand command4 = new SqlCommand
                    (
                    "INSERT INTO minions (id, name, age) VALUES ('1', 'Kevin', '15');" +
                    "INSERT INTO minions (id, name, age) VALUES ('2', 'Bob', '22');" +
                    "INSERT INTO minions (id, name, age) VALUES ('3', 'Steward', '42');", db
                    );
                command4.ExecuteNonQuery();
            }
            SqlCommand command5 = new SqlCommand
                    (
                    "SELECT name,age FROM minions;", db
                    );
            SqlDataReader reader = command5.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Name: {0}, Age: {1}", reader[0], reader[1]); 
            }
        }
    }
}
