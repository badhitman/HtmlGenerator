////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

namespace HtmlGenerator.mud;

/// <summary>
/// MudTextFieldProvider
/// </summary>
public class MudTextFieldProvider : MudBaseFieldProvider
{
    /// <summary>
    /// Property: InputType
    /// </summary>
    public required string InputType { get; set; }

    /// <summary>
    /// Property: T
    /// </summary>
    public required string DescriptorType { get; set; }

    /// <inheritdoc/>
    public override string? tag_custom_name => "MudTextField";

    /// <inheritdoc/>   
    public override string GetHTML(int deep = 0)
    {
        _ = SetAttribute("T", $"{DescriptorType}{(IsNullable && !DescriptorType.EndsWith('?') ? "?" : "")}");

        return base.GetHTML(deep);
    }
}