using System.Data.SQLite;
using System.Security.Cryptography.X509Certificates;

namespace TP3.Models
{
    public class Personal_info
    { 
        public static List<Person> GetAllPerson(SQLiteConnection sqlCon)
        {
            List<Person> persons= new List<Person>();
            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();
                    Console.WriteLine("connection opened");
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", sqlCon);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
							int id = (int)reader["id"];
							string first_name = (string)reader["first_name"];
							string last_name = (string)reader["last_name"];
							string email = (string)reader["email"];
							string image = (string)reader["image"];
							string country = (string)reader["country"];
							Person person = new Person(id, first_name, last_name, email, image, country);
                            persons.Add(person);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
            }
            return persons;
        }
        public static Person? GetPerson(SQLiteConnection sqlCon , int id) {
                using (sqlCon)
                    {
                    sqlCon.Open();
                    Console.WriteLine("connection opened");
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info where id=@id", sqlCon);
                    cmd.Parameters.Add(new SQLiteParameter("@id", id));
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                        string first_name = (string)reader["first_name"];
                        string last_name = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        Person person = new Person(id, first_name, last_name, email, image, country);
                        return person;
                    }
                
                    }
                
                }
            return null;

        }
        public static int search(string country, string first_name, SQLiteConnection con) { 
            using (con)
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand("SELECT id FROM personal_info where country=@country and first_name=@first_name ", con);
                cmd.Parameters.Add(new SQLiteParameter("@country", country));
                cmd.Parameters.Add(new SQLiteParameter("@first_name", first_name));
                return (int) cmd.ExecuteScalar();
            }
        }
        public static void Add(Person p, SQLiteConnection con)
        {
            using (con)
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand("Insert into personal_info(id,first_name,last_name,email,date_birth,image,country) Values (@id,@first_name,@last_name,@email,@date_birth,@image,@country)", con);
                cmd.Parameters.Add(new SQLiteParameter("@id", p.id));
                cmd.Parameters.Add(new SQLiteParameter("@first_name", p.first_name));
                cmd.Parameters.Add(new SQLiteParameter("@last_name", p.last_name));
                cmd.Parameters.Add(new SQLiteParameter("@email", p.email));
                cmd.Parameters.Add(new SQLiteParameter("@date_birth", p.date_birth));
                cmd.Parameters.Add(new SQLiteParameter("@image", p.image));
                cmd.Parameters.Add(new SQLiteParameter("@country", p.country));
                cmd.ExecuteNonQuery();
            }
        }
         public static void Delete(int id ,SQLiteConnection con)
        {
            using (con)
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand("Delete from personal_info where id=@id",con);
                cmd.Parameters.Add(new SQLiteParameter("@id", id));
                cmd.ExecuteNonQuery();
            }
        }
    }
}
