using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAssignment2019.Pages.Components
{
    public class BaseViewComponent : ViewComponent
    {
        public virtual async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)new ViewComponentResult());
        }
    }
}
