using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiNet.Contexts;
using ApiNet.Entities;
using ApiNet.Interfaces;
using ApiNet.ModuleAdministration.Inputs;
using ApiNet.ModuleAdministration.Interfaces;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiNet.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase, IModulesAdministrationController
    {
        private readonly AppDbContext context;
        private readonly IModulesAdministrationServices _ModulesAdministrationServices;
        
        public UsersController(AppDbContext context, IModulesAdministrationServices ModuleAdministrationServices)
        {
            this.context = context;
            _ModulesAdministrationServices = ModuleAdministrationServices;
        }


        [HttpGet("GetEmail")]
        public async Task<ModuleRolDto> GetEmail([FromQuery] EmailInput input)
        {
            try
            {
                return await _ModulesAdministrationServices.GetEmail(input);
            }
            catch (Exception ex)
            {
                Console.Write("Error info:" + ex.Message);
            }
            return null;
        }

        [HttpGet("GetAll")]
        public async Task<List<ModuleRolDto>> GetAll()
        {
            try
            {
                return await _ModulesAdministrationServices.GetAll();
            }
            catch (Exception ex)
            {
                Console.Write("Error info:" + ex.Message);
            }
            return null;
        }

        [HttpGet("GetRol")]
        public async Task<ModuleRolDto> GetRol([FromQuery] IdInput input)
        {
            try
            {
                return await _ModulesAdministrationServices.GetRol(input);
            }
            catch (Exception ex)
            {
                Console.Write("Error info:" + ex.Message);
            }
            return null;
        }

        [HttpGet("GetFecha")]
        public async Task<ModuleRolDto> GetFecha([FromQuery] FechaInput input)
        {
            try
            {
                return await _ModulesAdministrationServices.Getfecha(input);
            }
            catch (Exception ex)
            {
                Console.Write("Error info:" + ex.Message);
            }
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserInput input)
        {
           await _ModulesAdministrationServices.Create(input);
           return Ok();
        }

        [HttpDelete]
        public async Task<UserDto> Delete(IdInput input)
        {
            try
            {
                return await _ModulesAdministrationServices.Delete(input);
            }
            catch (Exception ex)
            {
                Console.Write("Error info:" + ex.Message);
            }
            return null;
        }
    }
}
