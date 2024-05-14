using cfms_web_api.Models;

namespace cfms_web_api.Interfaces
{
	public interface IUserRepository
	{
        User GetUser(string email, string password);
        List<User> GetAllUsers();
        List<User> DeleteUserById(string id);
        List<User> AddUser(User user);
        void DeleteAllUsers();
    }
}