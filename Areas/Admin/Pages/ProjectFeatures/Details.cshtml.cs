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
    public class DetailsModel : BasePageModel
    {
        private readonly NewAssignment2019.Data.ApplicationDbContext _context;

        public DetailsModel(NewAssignment2019.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ProjectFeature ProjectFeature { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectFeature = await _context.ProjectFeature.FirstOrDefaultAsync(m => m.Id == id);

            if (ProjectFeature == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
