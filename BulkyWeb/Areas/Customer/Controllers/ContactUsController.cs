using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Web.Domain.Model;
using Web.Infrastracture.SD;

namespace BulkyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class ContactUsController : Controller
    {

        [Authorize]
        [HttpGet]

        public IActionResult SendEmail()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult SendEmail(ContactUs contact)
        {
            contact.From = User.Identity.Name;

            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msg = new MailMessage
                    {
                        From = new MailAddress(contact.From)
                    };

                    msg.To.Add(new MailAddress("email who you want to  send"));
                    msg.Subject = contact.Subject;
                    msg.Body = contact.Body;
                    msg.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;

                        NetworkCredential cred = new NetworkCredential("your email from", "");
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = cred;
                        smtp.Port = 587;
                        smtp.Send(msg);

                        ViewBag.success = "Email sent successfully";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.error = $"Error sending email: {ex.Message}";
             
                }
            }
            else
            {
             
                return View("SendEmail", contact);
            }

            return View("SendEmail");
        }




    }
}
