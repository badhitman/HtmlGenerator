////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.DOM;
using HtmlGenerator.DOM.forms;
using HtmlGenerator.DOM.textual;
using HtmlGenerator.DOM.set.bootstrap_enum;

namespace HtmlGenerator.bootstrap
{
    /// <summary>
    /// Класс Web/DOM уведомления для пользователя.
    /// </summary>
    public class WebNotification : div
    {
        /// <summary>
        /// Стиль оформления уведомления
        /// </summary>
        public VisualBootstrapStylesEnum CurrStatus;

        /// <summary>
        /// Текст уведомления
        /// </summary>
        public string Message;

        public WebNotification(VisualBootstrapStylesEnum status_style, string text_msg)
        {
            tag_custom_name = typeof(div).Name;
            CurrStatus = status_style;
            Message = text_msg;
        }

        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();
            css_class = "alert alert-" + CurrStatus.ToString("g").ToLower() + " alert-dismissible fade show";
            css_style = "min-height: 50px;";
            SetAtribute("role", "alert");
            button button_close = new button(null) { css_class = "close" };
            button_close.SetAtribute("data-dismiss", "alert");
            button_close.SetAtribute("aria-label", "Close");
            span my_span = new span() { InnerText = "&times;" };
            my_span.SetAtribute("aria-hidden", "true");
            button_close.Childs.Add(my_span);
            InnerText = Message;
            Childs.Add(button_close);

            return base.GetHTML(deep);
        }
    }
}
