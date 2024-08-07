﻿////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.set;

/// <summary>
/// Определяет устройство, для которого будет воспроизводиться аудио или видеофайл. 
/// </summary>
public enum MediaDevicesEnum
{
    /// <summary>
    /// Все устройства.
    /// </summary>
    all,

    /// <summary>
    /// Устройства, основанные на системе Брайля, предназначены для слепых людей.
    /// </summary>
    braille,

    /// <summary>
    /// Наладонники, смартфоны, устройства с малой шириной экрана.
    /// </summary>
    handheld,

    /// <summary>
    /// Печатающее устройство вроде принтера.
    /// </summary>
    print,

    /// <summary>
    /// Экран монитора.
    /// </summary>
    screen,

    /// <summary>
    /// Речевые синтезаторы, а также программы для воспроизведения текста вслух. Сюда же входят речевые браузеры.
    /// </summary>
    speech,

    /// <summary>
    /// Проектор.
    /// </summary>
    projection,

    /// <summary>
    /// Телетайпы, терминалы, портативные устройства с ограниченными возможностями экрана.
    /// </summary>
    tty,

    /// <summary>
    /// Телевизор.
    /// </summary>
    tv
}