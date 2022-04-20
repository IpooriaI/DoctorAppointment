using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientService
    {
        void Add(AddPatientDto dto);
        List<GetPatientDto> GetAll();
        GetPatientDto Get(int id);
        void Delete(int id);
        public void Update(UpdatePatientDto dto, int id);

    }
}
