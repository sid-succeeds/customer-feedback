using cfms_web_api.Models;

namespace cfms_web_api.Interfaces
{
	public interface IFeedbackService
	{
        List<Feedback> GetAllFeedback();
        Feedback GetFeedbackById(int id);
        List<Feedback> AddFeedback(Feedback Feedback);
        List<Feedback> UpdateFeedback(int id, Feedback Feedback);
        List<Feedback> DeleteFeedback(int id);
    }
}

