using DoctorAppointment.Entities;
using DoctorAppointment.Services.Appointments.Contracts;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointment.Persistence.EF.Appointments
{
    public class EFAppointmentRepository : AppointmentRepository
    {
        private readonly DbSet<Appointment> _appointments;

        public EFAppointmentRepository(ApplicationDbContext dbcontext)
        {
            _appointments = dbcontext.Set<Appointment>();
        }
        public void Add(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public bool CheckDuplicate(Appointment appointment)
        {
            return _appointments.Any(_ => _.PatientId 
            == appointment.PatientId
            && _.Date.Date == appointment.Date.Date
            && _.DoctorId == appointment.DoctorId);
        }

        public void Delete(Appointment appointment)
        {
            _appointments.Remove(appointment);
        }

        public GetAppointmentWithDoctorAndPatientDto Get(int id)
        {
            return _appointments
                .Where(_ => _.Id == id)
                .Select(_ => new GetAppointmentWithDoctorAndPatientDto
            {
                Date = _.Date,
                Doctor = new GetDoctorDto
                {
                    FirstName = _.Doctor.FirstName,
                    LastName = _.Doctor.LastName,
                    NationalCode = _.Doctor.NationalCode,
                    Field = _.Doctor.Field
                },
                Patient = new GetPatientDto
                {
                    FirstName = _.Patient.FirstName,
                    LastName = _.Patient.LastName,
                    NationalCode = _.Patient.LastName
                }
            }).FirstOrDefault();
        }

        public List<GetAppointmentWithDoctorAndPatientDto> GetAll()
        {
            return _appointments
                .Select(_ => new GetAppointmentWithDoctorAndPatientDto
            {
                Date = _.Date,
                Doctor = new GetDoctorDto
                {
                    FirstName = _.Doctor.FirstName,
                    LastName = _.Doctor.LastName,
                    NationalCode = _.Doctor.NationalCode,
                    Field = _.Doctor.Field
                },
                Patient = new GetPatientDto
                {
                    FirstName = _.Patient.FirstName,
                    LastName = _.Patient.LastName,
                    NationalCode = _.Patient.LastName
                }
            }).ToList();
        }

        public Appointment GetById(int id)
        {
            return _appointments
                .FirstOrDefault(_ => _.Id == id);
        }

        public int GetCount(int id,DateTime date)
        {
            var appointments = _appointments
                .Where(_ => _.DoctorId == id && _.Date.Date
                == date.Date)
                .ToList().Count;

            return appointments;
        }
    }
}
