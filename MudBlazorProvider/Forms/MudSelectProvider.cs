////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5;

namespace HtmlGenerator.mud;

/// <summary>
/// MudSelect (for Enum)
/// </summary>
public class MudSelectProvider : safe_base_dom_root
{
    /// <summary>
    /// Options
    /// </summary>
    public required IEnumerable<(int id, string name)> Options { get; set; }

    /// <summary>
    /// Text
    /// </summary>
    public required string Label { get; set; }

    /// <inheritdoc/>
    public override bool Inline => false;

    /// <inheritdoc/>
    /// <remarks>MudSelect</remarks>
    public override string tag_custom_name => "MudSelect";

    /// <summary>
    /// Имя типа данных (перечисление)
    /// </summary>
    public required string TypeNameEnum { get; set; }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        SetAttribute("T", "EntryModel");
        SetAttribute("Label", Label);

        foreach ((int id, string name) in Options)
            Childs.Add(new MudSelectItemProvider() { Id = id, Label = name });

        return base.GetHTML(deep);
    }
}