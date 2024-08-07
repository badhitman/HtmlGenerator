﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.areas;

/// <summary>
/// Элемент [body] предназначен для хранения содержания веб-страницы (контента), отображаемого в окне браузера.
/// Информацию, которую следует выводить в документе, следует располагать именно внутри контейнера [body].
/// К такой информации относится текст, изображения, теги, скрипты JavaScript и т.д.
/// Тег [body] также применяется для определения цветов ссылок и текста на веб-странице.Подобная практика в HTML 4 осуждается и взамен для указания цветовой схемы рекомендуется использовать стили, применяя их к селектору BODY.
/// Тем не менее, большинство атрибутов до сих пор поддерживается разными браузерами.
/// Часто тег [body] используется для размещения обработчика событий, например, [onload], которое выполняется после того, как документ завершил загрузку в текущее окно или фрейм.
/// Открывающий и закрывающий теги [body] на веб-странице не являются обязательными, однако хорошим стилем считается их использование, чтобы определить начало и конец HTML-документа.
/// </summary>
public class body : base_dom_root
{

}