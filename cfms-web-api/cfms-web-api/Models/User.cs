namespace cfms_web_api.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public User(string id, string firstName, string lastName, string email, bool isAdmin)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsAdmin = isAdmin;
        }
    }
}
