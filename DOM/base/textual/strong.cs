////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.textual
{
    /// <summary>
    /// Тег [strong] предназначен для акцентирования текста. Браузеры отображают такой текст жирным начертанием.
    /// </summary>
    public class strong : base_dom_root
    {
        public strong(string in_text)
        {
            InnerText = in_text;
        }
    }
}
