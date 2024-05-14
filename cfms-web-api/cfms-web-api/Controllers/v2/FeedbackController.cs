using cfms_web_api.Attributes;
using cfms_web_api.Controllers.v2;
using cfms_web_api.Interfaces;
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
        private readonly NotificationController _NotificationController;
        private readonly IConfiguration _configuration;

        public FeedbackController(IFeedbackService FeedbackService, NotificationController NotificationController, IConfiguration configuration)
        {
            _FeedbackService = FeedbackService;
            _NotificationController = NotificationController;
            _configuration = configuration;

            // Set the configuration for ApiKeyAttribute
            ApiKeyAttribute.Configuration = configuration;
        }

        #region GET Methods
        /// <summary>
        /// Retrieves all feedbacks.
        /// </summary>
        /// <returns>The HTTP status code and a list of all feedbacks.</returns>
        /// <response code="200">Returns a list of all feedbacks.</response>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Feedback>))]
        public ActionResult<List<Feedback>> GetAllFeedbacks()
        {
            return _FeedbackService.GetAllFeedback();
        }

        /// <summary>
        /// Retrieves feedback by ID.
        /// </summary>
        /// <param name="id">The ID of the feedback to retrieve.</param>
        /// <returns>The HTTP status code and the feedback with the specified ID.</returns>
        /// <response code="200">Returns the feedback with the specified ID.</response>
        /// <response code="404">If the feedback is not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Feedback))]
        [ProducesResponseType(404)]
        public ActionResult<Feedback> GetFeedbackById(string id)
        {
            var Feedback = _FeedbackService.GetFeedbackById(id);
            if (Feedback == null)
            {
                return NotFound();
            }
            return Feedback;
        }
        #endregion

        #region POST Methods
        /// <summary>
        /// Adds a new feedback.
        /// </summary>
        /// <param name="apiKey">The API key for authorization.</param>
        /// <param name="feedback">The feedback to add.</param>
        /// <returns>The HTTP status code and the added feedback.</returns>
        /// <response code="201">Returns the added feedback.</response>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(List<Feedback>))]
        public ActionResult<List<Feedback>> AddFeedback(string apiKey, Feedback feedback)
        {
            // Check if the API key is valid
            if (!ValidateApiKey(apiKey))
            {
                return Unauthorized("Invalid API key");
            }

            var addedFeedback = _FeedbackService.AddFeedback(feedback);

            if (addedFeedback != null)
            {
                // If the feedback was added successfully, send notification alert
                string message = $"Feedback ID: {feedback.Id}\nSubject: {feedback.Subject}\nMessage: {feedback.Message}\nSubmitted Date: {feedback.SubmittedDate}";
                string storedNotifReceiver = _configuration["Mailgun:Receiver"];
                _NotificationController.SendNotif(storedNotifReceiver, "Feedback Received", message);
            }

            return addedFeedback;
        }

        private bool ValidateApiKey(string apiKey)
        {
            string storedApiKey = _configuration["AppSettings:ApiKey"];
            return apiKey == storedApiKey;
        }

        #endregion

        #region DELETE Methods
        /// <summary>
        /// Deletes all feedback entries.
        /// </summary>
        /// <returns>The HTTP status code.</returns>
        /// <response code="200">If all feedback entries were deleted successfully.</response>
        /// <response code="500">If an exception was thrown.</response>
        [HttpDelete("All")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult DeleteAllFeedback()
        {
            try
            {
                _FeedbackService.DeleteAllFeedback();
                return Ok();
            }
            catch (Exception ex)
            {
                //TODO: Logging
                return StatusCode(500);
            }
        }

        #endregion
    }
}
