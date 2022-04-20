using DoctorAppointment.Entities;
using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Patients
{
    public class EFPatientRepository : PatientRepository
    {
        private readonly DbSet<Patient> _patients;

        public EFPatientRepository(ApplicationDbContext dbcontext)
        {
            _patients = dbcontext.Set<Patient>();
        }
        public void Add(Patient patient)
        {
            _patients.Add(patient);
        }

        public void Delete(Patient patient)
        {
            _patients.Remove(patient);
        }

        public GetPatientDto Get(int id)
        {
            return _patients
                .Where(_ => _.Id == id)
                .Select(_ => new GetPatientDto
            {
                FirstName = _.FirstName,
                LastName = _.LastName,
                NationalCode = _.NationalCode
            }).FirstOrDefault();
        }

        public List<GetPatientDto> GetAll()
        {
            return _patients
                .Select(_ => new GetPatientDto
            {
                NationalCode = _.NationalCode,
                FirstName = _.FirstName,
                LastName = _.LastName
            }).ToList();
        }

        public Patient GetById(int id)
        {
            return _patients
                .FirstOrDefault(_ => _.Id == id);
        }

        public bool IsExistNationalCode(string nationalCode,int id)
        {
            return _patients.Where(_ => _.Id != id).Any(_ => _.NationalCode == nationalCode);
        }
    }
}
