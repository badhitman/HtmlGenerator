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
    /// <remarks>true</remarks>
    public override bool Inline => true;

    /// <inheritdoc/>
    /// <remarks>true</remarks>
    public override bool NeedEndTagSection => true;

    /// <inheritdoc/>
    public override string? tag_custom_name => "MudTextField";
}