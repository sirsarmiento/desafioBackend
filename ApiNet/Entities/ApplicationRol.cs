using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNet.Entities
{
    public class ApplicationRol
    {

        [Key]
        public Guid RolId { get; set; }
        public string RolName { get; set; }
        public string RolEstado { get; set; }

    }
}
