using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NewAssignment2019.Pages.Components;
using NewAssignment2019.Services.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NewAssignment2019.Pages.Shared.Components.Menu
{
    public class MenuViewComponent : BaseViewComponent
    {
        public override async Task<IViewComponentResult> InvokeAsync()
        {
            List<MenuItem> menuItems = new MenuService().GetMenu();
            foreach (var item in menuItems)
            {
                GenerateUrl(item);
            }
            return await Task.FromResult(View(menuItems));
            
            //return await Task.FromResult(View(GetMenuItems()));
        }

        public void GenerateUrl(MenuItem menu)
        {
            if (menu.Items != null)
                foreach (var item in menu.Items)
                {
                    if (!string.IsNullOrWhiteSpace(item.url))
                    {
                        item.url = $"{Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}/{item.url}";
                    }
                    GenerateUrl(item);
                }
        }

        //public class MenuItem
        //{
        //    [Newtonsoft.Json.JsonProperty("text")]
        //    public string Text { get; set; }

        //    [Newtonsoft.Json.JsonProperty("iconcss")]
        //    public string IconCss { get; set; }

        //    [Newtonsoft.Json.JsonProperty("separator")]
        //    public bool Separator { get; set; }

        //    [DefaultValue(true)]
        //    [HtmlAttributeName()]
        //    [Newtonsoft.Json.JsonProperty("items")]
        //    public object Items { get; set; }
        //}

        //private List<MenuItem> GetMenuItems()
        //{
        //    List<MenuItem> result = new List<MenuItem>
        //    {
        //        new MenuItem
        //        {
        //            Text = "File",
        //            IconCss = "e-menu-icons e-file",
        //            Items = new List<MenuItem>()
        //        {
        //            new MenuItem{ Text= "Open", IconCss= "e-menu-icons e-open" },
        //            new MenuItem{ Text= "Save", IconCss= "e-icons e-save" },
        //            new MenuItem{ Separator= true },
        //            new MenuItem{ Text= "Exit" }
        //        }
        //        },
        //        new MenuItem
        //        {
        //            Text = "Edit",
        //            IconCss = "e-menu-icons e-edit",
        //            Items = new List<MenuItem>()
        //        {
        //            new MenuItem{ Text= "Cut", IconCss= "e-menu-icons e-cut" },
        //            new MenuItem{ Text= "Copy", IconCss= "e-menu-icons e-copy" },
        //            new MenuItem{ Text= "Paste", IconCss= "e-menu-icons e-paste" }
        //        }
        //        },
        //        new MenuItem
        //        {
        //            Text = "View",
        //            Items = new List<MenuItem>()
        //        {
        //            new MenuItem {
        //                Text = "Toolbars",
        //                Items = new List<MenuItem>()
        //                {
        //                    new MenuItem{ Text= "Menu Bar" },
        //                    new MenuItem{ Text= "Bookmarks Toolbar" },
        //                    new MenuItem{ Text= "Customize" }
        //                }
        //            },
        //            new MenuItem {
        //                Text = "Zoom",
        //                Items = new List<MenuItem>()
        //                {
        //                    new MenuItem { Text= "Zoom In" },
        //                    new MenuItem{ Text= "Zoom Out" },
        //                    new MenuItem{ Text= "Reset" },
        //                }
        //            },
        //            new MenuItem {
        //                Text = "Full Screen"
        //            }
        //        }
        //        },
        //        new MenuItem
        //        {
        //            Text = "Tools",
        //            Items = new List<MenuItem>()
        //        {
        //            new MenuItem { Text= "Spelling & Grammar" },
        //            new MenuItem { Text= "Customize" },
        //            new MenuItem { Separator= true },
        //            new MenuItem { Text= "Options" }
        //        }
        //        },
        //        new MenuItem
        //        {
        //            Text = "Help",
        //        }
        //    };

        //    return result;
        //}
    }
}
