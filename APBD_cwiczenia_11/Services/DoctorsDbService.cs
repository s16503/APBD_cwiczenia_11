using APBD_cwiczenia_11.Models;
using APBD_cwiczenia_11.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cwiczenia_11.Services
{
    public class DoctorsDbService : IDbService
    {
        public DoctorsDbContext _context { get; set; }

        public DoctorsDbService(DoctorsDbContext context)
        {
            _context = context;
        }
        public Doctor AddDoctor(AddDoctorRequest req)
        {

         
            Doctor doctor = new Doctor
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Email = req.Email
            };

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return doctor;


        }

        public void DeleteDoctor(int id)
        {
            var doc = _context.Doctors.Find(id);
            if(doc == null)
                throw new Exception("nie znaleziono doktora");

            _context.Doctors.Remove(doc);
            _context.SaveChanges();

        }

        public Doctor GetDoctor(int id)
        {
            var doc = _context.Doctors.Find(id);

            if (doc == null)
                throw new Exception("nie znaleziono doktora");

            return doc;
        }


        public Doctor UpdateDoctor(UpdateDoctorRequest req)
        {
            var doc = _context.Doctors.Find(req.IdDoctor);

            if (doc == null)
                throw new Exception("nie znaleziono doktora");

            if (req.FirstName != null)
                doc.FirstName = req.FirstName;

            if (req.LastName != null)
                doc.LastName = req.LastName;

            if (req.Email != null)
                doc.Email = req.Email;

            if (req.Prescriptions != null)
                foreach (Prescription p in req.Prescriptions)
                    doc.Prescriptions.Add(p);

            _context.SaveChanges();

            return doc;

        }

        public List<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }
    }
}
