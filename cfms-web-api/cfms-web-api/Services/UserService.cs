using cfms_web_api.Interfaces;
using cfms_web_api.Models;

namespace cfms_web_api.Services
{
	public class UserService: IUserService
    {
        private readonly IUserRepository _UserRepository;

		public UserService(IUserRepository UserRepository)
		{
            _UserRepository = UserRepository;
		}

        public List<User> AddUser(User user)
        {
            return _UserRepository.AddUser(user);
        }

        public void DeleteAllUsers()
        {
            _UserRepository.DeleteAllUsers();
        }

        public List<User> DeleteUserById(string id)
        {
            return _UserRepository.DeleteUserById(id);
        }

        public List<User> GetAllUsers()
        {
            return _UserRepository.GetAllUsers();
        }
    }
}

