using APBD_cwiczenia_11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cwiczenia_11.Requests
{
    public class AddDoctorRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }

    }
}
