////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.set.bootstrap;
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// Объедините наборы групп кнопок в панели инструментов кнопок для более сложных компонентов.
/// Используйте служебные классы по мере необходимости, чтобы выделить группы, кнопки и многое другое.
/// </summary>
public class GroupsToolbarBootstrap : safe_base_dom_root
{
    /// <summary>
    /// Группы и панели инструментов должны иметь явную метку, так как в противном случае большинство вспомогательных технологий не будут объявлять их, несмотря на наличие правильного атрибута роли.
    /// </summary>
    public string? aria_label;

    /// <summary>
    /// Группы элементов, которые будут размещены внутри
    /// </summary>
    public List<GroupElementsBootstrap> Groups { get; private set; } = [];

    /// <summary>
    /// Выравнивание вложенных элементов
    /// </summary>
    public JustifyingContentModesEnum? Justifying = null;

    /// <summary>
    /// div
    /// </summary>
    public override string tag_custom_name => "div";

    /// <summary>
    /// Объедините наборы групп кнопок в панели инструментов кнопок для более сложных компонентов.
    /// Используйте служебные классы по мере необходимости, чтобы выделить группы, кнопки и многое другое.
    /// </summary>
    public GroupsToolbarBootstrap()
    {
        AddCSS("btn-toolbar");
        SetAttribute("role", "toolbar");
    }

    /// <inheritdoc/>
    /// <remarks>При вызове этого метода поле Childs очищается и заново заполняется</remarks>
    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        SetAttribute("aria-label", aria_label is null ? "Toolbar with button groups" : aria_label);
        Groups.ForEach(x => Childs.Add(x));

        if (Justifying is not null)
        {
            string? _css = Justifying?.ToString("g").Replace("_", "-");
            if (!string.IsNullOrWhiteSpace(_css))
                AddCSS(_css);
        }
        return base.GetHTML(deep);
    }
}