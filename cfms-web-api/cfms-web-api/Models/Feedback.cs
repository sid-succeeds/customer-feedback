namespace cfms_web_api.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedDate { get; set; }

        public Feedback(int id, string customerName, string email, string subject, string message, DateTime submittedDate)
        {
            Id = id;
            CustomerName = customerName;
            Email = email;
            Subject = subject;
            Message = message;
            SubmittedDate = submittedDate;
        }
    }

}

