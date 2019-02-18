////////////////////////////////////////////////
// © https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace DataViewHtml.dom
{
    /// <summary>
    /// Тег "strong" предназначен для акцентирования текста. Браузеры отображают такой текст жирным начертанием.
    /// </summary>
    public class strong : basic_html_dom
    {
        public strong(string in_text)
        {
            inner_html = in_text;
        }
    }
}
