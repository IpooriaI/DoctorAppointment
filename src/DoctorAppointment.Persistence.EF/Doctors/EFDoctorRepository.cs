using DoctorAppointment.Entities;
using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointment.Persistence.EF.Doctors
{
    public class EFDoctorRepository : DoctorRepository
    {
        private readonly DbSet<Doctor> _doctors;

        public EFDoctorRepository(ApplicationDbContext dbcontext)
        {
            _doctors = dbcontext.Set<Doctor>();
        }

        public void Add(Doctor doctor)
        {
           _doctors.Add(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _doctors.Remove(doctor);
        }

        public GetDoctorDto Get(int id)
        {
            return _doctors
                .Where(_ => _.Id == id)
                .Select(_ => new GetDoctorDto
            {
                FirstName = _.FirstName,
                LastName = _.LastName,
                Field = _.Field,
                NationalCode = _.NationalCode
            }).FirstOrDefault();
        }

        public List<GetDoctorDto> GetAll()
        {
            return _doctors
                .Select(_ => new GetDoctorDto
            {
                Field = _.Field,
                FirstName = _.FirstName,
                LastName = _.LastName,
                NationalCode = _.NationalCode
            }).ToList();
        }

        public Doctor GetById(int id)
        {
            return _doctors.FirstOrDefault(_ => _.Id == id);
        }

        public bool IsExistNationalCode(string nationalCode,int id)
        {
            return _doctors.Any(_ => _.NationalCode == nationalCode && _.Id != id);
        }
    }
}
