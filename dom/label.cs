////////////////////////////////////////////////
// © https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace DataViewHtml.dom
{
    public class label : basic_html_dom
    {
        public label(string i_text, string i_for)
        {
            inline = true;
            inner_html = i_text;
            SetAtribute("for", i_for);
        }
    }
}
