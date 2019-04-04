////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.html5;
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.forms;
using HtmlGenerator.html5.textual;
using HtmlGenerator.set.bootstrap;
using HtmlGenerator.set.entities;
using System;
using System.Collections.Generic;

namespace HtmlGenerator.bootstrap
{
    /// <summary>
    /// Группировка кнопок вместе в единую линию
    /// </summary>
    public class GroupElements : safe_base_dom_root
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
            AddCSS("btn-group");
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
            button node_button = new button(title_node) { Id_DOM = id_node };
            node_button.AddCSS("btn");
            node_button.AddCSS("btn-" + default_style.ToString());
            node_button.AddCSS("dropdown-toggle");
            node_button.SetAttribute("data-toggle", "dropdown");
            node_button.SetAttribute("aria-haspopup", "true");
            node_button.SetAttribute("aria-expanded", "false");
            nested_group.Childs.Add(node_button);

            div dropdown_node = new div();
            dropdown_node.AddCSS("dropdown-menu");
            dropdown_node.SetAttribute("aria-labelledby", id_node);
            foreach (DataParticleItem item in nesting)
            {
                using (a a_item = new a() { href = item.Value, InnerText = item.Title })
                {
                    a_item.AddCSS("dropdown-item");
                    dropdown_node.Add(a_item);
                }
            }
            Childs.Add(nested_group);
        }

        public override string GetHTML(int deep = 0)
        {
            SetAttribute("aria-label", string.IsNullOrEmpty(aria_label) ? "Basic group - " + Guid.NewGuid().ToString().Replace("-", "") : aria_label);

            if (!(Size is null))
                AddCSS("btn-group-" + Size?.ToString("g"));

            if (VerticalVariation)
                AddCSS("btn-group-vertical");

            return base.GetHTML(deep);
        }
    }
}
