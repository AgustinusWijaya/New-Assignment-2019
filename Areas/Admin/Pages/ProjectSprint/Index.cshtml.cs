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
    public class IndexModel : BasePageModel
    {
        public IList<Models.ProjectSprint> ProjectSprint { get; set; }

        public async Task OnGetAsync()
        {
            ProjectSprint = await db.ProjectSprint.ToListAsync();
        }
    }
}
