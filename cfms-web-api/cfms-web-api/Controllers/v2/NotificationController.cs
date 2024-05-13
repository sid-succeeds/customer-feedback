using cfms_web_api.Interfaces;
using RestSharp;

namespace cfms_web_api.Controllers.v2
{
	public class NotificationController
	{
        private readonly IMailService _mailService;

        public NotificationController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public void SendNotif(string to, string subject, string message)
        {
            RestResponse response = _mailService.SendMessage(to, subject, message);
            // log response
        }
    }
}

