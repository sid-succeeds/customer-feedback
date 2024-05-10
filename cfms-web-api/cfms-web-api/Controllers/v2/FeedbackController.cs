﻿using cfms_web_api.Interfaces;
using cfms_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace cfms_web_api.Controller.v2
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _FeedbackService;

        public FeedbackController(IFeedbackService FeedbackService)
        {
            _FeedbackService = FeedbackService;
        }

        [HttpGet]
        public ActionResult<List<Feedback>> GetAllFeedbacks()
        {
            return _FeedbackService.GetAllFeedback();
        }

        [HttpGet("{id}")]
        public ActionResult<Feedback> GetFeedbackById(string id)
        {
            var Feedback = _FeedbackService.GetFeedbackById(id);
            if (Feedback == null)
            {
                return NotFound();
            }
            return Feedback;
        }

        [HttpPost]
        public ActionResult<List<Feedback>> AddFeedback(Feedback feedback)
        {
            return _FeedbackService.AddFeedback(feedback);
        }

        [HttpPost("Bulk")]
        public ActionResult<List<Feedback>> AddFeedback(List<Feedback> feedbackList)
        {
            return _FeedbackService.AddFeedback(feedbackList);
        }

        [HttpPut("{id}")]
        public ActionResult<List<Feedback>> UpdateFeedback(string id, Feedback Feedback)
        {
            var updatedFeedbacks = _FeedbackService.UpdateFeedback(id, Feedback);
            if (updatedFeedbacks == null)
            {
                return NotFound();
            }
            return updatedFeedbacks;
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Feedback>> DeleteFeedback(string id)
        {
            var deletedFeedbacks = _FeedbackService.DeleteFeedback(id);
            if (deletedFeedbacks == null)
            {
                return NotFound();
            }
            return deletedFeedbacks;
        }

        //New Functions on API v2
        //Get all feedback records for a particular customer
        [HttpGet("Customer/{customerId}")]
        public ActionResult<List<Feedback>> GetFeedbacksByCustomerId(string customerId)
        {
            List<Feedback> feedbacks = _FeedbackService.GetFeedbacksByCustomerId(customerId);
            if (feedbacks == null || feedbacks.Count == 0)
            {
                return NotFound();
            }
            return feedbacks;
        }

        //Create a new feedback record for a customer
        [HttpPost("Customer/{customerId}")]
        public ActionResult<List<Feedback>> AddFeedbackForCustomer(string customerId, Feedback feedback)
        {
            feedback.CustomerId = customerId;
            List<Feedback> addedFeedback = _FeedbackService.AddFeedback(customerId, feedback);
            return addedFeedback;
        }

    }
}
