using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NewAssignment2019.Services.Menu
{
    public class MenuService : ServiceBase
    {
        public List<MenuItem> GetMenu()
        {
            List<MenuItem> result = new List<MenuItem>
            {
                new MenuItem
                {
                    Id = Menus.MenuId_Master, Text = "Master", ParentId = null, Url = string.Empty,
                    Items = new List<MenuItem>
                    {
                        new MenuItem { Id = Menus.MenuId_Master_Client, Text = "Clients", ParentId = Menus.MenuId_Master, Url = "Master/Client" },
                        new MenuItem { Id = Menus.MenuId_Master_Project, Text = "Projects", ParentId = Menus.MenuId_Master, Url = "Master/Project" },
                    }
                }
            };

            return result;
        }
    }

    public class MenuItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }

        [Newtonsoft.Json.JsonProperty("iconcss")]
        public string IconCss { get; set; }


        [Newtonsoft.Json.JsonProperty("text")]
        public string Text { get; set; }
        public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("separator")]
        public bool Separator { get; set; }

        [DefaultValue(true)]
        [HtmlAttributeName()]
        [Newtonsoft.Json.JsonProperty("items")]
        public List<MenuItem> Items { get; set; }
    }



    public class Menus
    {
        public const string MenuId_Master = "0080.0000.0000";
        public const string MenuId_Master_Client = "0080.0000.0100";
        public const string MenuId_Master_Project = "0080.0000.0200";
    }
}
