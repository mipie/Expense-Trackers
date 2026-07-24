using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.DTO;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/auth")]
public class UserController: ControllerBase
{
    private readonly UserService _userService;
    
    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = _userService.Get(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpGet]
    public ActionResult<List<User>> GetAll()
    {
        return _userService.GetAll();
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] RegisterDto user)
    {
        if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
        {
            return BadRequest(new { message = "Données invalides." });
        }
        if (await this._userService.ExistsEmail(user.Email))
        {
            return BadRequest( new {message = "Email already exists"});
        }

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

        var newUser = new User
        {
            Email = user.Email,
            PasswordHash = passwordHash,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
        
        await _userService.Add(newUser);
        return Ok(new {message = "User created"});
    }
    
    [HttpPost("signIn")]
    public async Task<IActionResult> SignIn([FromBody] LoginDto loginDto)
    {
        if (string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
        {
            return BadRequest(new { message = "Email or password is incorrect" });
        }
        

        var user = await this._userService.Authenticate(loginDto.Email, loginDto.Password);

        if (user == null)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }
        
        return Ok(new {message = "User created", user = new User
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        }});
    }
}