using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ApiNet.Contexts;
using ApiNet.Entities;
using ApiNet.ModuleAdministration.Inputs;
using ApiNet.ModuleAdministration.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiNet.ModuleAdministration.Services
{
    public class ModulesAdministrationServices : ControllerBase, IModulesAdministrationServices
    {
        private readonly AppDbContext context;
        private readonly DbSet<ApplicationUser> _applicationUserRepository;
        private readonly DbSet<ApplicationRol> _applicationRolRepository;

        public ModulesAdministrationServices(AppDbContext context)
        {
            this.context = context;
            _applicationUserRepository = context.ApplicationUser;
            _applicationRolRepository = context.ApplicationRol;
        }

        public async Task<IActionResult> Create(UserInput input)
        {
            var user = new ApplicationUser
            {
                Nombres = input.Nombres,
                Apellidos = input.Apellidos,
                Email = input.Email,
                RolId = input.RolId,
                Fecha_Nac = input.Fecha_Nac,
                Password = input.Password
            };

            await _applicationUserRepository.AddAsync(user);
            await context.SaveChangesAsync();

            return Ok();

        }

        public async Task<List<ModuleRolDto>> GetAll()
        {
            try
            {

                var users = _applicationUserRepository.ToList();

                var userList = new List<ModuleRolDto>();

                foreach (var user in users)
                {
                    var result = new ModuleRolDto();
                    result.Nombres = user.Nombres;
                    result.Apellidos = user.Apellidos;
                    result.Email = user.Email;
                    result.Fecha_Nac = user.Fecha_Nac;
                    result.edad = calcularEdad(result.Fecha_Nac);

                    var rol = await _applicationRolRepository.FirstOrDefaultAsync(r => r.RolId == user.RolId);
                    result.Rol = rol.RolName;
                    userList.Add(result);
                }

                return userList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModuleRolDto> GetEmail(EmailInput input)
        {
            try
            {

                var user = await _applicationUserRepository.FirstOrDefaultAsync(au => au.Email == input.Email);

                var result = new ModuleRolDto();

                result.Nombres = user.Nombres;
                result.Apellidos = user.Apellidos;
                result.Email = user.Email;
                result.Fecha_Nac = user.Fecha_Nac;
                result.edad = calcularEdad(result.Fecha_Nac);

                var rol = await _applicationRolRepository.FirstOrDefaultAsync(r => r.RolId == user.RolId);
                result.Rol = rol.RolName;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ModuleRolDto> GetRol(IdInput input)
        {
            try
            {
                var user = await _applicationUserRepository.FirstOrDefaultAsync(au => au.RolId == input.Id);

                var result = new ModuleRolDto();

                result.Nombres = user.Nombres;
                result.Apellidos = user.Apellidos;
                result.Email = user.Email;
                result.Fecha_Nac = user.Fecha_Nac;
                result.edad = calcularEdad(result.Fecha_Nac);
                var rol = await _applicationRolRepository.FirstOrDefaultAsync(r => r.RolId == user.RolId);
                result.Rol = rol.RolName;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<ModuleRolDto> Getfecha(FechaInput input)
        {
            try
            {
                var user = await _applicationUserRepository.FirstOrDefaultAsync(au => au.Fecha_Nac == input.Fecha_Nac);

                var result = new ModuleRolDto();
                result.Nombres = user.Nombres;
                result.Apellidos = user.Apellidos;
                result.Email = user.Email;
                result.Fecha_Nac = user.Fecha_Nac;
                result.edad = calcularEdad(result.Fecha_Nac);
                var rol = await _applicationRolRepository.FirstOrDefaultAsync(r => r.RolId == user.RolId);
                result.Rol = rol.RolName;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserDto> Delete(IdInput input)
        {
            var user = await _applicationUserRepository.FirstOrDefaultAsync(pa => pa.Id == input.Id);
            _applicationUserRepository.Remove(user);
            await context.SaveChangesAsync();
            return null;
        }


        private int calcularEdad(DateTime fecha_Nac)
        {
            int edad = DateTime.Today.Year - fecha_Nac.Year;

            if (DateTime.Today.Month < fecha_Nac.Month)
            {
                --edad;
            }
            else if (DateTime.Today.Month == fecha_Nac.Month && DateTime.Today.Day < fecha_Nac.Day)
            {
                --edad;
            }

            return edad;
        }
    }
}
