using cfms_web_api.Interfaces;
using cfms_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace cfms_web_api.Controller.v1
{
    [Route("[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiController]
    [Obsolete]
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
    }
}

