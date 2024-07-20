﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.tables;

/// <summary>
/// Тег [tr] служит контейнером для создания строки таблицы. Каждая ячейка в пределах такой строки может задаваться с помощью тега [th] или [td].
/// </summary>
public class tr : safe_base_dom_root
{
    /// <summary>
    /// Колонки заголовочной части
    /// </summary>
    public List<th> Columns { get; private set; } = new List<th>();

    public override string GetHTML(int deep = 0)
    {
        Childs ??= [];
        Childs.AddRange(Columns);
        return base.GetHTML(deep);
    }
}