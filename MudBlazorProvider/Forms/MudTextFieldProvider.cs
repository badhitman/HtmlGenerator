////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.mud;

/// <summary>
/// MudTextFieldProvider
/// </summary>
public class MudTextFieldProvider : MudBaseFieldProvider
{
    /// <summary>
    /// InputType
    /// </summary>
    public required string InputType { get; set; }

    /// <inheritdoc/>
    public override string? tag_custom_name => "MudTextField";
}