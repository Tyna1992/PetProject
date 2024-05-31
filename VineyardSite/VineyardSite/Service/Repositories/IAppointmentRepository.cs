using VineyardSite.Model;

namespace VineyardSite.Service.Repositories;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> GetAllAppointments();
    Task<Appointment> GetAppointmentById(int id);
    Task AddAppointment(Appointment appointment);
    Task UpdateAppointment(int id, Appointment appointment);
    Task DeleteAppointment(int id);
}