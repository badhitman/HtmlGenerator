﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.text
{
    /// <summary>
    /// Тег [s] отображает текст как перечеркнутый. Этот тег аналогичен тегу [strike], но в отличие от него имеет сокращенную форму записи подобно тегам [b], [i] и [u].
    /// Взамен этого тега рекомендуется использовать стили. 
    /// </summary>
    public class s : basic_html_dom
    {
        public s()
        {
            inline = true;
        }
    }
}
