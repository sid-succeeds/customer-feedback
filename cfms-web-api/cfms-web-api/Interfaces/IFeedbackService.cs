using cfms_web_api.Models;

namespace cfms_web_api.Interfaces
{
	public interface IFeedbackService
	{
        List<Feedback> GetAllFeedback();
        Feedback GetFeedbackById(string id);
        List<Feedback> AddFeedback(Feedback feedback);
        void DeleteAllFeedback();
    }
}

