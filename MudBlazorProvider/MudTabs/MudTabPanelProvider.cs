////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5;

namespace HtmlGenerator;

/// <summary>
/// MudTabPanel - MudBlazor provider
/// </summary>
public class MudTabPanelProvider : safe_base_dom_root
{
    /// <summary>
    /// MudTabs
    /// </summary>
    public override string tag_custom_name => "MudTabPanel";
}
