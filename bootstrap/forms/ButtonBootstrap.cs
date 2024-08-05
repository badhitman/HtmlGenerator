////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

using HtmlGenerator.html5.forms;
using HtmlGenerator.set.bootstrap;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// Button
/// </summary>
public class ButtonBootstrap : button
{
    /// <summary>
    /// Тип контейнера, который выполняет роль "носителя" кнопки в Bootstrap
    /// </summary>
    public new TypesBootstrapButton TypeButton = TypesBootstrapButton.button;

    /// <summary>
    /// Стиль оформления
    /// </summary>
    public VisualBootstrapStylesEnum StyleButton;

    /// <summary>
    /// Признак оформления кнопки в стиле Outline
    /// </summary>
    public bool isOutlineStyle = false;

    /// <summary>
    /// Переключаемое состояние кнопки (нажата/не нажата). Работает только с [button] (не работает с [input] или [a])
    /// </summary>
    public bool ToggleState = false;

    /// <summary>
    /// Размер кнопки
    /// </summary>
    public SizingBootstrap? SizeButton = null;

    /// <summary>
    /// Button
    /// </summary>
    public ButtonBootstrap(string text_button, VisualBootstrapStylesEnum style_button) : base(text_button)
    {
        StyleButton = style_button;
        Inline = true;
    }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        Childs = null;
        AddCSS("btn " + "btn" + (isOutlineStyle ? "-outline" : "") + "-" + StyleButton.ToString("g"), true);

        tag_custom_name = TypeButton.ToString("g").ToLower();

        switch (TypeButton)
        {
            case TypesBootstrapButton.a:
                base.TypeButton = null;
                SetAttribute("role", "button");
                if (disabled)
                {
                    AddCSS("disabled");
                    SetAttribute("aria-disabled", "true");
                    SetAttribute("tabindex", "-1");
                }
                break;
            case TypesBootstrapButton.button:
                if (ToggleState)
                {
                    SetAttribute("data-toggle", "button");
                    SetAttribute("aria-pressed", "false");
                }
                break;
            case TypesBootstrapButton.input:
                SetAttribute("value", InnerText);
                InnerText = null;
                break;
            default:
                // какая-то ошибка
                break;
        }

        if (SizeButton is not null)
            AddCSS("btn-" + SizeButton?.ToString("g"));

        return base.GetHTML(deep);
    }
}