using HealthManagerServer.Contracts;
using Microsoft.AspNetCore.Mvc;
using VineyardSite.Contracts;
using VineyardSite.Model;
using VineyardSite.Service.Repositories;

namespace VineyardSite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet("GetUserDetails/{id}")]
    public async Task<ActionResult> GetUserDetails(string id)
    {
        var user = await _userRepository.GetByUsername(id);
        if (user == null)
        {
            return NotFound("User not found");
        }
        var userResponse = new
        {
            user.UserName,
            user.Email,
            user.Address,
            user.PhoneNumber
        };
        return Ok(userResponse);
    }
    
    [HttpPatch("UpdateUser/{id}")]
    public async Task<ActionResult> UpdateUser(string id, [FromBody] UserDetailResponse userDetailResponse)
    {
        try
        {
            await _userRepository.UpdateUser(id, userDetailResponse);
            return Ok("User updated");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Error updating user");
        }
    }
    
    [HttpPatch("ChangePassword/{id}")]
    public async Task<ActionResult> ChangePassword(string id, [FromBody] PasswordChangeResponse passwordChangeResponse)
    {
        try
        {
            await _userRepository.ChangePassword(id, passwordChangeResponse);
            return Ok("Password changed");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest("Error changing password");
        }
    }
}