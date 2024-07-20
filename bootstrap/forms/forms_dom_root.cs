﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.html5;
using HtmlGenerator.html5.areas;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// form`s
/// </summary>
public class forms_dom_root : safe_base_dom_root
{
    /// <inheritdoc/>
    public static div[] GetValidationAlerts(string? validation_input_id, string? invalid_text = "Укажите значение", string? valid_text = null)
    {
        div valid_element = new() { InnerText = valid_text, Id_DOM = "valid-tooltip-" + validation_input_id, inline = true };
        valid_element.AddCSS("valid-feedback");
        div invalid_element = new() { InnerText = invalid_text, Id_DOM = "invalid-tooltip-" + validation_input_id, inline = true };
        invalid_element.AddCSS("invalid-feedback");
        // 
        if (!string.IsNullOrEmpty(valid_text))
            return [valid_element, invalid_element];
        else
            return [invalid_element];
    }
}