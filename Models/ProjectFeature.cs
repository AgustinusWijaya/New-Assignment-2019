using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewAssignment2019.Models
{
    public class ProjectFeature : EntityBase
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [StringLength(15)]
        [DisplayName(@"Parent Code")]
        public string ParentCode { get; set; }

        public bool IsLeaf { get; set; }

    }
}
