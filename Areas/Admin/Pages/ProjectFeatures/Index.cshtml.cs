using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewAssignment2019.Base;
using NewAssignment2019.Data;
using NewAssignment2019.Models;

namespace NewAssignment2019.Areas.Admin.Pages.ProjectFeatures
{
    public class IndexModel : BasePageModel
    {

        public IList<ProjectFeature> ProjectFeature { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid projectId)
        {
            if (projectId.Equals(Guid.Empty))
            {
                return NotFound();
            }

            ProjectFeature = await db.ProjectFeature.Where(w => w.ProjectId == projectId).OrderBy(o=>o.Code).ToListAsync();
            return Page();
        }
    }
}
