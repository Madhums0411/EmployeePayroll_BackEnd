using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EmployeePayroll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBL employeeBL;

        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;

        }
        [HttpPost]
        [Route("Register")]
        public ActionResult Registration(EmployeeRegistration employeeRegistration)
        {
            try
            {
                var result = employeeBL.Register(employeeRegistration);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Registration Successfull", data = result });
                }
                else
                {
                    return NotFound(new { success = false, message = "Unsuccessfull" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(EmployeeLogin  employeeLogin)
        {
            try
            {
                var result = employeeBL.Login(employeeLogin);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Login is Successfull", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Login is Not Successfull" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
