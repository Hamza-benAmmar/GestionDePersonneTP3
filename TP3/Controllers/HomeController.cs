using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using TP3.Models;

namespace TP3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Console.WriteLine("opening a conection to a database : ");
            try
            {
                using (SQLiteConnection sqlCon = new SQLiteConnection("Data Source=.\\2022 GL3 .NET Framework TP3 - SQLite database.db;Integrated Security=True"))
                {
                    sqlCon.Open();
                    Console.WriteLine("connection opened");
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", sqlCon);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("id:{0} ,first name :{1} ,last name : {2} ,email : {3} , image: {4}, country :{5}",
                                reader["id"], reader["first_name"], reader["last_name"], reader["email"], reader["image"], reader["country"]
                                );
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}