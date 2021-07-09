using System;

namespace ApiNet.ModuleAdministration.Inputs
{
    public class UserInput
    {
        public Guid Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public Guid RolId { get; set; }
        public DateTime Fecha_Nac { get; set; }
        public string Password { get; set; }
    }
}
