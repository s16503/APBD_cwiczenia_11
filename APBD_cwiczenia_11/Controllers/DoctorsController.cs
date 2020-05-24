using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_cwiczenia_11.Models;
using APBD_cwiczenia_11.Requests;
using APBD_cwiczenia_11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_cwiczenia_11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDbService _service;

        public DoctorsController(IDbService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult getDoctors()
        {
            return Ok(_service.GetDoctors());
        }


        [HttpGet("{id}")]
        public IActionResult getDoctor(int id)
        {
            try
            {

                return Ok(_service.GetDoctor(id));

            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPut]
        public IActionResult AddDoctor(AddDoctorRequest req)
        {
                
            try
            {
                var doctor = _service.AddDoctor(req);
                return Ok(doctor);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
                        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {

            try
            {
                _service.DeleteDoctor(id);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("usunięto pomyślnie");
        }

        [HttpPost]
        public IActionResult UpdateDoctor(UpdateDoctorRequest req)
        {

            try
            {
                return Ok(_service.UpdateDoctor(req));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }


    }
}