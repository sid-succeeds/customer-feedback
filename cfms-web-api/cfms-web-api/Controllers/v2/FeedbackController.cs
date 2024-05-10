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

        public FeedbackController(IFeedbackService FeedbackService)
        {
            _FeedbackService = FeedbackService;
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

        /// <summary>
        /// Retrieves feedbacks by customer ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer to retrieve feedbacks for.</param>
        /// <returns>The HTTP status code and a list of feedbacks for the specified customer.</returns>
        /// <response code="200">Returns a list of feedbacks for the specified customer.</response>
        /// <response code="404">If no feedbacks are found for the specified customer.</response>
        [HttpGet("Customer/{customerId}")]
        [ProducesResponseType(200, Type = typeof(List<Feedback>))]
        [ProducesResponseType(404)]
        public ActionResult<List<Feedback>> GetFeedbacksByCustomerId(string customerId)
        {
            List<Feedback> feedbacks = _FeedbackService.GetFeedbacksByCustomerId(customerId);
            if (feedbacks == null || feedbacks.Count == 0)
            {
                return NotFound();
            }
            return feedbacks;
        }
        #endregion

        #region POST Methods
        /// <summary>
        /// Adds a new feedback.
        /// </summary>
        /// <param name="feedback">The feedback to add.</param>
        /// <returns>The HTTP status code and the added feedback.</returns>
        /// <response code="201">Returns the added feedback.</response>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(List<Feedback>))]
        public ActionResult<List<Feedback>> AddFeedback(Feedback feedback)
        {
            return _FeedbackService.AddFeedback(feedback);
        }

        /// <summary>
        /// Adds multiple feedbacks in bulk.
        /// </summary>
        /// <param name="feedbackList">The list of feedbacks to add.</param>
        /// <returns>The HTTP status code and the added feedbacks.</returns>
        /// <response code="201">Returns the added feedbacks.</response>
        [HttpPost("Bulk")]
        [ProducesResponseType(201, Type = typeof(List<Feedback>))]
        public ActionResult<List<Feedback>> AddFeedback(List<Feedback> feedbackList)
        {
            return _FeedbackService.AddFeedback(feedbackList);
        }

        /// <summary>
        /// Adds feedback for a specific customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer to add feedback for.</param>
        /// <param name="feedback">The feedback to add.</param>
        /// <returns>The HTTP status code and the added feedback.</returns>
        /// <response code="201">Returns the added feedback.</response>
        [HttpPost("Customer/{customerId}")]
        [ProducesResponseType(201, Type = typeof(List<Feedback>))]
        public ActionResult<List<Feedback>> AddFeedbackForCustomer(string customerId, Feedback feedback)
        {
            feedback.CustomerId = customerId;
            List<Feedback> addedFeedback = _FeedbackService.AddFeedback(customerId, feedback);
            return addedFeedback;
        }
        #endregion

        #region PUT Methods
        /// <summary>
        /// Updates feedback.
        /// </summary>
        /// <param name="id">The ID of the feedback to update.</param>
        /// <param name="Feedback">The updated feedback data.</param>
        /// <returns>The HTTP status code and the updated feedback.</returns>
        /// <response code="200">Returns the updated feedback.</response>
        /// <response code="404">If the feedback is not found.</response>
        /// <response code="400">If the updated feedback data is not in the correct format.</response>
        /// <response code="422">If the updated feedback data is invalid.</response>
        /// <response code="500">If an exception was thrown.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(List<Feedback>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public ActionResult<List<Feedback>> UpdateFeedback(string id, Feedback Feedback)
        {
            var updatedFeedbacks = _FeedbackService.UpdateFeedback(id, Feedback);
            if (updatedFeedbacks == null)
            {
                return NotFound();
            }
            return updatedFeedbacks;
        }
        #endregion

        #region DELETE Methods
        /// <summary>
        /// Deletes feedback.
        /// </summary>
        /// <param name="id">The ID of the feedback to delete.</param>
        /// <returns>The HTTP status code.</returns>
        /// <response code="200">If the deletion was successful.</response>
        /// <response code="404">If the feedback is not found.</response>
        /// <response code="500">If an exception was thrown.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<List<Feedback>> DeleteFeedback(string id)
        {
            var deletedFeedbacks = _FeedbackService.DeleteFeedback(id);
            if (deletedFeedbacks == null)
            {
                return NotFound();
            }
            return deletedFeedbacks;
        }

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
