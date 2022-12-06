using Microsoft.AspNetCore.Mvc;
using KekMoneyApplication.dto;
using KekMoneyApplication.repository;

namespace KekMoneyApplication.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UserController(UserRepository context)
        {
            _repository = context;
        }

        [HttpPost("login")]
        public ActionResult ChangeAlias(LoginRequest request)
        {
            try
            {
                _repository.Authorization(request.UserName, request.Password);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("registration")]
        public ActionResult Registration(RegistrationRequest request)
        {
            _repository.AddUser(request.UserName, request.Password);
            return Ok();
        }
    }
}