using RestSharp;
namespace cfms_web_api.Interfaces
{
	public interface IMailService
	{
        RestResponse SendMessage(string to, string subject, string message);
    }
}

