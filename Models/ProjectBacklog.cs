using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewAssignment2019.Models
{
    public class ProjectBacklog : EntityBase
    {
        public enum StatusChoices
        {
            New,
            BeingDeveloped,
            Bug,
            OnHold,
            Closed
        }

        public enum PriorityChoices
        {
            Low,
            Normal,
            High,
            Immediate
        }

        [Required]
        public Guid ProjectId { get; set; }


        [Required]
        public Guid ProjectSprintId { get; set; }

        [Required]
        public Guid ProjectFeatureId { get; set; }

        public ProjectFeature ProjectFeature => new Services.Project.ProjectService().GetProjectFeature(ProjectFeatureId);

        [Required]
        public StatusChoices Status { get; set; }

        [Required]
        public PriorityChoices Priority { get; set; }

        public string Assignee { get; set; }

        [DataType(DataType.DateTime)]
        [Description("Assigned Date")]
        public DateTime AssignedDate { get; set; }
    }
}
