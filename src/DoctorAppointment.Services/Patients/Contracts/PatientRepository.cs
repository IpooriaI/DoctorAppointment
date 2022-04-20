using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientRepository
    {
        void Add(Patient patient);
        List<GetPatientDto> GetAll();
        GetPatientDto Get(int id);
        Patient GetById(int id);
        void Delete(Patient patient);
        bool IsExistNationalCode(string nationalCode,int id);
    }
}
