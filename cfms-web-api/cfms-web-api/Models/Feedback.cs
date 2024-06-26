﻿namespace cfms_web_api.Models
{
    public class Feedback
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedDate { get; set; }

        public Feedback(string id, string subject, string message, DateTime submittedDate)
        {
            Id = id;
            Subject = subject;
            Message = message;
            SubmittedDate = submittedDate;
        }
    }

}

