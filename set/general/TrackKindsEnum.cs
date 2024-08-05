﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.set;

/// <summary>
/// Track kinds
/// </summary>
public enum TrackKindsEnum
{
    /// <summary>
    /// Субтитры - Предназначены для дублирования звуковой дорожки фильма в виде текста на языке оригинала для глухих людей.
    /// Также могут содержать перевод на другие языки для тех, кто не знаком с языком оригинала. Текст субтитров выводится поверх видео.
    /// </summary>
    subtitles,

    /// <summary>
    /// Заголовки - Дублирование диалогов, звуковых эффектов, музыкального сопровождения в виде текста для тех случаев, когда звук недоступен или для глухих пользователей.
    /// Выводится поверх видео, при этом помечается, что подходит для плохо слышащих людей.
    /// </summary>
    captions,

    /// <summary>
    /// Описание - Звуковое описание происходящего в видео для тех случаев, когда изображение недоступно или для слепых людей.
    /// </summary>
    descriptions,

    /// <summary>
    /// Главы - Названия глав используемые для быстрой навигации по видео или аудио. Отображаются в виде списка.
    /// </summary>
    chapters,

    /// <summary>
    /// Метаданные - Предназначены для использования скриптами и не отображаются в браузере.
    /// </summary>
    metadata
}