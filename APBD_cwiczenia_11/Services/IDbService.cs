using APBD_cwiczenia_11.Models;
using APBD_cwiczenia_11.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cwiczenia_11.Services
{
    public interface IDbService
    {
        public Doctor GetDoctor(int id);
        public List<Doctor> GetDoctors();
        public Doctor AddDoctor(AddDoctorRequest req);
        public Doctor UpdateDoctor(UpdateDoctorRequest req);
        public void DeleteDoctor(int id);

    }
}
