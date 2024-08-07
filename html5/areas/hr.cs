﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.areas;

/// <summary>
///  Рисует горизонтальную линию, которая по своему виду зависит от используемых параметров, а также браузера.
///  Тег [hr] относится к блочным элементам, линия всегда начинается с новой строки, а после нее все элементы отображаются на следующей строке. 
/// </summary>
public class hr : base_dom_root
{
    /// <inheritdoc/>
    public hr()
    {
        Inline = true;
    }
}