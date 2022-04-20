using System.Collections.Generic;

namespace DoctorAppointment.Services.Appointments.Contracts
{
    public interface AppointmentService
    {
        void Add(AddAppointmentDto dto);
        List<GetAppointmentWithDoctorAndPatientDto> GetAll();
        GetAppointmentWithDoctorAndPatientDto Get(int id);
        void Update(int id, UpdateAppointmentDto dto);
        void Delete(int id);
    }
}
