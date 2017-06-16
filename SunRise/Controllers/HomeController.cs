using SunRise.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SunRise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            Enqiry model = new Enqiry();
            return View(model);
        }


        public ActionResult Divisions()
        {

            return View();
        }

        public ActionResult QualityCommit()
        {

            return View();
        }


        public ActionResult About()
        {

            return View();
        }

        public ActionResult Carer()
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

        public ActionResult Updates()
        {

            return View();
        }

        public ActionResult ReadyMix()
        {

            return View();
        }

        public ActionResult Mission()
        {

            return View();
        }
        public ActionResult CoreValues()
        {

            return View();
        }
        public ActionResult Management()
        {

            return View();
        }
        public ActionResult ReadyMixConcrete()
        {

            return View();
        }

        public ActionResult Advantages()
        {

            return View();
        }

        public ActionResult Technology()
        {

            return View();
        }

        public ActionResult SendEnqry(Enqiry model)
        {
            SendEnqury(model);
          return   RedirectToAction("Contact");
        }

        private void SendEnqury(Enqiry model)
        {
            string fromaddr=ConfigurationManager.AppSettings["from"].ToString();
            string pass= ConfigurationManager.AppSettings["pass"].ToString();

            // Command line argument must the the SMTP host.
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(fromaddr, pass);

            MailMessage mm = new MailMessage(fromaddr, model.Email.Trim(), model.Name , model.YourRequirements);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }
    }
}