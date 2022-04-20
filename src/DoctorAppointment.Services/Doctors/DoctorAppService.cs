using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointment.Services.Doctors
{
    public class DoctorAppService : DoctorService
    {
        private readonly DoctorRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public DoctorAppService(
            DoctorRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddDoctorDto dto)
        {
            var doctor = new Doctor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Field = dto.Field,
                NationalCode = dto.NationalCode,
            };

            var isDoctorExist = _repository
                .IsExistNationalCode(doctor.NationalCode,0);

            if(isDoctorExist)
            {
                throw new DoctorAlreadyExistException();
            }

            if(dto.NationalCode.Length != 10
                ||doctor.NationalCode
                .Any(char.IsLetter) == true)
            {
                throw new BadNationalCodeFormatExption();
            }

            if (doctor.FirstName.Any(char.IsDigit) == true
                || string.IsNullOrEmpty(doctor.FirstName)
                || doctor.LastName.Any(char.IsDigit) == true
                || string.IsNullOrEmpty(doctor.LastName))
            {
                throw new BadNameFormatExeption();
            }


            _repository.Add(doctor);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var doctor = _repository.GetById(id);
            _repository.Delete(doctor);
            _unitOfWork.Commit();
        }

        public GetDoctorDto Get(int id)
        {
            return _repository.Get(id);
        }

        public List<GetDoctorDto> GetAll()
        {
           return _repository.GetAll();
        }

        public void Update(UpdateDoctorDto dto,int id)
        {
            var doctor = _repository.GetById(id);

            var isDoctorExist = _repository
                .IsExistNationalCode(doctor.NationalCode,id);

            if(dto.NationalCode.Length != 10
                ||dto.NationalCode
                .Any(char.IsLetter) == true)
            {
                throw new BadNationalCodeFormatExption();
            }

            if (dto.FirstName.Any(char.IsDigit) == true
                || string.IsNullOrEmpty(dto.FirstName)
                || dto.LastName.Any(char.IsDigit) == true
                || string.IsNullOrEmpty(dto.LastName))
            {
                throw new BadNameFormatExeption();
            }

            if(isDoctorExist)
            {
                throw new DoctorAlreadyExistException();
            }

            doctor.FirstName = dto.FirstName;
            doctor.LastName = dto.LastName;
            doctor.Field = dto.Field;
            doctor.NationalCode = dto.NationalCode;

            _unitOfWork.Commit();
        }
    }
}
