﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.media;

/// <summary>
/// Добавляет, воспроизводит и управляет настройками аудиозаписи на веб-странице.
/// Путь к файлу задается через атрибут [src] или вложенный тег [source]. Внутри контейнера [audio] можно написать текст, который будет выводиться в браузерах, не работающих с этим тегом. 
/// </summary>
public class audio : base_dom_root
{
    /// <summary>
    /// При наличии этого атрибута аудио начинает воспроизводиться автоматически после загрузки страницы. Атрибут autoplay отменяет действие preload.
    /// </summary>
    public bool autoplay = false;

    /// <summary>
    /// Добавляет панель управления к аудио треку. Вид панели и ее содержимое зависит от браузера и может в себя включать: кнопку воспроизведения, паузы, перемотки, ползунок для изменения уровня громкости и др.
    /// </summary>
    public bool controls = false;

    /// <summary>
    /// Зацикливает воспроизведение аудио, чтобы оно повторялось с начала после завершения.
    /// </summary>
    public bool loop = false;

    /// <summary>
    /// Используется для загрузки аудиофайла вместе с загрузкой веб-страницы. Этот атрибут игнорируется, если установлен autoplay.
    /// Пустое значение атрибута воспринимается как auto.
    /// </summary>
    public PreloadModes preload = PreloadModes.none;

    /// <summary>
    /// Указывает путь к воспроизводимому аудиофайлу.
    /// Для этой же цели также можно использовать вложенный(ые) тег(и) "source".
    /// </summary>
    public string src = "#";

    /// <inheritdoc/>
    /// <remarks>При вызове этого метода поле Childs очищается и заново заполняется</remarks>
    public override string GetHTML(int deep = 0)
    {
        // Вложенные элементы могут быть только source
        Childs = Childs?.Where(x => x is source).ToList();
        if (Childs?.Count < 1)
            SetAttribute("src", src);

        if (autoplay)
            SetAttribute("autoplay", "autoplay");
        else
            SetAttribute("preload", preload.ToString("g"));

        if (controls)
            SetAttribute("controls", "controls");

        if (loop)
            SetAttribute("loop", "loop");

        return base.GetHTML(deep);
    }
}