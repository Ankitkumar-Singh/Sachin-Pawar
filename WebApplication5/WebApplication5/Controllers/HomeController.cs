using RSVPForm.Controllers;
using System.Net.Mail;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        #region "Index Method"
        /// <summary>
        /// Index Method returns the Index view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region "RSVPForm"
        /// <summary>
        /// RSVPForm returns the RsvpForm view contains httpget 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        #endregion

        #region "RSVPForm GuestResponse"
        /// <summary>
        /// RSVPForm GuestResponse containing HttpPost request
        /// </summary>
        /// <param name="guestResponse"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                //TODO: Email response to the party organizer
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.EnableSsl = true;

                MailMessage msg = new MailMessage("wcyber23@gmail.com", guestResponse.Email);
                msg.Subject = "Hey, welcome.";
                msg.Body = "You are invited for the party";

                smtpClient.Send(msg);
                return View("Thanks", guestResponse);
            }
            else
            {
                // there is a validation error
                return View();
            }
        }
        #endregion
    }
}