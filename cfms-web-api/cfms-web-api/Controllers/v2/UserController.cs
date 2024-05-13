using cfms_web_api.Interfaces;
using cfms_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace cfms_web_api.Controllers.v2
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService _UserService)
		{
            this._UserService = _UserService;
		}

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>The HTTP status code and a list of all users.</returns>
        /// <response code="200">Returns a list of all users.</response>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<User>))]
        public ActionResult<List<User>> GetAllUsers()
        {
            return _UserService.GetAllUsers();
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <returns>The HTTP status code and the added user.</returns>
        /// <response code="201">Returns the added user.</response>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(List<User>))]
        public ActionResult<List<User>> AddUser(User user)
        {
            return _UserService.AddUser(user);
        }

        // <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The Id of the user to delete.</param>
        /// <returns>The HTTP status code.</returns>
        /// <response code="200">If the deletion was successful.</response>
        /// <response code="404">If the customer is not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<List<User>> DeleteUser(string id)
        {
            var deletedUser = _UserService.DeleteUserById(id);
            if (deletedUser == null)
            {
                return NotFound();
            }
            return _UserService.GetAllUsers();
        }
    }
}

