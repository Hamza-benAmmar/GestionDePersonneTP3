using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using TP3.Models;

namespace TP3.Controllers
{
    public class PersonController : Controller
    {
        [Route("person/All")]

        public IActionResult All()
        {
            SQLiteConnection dbcon = new SQLiteConnection("Data Source=.\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            return View(Personal_info.GetAllPerson(dbcon));
        }

        [Route("person/{id}")]
        public IActionResult GetPersonByID(int id)
        {
            SQLiteConnection dbcon = new SQLiteConnection("Data Source=.\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            ViewBag.Id = id;
            return View(Personal_info.GetPerson(dbcon,id));
        }

        [HttpPost]
        [Route("person/Search")]
        public RedirectToActionResult Search(Person p)
        {
                SQLiteConnection dbcon = new SQLiteConnection("Data Source=.\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
                return RedirectToAction("GetPersonByID", new { id = Personal_info.search(p.country, p.first_name, dbcon) });
        }
        [HttpGet]
        [Route("person/Search")]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        [Route("person/Add")]
        public RedirectToActionResult Add(Person p)
        {
            SQLiteConnection dbcon = new SQLiteConnection("Data Source=.\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            Personal_info.Add(p, dbcon);
            return RedirectToAction("GetPersonByID", new { id=p.id });
        }
        [Route("person/Add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        //[Route("person/Delete/{id}")]
        public RedirectToActionResult Delete(int id)
        {
            SQLiteConnection dbcon = new SQLiteConnection("Data Source=.\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            Personal_info.Delete(id, dbcon);
            ViewBag.Messsage = "Person Deleted Successfully";
            return RedirectToAction("All");
        }
        // GET: PersonController

        /*public ActionResult Index()
        {
            return View();
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
