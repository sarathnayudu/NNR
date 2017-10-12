using NNR_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace NNR_Test.Controllers
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
            return View(new ModelContact());
        }
        public ActionResult QualityCommitment()
        {
            return View();
        }
        public ActionResult Carer()
        {
            return View();
        }
        public ActionResult Updates()
        {
            return View();
        }
        public ActionResult CSR()
        {
            return View();
        }
        public ActionResult CorporatePolicies()
        {
            return View();
        }
        public ActionResult UnderConstruction()
        {
            return View();
        }
        public ActionResult Email(ModelContact model)
        {
            SendEmail(model);
            model = new ModelContact();
            model.Succesmessage = "Thank You For your Interest With VNS Our Representative Will Get Back You Shortely";
            return View("../Home/Contact", model);
        }

        private void SendEmail(ModelContact model)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            //set the addresses
            mail.From = new MailAddress("vnsrmcweb@gmail.com");
            mail.To.Add("vnsrmcqc@gmail.com");

            //set the content
            mail.Subject = "VNS WEB Mail";
            mail.Body = "Party Name " + model.Name + "<br />" +
                        "Party City" + model.City + "<br />" +
                        "Party Contry" + model.Country + "<br />" +
                        "Party Email" + model.Email + "<br />" +
                        "Party PhoneNumber" + model.PhoneNumber + "<br />" +
                        "Party Requirements" + model.YourRequirements + "<br />";
            
            mail.IsBodyHtml = true;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("vnsrmcweb@gmail.com", "nayudunz");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);           
        }
    }
}