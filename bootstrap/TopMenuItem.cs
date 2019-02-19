////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////
using HtmlGenerator.dom;
using System;
using System.Collections.Generic;

namespace HtmlGenerator.bootstrap
{
    public class TopMenuItem : basic_html_dom
    {
        public List<TopMenuItem> SubItems = new List<TopMenuItem>();
        public string li_class = "nav-item";

        public string a_class = "nav-link";

        public string href = "#";

        public string text = "";

        public string tool_tip = "";

        public TopMenuItem(string in_href, string in_text, string in_tool_tip)
        {
            href = in_href;
            text = in_text;
            tool_tip = in_tool_tip;
        }

        
         public li GetMenuItemHtmlDom
        {
            get
            {
                li li_dom_result = new li() { css_class = li_class };

                a.a_set a_set = new a.a_set();
                a_set.href = href;
                a_set.target = Targets._blank;
                a_set.text = text;
                

                a a_dom_result = new a(a_set);
                a_dom_result.css_class = "nav-link";
                if (SubItems.Count > 0)
                {
                     li_dom_result.css_class = (li_dom_result.css_class + " dropdown").Trim();
                    //
                    a_dom_result.css_class += " dropdown-toggle";
                    a_dom_result.CustomAtributes.Add("data-toggle", "dropdown");
                    a_dom_result.CustomAtributes.Add("aria-haspopup", "true");
                    a_dom_result.CustomAtributes.Add("aria-expanded", "false");
                    string id_a_parent = "dropdown_" + new Guid().ToString().Replace("-", "");
                    a_dom_result.Id_DOM = id_a_parent;
                    //
                    div submenu = new div() { css_class = "dropdown-menu" };
                    submenu.CustomAtributes.Add("aria-labelledby", id_a_parent);
                    foreach (TopMenuItem i in SubItems)
                    {
                        a.a_set submenu_a_set = new a.a_set();
                        submenu_a_set.href = i.href;
                        submenu_a_set.target = Targets._blank;
                        submenu_a_set.text = i.text;
                        submenu.Childs.Add(new a(submenu_a_set) { css_class = "dropdown-item", inline = true });
                    }
                    li_dom_result.Childs.Add(submenu);
                }
                li_dom_result.Childs.Add(a_dom_result);

                return li_dom_result;
            }
        }
         
    }
}
