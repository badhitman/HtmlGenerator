﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;

namespace HtmlGenerator.html5.collections;

/// <summary>
/// Тег [li] определяет отдельный элемент списка. Внешний тег [ul] или [ol] устанавливает тип списка — маркированный или нумерованный.
/// </summary>
public class li : base_dom_root
{
    /// <summary>
    /// Устанавливает вид маркера списка. 
    /// </summary>
    public TypesULEnum TypeUL = TypesULEnum.disc;

    public override string GetHTML(int deep = 0)
    {
        SetAttribute("type", TypeUL.ToString("g"));
        return base.GetHTML(deep);
    }
}