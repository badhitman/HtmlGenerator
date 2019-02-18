////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////

namespace DataViewHtml.dom
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
