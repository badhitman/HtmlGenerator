﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.textual
{
    /// <summary>
    ///  Тег [em] предназначен для акцентирования текста. Браузеры отображают такой текст курсивным начертанием.
    ///  
    /// Следует отметить, что теги [i] и [em], также как [b] и [strong], несмотря на сходство результата, являются не совсем эквивалентными и заменяемыми.
    /// Первый тег [i] — является тегом физической разметки и устанавливает курсивный текст, а тег [em] — тегом логической разметки и определяет важность помеченного текста.
    /// Такое разделение тегов на логическое и физическое форматирование изначально предназначалось, чтобы сделать HTML универсальным, в том числе не зависящим от устройства вывода информации.
    /// Теоретически, если воспользоваться, например, речевым браузером, то текст, оформленный с помощью тегов [i] и [em], будет отмечен по-разному.
    /// Однако получилось так, что в популярных браузерах результат использования этих тегов равнозначен.
    /// </summary>
    public class em : base_dom_root
    {

    }
}
