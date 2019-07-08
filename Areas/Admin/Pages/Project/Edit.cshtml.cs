using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewAssignment2019.Base;
using NewAssignment2019.Models;
using NewAssignment2019.Services.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace NewAssignment2019.Areas.Admin.Pages.Project
{
    public class EditModel : BasePageModel
    {
        private readonly IMapper mapper;

        public EditModel(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [BindProperty]
        public NewAssignment2019.Models.Project Project { get; set; }

        [Display(Name = "Features File Upload")]
        public IFormFile UploadFeatureFile { get; set; }

        [Display(Name = "Feature Count")]
        public int FeatureCount { get; set; }

        public List<ProjectSprintVM> ProjectSprints { get; private set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await db.Project.FirstOrDefaultAsync(m => m.Id == id);

            if (Project == null)
            {
                return NotFound();
            }

            IOrderedQueryable<Models.ProjectSprint> projectSprints = db.ProjectSprint.Where(w => w.ProjectId == Project.Id).OrderBy(o => o.DateBegin);
            ProjectSprints = this.mapper.Map<IOrderedQueryable<Models.ProjectSprint>, List<ProjectSprintVM>>(projectSprints);

            foreach (ProjectSprintVM item in ProjectSprints)
            {
                var fc = new ProjectService().GetBacklogs(item.Id).Count();
                item.SetFeatureCount(fc);
            }

            FeatureCount = await db.ProjectFeature.Where(w => w.ProjectId == Project.Id).CountAsync();


            ViewData["ClientId"] = new SelectList(db.Client, "Id", "Code");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Project.ModifiedDate = DateTime.UtcNow;
            Project.ModifiedBy = User.Identity.Name;

            db.Attach(Project).State = EntityState.Modified;

            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    await db.SaveChangesAsync();

                    transaction.Commit();

                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    transaction.Rollback();

                    if (!ProjectExists(Project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }


        public async Task<IActionResult> OnPostUploadFeatureFileAsync()
        {
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile f = Request.Form.Files[0];

                    (IEnumerable<ProjectFeature> ProjectFeatures, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary ModelState) projectFeatureResult = await new ProjectService().UploadProjectFeaturesAsync(f, Project.Id);

                    // Perform a second check to catch ProcessFormFile method
                    // violations.
                    if (!projectFeatureResult.ModelState.IsValid)
                    {
                        return Page();
                    }

                    db.ProjectFeature.AddRange(projectFeatureResult.ProjectFeatures);

                    await db.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }

            //Project = await db.Project.FirstOrDefaultAsync(m => m.Id == Project.Id);
            //ProjectSprint = await db.ProjectSprint.Where(w => w.ProjectId == Project.Id).ToListAsync();
            //FeatureCount = await db.ProjectFeature.Where(w => w.ProjectId == Project.Id).CountAsync();
            //ViewData["ClientId"] = new SelectList(db.Client, "Id", "Code");

            //ModelState.Clear();

            //return Page();

            return RedirectToPage("Edit", new { id = Project.Id });
        }

        private bool ProjectExists(Guid id)
        {
            return db.Project.Any(e => e.Id == id);
        }

        public class ProjectSprintVM : Models.ProjectSprint
        {
            private int featureCount = 0;
            public int FeatureCount => featureCount;

            public void SetFeatureCount(int featureCount)
            {
                this.featureCount = featureCount;
            }
        }

        public class ProjectSprintMappingProfile : Profile
        {
            public ProjectSprintMappingProfile()
            {
                CreateMap<Models.ProjectSprint, ProjectSprintVM>();
            }
        }
    }
}
