﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.DOM.text
{
    /// <summary>
    /// Определяет текстовый абзац. Тег [p] является блочным элементом, всегда начинается с новой строки,
    /// абзацы текста идущие друг за другом разделяются между собой отбивкой. Величиной отбивки можно управлять с помощью стилей.
    /// Если закрывающего тега нет, считается, что конец абзаца совпадает с началом следующего блочного элемента.
    /// </summary>
    public class p : base_dom_root
    {
        public p(string in_text)
        {
            InnerText = in_text;
        }
    }
}
