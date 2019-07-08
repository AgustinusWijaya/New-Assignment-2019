using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewAssignment2019.Base;
using NewAssignment2019.Data;
using NewAssignment2019.Models;

namespace NewAssignment2019.Areas.Admin.Pages.Client
{
    public class CreateModel : BasePageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NewAssignment2019.Models.Client Client { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Client.Add(Client);
            await db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}