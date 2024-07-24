﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5;
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
    /// <remarks>true</remarks>
    public override bool Inline => true;

    /// <inheritdoc/>
    /// <remarks>true</remarks>
    public override bool NeedEndTagSection => false;


    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        SetAttribute("Immediate", Immediate.ToString());

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

        if (string.IsNullOrEmpty(Hint))
            RemoveAttribute("HelperText");
        else
            SetAttribute("HelperText", Hint);

        if (string.IsNullOrWhiteSpace(BindValue))
            RemoveAttribute("@bind-Value");
        else
            SetAttribute("@bind-Value", BindValue);

        return base.GetHTML(deep);
    }
}
