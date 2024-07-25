////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5;

namespace HtmlGenerator.mud;

/// <summary>
/// MudSelect (for Enum)
/// </summary>
public class MudSelectProvider : MudBaseFieldLowProvider
{
    /// <summary>
    /// Options
    /// </summary>
    public IEnumerable<(string id, string name)>? Options { get; set; }

    /// <inheritdoc/>
    public override bool Inline => false;

    /// <inheritdoc/>
    /// <remarks>MudSelect</remarks>
    public override string tag_custom_name => "MudSelect";

    /// <summary>
    /// Имя типа данных (перечисление)
    /// </summary>
    public required string TypeNameEnum { get; set; }

    /// <summary>
    /// запрещено
    /// </summary>
    public override base_dom_root AddCSS(string? css_class, bool CheckSpices = false, bool low_and_trim_name_class = true)
        => throw new Exception();

    /// <summary>
    /// запрещено
    /// </summary>
    public override base_dom_root RemoveCSS(string css_class, bool CheckSpices = false)
        => throw new Exception();

    /// <summary>
    /// запрещено
    /// </summary>
    public override base_dom_root ToggleCSS(string css_class)
        => throw new Exception();

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        Childs = [];

        SetAttribute("T", "EntryModel");

        if (Options?.Any() == true)
            foreach ((string id, string name) in Options)
                Childs.Add(new MudSelectItemProvider() { Value = id, Title = name });

        return base.GetHTML(deep);
    }
}