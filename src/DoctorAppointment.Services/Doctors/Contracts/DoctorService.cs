using System.Collections.Generic;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorService
    {
        void Add(AddDoctorDto dto);
        List<GetDoctorDto> GetAll();
        GetDoctorDto Get(int id);
        public void Delete(int id);
        public void Update(UpdateDoctorDto dto,int id);
    }
}
