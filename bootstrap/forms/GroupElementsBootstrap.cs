////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5.textual;
using HtmlGenerator.set.bootstrap;
using HtmlGenerator.set.entities;
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.forms;
using HtmlGenerator.html5;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// Группировка кнопок вместе в единую линию
/// </summary>
public class GroupElementsBootstrap : base_dom_root
{
    /// <summary>
    /// Группы и панели инструментов должны иметь явную метку, так как в противном случае большинство вспомогательных технологий не будут объявлять их, несмотря на наличие правильного атрибута роли.
    /// </summary>
    public string? aria_label;

    /// <summary>
    /// Размер группы
    /// </summary>
    public SizingBootstrap? Size;

    /// <summary>
    /// Вертикальный набор кнопок (а не горизонтальным). Выпадающие меню кнопки Split здесь не поддерживаются.
    /// </summary>
    public bool VerticalVariation = false;

    /// <inheritdoc/>
    public VisualBootstrapStylesEnum default_style = VisualBootstrapStylesEnum.secondary;

    /// <inheritdoc/>
    public GroupElementsBootstrap()
    {
        tag_custom_name = typeof(div).Name.ToLower();
        AddCSS("btn-group");
        SetAttribute("role", "group");
    }

    /// <summary>
    /// Добавить вложенную группу, как dropdown menus
    /// </summary>
    /// <param name="nesting">Набор вложенной группы кнопок</param>
    /// <param name="title_node">Title</param>
    /// <param name="id_node">Уникальный идентификатор вложенного узла. Если IsNullOrEmpty => будет сгенерирован guid</param>
    public void AddNestingDropdownGroup(List<DataParticleItem> nesting, string title_node, string? id_node = null)
    {
        if (string.IsNullOrEmpty(id_node))
            id_node = Guid.NewGuid().ToString().Replace("-", "");

        GroupElementsBootstrap nested_group = new() { aria_label = "nested group - " + id_node, Childs = [] };
        button node_button = new(title_node) { Id_DOM = id_node };
        node_button.AddCSS("btn btn-" + default_style.ToString() + " dropdown-toggle", true);
        node_button.SetAttribute("data-toggle", "dropdown");
        node_button.SetAttribute("aria-haspopup", "true");
        node_button.SetAttribute("aria-expanded", "false");
        nested_group.Childs.Add(node_button);

        div dropdown_node = new();
        dropdown_node.AddCSS("dropdown-menu");
        dropdown_node.SetAttribute("aria-labelledby", id_node);
        foreach (DataParticleItem item in nesting)
        {
            a a_item = new() { href = item.Value, InnerText = item.Title };

            a_item.AddCSS("dropdown-item");
            dropdown_node.AddDomNode(a_item);

        }

        Childs ??= [];
        Childs.Add(nested_group);
    }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        SetAttribute("aria-label", string.IsNullOrEmpty(aria_label) ? "Basic group - " + Guid.NewGuid().ToString().Replace("-", "") : aria_label);

        if (Size is not null)
            AddCSS("btn-group-" + Size?.ToString("g"));

        if (VerticalVariation)
            AddCSS("btn-group-vertical");

        return base.GetHTML(deep);
    }
}