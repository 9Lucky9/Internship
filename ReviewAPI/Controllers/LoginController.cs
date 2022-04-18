using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewAPI.Authentication;
using ReviewAPI.Models;
using ReviewAPI.Repository;

namespace ReviewAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUser _iUser;

        public LoginController(IUser iUser)
        {
            _iUser = iUser;
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            var authUser = _iUser.FindUser(user.Login, user.Password);
            if (authUser != null)
            {
                var tokenString = TokenHelper.GenerateToken(authUser);
                return Ok(tokenString);
            }

            return Unauthorized();
        }
    }
}
