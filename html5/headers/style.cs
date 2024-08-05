﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;

namespace HtmlGenerator.html5.headers;

/// <summary>
///  Тег [style] применяется для определения стилей элементов веб-страницы.
///  Тег [style] необходимо использовать внутри контейнера [head]. Можно задавать более чем один тег [style].
/// </summary>
public class style : base_dom_root
{
    /// <summary>
    ///  Устанавливает устройство вывода, для которого предназначена таблица стилей.
    ///  Для каждого устройства — от карманного компьютера до принтера можно определить свой собственный стиль, который бы учитывал специфику устройства и подгонял под него вид веб-страницы. 
    /// </summary>
    public List<MediaDevicesEnum> media = [MediaDevicesEnum.all];

    /// <summary>
    ///  Сообщает браузеру, какой синтаксис использовать, чтобы правильно интерпретировать таблицу стилей.
    ///  Как правило, браузеры корректно работают со стилями и при отсутствии этого атрибута, он необходим для некоторых старых браузеров, которые могут не распознать содержимое контейнера [style].
    /// </summary>
    public string type = "text/css";

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        SetAttribute("media", media, ", ");

        if (!string.IsNullOrEmpty(type))
            SetAttribute("type", type);

        return base.GetHTML(deep);
    }
}