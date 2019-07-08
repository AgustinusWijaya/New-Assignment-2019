using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewAssignment2019.Models
{
    public class EntityBase
    {
        [Required]
        [Key]
        [Column(Order = 1)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; } = "Unknown";

        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
    }
}
