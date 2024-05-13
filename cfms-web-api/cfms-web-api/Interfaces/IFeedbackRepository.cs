using cfms_web_api.Models;

namespace cfms_web_api.Interfaces
{
	public interface IFeedbackRepository
	{
        List<Feedback> GetAllFeedback();
        Feedback GetFeedbackById(string id);
        List<Feedback> AddFeedback(Feedback feedback);
        void DeleteAllFeedback();
    }
}

