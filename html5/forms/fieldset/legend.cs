////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.forms;

/// <summary>
/// Тег [legend] применяется для создания заголовка группы элементов формы, которая определяется с помощью тега [fieldset].
/// Группа элементов обозначается в браузере с помощью рамки, а текст, который располагается внутри контейнера [legend], встраивается в эту рамку.
/// </summary>
public class legend : base_dom_root
{
    public legend(string text_legend)
    {
        InnerText = text_legend;
    }
}