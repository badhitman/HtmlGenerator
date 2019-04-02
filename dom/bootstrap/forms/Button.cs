using HtmlGenerator.dom.set.bootstrap_enum;
using HtmlGenerator.DOM.forms;
using HtmlGenerator.DOM.set.bootstrap_enum;

namespace HtmlGenerator.dom.bootstrap.forms
{
    public class Button : button
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
        /// Признак оформления кнопки в стиде Outline
        /// </summary>
        public bool isOutlineStyle = false;

        /// <summary>
        /// Переключаемое состояние кнопки (нажата/ненажата). Работает только с [button] (не работает с [input] или [a])
        /// </summary>
        public bool ToggleState = false;

        /// <summary>
        /// Размер кнопки
        /// </summary>
        public SizingBootstrap? SizeButton = null;

        public Button(string text_button, VisualBootstrapStylesEnum style_button) : base(text_button)
        {
            StyleButton = style_button;

        }

        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();
            css_class = "btn btn" + (isOutlineStyle ? "-outline" : "") + "-" + StyleButton.ToString("g").ToLower();
            tag_custom_name = TypeButton.ToString("g");

            switch (TypeButton)
            {
                case TypesBootstrapButton.a:
                    base.TypeButton = null;
                    SetAttribute("role", "button");
                    if (disabled)
                    {
                        css_class = (css_class + " disabled").Trim();
                        SetAttribute("aria-disabled", "true");
                        SetAttribute("tabindex", "-1");
                    }
                    break;
                case TypesBootstrapButton.button:
                    if(ToggleState)
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

            if (!(SizeButton is null))
                css_class = (css_class + " btn-" + SizeButton?.ToString("g")).Trim();

            return base.GetHTML(deep);
        }
    }
}
