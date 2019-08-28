using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Models;
using NewsWebApp.Models.DataModels;
using NewsWebApp.Models.DBModels;

namespace NewsWebApp.Controllers
{
    public class HomeController : Controller
    {
        DBContext db = new DBContext();

        public IActionResult Index()
        {
            HomeDataModel data = new HomeDataModel();

            return View(data);
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Subcribe(string name, string email)
        {
            Subscriber subcribe = new Subscriber();
            subcribe.Name = name;
            subcribe.Email = email;
            try
            {
                db.Add(subcribe);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SendMessage(string name, string email, string subject, string message)
        {
            Messages mess = new Messages();
            mess.Name = name;
            mess.Email = email;
            mess.Subject = subject;
            mess.Message = message;
            mess.SentDate = DateTime.Now;
            try
            {
                db.Add(mess);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Contact");
        }
    }
}
