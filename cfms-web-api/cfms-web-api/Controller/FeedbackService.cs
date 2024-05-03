using System;
using cfms_web_api.Interfaces;
using cfms_web_api.Models;

namespace cfms_web_api.Controller
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _FeedbackRepository;

        public FeedbackService(IFeedbackRepository FeedbackRepository)
        {
            _FeedbackRepository = FeedbackRepository;
        }

        public List<Feedback> GetAllFeedback()
        {
            return _FeedbackRepository.GetAllFeedback();
        }

        public Feedback GetFeedbackById(int id)
        {
            return _FeedbackRepository.GetFeedbackById(id);
        }

        public List<Feedback> AddFeedback(Feedback Feedback)
        {
            return _FeedbackRepository.AddFeedback(Feedback);
        }

        public List<Feedback> UpdateFeedback(int id, Feedback Feedback)
        {
            return _FeedbackRepository.UpdateFeedback(Feedback);
        }

        public List<Feedback> DeleteFeedback(int id)
        {
            return _FeedbackRepository.DeleteFeedback(id);
        }
    }
}

