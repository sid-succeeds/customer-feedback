using NUnit.Framework;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using cfms_web_api.Controllers.v2;
using cfms_web_api.Interfaces;
using cfms_web_api.Models;
using cfms_web_api.Controller.v2;

namespace cfms_web_api_tests.Controllers.v2
{
    [TestFixture]
    public class FeedbackControllerTests
    {
        private FeedbackController _feedbackController;
        private Mock<IFeedbackService> _feedbackServiceMock;
        private Mock<NotificationController> _notificationControllerMock;

        [SetUp]
        public void Setup()
        {
            _feedbackServiceMock = new Mock<IFeedbackService>();
            _notificationControllerMock = new Mock<NotificationController>();
            _feedbackController = new FeedbackController(_feedbackServiceMock.Object, _notificationControllerMock.Object);
        }

        [Test]
        public void GetAllFeedbacks_Returns_All_Feedbacks()
        {
            // Arrange
            var feedbacks = new List<Feedback>
            {
                new Feedback ("1","Subject 1", "Message 1",DateTime.Now ),
                new Feedback ("2","Subject 2", "Message 2",DateTime.Now )
            };
            _feedbackServiceMock.Setup(service => service.GetAllFeedback()).Returns(feedbacks);

            // Act
            var result = _feedbackController.GetAllFeedbacks();

            // Assert
            result.Should().BeOfType<ActionResult<List<Feedback>>>()
                .Which.Value.Should().BeEquivalentTo(feedbacks);
        }

        [Test]
        public void GetFeedbackById_Returns_Feedback_By_Id()
        {
            // Arrange
            var feedbackId = "1";
            var feedback = new Feedback (feedbackId, "Subject","Message",DateTime.Now);
            _feedbackServiceMock.Setup(service => service.GetFeedbackById(feedbackId)).Returns(feedback);

            // Act
            var result = _feedbackController.GetFeedbackById(feedbackId);

            // Assert
            result.Should().BeOfType<ActionResult<Feedback>>()
                .Which.Value.Should().BeEquivalentTo(feedback);
        }

        [Test]
        public void AddFeedback_Adds_New_Feedback()
        {
            // Arrange
            var newFeedback = new Feedback ("3", "New Subject", "New Message", DateTime.Now);
            _feedbackServiceMock.Setup(service => service.AddFeedback(newFeedback)).Returns(new List<Feedback> { newFeedback });

            // Act
            var result = _feedbackController.AddFeedback(newFeedback);

            // Assert
            result.Should().BeOfType<ActionResult<List<Feedback>>>()
                .Which.Value.Should().ContainEquivalentOf(newFeedback);
            _notificationControllerMock.Verify(x => x.SendNotif(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void DeleteAllFeedback_Deletes_All_Feedback_Entries()
        {
            // Arrange
            _feedbackServiceMock.Setup(service => service.DeleteAllFeedback());

            // Act
            var result = _feedbackController.DeleteAllFeedback();

            // Assert
            result.Should().BeOfType<OkResult>();
            _feedbackServiceMock.Verify(service => service.DeleteAllFeedback(), Times.Once);
        }
    }
}
