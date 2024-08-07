﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.tables;

/// <summary>
/// Предназначен для создания одной ячейки таблицы. Тег [td] должен размещаться внутри контейнера [tr],
/// который в свою очередь располагается внутри тега [table].
/// </summary>
public class td : th
{
    /// <summary>
    /// Позволяет связать ячейки таблицы с заголовками.
    /// Этот атрибут предназначен для повышения доступности таблицы пользователям речевых браузеров, в обычных браузерах результат применения атрибута [headers] не заметен.
    /// 
    /// Для связывания ячеек между собой одной ячейке в теге [td] или [th] задается атрибут [id], а второй ячейке — атрибут [headers] со значением, совпадающим со значением [id].
    /// </summary>
    public string? headers;

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        if (!string.IsNullOrEmpty(headers))
            SetAttribute("headers", headers);

        return base.GetHTML(deep);
    }
}