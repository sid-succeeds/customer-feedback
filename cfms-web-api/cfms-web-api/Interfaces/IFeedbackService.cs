using cfms_web_api.Models;

namespace cfms_web_api.Interfaces
{
	public interface IFeedbackService
	{
        List<Feedback> GetAllFeedback();
        Feedback GetFeedbackById(string id);
        List<Feedback> GetFeedbacksByCustomerId(string customerId);

        List<Feedback> AddFeedback(Feedback feedback);
        List<Feedback> AddFeedback(List<Feedback> feedback);
        List<Feedback> AddFeedback(string customerId, Feedback feedback);

        List<Feedback> UpdateFeedback(string id, Feedback feedback);

        List<Feedback> DeleteFeedback(string id);
        void DeleteAllFeedback();
    }
}

