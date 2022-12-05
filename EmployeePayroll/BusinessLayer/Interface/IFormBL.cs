using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IFormBL
    {
        public EmployeeFormEntity Create(EmployeeFormModel details, long EmployeeId);
        public List<EmployeeFormEntity> Getall(long EmployeeId);
    }
}
