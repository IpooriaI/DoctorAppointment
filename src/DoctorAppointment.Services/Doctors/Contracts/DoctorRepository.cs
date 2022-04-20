using DoctorAppointment.Entities;
using System.Collections.Generic;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorRepository 
    {
        void Add(Doctor doctor);
        List<GetDoctorDto> GetAll();
        GetDoctorDto Get(int id);
        Doctor GetById(int id);
        void Delete(Doctor doctor);
        bool IsExistNationalCode(string nationalCode,int id);
        
    }
}
