﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;

namespace HtmlGenerator.html5.headers;

/// <summary>
///  Элемент [base] определен внутри контейнера [head] и инструктирует браузер относительно полного базового адреса текущего документа.
///  Тег [base] предназначен для документов, в которых используется относительный адрес и эти документы могут переноситься в другую папку или даже на другой компьютер без потери связи.
///  Браузер ищет тег [base], определяет полный адрес документа и корректно загружает его.
///  Например, если адрес документа указан как [base href="http://www.megasite.ru/hzchd/"], то при добавлении рисунков достаточно использовать относительный адрес [img src="images/labuda.gif"].
///  При этом полный путь к изображению будет http://www.megasite.ru/hzchd/images/labuda.gif, что позволяет браузеру всегда находить графический файл, независимо от того, где находится текущая веб-страница.
///  Также можно применять и иерархическую систему пути с двумя точками. Так, если изображение добавляется как [img src="../images/labuda.gif"], то полный путь к файлу будет http://www.megasite.ru/images/labuda.gif.
///
///  Второе применение тега [base] — задание целевого окна для всех ссылок на текущей странице.
/// </summary>
public class @base : base_dom_root
{
    /// <inheritdoc/>
    /// <remarks>false</remarks>
    public override bool NeedEndTagSection => false;

    /// <inheritdoc/>
    /// <remarks>true</remarks>
    public override bool Inline => true;

    /// <summary>
    ///  Адрес, который должен использоваться для указания полного пути к файлам.
    ///  Обычно это типичный путь к текущему документу, но он может быть задан и другим, если это необходимо для организации файлов на сайте.
    /// </summary>
    public string? href;

    /// <summary>
    /// Вы можете определить окно, в которое будет загружаться веб-страница, открытая по ссылке.
    /// Для этого используется атрибут target, в качестве его значения указывается имя окна или фрейма.
    /// Если target не установлен, возвращаемый результат показывается в текущем окне. 
    /// </summary>
    public TargetsEnum? target;

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        Childs = null;

        if (!string.IsNullOrEmpty(href))
            SetAttribute("href", href);

        if (target is not null)
            SetAttribute("target", target?.ToString("g"));

        return base.GetHTML(deep);
    }
}