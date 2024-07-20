﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.tables;

/// <summary>
///  Тег [col] задает ширину и другие характеристики одной или нескольких колонок таблицы.
///  При наличии этого тега браузер начинает показывать содержимое таблицы, не дожидаясь ее полной загрузки.
///  Тег [col] можно использовать совместно с тегом [colgroup], который задает группу колонок, обладающих общими характеристиками.
/// </summary>
public class col : safe_base_dom_root
{
    /// <summary>
    ///  Определяет число колонок, к которым будут применяться заданные характеристики. Если этот атрибут отсутствует, то тег [col] работает для одной колонки.
    ///  Допускается применять атрибут span к нескольким колонкам и таким образом формировать группы колонок с одинаковыми характеристиками.
    /// </summary>
    public int span = -1;

    public override string GetHTML(int deep = 0)
    {
        if (span > 0)
            SetAttribute("span", span);

        return base.GetHTML(deep);
    }
}