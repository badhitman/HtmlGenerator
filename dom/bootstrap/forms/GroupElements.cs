////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.DOM;
using HtmlGenerator.DOM.set.bootstrap_enum;
using System.Collections.Generic;

namespace HtmlGenerator.dom.bootstrap.forms.buttons
{
    /// <summary>
    /// Группировка кнопок вместе в единую линию
    /// </summary>
    public class GroupElements : div
    {
        /// <summary>
        /// Группы и панели инструментов должны иметь явную метку, так как в противном случае большинство вспомогательных технологий не будут объявлять их, несмотря на наличие правильного атрибута роли.
        /// </summary>
        public string aria_label;


        /// <summary>
        /// Размер группы
        /// </summary>
        public SizingBootstrap? Size = null;


        public GroupElements()
        {
            tag_custom_name = typeof(div).Name;
            css_class = "btn-group";
            SetAttribute("role", "group");
        }

        public override string GetHTML(int deep = 0)
        {
            SetAttribute("aria-label", aria_label is null ? "Basic group" : aria_label);

            if (!(Size is null))
                css_class = (css_class + " btn-group-" + Size?.ToString("g")).Trim();


            return base.GetHTML(deep);
        }
    }
}
