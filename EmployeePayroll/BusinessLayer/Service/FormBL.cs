using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class FormBL:IFormBL
    {
        private readonly IFormRL formRL;
        public FormBL(IFormRL formRL)
        {
            this.formRL = formRL;
        }

        public EmployeeFormEntity Create(EmployeeFormModel details, long EmployeeId)
        {
            try
            {
                return formRL.Create(details, EmployeeId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<EmployeeFormEntity> Getall(long EmployeeId)
        {
            try
            {
                return formRL.Getall(EmployeeId);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
