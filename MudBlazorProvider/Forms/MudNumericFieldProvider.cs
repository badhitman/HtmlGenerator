////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.mud;

/// <summary>
/// MudNumericField
/// </summary>
public class MudNumericFieldProvider : MudBaseFieldProvider
{
    /// <summary>
    /// is double
    /// </summary>
    public bool IsDouble { get; set; } = false;

    /// <inheritdoc/>
    public override string? tag_custom_name => "MudNumericField";

    /// <inheritdoc/>
    /// <remarks>false</remarks>
    public override bool NeedEndTagSection => false;

    /// <inheritdoc/>
    /// <remarks>true</remarks>
    public override bool Inline => true;

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        SetAttribute("T", $"{(IsDouble ? "double" : "int")}{(IsNullable ? "?" : "")}");
        return base.GetHTML(deep);
    }
}