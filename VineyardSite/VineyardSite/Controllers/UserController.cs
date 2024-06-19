
using Microsoft.AspNetCore.Mvc;
using VineyardSite.Contracts;
using VineyardSite.Model;
using VineyardSite.Model.Address;
using VineyardSite.Service.Repositories;
using VineyardSite.Service.Repositories.Profile;

namespace VineyardSite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IAddressRepository _addressRepository;
    
    public UserController(IUserRepository userRepository, IAddressRepository addressRepository)
    {
        _userRepository = userRepository;
        _addressRepository = addressRepository;
    }
    
    [HttpGet("GetUserDetails/{id}")]
    public async Task<ActionResult> GetUserDetails(string id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user == null)
        {
            return NotFound("User not found");
        }
        var userResponse = new
        {
            user.UserName,
            user.Email,
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
    
    [HttpPost("AddAddress/{id}")]
    public async Task<ActionResult> AddAddress(string id, [FromBody] Address address)
    {
        try
        {
            await _addressRepository.AddAddressToUser(id, address);
            return Ok("Address added");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Error adding address");
        }
    }
    
    [HttpGet("GetPrimaryAddress/{id}")]
    public async Task<ActionResult> GetAddress(string id)
    {
        var address = await _addressRepository.GetPrimaryAddress(id);
        if (address == null)
        {
            return NotFound("Address not found");
        }
        return Ok(address);
    }
    
    [HttpPatch("UpdateAddress/{id}")]
    public async Task<ActionResult> UpdateAddress(int id, [FromBody] Address address)
    {
        try
        {
            await _addressRepository.UpdateAddress(id, address);
            return Ok("Address updated");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Error updating address");
        }
    }
    
    [HttpDelete("DeleteAddress/{id}")]
    public async Task<ActionResult> DeleteAddress(int id)
    {
        try
        {
            await _addressRepository.DeleteAddress(id);
            return Ok("Address deleted");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, "Error deleting address");
        }
    }
    
    [HttpGet("GetAllAddress/{userId}")]
    public async Task<ActionResult> GetAllAddress(string userId)
    {
        var addresses = await _addressRepository.GetAllAddress(userId);
        if (addresses == null)
        {
            return NotFound("Addresses not found");
        }
        return Ok(addresses);
    }
}