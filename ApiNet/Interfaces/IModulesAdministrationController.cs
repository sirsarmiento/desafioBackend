using ApiNet.Entities;
using ApiNet.ModuleAdministration.Inputs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNet.Interfaces
{
    public interface IModulesAdministrationController
    {
        Task<List<ModuleRolDto>> GetAll();
        Task<IActionResult> Create(UserInput input);
        Task<ModuleRolDto> GetRol(IdInput input);
        Task<ModuleRolDto> GetEmail(EmailInput input);
        Task<ModuleRolDto> GetFecha(FechaInput input);
        Task<UserDto> Delete(IdInput input);
    }
}
