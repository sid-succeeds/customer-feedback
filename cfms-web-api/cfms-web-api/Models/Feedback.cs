namespace cfms_web_api.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedDate { get; set; }

        public Feedback(int id, int customerId, string subject, string message, DateTime submittedDate)
        {
            Id = id;
            CustomerId = customerId;
            Subject = subject;
            Message = message;
            SubmittedDate = submittedDate;
        }
    }

}

