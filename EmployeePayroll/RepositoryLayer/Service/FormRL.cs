using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class FormRL:IFormRL
    {
        private readonly EmployeeContext employeeContext;
        private readonly IConfiguration configuration;
        public FormRL(EmployeeContext employeeContext, IConfiguration configuration)
        {
            this.employeeContext = employeeContext;
            this.configuration = configuration;

        }

        public EmployeeFormEntity Create(EmployeeFormModel details, long EmployeeId)
        {
            try
            {
                EmployeeFormEntity detailsent = new EmployeeFormEntity();
                var result = employeeContext.EmployeeFormTable.Where(e => e.EmployeeId == EmployeeId);
                if (result != null)
                {


                    detailsent.EmployeeId = EmployeeId;
                    detailsent.Name = details.Name;
                    detailsent.Image = details.Image;
                    detailsent.Gender = details.Gender;
                    detailsent.Department = details.Department;
                    detailsent.Salary = details.Salary;
                    detailsent.Notes = details.Notes;

                    employeeContext.EmployeeFormTable.Add(detailsent);
                    employeeContext.SaveChanges();
                    return detailsent;
                }
                else
                {
                    return null;
                }

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
                var result = employeeContext.EmployeeFormTable.Where(e => e.EmployeeId == EmployeeId).ToList();
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
