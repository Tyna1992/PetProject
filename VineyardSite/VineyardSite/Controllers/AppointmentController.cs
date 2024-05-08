using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VineyardSite.Model;
using VineyardSite.Service.Repositories;

namespace VineyardSite.Controllers;

[ApiController]
[Route("api/[controller]")]


public class AppointmentController : ControllerBase
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IWineTastingRepository _wineTastingPackageRepository;
    
    public AppointmentController(IAppointmentRepository appointmentRepository, IUserRepository userRepository, IWineTastingRepository wineTastingPackageRepository)
    {
        _appointmentRepository = appointmentRepository;
        _userRepository = userRepository;
        _wineTastingPackageRepository = wineTastingPackageRepository;
    }

    [HttpPost("/create"), Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> BookAppointment(DateTime date, int participants, string name, string? requests,
        string username, int packageId)
    {
        var user = await _userRepository.GetByUsername(username);
        var package = await _wineTastingPackageRepository.GetWineTastingPackageById(packageId);
        var appointment = new Appointment
        {
            Date = date,
            People = participants,
            Name = name,
            Requests = requests,
            Email = user.Email,
            User = user,
            Package = package,
            UserId = user.Id,
            PackageId = package.Id
        };
        await _appointmentRepository.AddAppointment(appointment);
        return Ok(appointment);
    }
    
    [HttpDelete("/delete/{id"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        await _appointmentRepository.DeleteAppointment(id);
        return Ok();
    }
    
    
}