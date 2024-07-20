﻿////////////////////////////////////////////////
// https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.collections;

public class ol(ol.TypesOL in_TypeOL = ol.TypesOL.Numb) : base_dom_root
{
    /// <summary>
    /// Устанавливает вид маркера.
    /// </summary>
    public enum TypesOL
    {
        /// <summary>
        /// Без указания типа
        /// </summary>
        None,

        /// <summary>
        /// арабские цифры.
        /// </summary>
        Numb,

        /// <summary>
        /// заглавные латинские буквы;
        /// </summary>
        A,

        /// <summary>
        /// строчные латинские буквы;
        /// </summary>
        a,

        /// <summary>
        /// заглавные римские цифры;
        /// </summary>
        I,

        /// <summary>
        /// строчные римские цифры;
        /// </summary>
        i
    }

    /// <summary>
    /// Тип списка
    /// </summary>
    public TypesOL TypeOL = in_TypeOL;

    public override string GetHTML(int deep = 0)
    {
        if (TypeOL == TypesOL.Numb)
            SetAttribute("type", "1");
        else if (TypeOL != TypesOL.None)
            SetAttribute("type", TypeOL.ToString("g"));
        else
            RemoveAttribute("type");

        return base.GetHTML(deep);
    }

    /// <summary>
    ///  Тег "li" определяет отдельный элемент списка. Внешний тег "ul" или "ol" устанавливает тип списка — маркированный или нумерованный. 
    /// </summary>
    public li GetLi()
    {
        li ret_val = new();
        if (TypeOL != TypesOL.None)
            ret_val.SetAttribute("type", TypeOL.ToString("g"));
        else
            ret_val.RemoveAttribute("type");

        return ret_val;
    }
}