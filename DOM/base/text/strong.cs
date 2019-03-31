////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.DOM.text
{
    /// <summary>
    /// Тег [strong] предназначен для акцентирования текста. Браузеры отображают такой текст жирным начертанием.
    /// </summary>
    public class strong : html_dom_root
    {
        public strong(string in_text)
        {
            InnerText = in_text;
        }
    }
}
