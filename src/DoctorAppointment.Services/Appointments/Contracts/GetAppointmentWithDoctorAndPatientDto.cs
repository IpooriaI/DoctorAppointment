using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Patients.Contracts;
using System;

namespace DoctorAppointment.Services.Appointments.Contracts
{
    public class GetAppointmentWithDoctorAndPatientDto
    {
        public DateTime Date { get; set; }
        public GetDoctorDto Doctor { get; set; }
        public GetPatientDto Patient { get; set; }
    }
}
