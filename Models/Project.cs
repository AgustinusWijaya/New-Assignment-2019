using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewAssignment2019.Models
{
    public class Project:EntityBase
    {
        [Required]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public Guid ClientId { get; set; }
    }
}
