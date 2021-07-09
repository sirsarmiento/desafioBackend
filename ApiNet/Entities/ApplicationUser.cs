using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNet.Entities
{
    public class ApplicationUser
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public Guid RolId { get; set; }
        public DateTime Fecha_Nac { get; set; }
        public string Password { get; set; }
    }
}
