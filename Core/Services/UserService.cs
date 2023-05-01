using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DataLayer.Mapping;
using Microsoft.AspNetCore.Mvc;
//using Core.Dtos;

namespace Core.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;

        private AuthorizationService authService { get; set; }

        public UserService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            this.unitOfWork = unitOfWork;
            this.authService = authService;
        }

        public void Register(RegisterDto registerData)
        {
            if (registerData == null)
            {
                return;
            }

            var hashedPassword = authService.HashPassword(registerData.Password);

            var user = new User
            {
                Username = registerData.Username,
                Password = hashedPassword,
                RoleId = registerData.RoleId
            };

            unitOfWork.Users.Insert(user);
            unitOfWork.SaveChanges();
        }

        public string Validate(LoginDto payload)
        {
            var user = unitOfWork.Users.GetByUsername(payload.Username);

            if (user == null)
            {
                return null;
            }

            var passwordFine = authService.VerifyPassword( payload.Password, user.Password);

            if (passwordFine)
            {
                var role = unitOfWork.Roles.GetById(user.RoleId);

                return authService.GenerateToken(user, role.Name);
            }
            else
            {
                return null;
            }

        }

      
    }
}
