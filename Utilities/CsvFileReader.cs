using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAssignment2019.Utilities
{
    public class CsvFileReader
    {
        public async Task<string> ReadFileAsync(IFormFile formFile)
        {
            if (formFile.ContentType.ToLower() != "application/vnd.ms-excel")
            {
                //throw error
                //modelState.AddModelError(formFile.Name,
                //    $"The {fieldDisplayName}file ({fileName}) must be a text file.");
            }

            string result = await new FileHelper().ReadFileAsync(formFile);
            return result;
        }
    }
}
