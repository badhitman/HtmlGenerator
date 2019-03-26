////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom;
using HtmlGenerator.dom.collections;
using HtmlGenerator.set;
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
                li li_dom_result = new li(null) { css_class = li_class };

                a a_dom_result = new a() { href = href, target = TargetsEnum._self, InnerText = text };
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
                        submenu.Childs.Add(new a() { css_class = "dropdown-item", inline = true, href = i.href, target = TargetsEnum._blank, InnerText = i.text });
                    }
                    li_dom_result.Childs.Add(submenu);
                }
                li_dom_result.Childs.Add(a_dom_result);

                return li_dom_result;
            }
        }

    }
}
