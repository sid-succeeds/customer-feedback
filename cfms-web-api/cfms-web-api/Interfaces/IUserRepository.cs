﻿using cfms_web_api.Models;

namespace cfms_web_api.Interfaces
{
	public interface IUserRepository
	{
        List<User> GetAllUsers();
        User DeleteUserById(string id);
        List<User> AddUser(User user);
        void DeleteAllUsers();
    }
}

