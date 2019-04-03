////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom.html.areas;
using HtmlGenerator.dom.set.bootstrap;
using System.Collections.Generic;

namespace HtmlGenerator.dom.bootstrap.forms
{
    /// <summary>
    /// Объедините наборы групп кнопок в панели инструментов кнопок для более сложных компонентов.
    /// Используйте служебные классы по мере необходимости, чтобы выделить группы, кнопки и многое другое.
    /// </summary>
    public class GroupsToolbar : div
    {
        /// <summary>
        /// Группы и панели инструментов должны иметь явную метку, так как в противном случае большинство вспомогательных технологий не будут объявлять их, несмотря на наличие правильного атрибута роли.
        /// </summary>
        public string aria_label;

        /// <summary>
        /// Группы элементов, которые будут размещены внутри
        /// </summary>
        public List<GroupElements> Groups { get; private set; } = new List<GroupElements>();

        /// <summary>
        /// Выравнивание вложеных элементов
        /// </summary>
        public JustifyingContent? Justifying = null;

        public GroupsToolbar()
        {
            tag_custom_name = typeof(div).Name;

            css_class = "btn-toolbar";
            SetAttribute("role", "toolbar");
        }

        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();
            SetAttribute("aria-label", aria_label is null ? "Toolbar with button groups" : aria_label);
            Groups.ForEach(x => Childs.Add(x));

            if (!(Justifying is null))
                css_class = (css_class + " " + Justifying?.ToString("g").Replace("_", "-")).Trim();

            return base.GetHTML(deep);
        }
    }
}
