using cfms_web_api.Models;

namespace cfms_web_api.Interfaces
{
	public interface IFeedbackService
	{
        List<Feedback> GetAllFeedback();
        Feedback GetFeedbackById(int id);
        List<Feedback> AddFeedback(Feedback feedback);
        List<Feedback> UpdateFeedback(int id, Feedback feedback);
        List<Feedback> DeleteFeedback(int id);
    }
}

