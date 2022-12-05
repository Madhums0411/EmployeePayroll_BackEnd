using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public EmployeeEntity Register(EmployeeRegistration employeeRegistration);
        public string Login(EmployeeLogin employeeLogin);
    }
}
