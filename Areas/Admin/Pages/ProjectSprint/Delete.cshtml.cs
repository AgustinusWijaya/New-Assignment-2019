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

namespace NewAssignment2019.Areas.Admin.Pages.ProjectSprint
{
    public class DeleteModel : 
        BasePageModel
    {
        [BindProperty]
        public Models.ProjectSprint ProjectSprint { get; set; }

        public Models.Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectSprint = await db.ProjectSprint.FirstOrDefaultAsync(m => m.Id == id);

            if (ProjectSprint == null)
            {
                return NotFound();
            }

            Project = await db.Project.FirstOrDefaultAsync(w => w.Id == ProjectSprint.ProjectId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectSprint = await db.ProjectSprint.FindAsync(id);

            if (ProjectSprint != null)
            {
                db.ProjectSprint.Remove(ProjectSprint);
                await db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
