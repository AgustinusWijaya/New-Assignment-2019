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

namespace NewAssignment2019.Areas.Admin.Pages.Client
{
    public class IndexModel : BasePageModel
    {
        private readonly NewAssignment2019.Data.ApplicationDbContext db;

        public IndexModel(NewAssignment2019.Data.ApplicationDbContext context)
        {
            db = context;
        }

        public IList<NewAssignment2019.Models.Client> Client { get;set; }

        public async Task OnGetAsync()
        {
            Client = await db.Client.ToListAsync();
        }
    }
}
