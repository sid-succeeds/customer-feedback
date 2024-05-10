using cfms_web_api.Data;
using cfms_web_api.Interfaces;
using cfms_web_api.Models;

namespace cfms_web_api.Controller
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Feedback> GetAllFeedback()
        {
            return _context.Feedbacks.ToList();
        }

        public Feedback GetFeedbackById(string id)
        {
            return _context.Feedbacks.FirstOrDefault(c => c.Id.Equals(id)) ?? throw new ArgumentException("Customer not found.");
        }

        public List<Feedback> AddFeedback(Feedback feedback)
        {
            try
            {
                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();
                return _context.Feedbacks.ToList();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately (e.g., log it)
                throw new Exception("Error occurred while adding feedback.", ex);
            }
        }

        public List<Feedback> AddFeedback(List<Feedback> feedbackList)
        {
            try
            {
                _context.Feedbacks.AddRange(feedbackList);
                _context.SaveChanges();
                return _context.Feedbacks.ToList();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately (e.g., log it)
                throw new Exception("Error occurred while adding feedback list.", ex);
            }
        }

        public List<Feedback> UpdateFeedback(string id, Feedback feedback)
        {
            var existingFeedback = _context.Feedbacks.FirstOrDefault(f => f.Id.Equals(feedback.Id));
            if (existingFeedback != null)
            {
                existingFeedback.CustomerId = feedback.CustomerId;
                existingFeedback.Subject = feedback.Subject;
                existingFeedback.Message = feedback.Message;
            }
            return _context.Feedbacks.ToList();
        }

        public List<Feedback> DeleteFeedback(string id)
        {
            var feedbackToDelete = _context.Feedbacks.FirstOrDefault(f => f.Id.Equals(id));
            if (feedbackToDelete != null)
            {
                _context.Feedbacks.Remove(feedbackToDelete);
            }
            return _context.Feedbacks.ToList();
        }

        List<Feedback> IFeedbackRepository.AddFeedback(string customerId, Feedback feedback)
        {
            feedback.CustomerId = customerId;
            try
            {
                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();
                return _context.Feedbacks.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding feedback.", ex);
            }
        }

        List<Feedback> IFeedbackRepository.GetFeedbacksByCustomerId(string customerId)
        {
            return _context.Feedbacks.Where(f => f.CustomerId.Equals(customerId)).ToList();
        }

        public void DeleteAllFeedback()
        {
            _context.Feedbacks.RemoveRange(_context.Feedbacks);
            _context.SaveChanges();
        }
    }

}