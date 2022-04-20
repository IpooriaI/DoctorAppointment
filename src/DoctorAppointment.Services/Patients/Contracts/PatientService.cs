using System.Collections.Generic;

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
