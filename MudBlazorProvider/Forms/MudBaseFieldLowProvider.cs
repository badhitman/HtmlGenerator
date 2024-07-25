////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
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
        Childs = null;
        SetAttribute("Label", Label);

        return base.GetHTML(deep);
    }
}