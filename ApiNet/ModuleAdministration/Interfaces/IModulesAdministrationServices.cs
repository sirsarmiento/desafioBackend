using ApiNet.Entities;
using ApiNet.ModuleAdministration.Inputs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNet.ModuleAdministration.Interfaces
{
    public interface IModulesAdministrationServices
    {
       Task<List<ModuleRolDto>> GetAll();
       Task<IActionResult> Create(UserInput input);
       Task<ModuleRolDto> GetRol(IdInput input);
       Task<ModuleRolDto> GetEmail(EmailInput input);
       Task<ModuleRolDto> Getfecha(FechaInput input);
       Task<UserDto> Delete(IdInput input);
    }
}

