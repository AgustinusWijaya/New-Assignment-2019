using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewAssignment2019.Base;
using NewAssignment2019.Data;
using NewAssignment2019.Models;
using NewAssignment2019.Services.Project;

namespace NewAssignment2019.Areas.Admin.Pages.Project
{
    public class CreateModel : BasePageModel
    {
        [BindProperty]
        public NewAssignment2019.Models.Project Project { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Features File Upload")]
        public IFormFile UploadFeatureFile { get; set; }


        public IActionResult OnGet()
        {
            ViewData["ClientId"] = new SelectList(db.Client, "Id", "Code");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ClientId"] = new SelectList(db.Client, "Id", "Code");
                return Page();
            }


            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = db.Database.BeginTransaction())
            {

                try
                {
                    var projectFeatureResult = await new ProjectService().UploadProjectFeaturesAsync(UploadFeatureFile, Project.Id);

                    // Perform a second check to catch ProcessFormFile method
                    // violations.
                    if (!projectFeatureResult.ModelState.IsValid)
                    {

                        ViewData["ClientId"] = new SelectList(db.Client, "Id", "Code");
                        return Page();
                    }

                    db.ProjectFeature.AddRange(projectFeatureResult.ProjectFeatures);
                    db.Project.Add(Project);

                    await db.SaveChangesAsync();

                    transaction.Commit();

                    return RedirectToPage("./Index");
                }

                catch (Exception)
                {
                    transaction.Rollback();

                    throw;
                }
            }
        }
    }
}