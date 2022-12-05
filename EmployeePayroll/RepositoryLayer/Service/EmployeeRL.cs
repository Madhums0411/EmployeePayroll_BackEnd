using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly EmployeeContext employeeContext;
        private readonly IConfiguration configuration;
        public EmployeeRL(EmployeeContext employeeContext, IConfiguration configuration)
        {
            this.employeeContext = employeeContext;
            this.configuration = configuration;
        }
        public EmployeeEntity Register(EmployeeRegistration employeeRegistration)
        {
            try
            {
                EmployeeEntity user = new EmployeeEntity();
                user.FirstName = employeeRegistration.FirstName;
                user.LastName = employeeRegistration.LastName;
                user.Email = employeeRegistration.Email;
                user.Password = employeeRegistration.Password;
                employeeContext.EmployeeTable.Add(user);
                int res = employeeContext.SaveChanges();
                if (res > 0)
                {
                    return user;
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
        public string Login(EmployeeLogin employeeLogin)
        {
            try
            {
                var LoginDetails = employeeContext.EmployeeTable.Where(x => x.Email == employeeLogin.Email && x.Password == employeeLogin.Password).FirstOrDefault();
                if (LoginDetails != null)
                {
                    var token = GenerateSecurityToken(LoginDetails.Email, LoginDetails.EmployeeId);
                    return token;
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
        private string GenerateSecurityToken(string Email, long EmployeeId)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.configuration[("JWT:key")]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, Email),
                    new Claim("EmployeeId", EmployeeId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
