﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

using HtmlGenerator.html5.textual;
using HtmlGenerator.set.bootstrap;
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.forms;
using HtmlGenerator.html5;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// Класс Web/DOM уведомления для пользователя.
/// </summary>
/// <remarks>
/// Класс Web/DOM уведомления для пользователя.
/// </remarks>
public class AlertBootstrap(VisualBootstrapStylesEnum status_style, string text_msg) : safe_base_dom_root
{
    /// <summary>
    /// Стиль оформления уведомления
    /// </summary>
    public VisualBootstrapStylesEnum StyleAlert = status_style;

    /// <summary>
    /// Текст уведомления
    /// </summary>
    public string Message = text_msg;

    /// <summary>
    /// Флаг/Признак наличия у Alert-а кнопки закрытия
    /// </summary>
    public bool isDismissible = false;

    /// <summary>
    /// div
    /// </summary>
    public override string tag_custom_name => "div";

    /// <inheritdoc/>
    /// <remarks>При вызове этого метода поле Childs очищается и заново заполняется</remarks>
    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        AddCSS("alert alert-" + StyleAlert.ToString("g"), true);
        if (isDismissible)
            AddCSS("alert-dismissible fade show", true);

        css_style = "min-height: 50px;";
        SetAttribute("role", "alert");

        if (isDismissible)
        {
            button button_close = new(null);
            button_close.AddCSS("close");

            button_close.SetAttribute("data-dismiss", "alert");
            button_close.SetAttribute("aria-label", "Close");
            span my_span = new() { InnerText = "&times;" };
            my_span.SetAttribute("aria-hidden", "true");
            button_close.AddDomNode(my_span);
            Childs.Add(button_close);
        }

        Childs.Add(new text(Message));

        return base.GetHTML(deep);
    }
}