////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

using HtmlGenerator.html5;

namespace HtmlGenerator.mud;

/// <summary>
/// MudBaseFieldLowProvider
/// </summary>
public abstract class MudBaseFieldLowProvider : safe_base_dom_root
{
    /// <summary>
    /// Label
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    /// Helper text
    /// </summary>
    public string? Hint { get; set; }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        SetAttribute("Label", Label);
        return base.GetHTML(deep);
    }
}