using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewAssignment2019.Base;
using NewAssignment2019.Data;
using NewAssignment2019.Models;

namespace NewAssignment2019.Areas.Admin.Pages.ProjectSprint
{
    public class CreateModel : BasePageModel
    {
        [BindProperty]
        public Models.ProjectSprint ProjectSprint { get; set; }

        public Models.Project Project{ get; set; }

        public async Task<IActionResult> OnGetAsync(Guid projectId)
        {
            this.ProjectSprint = new Models.ProjectSprint
            {
                ProjectId = projectId
            };

            this.Project = await db.Project.FirstOrDefaultAsync(w => w.Id == projectId);

            ViewData["ProjectId"] = new SelectList(db.Project, "Id", "Code");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.ProjectSprint.Add(ProjectSprint);
            await db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}