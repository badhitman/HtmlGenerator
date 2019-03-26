////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.text
{
    /// <summary>
    ///  Устанавливает жирное начертание шрифта. Допустимо использовать этот тег совместно с другими тегами, которые определяют начертание текста.
    /// </summary>
    public class b : basic_html_dom
    {
        public b()
        {
            inline = true;
        }
    }
}
