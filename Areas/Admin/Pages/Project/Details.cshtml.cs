﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewAssignment2019.Base;
using NewAssignment2019.Data;
using NewAssignment2019.Models;

namespace NewAssignment2019.Areas.Admin.Pages.Project
{
    public class DetailsModel : BasePageModel
    {
        public NewAssignment2019.Models.Project Project { get; set; }

        [Display(Name = "Features count")]
        public Task<int> FeaturesCount => db.ProjectFeature.Where(w => w.ProjectId == Project.Id).CountAsync();
        public NewAssignment2019.Models.Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await db.Project.FirstOrDefaultAsync(m => m.Id == id);
            Client = await db.Client.FirstOrDefaultAsync(w => w.Id == Project.ClientId);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
