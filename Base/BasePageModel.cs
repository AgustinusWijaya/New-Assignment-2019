using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewAssignment2019.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewAssignment2019.Base
{
    public class BasePageModel : PageModel
    {
        internal ApplicationDbContext db;

        public BasePageModel()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            var Configuration = builder.Build();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            db = new ApplicationDbContext(optionsBuilder.Options);
        }

        public BasePageModel(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}
