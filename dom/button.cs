////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    public class button : basic_html_dom
    {
        public button(string text_button)
        {
            inner_html = text_button;
            inline = true;
        }
    }
}
