using System;
using cfms_web_api.Interfaces;
using cfms_web_api.Models;
using Microsoft.EntityFrameworkCore;

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

        public Feedback GetFeedbackById(string id)
        {
            return _FeedbackRepository.GetFeedbackById(id);
        }

        public List<Feedback> AddFeedback(Feedback feedback)
        {
            return _FeedbackRepository.AddFeedback(feedback);
        }

        public void DeleteAllFeedback()
        {
            _FeedbackRepository.DeleteAllFeedback();
        }
    }
}

