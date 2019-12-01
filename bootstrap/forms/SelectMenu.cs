////////////////////////////////////////////////
// https://github.com/badhitman 
////////////////////////////////////////////////
using HtmlGenerator.html5;
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.forms;
using HtmlGenerator.set.bootstrap;
using System;

namespace HtmlGenerator.bootstrap
{
    public class SelectMenu : safe_base_dom_root
    {
        /// <summary>
        /// Текстова метка для [select]-а
        /// </summary>
        public label LabelSelectMenu;

        public select Select;

        /// <summary>
        /// Размер селектора
        /// </summary>
        public SizingBootstrap? SizeSelect = null;

        /// <summary>
        /// Флаг/Признак того, что к селектору необходимо применить custom-select класс.
        /// Этот флаг добавляет: Select.css_class + " custom-select"
        /// </summary>
        public bool isCustomBootstrapSelect = false;

        public SelectMenu(string Label, select my_select)
        {
            if (!string.IsNullOrEmpty(Label))
                LabelSelectMenu = new label(Label, my_select.Id_DOM);

            tag_custom_name = typeof(div).Name;
            AddCSS("form-group");
            Select = my_select;
            Select.AddCSS("form-control");
        }

        public override string GetHTML(int deep = 0)
        {
            if (string.IsNullOrEmpty(Select.Id_DOM))
            {
                if (!string.IsNullOrEmpty(Select.Name))
                {
                    Select.Id_DOM = Select.Name;
                }
                else
                {
                    Select.Id_DOM = Guid.NewGuid().ToString().Replace("-", "");
                    Select.Name_DOM = Select.Id_DOM;
                }
            }
            Childs.Clear();
            if (!(LabelSelectMenu is null))
            {
                LabelSelectMenu.@for = Select.Id_DOM;
                Childs.Add(LabelSelectMenu);
            }
            if (!(SizeSelect is null))
                Select.AddCSS("form-control-" + SizeSelect?.ToString("g"));

            if (isCustomBootstrapSelect)
                Select.AddCSS("custom-select");

            Childs.Add(Select);

            return base.GetHTML(deep);
        }
    }
}
