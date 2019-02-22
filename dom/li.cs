////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Тег "li: определяет отдельный элемент списка. Внешний тег "ul" или "ol" устанавливает тип списка — маркированный или нумерованный.
    /// </summary>
    public class li : basic_html_dom
    {
        public li(string text_value)
        {
            InnerText = text_value;
        }
    }
}
