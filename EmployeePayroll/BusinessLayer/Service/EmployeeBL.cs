using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        public EmployeeEntity Register(EmployeeRegistration userRegistration)
        {
            try
            {
                return employeeRL.Register(userRegistration);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Login(EmployeeLogin employeeLogin)
        {
            try
            {
                return employeeRL.Login(employeeLogin);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
