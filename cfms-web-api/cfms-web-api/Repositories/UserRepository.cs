using cfms_web_api.Data;
using cfms_web_api.Interfaces;
using cfms_web_api.Models;

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
                _context.Users.Add(user);
                _context.SaveChanges();
                return _context.Users.ToList();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately (e.g., log it)
                //throw new Exception("Error occurred while adding feedback.", ex);
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
    }
}

