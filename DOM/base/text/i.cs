////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.DOM.text
{
    /// <summary>
    /// Устанавливает курсивное начертание шрифта. Допустимо использовать этот тег совместно с другими тегами, которые определяют начертание текста.
    /// </summary>
    public class i : html_dom_root
    {
        public i(string inner_text)
        {
            InnerText = inner_text;
        }
    }
}
