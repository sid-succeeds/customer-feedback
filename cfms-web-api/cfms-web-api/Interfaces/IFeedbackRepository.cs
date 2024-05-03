using System;
using cfms_web_api.Models;

namespace cfms_web_api.Interfaces
{
	public interface IFeedbackRepository
	{
        List<Feedback> GetAllFeedback();
        Feedback GetFeedbackById(int id);
        List<Feedback> AddFeedback(Feedback Feedback);
        List<Feedback> UpdateFeedback(Feedback Feedback);
        List<Feedback> DeleteFeedback(int id);
    }
}

