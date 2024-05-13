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
            List<Feedback> ret = _context.Feedbacks.ToList();
            if (ret == null)
                return null;
            else return ret;
        }

        public Feedback GetFeedbackById(string id)
        {
            var feedback = _context.Feedbacks.FirstOrDefault(c => c.Id.Equals(id));
            if (feedback == null)
                return null;
            else return feedback;
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
                //throw new Exception("Error occurred while adding feedback.", ex);
                return null;
            }
        }

        public void DeleteAllFeedback()
        {
            _context.Feedbacks.RemoveRange(_context.Feedbacks);
            _context.SaveChanges();
        }
    }

}