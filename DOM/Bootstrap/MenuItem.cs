////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.DOM;
using HtmlGenerator.DOM.collections;
using HtmlGenerator.DOM.textual;
using HtmlGenerator.set;
using System;
using System.Collections.Generic;

namespace HtmlGenerator.bootstrap
{
    public class MenuItem : li
    {
        /// <summary>
        /// НЕ ИСПОЛЬЗУЙ ЭТО! При формировании HTML(int deep = 0) - этот спсиок пере-заполняется.
        /// Для наполнения тела модального окна используется BodyElements
        /// </summary>
        public new List<base_dom_root> Childs { get => base.Childs; set => base.Childs = value; }

        /// <summary>
        /// Вложеные элементы пунктов меню
        /// </summary>
        public List<MenuItem> SubItems = new List<MenuItem>();

        /// <summary>
        /// CSS класс для [LI] контейнера
        /// </summary>
        public string li_class = "nav-item";

        /// <summary>
        /// CSS класс для [A] контейнера
        /// </summary>
        public string a_class = "nav-link";

        /// <summary>
        /// Ссылка пункта меню
        /// </summary>
        public string href_menu_item = "#";

        /// <summary>
        /// Текст пункта меню
        /// </summary>
        public string text_menu_item;

        /// <summary>
        /// Подсказка для пункта меню
        /// </summary>
        public string tool_tip = "";

        public MenuItem(string in_text, string in_href, string in_tool_tip)
        {
            tag_custom_name = typeof(li).Name;
            text_menu_item = in_text;
            href_menu_item = in_href;
            tool_tip = in_tool_tip;
        }

        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();

            css_class = li_class;
            a a_dom_result = new a() { href = href_menu_item, target = TargetsEnum._self, InnerText = text_menu_item };
            a_dom_result.css_class = a_class;
            if (SubItems.Count > 0)
            {
                css_class = (css_class + " dropdown").Trim();
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
                foreach (MenuItem i in SubItems)
                    submenu.Childs.Add(new a() { css_class = "dropdown-item", inline = true, href = i.href_menu_item, target = TargetsEnum._blank, InnerText = i.text_menu_item });

                Childs.Add(submenu);
            }
            Childs.Add(a_dom_result);

            return base.GetHTML(deep);
        }
    }
}
