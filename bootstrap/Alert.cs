////////////////////////////////////////////////
// https://github.com/badhitman 
////////////////////////////////////////////////

using HtmlGenerator.html5;
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.forms;
using HtmlGenerator.html5.textual;
using HtmlGenerator.set.bootstrap;

namespace HtmlGenerator.bootstrap
{
    /// <summary>
    /// Класс Web/DOM уведомления для пользователя.
    /// </summary>
    public class Alert : safe_base_dom_root
    {
        /// <summary>
        /// Стиль оформления уведомления
        /// </summary>
        public VisualBootstrapStylesEnum StyleAlert;

        /// <summary>
        /// Текст уведомления
        /// </summary>
        public string Message;

        /// <summary>
        /// Флаг/Признак наличия у Alert-а кнопки закрытия
        /// </summary>
        public bool isDismissible = false;

        public Alert(VisualBootstrapStylesEnum status_style, string text_msg)
        {
            tag_custom_name = typeof(div).Name;
            StyleAlert = status_style;
            Message = text_msg;
        }

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
}