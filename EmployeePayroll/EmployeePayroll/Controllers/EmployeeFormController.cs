using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Linq;
using System;
using BusinessLayer.Interface;
using RepositoryLayer.Context;
using CommonLayer.Model;

namespace EmployeePayroll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeFormController : ControllerBase
    {
        private readonly IFormBL formBL;
        private readonly EmployeeContext employeeContext;

        public EmployeeFormController(IFormBL formBL, EmployeeContext employeeContext)
        {
            this.formBL = formBL;
            this.employeeContext = employeeContext;

        }
        [Authorize]
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(EmployeeFormModel details)
        {
            try
            {
                long EmployeeId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "EmployeeId").Value);
                var result = formBL.Create(details, EmployeeId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Employee Form Created Successfully", data = result });
                }
                else
                {
                    return NotFound(new { success = false, message = "UnSuccessfully " });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Getall()
        {
            try
            {
                long EmployeeId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "EmployeeId").Value);
                var result = formBL.Getall(EmployeeId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Read all Employee details", data = result });
                }
                else
                {
                    return NotFound(new { success = false, message = "Unable to Read all Employee details" });
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
