////////////////////////////////////////////////
// © https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
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
