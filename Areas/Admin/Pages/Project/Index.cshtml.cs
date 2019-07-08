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

namespace NewAssignment2019.Areas.Admin.Pages.Project
{
    public class IndexModel : BasePageModel
    {
        public IList<ProjectClient> ProjectClients { get; set; }

        public async Task OnGetAsync()
        {
            ProjectClients = await (from p in db.Project
                                    join c in db.Client on p.ClientId equals c.Id
                                    select new ProjectClient
                                    {
                                        Id = p.Id,
                                        Code = p.Code,
                                        Name = p.Name,
                                        Client = c
                                    }).ToListAsync();
        }

        public class ProjectClient : Models.Project
        {
            public Models.Client Client { get; set; }
        }
    }
}
