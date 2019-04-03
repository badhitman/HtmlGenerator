////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom.set.entities;
using HtmlGenerator.DOM;
using HtmlGenerator.DOM.forms;
using HtmlGenerator.DOM.set.bootstrap_enum;
using HtmlGenerator.DOM.textual;
using System;
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

        /// <summary>
        /// Вертикальный набор кнопок (а не горизонтальным). Выпадающие меню кнопки Split здесь не поддерживаются.
        /// </summary>
        public bool VerticalVariation = false;

        public VisualBootstrapStylesEnum default_style = VisualBootstrapStylesEnum.secondary;

        public GroupElements()
        {
            tag_custom_name = typeof(div).Name;
            css_class = "btn-group";
            SetAttribute("role", "group");
        }

        /// <summary>
        /// Добавить вложеную группу, как dropdown menus
        /// </summary>
        /// <param name="nesting">Набор вложеной группы кнопок</param>
        /// <param name="id_node">Уникальный идентификатор вложеного узла. Если IsNullOrEmpty => будет сгенерирован guid</param>
        public void AddNestingDropdownGroup(List<DataParticleItem> nesting, string title_node, string id_node = null)
        {
            if (string.IsNullOrEmpty(id_node))
                id_node = Guid.NewGuid().ToString().Replace("-", "");

            GroupElements nested_group = new GroupElements() { aria_label = "nested group - " + id_node };
            button node_button = new button(title_node) { Id_DOM = id_node, css_class = "btn btn-"+ default_style.ToString() + " dropdown-toggle" };
            node_button.SetAttribute("data-toggle","dropdown");
            node_button.SetAttribute("aria-haspopup", "true");
            node_button.SetAttribute("aria-expanded", "false");
            nested_group.Childs.Add(node_button);

            div dropdown_node = new div() { css_class = "dropdown-menu" };
            dropdown_node.SetAttribute("aria-labelledby", id_node);
            nesting.ForEach(x=> dropdown_node.Childs.Add(new a() { css_class = "dropdown-item", href = x.Value, InnerText = x.Title }));
            
            Childs.Add(nested_group);
        }

        public override string GetHTML(int deep = 0)
        {
            SetAttribute("aria-label", string.IsNullOrEmpty(aria_label) ? "Basic group - " + Guid.NewGuid().ToString().Replace("-", "") : aria_label);

            if (!(Size is null))
                css_class = (css_class + " btn-group-" + Size?.ToString("g")).Trim();

            if (VerticalVariation)
                css_class = (css_class + " btn-group-vertical").Trim();

            return base.GetHTML(deep);
        }
    }
}
