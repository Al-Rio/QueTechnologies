using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QueTECHnologies2.Models;
using QueTECHnologies2.Services;

namespace QueTECHnologies2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment Form: {1}{0}Email:{2}{0}LastName:{3}{0}Subject:{4}{0}Comment:",
            model.Name,
            model.Email,
            model.LastName,
            model.Subject,
            model.Comment);

            var svc = new MailService();

           if (svc.SendMail("snoob13@hotmail.com",
                "lil-rio@hotmail.com",
                "Website Contact", 
                msg))
           {
               ViewBag.MailSent = true;
           }

            return View();
        }
    }
}
