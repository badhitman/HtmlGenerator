﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.tables;

/// <summary>
/// Тег [th] предназначен для создания одной ячейки таблицы, которая обозначается как заголовочная. Текст в такой ячейке отображается 
/// браузером обычно жирным шрифтом и выравнивается по центру. Тег [th] должен размещаться внутри контейнера [tr], который в свою очередь располагается 
/// внутри тега [table].
/// </summary>
public class th : safe_base_dom_root
{
    /// <summary>
    /// Устанавливает число ячеек, которые должны быть объединены по горизонтали. Этот атрибут имеет смысл для таблиц, состоящих из нескольких строк.
    /// </summary>
    public int colspan = 0;

    /// <summary>
    /// Устанавливает число ячеек, которые должны быть объединены по вертикали. Этот атрибут имеет смысл для таблиц, состоящих из нескольких строк.
    /// </summary>
    public int rowspan = 0;

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        if (colspan > 0)
            SetAttribute("colspan", colspan);

        if (rowspan > 0)
            SetAttribute("rowspan", rowspan);

        return base.GetHTML(deep);
    }
}