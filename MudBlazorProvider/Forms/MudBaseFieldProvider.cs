////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5;
using System;
using System.Globalization;

namespace HtmlGenerator.mud;

/// <summary>
/// MudBaseFieldProvider
/// </summary>
public abstract class MudBaseFieldProvider : safe_base_dom_root
{
    /// <summary>
    /// @bind-Value
    /// </summary>
    public string? BindValue { get; set; }

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

    /// <summary>
    /// Allow NULL value
    /// </summary>
    public bool IsNullable { get; set; }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        SetAttribute("Immediate", Immediate.ToString().ToLower());

        if (!string.IsNullOrEmpty(Label))
            SetAttribute("Label", Label);
        else
            RemoveAttribute("Label");

        if (!string.IsNullOrWhiteSpace(Format))
            SetAttribute("Format", Format);
        else
            RemoveAttribute("Format");

        if (CultureInfoField is not null)
            SetAttribute("Culture", $"@(CultureInfo.GetCultureInfo(\"{CultureInfoField}\"))");
        else
            RemoveAttribute("Culture");

        if (!string.IsNullOrEmpty(Hint))
            SetAttribute("HelperText", Hint);
        else
            RemoveAttribute("HelperText");

        if (!string.IsNullOrWhiteSpace(BindValue))
            SetAttribute("@bind-Value", BindValue);
        else
            RemoveAttribute("@bind-Value");

        return base.GetHTML(deep);
    }
}
