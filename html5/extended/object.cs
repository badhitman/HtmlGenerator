﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;

namespace HtmlGenerator.html5.extended;

/// <summary>
/// Элемент [object] сообщает браузеру, как загружать и отображать объекты, которые исходно браузер не понимает.
/// Как правило, такие объекты требуют подключения к браузеру специального модуля, который называется плагин, или запуска вспомогательной программы.
/// 
/// Спецификация HTML 4 разрешает вкладывать несколько тегов [object] с разным содержанием друг в друга.
/// Это позволяет отображать тот контент, который понимает браузер, при отсутствии нужного плагина.
/// Например, внешний тег [object] загружает видеофайл, а для случая, когда соответствующий кодек (программа для сжатия и восстановления видеоданных) не установлен, внутренний тег [object] показывает графическое изображение.
/// Дополнительно внутрь контейнера [object] можно поместить тег [param], который передает дополнительные параметры для отображения объекта.
/// </summary>
public class @object : base_dom_root
{
    /// <summary>
    /// Определяет файл, который следует отобразить в окне браузера.
    /// Для популярных форматов данных достаточно указать путь к файлу и его тип (атрибут [type]) для загрузки и демонстрации результата.
    /// Для специфичных плагинов желательно еще включить атрибут [classid].
    /// 
    /// Путь к файлу определяется относительно папки, заданной атрибутом [codebase]. Если [codebase] не указан, тогда путь следует задавать относительно текущего документа.
    /// </summary>
    public string? data;

    /// <summary>
    /// Атрибут [height] устанавливает высоту объекта, а width — его ширину.
    /// В заданные размеры входит не только само изображение, например в случае воспроизведения видеофайла, но и панель управления им, включая кнопки проигрывания, паузы, остановки и т.д.
    /// По этой причине на размер отображаемого объекта влияет тип файла и применяемый плагин.
    /// 
    /// Если используется процентная запись, то размеры объекта вычисляются относительно родительского элемента — контейнера, где находится тег [object].
    /// В случае отсутствия родительского контейнера, в его качестве выступает окно браузера.Иными словами, width= "100%" означает, что объект будет занимать всю доступную ширину веб-страницы.
    /// </summary>
    public NativeSizingCSS height = new() { type = NativeSizingCSS.TypeSize.auto };

    /// <summary>
    /// Атрибут [height] устанавливает высоту объекта, а [width] — его ширину.
    /// В заданные размеры входит не только само изображение, например в случае воспроизведения видеофайла, но и панель управления им, включая кнопки проигрывания, паузы, остановки и т.д.
    /// По этой причине на размер отображаемого объекта влияет тип файла и применяемый плагин.
    /// 
    /// Если используется процентная запись, то размеры объекта вычисляются относительно родительского элемента — контейнера, где находится тег [object].
    /// В случае отсутствия родительского контейнера, в его качестве выступает окно браузера.
    /// Иными словами, width= "100%" означает, что объект будет занимать всю доступную ширину веб-страницы.
    /// </summary>
    public NativeSizingCSS width = new() { type = NativeSizingCSS.TypeSize.auto };

    /// <summary>
    /// Сообщает браузеру о типе объекта, который указан в атрибуте [data].
    /// Браузер может использовать эту информацию, чтобы подготовить необходимые ресурсы для воспроизведения файла.
    /// </summary>
    public string? mimetype;

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        if (!string.IsNullOrEmpty(data))
            SetAttribute("data", data);

        if (!string.IsNullOrEmpty(mimetype))
            SetAttribute("type", mimetype);

        SetAttribute("height", height.ToString());
        SetAttribute("width", width.ToString());

        return base.GetHTML(deep);
    }
}