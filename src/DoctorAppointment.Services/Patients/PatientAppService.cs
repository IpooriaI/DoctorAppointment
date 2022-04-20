using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Patients.Exceptions;
using DoctorAppointment.Services.Patients.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients
{
    public class PatientAppService : PatientService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly PatientRepository _repository;
        public PatientAppService(UnitOfWork unitOfWork,PatientRepository patientRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = patientRepository;
        }
        public void Add(AddPatientDto dto)
        {
            var patient = new Patient
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                NationalCode = dto.NationalCode
            };

            var isPatientExist = _repository
                .IsExistNationalCode(dto.NationalCode,0);

            if (dto.NationalCode.Length != 10
                ||patient.NationalCode
                .Any(char.IsLetter) == true)
            {
                throw new BadNationalCodeFormatExeption();
            }

            if (patient.FirstName.Any(char.IsDigit) == true
                || string.IsNullOrEmpty(patient.FirstName)
                || patient.LastName.Any(char.IsDigit) == true
                || string.IsNullOrEmpty(patient.LastName))
            {
                throw new BadNameFormatException();
            }

            if(isPatientExist)
            {
                throw new PatientAlreadyExistException();
            }

            _repository.Add(patient);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var patient = _repository.GetById(id);
            _repository.Delete(patient);
            _unitOfWork.Commit();
        }

        public GetPatientDto Get(int id)
        {
            return _repository.Get(id);
        }

        public List<GetPatientDto> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(UpdatePatientDto dto, int id)
        {

            var patient = _repository.GetById(id);


            var isDoctorExist = _repository
                .IsExistNationalCode(patient.NationalCode,id);

            if(isDoctorExist)
            {
                throw new PatientAlreadyExistException();
            }

            if (dto.NationalCode.Length != 10
                ||dto.NationalCode
                .Any(char.IsLetter) == true)
            {
                throw new BadNationalCodeFormatExeption();
            }

            if (dto.FirstName.Any(char.IsDigit) == true
                || string.IsNullOrEmpty(dto.FirstName)
                || dto.LastName.Any(char.IsDigit) == true
                || string.IsNullOrEmpty(dto.LastName))
            {
                throw new BadNameFormatException();
            }

            patient.FirstName = dto.FirstName;
            patient.LastName = dto.LastName;
            patient.NationalCode = dto.NationalCode;



            _unitOfWork.Commit();
        }
    }
}
