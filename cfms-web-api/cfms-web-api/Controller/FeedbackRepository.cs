using cfms_web_api.Interfaces;
using cfms_web_api.Models;

namespace cfms_web_api.Controller
{
    public class FeedbackRepository : IFeedbackRepository // Implement an interface for future extensibility
    {
        private List<Feedback> feedbackList = new List<Feedback>()
    {
        new Feedback(1, "John Doe", "john.doe@example.com", "Suggestion", "Add a feature for searching past feedback.", DateTime.Now),
        new Feedback(2, "Jane Smith", "jane.smith@example.com", "Bug Report", "Encountered an error when submitting feedback.", DateTime.Now.AddDays(-1)),
        new Feedback(3, "Michael Chen", "michael.chen@example.com", "Question", "How can I export my feedback data?", DateTime.Now.AddDays(-2)),
        new Feedback(4, "Alice Garcia", "alice.garcia@example.com", "Positive Feedback", "The new interface is very user-friendly!", DateTime.Now.AddDays(-3)),
        new Feedback(5, "David Lee", "david.lee@example.com", "Feature Request", "Implement a way to categorise feedback by topic.", DateTime.Now.AddDays(-4)),
    };

        public List<Feedback> GetAllFeedback()
        {
            return feedbackList; // Return a copy to avoid modifying the internal list
        }

        public Feedback GetFeedbackById(int id)
        {
            return feedbackList.FirstOrDefault(f => f.Id == id);
        }

        public List<Feedback> AddFeedback(Feedback feedback)
        {
            // Implement logic to assign a unique ID (e.g., database auto-increment)
            feedback.Id = feedbackList.Count + 1; // Temporary for in-memory list
            feedbackList.Add(feedback);
            return feedbackList;
        }

        public List<Feedback> UpdateFeedback(Feedback feedback)
        {
            var existingFeedback = feedbackList.FirstOrDefault(f => f.Id == feedback.Id);
            if (existingFeedback != null)
            {
                existingFeedback.CustomerName = feedback.CustomerName;
                existingFeedback.Email = feedback.Email;
                existingFeedback.Subject = feedback.Subject;
                existingFeedback.Message = feedback.Message;
                // Update SubmittedDate if necessary (logic not shown here)
            }
            return feedbackList;
        }

        public List<Feedback> DeleteFeedback(int id)
        {
            var feedbackToDelete = feedbackList.FirstOrDefault(f => f.Id == id);
            if (feedbackToDelete != null)
            {
                feedbackList.Remove(feedbackToDelete);
            }
            return feedbackList;
        }
    }

}

