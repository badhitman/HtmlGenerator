////////////////////////////////////////////////
// © https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Определяет заголовок документа. Элемент "title" не является частью документа и не показывается напрямую на веб-странице.
    /// В операционной системе Windows текст заголовка отображается в левом верхнем углу окна браузера
    /// </summary>
    public class title : basic_html_dom
    {
        public title(string text_title)
        {
            inline = true;
            inner_html = text_title;
        }
    }
}
