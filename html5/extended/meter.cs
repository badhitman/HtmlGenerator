﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.extended;

/// <summary>
/// Используется для вывода значения в некотором известном диапазоне.
/// Используется преимущественно для отображения числовых значений, например, количества результатов поиска, объема жидкости, давления и др.
/// </summary>
public class meter : base_dom_root
{
    /// <summary>
    /// Определяет предел, при достижении которого значение считается высоким.
    /// В качестве значения указывается целое или дробное число. Обязательно должно соблюдаться условие min ≤ high ≤ max, а также low ≤ high.
    /// </summary>
    public double high = 1;

    /// <summary>
    /// Определяет предел, при достижении которого значение считается низким.
    /// В качестве значения указывается целое или дробное число. Обязательно должно соблюдаться условие min ≤ low ≤ max, а также low ≤ high.
    /// </summary>
    public double low = 0;

    /// <summary>
    /// Задает максимальный порог, который может достигать значение. 
    /// В качестве значения указывается целое или дробное число. Обязательно должно соблюдаться условие min ≤ value ≤ max.
    /// </summary>
    public double max = 1;

    /// <summary>
    /// Задает минимальный порог, который может достигать значение.
    /// В качестве значения указывается целое или дробное число. Обязательно должно соблюдаться условие min ≤ value ≤ max.
    /// </summary>
    public double min = 0;

    /// <summary>
    /// Определяет наилучшее или оптимальное значение.
    /// В качестве значения указывается целое или дробное число. Обязательно должно соблюдаться условие min ≤ optimum ≤ max.
    /// </summary>
    public double optimum = 0.5;

    /// <summary>
    /// Устанавливает значение единицы измерения. Значение должно быть в диапазоне, задаваемым атрибутами min и max.
    /// В качестве значения указывается целое или дробное число. Допускается использование отрицательных значений.
    /// </summary>
    public double value = 0.5;

    public meter()
    {
        inline = true;
    }

    public override string GetHTML(int deep = 0)
    {
        SetAttribute("high", high);
        SetAttribute("low", low);
        SetAttribute("max", max);
        SetAttribute("min", min);
        SetAttribute("optimum", optimum);
        SetAttribute("value", value);

        return base.GetHTML(deep);
    }
}