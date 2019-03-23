////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Тег "strong" предназначен для акцентирования текста. Браузеры отображают такой текст жирным начертанием.
    /// </summary>
    public class strong : basic_html_dom
    {
        public strong(string in_text)
        {
            InnerHtml = in_text;
        }
    }
}
