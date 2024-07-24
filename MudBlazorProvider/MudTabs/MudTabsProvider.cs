////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5;

namespace HtmlGenerator.mud;

/// <summary>
/// MudTabs - MudBlazor provider
/// </summary>
public class MudTabsProvider : safe_base_dom_root
{
    /// <summary>
    /// Tabs Panels
    /// </summary>
    public List<MudTabPanelProvider> TabsPanels { get; set; } = [];

    /// <summary>
    /// MudTabs
    /// </summary>
    public override string tag_custom_name => "MudTabs";

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        Childs.AddRange(TabsPanels);

        return base.GetHTML(deep);
    }
}