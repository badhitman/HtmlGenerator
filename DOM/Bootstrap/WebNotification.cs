////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom;
using HtmlGenerator.dom.form;
using HtmlGenerator.dom.text;
using HtmlGenerator.DOM.set.bootstrap_enum;

namespace HtmlGenerator.bootstrap
{
    /// <summary>
    /// Класс Web/DOM уведомления для пользователя.
    /// </summary>
    public class WebNotification
    {
        //
        public VisualBootstrapStylesEnum CurrStatus;
        public string Message;
        public WebNotification(VisualBootstrapStylesEnum s, string msg)
        {
            CurrStatus = s;
            Message = msg;
        }

        public div GetDOM()
        {
            div div = new div();
            div.css_class = "alert alert-" + CurrStatus.ToString("g").ToLower() + " alert-dismissible fade show";
            div.css_style = "min-height: 50px;";
            div.CustomAtributes.Add("role", "alert");

            button button_close = new button(null) { css_class = "close" };
            button_close.CustomAtributes.Add("data-dismiss", "alert");
            button_close.CustomAtributes.Add("aria-label", "Close");

            span my_span = new span("&times;");
            my_span.SetAtribute("aria-hidden", "true");
            button_close.Childs.Add(my_span);

            div.InnerText = Message;
            div.Childs.Add(button_close);

            return div;
        }
    }
}
