////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

using HtmlGenerator.html5;
using HtmlGenerator.html5.textual;

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
    /// Value
    /// </summary>
    public required string Value { get; set; }

    /// <summary>
    /// Title
    /// </summary>
    public required string Title { get; set; }

    /// <inheritdoc/>
    /// <remarks>false</remarks>
    public override bool Inline => true;

    /// <inheritdoc/>
    /// <remarks>true</remarks>
    public override bool NeedEndTagSection => true;

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        Childs.Add(new text(Title));

        SetAttribute("Value", Value);

        return base.GetHTML(deep);
    }
}