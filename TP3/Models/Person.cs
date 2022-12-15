namespace TP3.Models
{
    public class Person
    {
        private object v1;
        private object v2;
        private object v3;
        private object v4;
        private object v5;
        private object v6;

        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set;}
        public string email { get; set; }
        public DateTime date_birth { get; set; }
        public string image { get; set; }
        public string country { get; set; } 
        public Person() { }
        public Person(int id , string first_name, string last_name , string email , string image , string country)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.image = image;
            this.country = country;
        }

        public Person(object v1, object v2, object v3, object v4, object v5, object v6)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
        }
    }
}
