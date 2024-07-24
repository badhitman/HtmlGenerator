////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5;

namespace HtmlGenerator.mud;

/// <summary>
/// MudNumericField
/// </summary>
public class MudNumericFieldProvider : safe_base_dom_root
{
    /// <inheritdoc/>
    public override string? tag_custom_name => "MudNumericField";

    /// <inheritdoc/>
    /// <remarks>false</remarks>
    public override bool NeedEndTagSection => false;

    /// <inheritdoc/>
    /// <remarks>true</remarks>
    public override bool inline => true;

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        return base.GetHTML(deep);
    }
}