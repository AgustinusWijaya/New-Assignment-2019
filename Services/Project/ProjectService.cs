using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using NewAssignment2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAssignment2019.Services.Project
{
    public class ProjectService : ServiceBase
    {
        public async Task<(IEnumerable<ProjectFeature> ProjectFeatures, ModelStateDictionary ModelState)> UploadProjectFeaturesAsync(IFormFile uploadProjectFeatureFile, Guid projectId)
        {
            List<ProjectFeature> projecFeatures = new List<ProjectFeature>();
            ModelStateDictionary modelState = new ModelStateDictionary();

            var featureFileContent =
                await new Utilities.CsvFileReader().ReadFileAsync(uploadProjectFeatureFile);

            var z = featureFileContent.Split("\r\n").Select(s => s.Split(";"));


            List<string> featureArray = featureFileContent.Split("\r\n").ToList();

            if (featureArray.Any())
            {
                // remove header
                featureArray.Remove(featureArray.First());


                foreach (string featureString in featureArray)
                {
                    var wbParts = featureString.Split(",");

                    if (wbParts[0].Length > 0)
                    {
                        projecFeatures.Add(new ProjectFeature
                        {
                            ProjectId = projectId,
                            Code = wbParts[0],
                            Name = wbParts[1],
                            Description = wbParts[2],
                            ParentCode = wbParts[3]
                        });
                    }
                }
            }

            return (projecFeatures, modelState);
        }

        public async Task<ProjectFeature> GetProjectFeatureAsync(Guid projectFeatureId)
        {
            return await db.ProjectFeature.SingleOrDefaultAsync(w => w.ProjectId == projectFeatureId);
        }

        public ProjectFeature GetProjectFeature(Guid projectFeatureId)
        {
            return db.ProjectFeature.SingleOrDefault(w => w.Id == projectFeatureId);
        }

        public IEnumerable<ProjectFeature> GetProjectFeatures(Guid projectId)
        {
            return db.ProjectFeature.Where(w => w.ProjectId == projectId);
        }

        public IEnumerable<ProjectBacklog> GetBacklogs(Guid projectSprintId)
        {
            return db.ProjectBacklog.Where(w => w.ProjectSprintId == projectSprintId);
        }

        public IEnumerable<ProjectBacklog> GetProjectBacklogs(Guid projectSprintId)
        {
            return db.ProjectBacklog.Where(w => w.ProjectSprintId == projectSprintId);
        }
    }
}
