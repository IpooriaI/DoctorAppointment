using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
