using cfms_web_api.Data;
using cfms_web_api.Interfaces;
using cfms_web_api.Models;
using cfms_web_api.Services;

namespace cfms_web_api.Repositories
{
	public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
		{
            _context = context;
        }

        public List<User> AddUser(User user)
        {
            try
            {
                // Hash the password before saving it to the database
                user.Password = PasswordHasher.HashPassword(user.Password);

                _context.Users.Add(user);
                _context.SaveChanges();
                return _context.Users.ToList();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately (e.g., log it)
                // throw new Exception("Error occurred while adding user.", ex);
                return null;
            }
        }

        public void DeleteAllUsers()
        {
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();
        }

        public List<User> DeleteUserById(string id)
        {
            var userToDelete = _context.Users.FirstOrDefault(c => c.Id.Equals(id));
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
            else
            {
                return null;
            }
            return _context.Users.ToList();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(string email, string password)
        {
            string hashedPassword = PasswordHasher.HashPassword(password);
            Console.WriteLine("Hashed: "+hashedPassword);
            var user = _context.Users.FirstOrDefault(c => c.Email.Equals(email) && c.Password.Equals(hashedPassword));

            if (user != null)
            {
                Console.WriteLine("User found: " + user.Email);
                return user;
            }
            else
            {
                Console.WriteLine("User not found for email: " + email);
                return null;
            }
        }
    }
}

