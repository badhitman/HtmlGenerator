////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5;
using System.Globalization;

namespace HtmlGenerator.mud;

/// <summary>
/// 
/// </summary>
public class MudBaseFieldProvider : safe_base_dom_root
{
    /// <summary>
    /// Label
    /// </summary>
    public string? Format { get; set; }

    /// <summary>
    /// Label
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    /// Immediate
    /// </summary>
    public bool Immediate { get; set; }

    /// <summary>
    /// CultureInfo - field
    /// </summary>
    public CultureInfo? CultureInfoField { get; set; }

    /// <summary>
    /// Helper text
    /// </summary>
    public string? Hint { get; set; }
}

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
        CustomAttributes.Clear();
        SetAttribute("Immediate", Immediate.ToString().ToLower());

        if (string.IsNullOrEmpty(Label))
            RemoveAttribute("Label");
        else
            SetAttribute("Label", Label);

        if (string.IsNullOrWhiteSpace(Format))
            RemoveAttribute("Format");
        else
            SetAttribute("Format", Format);

        if (CultureInfoField is null)
            RemoveAttribute("Culture");
        else
            SetAttribute("Culture", $"@(CultureInfo.GetCultureInfo(\"{CultureInfoField}\"))");

        return base.GetHTML(deep);
    }
}// <MudNumericField Culture="@_de" T="double?" @bind-Value="_valueDe" HelperText="@_valueDe.ToString()"/>