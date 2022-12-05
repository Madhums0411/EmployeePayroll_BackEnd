using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBL
    {
        public EmployeeEntity Register(EmployeeRegistration userRegistration);
        public string Login(EmployeeLogin employeeLogin);
    }
}
