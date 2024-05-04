using cfms_web_api.Interfaces;
using cfms_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace cfms_web_api.Controller
{
    [Route("api/[controller]")]
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
        public ActionResult<Feedback> GetFeedbackById(int id)
        {
            var Feedback = _FeedbackService.GetFeedbackById(id);
            if (Feedback == null)
            {
                return NotFound();
            }
            return Feedback;
        }

        [HttpPost]
        public ActionResult<List<Feedback>> AddFeedback(Feedback Feedback)
        {
            return _FeedbackService.AddFeedback(Feedback);
        }

        [HttpPut("{id}")]
        public ActionResult<List<Feedback>> UpdateFeedback(int id, Feedback Feedback)
        {
            var updatedFeedbacks = _FeedbackService.UpdateFeedback(id, Feedback);
            if (updatedFeedbacks == null)
            {
                return NotFound();
            }
            return updatedFeedbacks;
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Feedback>> DeleteFeedback(int id)
        {
            var deletedFeedbacks = _FeedbackService.DeleteFeedback(id);
            if (deletedFeedbacks == null)
            {
                return NotFound();
            }
            return deletedFeedbacks;
        }
    }
}

