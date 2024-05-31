using Microsoft.EntityFrameworkCore;
using VineyardSite.Data;
using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly DataContext _context;
    
    public AppointmentRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Appointment>> GetAllAppointments()
    {
        return await _context.Appointments.ToListAsync();
    }
    
    public async Task<Appointment> GetAppointmentById(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        return appointment;
    }
    
    public async Task AddAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAppointment(int id, Appointment appointment)
    {
        var appointmentToUpdate = await _context.Appointments.FirstOrDefaultAsync(appointment => appointment.Id == id);
        if (appointmentToUpdate != null)
        {
            appointmentToUpdate.Date = appointment.Date;
            appointmentToUpdate.People = appointment.People;
            appointmentToUpdate.Requests = appointment.Requests;
            appointmentToUpdate.Name = appointment.Name;
            appointmentToUpdate.Email = appointment.Email;
            appointmentToUpdate.Package = appointment.Package;
            appointmentToUpdate.PackageId = appointment.Package.Id;
            _context.Appointments.Update(appointmentToUpdate);
            await _context.SaveChangesAsync();
        }
        
        
    }
    
    public async Task DeleteAppointment(int id)
    {
        var appointment = await _context.Appointments.FirstOrDefaultAsync(appointment => appointment.Id == id);
        if (appointment != null)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
    }
}