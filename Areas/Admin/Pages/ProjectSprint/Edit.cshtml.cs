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
    public class EditModel : BasePageModel
    {
        [BindProperty]
        public Models.ProjectSprint ProjectSprint { get; set; }

        public IEnumerable<Models.ProjectBacklog> ProjectBacklogs { get; set; }

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

            ProjectBacklogs = new Services.Project.ProjectService().GetProjectBacklogs(id.Value);

            ViewData["ProjectId"] = new SelectList(db.Project, "Id", "Code");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Attach(ProjectSprint).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectSprintExists(ProjectSprint.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProjectSprintExists(Guid id)
        {
            return db.ProjectSprint.Any(e => e.Id == id);
        }
    }
}
