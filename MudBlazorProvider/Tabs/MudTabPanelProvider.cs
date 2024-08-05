////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

using HtmlGenerator.html5;

namespace HtmlGenerator.mud;

/// <summary>
/// MudTabPanel - MudBlazor provider
/// </summary>
public class MudTabPanelProvider : base_dom_root
{
    /// <summary>
    /// Text for Tab
    /// </summary>
    public required string Text { get; set; }

    /// <summary>
    /// BodyElements
    /// </summary>
    public required IEnumerable<base_dom_root> BodyElements { get; set; }

    /// <summary>
    /// MudTabPanel
    /// </summary>
    public override string tag_custom_name => "MudTabPanel";

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        SetAttribute("Text", Text);

        Childs.AddRange(BodyElements);

        return base.GetHTML(deep);
    }
}