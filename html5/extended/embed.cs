﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;

namespace HtmlGenerator.html5.extended;

/// <summary>
/// Элемент [embed] используется для загрузки и отображения объектов (например, видеофайлов, флэш-роликов, некоторых звуковых файлов и т.д.), которые исходно браузер не понимает.
/// Как правило, такие объекты требуют подключения к браузеру специального модуля, который называется плагин, или запуска вспомогательной программы.
/// 
/// Спецификация HTML 4.0 рекомендует использовать тег [object] для загрузки внешних данных вместо тега [embed].
/// Однако некоторые браузеры не отображают таким образом нужную информацию, поэтому наилучшим вариантом будет поместить [embed] внутрь контейнера [object].
/// 
/// Вид внедренного объекта зависит от установленных в браузере плагинов, типа загружаемого файла, а также от атрибутов тега [embed].
/// </summary>
public class embed : base_dom_root
{
    /// <summary>
    /// Атрибут [height] устанавливает высоту объекта. В заданные размеры входит не только само изображение, например в случае воспроизведения видеофайла, но и панель управления им, включая кнопки проигрывания, паузы, остановки и т.д. По этой причине на размер отображаемого объекта влияет тип файла и применяемый плагин.
    /// 
    /// Если используется процентная запись, то размеры объекта вычисляются относительно родительского элемента — контейнера, где находится тег [embed].
    /// В случае отсутствия родительского контейнера, в его качестве выступает окно браузера.Иными словами, [height= "100%"] означает, что объект будет занимать всю доступную высоту веб-страницы.
    /// </summary>
    public NativeSizingCSS height = new() { size = 100, type = NativeSizingCSS.TypeSize.percent };

    /// <summary>
    /// Атрибут [width] устанавливает ширину объекта. В заданные размеры входит не только само изображение, например в случае воспроизведения видеофайла, но и панель управления им, включая кнопки проигрывания, паузы, остановки и т.д.
    /// По этой причине на размер отображаемого объекта влияет тип файла и применяемый плагин.
    /// 
    /// Если используется процентная запись, то размеры объекта вычисляются относительно родительского элемента — контейнера, где находится тег [embed].
    /// В случае отсутствия родительского контейнера, в его качестве выступает окно браузера. Иными словами, [width= "100%"] означает, что объект будет занимать всю доступную ширину веб-страницы.
    /// </summary>
    public NativeSizingCSS width = new() { size = 100, type = NativeSizingCSS.TypeSize.percent };

    /// <summary>
    /// Атрибут [src] указывает путь к файлу, который необходимо загрузить в окно браузера.
    /// Браузер анализирует расширение файла и решает по нему, какой плагин или внешняя программа требуется для отображения файла. 
    /// </summary>
    public string? src;

    /// <summary>
    /// Не всегда браузер может распознать тип файла по его расширению. В таких случаях лучше указывать его тип с помощью атрибута [type], который устанавливает MIME-тип для данных.
    /// </summary>
    public string? type;

    public override string GetHTML(int deep = 0)
    {
        SetAttribute("height", height.ToString());
        SetAttribute("width", width.ToString());

        if (!string.IsNullOrEmpty(src))
        {
            SetAttribute("src", src);
            if (!string.IsNullOrEmpty(type))
                SetAttribute("type", type);
        }

        return base.GetHTML(deep);
    }
}