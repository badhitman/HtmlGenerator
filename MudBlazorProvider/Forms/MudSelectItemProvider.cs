////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5;

namespace HtmlGenerator.mud;

/// <summary>
/// MudSelectItem
/// </summary>
public class MudSelectItemProvider : safe_base_dom_root
{
    /// <inheritdoc/>
    /// <remarks>MudSelectItem</remarks>
    public override string tag_custom_name => "MudSelectItem";

    /// <summary>
    /// Id
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Text
    /// </summary>
    public required string Label { get; set; }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        Childs = null;
        SetAttribute("T", "EntryModel");
        SetAttribute("Label", Label);
        SetAttribute("Value", Id);

        return base.GetHTML(deep);
    }
}