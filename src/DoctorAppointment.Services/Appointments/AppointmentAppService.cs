using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Appointments.Contracts;
using DoctorAppointment.Services.Appointments.Exceptions;
using System.Collections.Generic;

namespace DoctorAppointment.Services.Appointments
{
    public class AppointmentAppService : AppointmentService
    {
        private readonly AppointmentRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public AppointmentAppService(
            AppointmentRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public void Add(AddAppointmentDto dto)
        {
            var appointment = new Appointment
            {
                Date = dto.Date,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId
            };

            var TodayAppointments = _repository
                .GetCount(dto.DoctorId, dto.Date);

            var duplicateAppointment = _repository
                .CheckDuplicate(appointment);

            if (duplicateAppointment == true)
            {
                throw new DuplicateAppointmentException();
            }

            if (TodayAppointments >= 5)
            {
                throw new FullVisitTimeException();                
            }


            _repository.Add(appointment);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var appointment = _repository.GetById(id);

            _repository.Delete(appointment);

            _unitOfWork.Commit();
        }

        public GetAppointmentWithDoctorAndPatientDto Get(int id)
        {
            return _repository.Get(id);
        }

        public List<GetAppointmentWithDoctorAndPatientDto> GetAll()
        {
            return _repository.GetAll();
        }
        
        public void Update(int id,UpdateAppointmentDto dto)
        {
           var appointment = _repository.GetById(id);

            appointment.PatientId = dto.PatientId;
            appointment.Date = dto.Date;
            appointment.DoctorId = dto.DoctorId;

            _unitOfWork.Commit();
        }
    }
}
