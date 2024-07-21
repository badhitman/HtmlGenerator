﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.headers;

/// <summary>
/// [meta] определяет метатеги, которые используются для хранения информации предназначенной для браузеров и поисковых систем.
/// Например, механизмы поисковых систем обращаются к метатегам для получения описания сайта, ключевых слов и других данных.
/// Разрешается использовать более чем один метатег, все они размещаются в контейнере [head]. Как правило, атрибуты любого метатега сводятся к
/// парам «имя=значение», которые определяются ключевыми словами [content], [name] или [http-equiv].
/// </summary>
public class meta : base_dom_root
{
    /// <summary>
    /// Указывает кодировку документа. Атрибут введен в HTML5 и предназначен для сокращения формы тега [meta], которая задавала кодировку в предыдущих версиях HTML и XHTML.
    /// 
    /// Пример: charset="utf-8"
    /// </summary>
    public string? charset;

    /// <summary>
    ///  Устанавливает значение атрибута, заданного с помощью [name] или [http-equiv].
    ///  Атрибут [content] может содержать более одного значения, в этом случае они разделяются запятыми или точкой с запятой. 
    /// 
    /// Пример: content="text/html; charset=utf-8"
    /// </summary>
    public string? content;

    /// <summary>
    /// Браузеры преобразовывают значение атрибута [http-equiv], заданное с помощью [content], в формат заголовка ответа HTTP и обрабатывают их, как будто они прибыли непосредственно от сервера.
    /// 
    /// Некоторые допустимые значения атрибута http-equiv:
    ///   Content-Type - Тип кодировки документа.
    ///   expires - Устанавливает дату и время, после которой информация в документе будет считаться устаревшей. 
    ///   pragma - Способ кэширования документа.
    ///   refresh - Загрузить другой документ в текущее окно браузера. 
    /// </summary>
    public string? http_equiv;

    /// <inheritdoc/>
    public meta()
    {
        inline = true;
        NeedEndTagSection = false;
    }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        if (!string.IsNullOrEmpty(charset))
            SetAttribute("charset", charset);

        if (!string.IsNullOrEmpty(content))
            SetAttribute("content", content);

        if (!string.IsNullOrEmpty(http_equiv))
            SetAttribute("http-equiv", http_equiv);

        return base.GetHTML(deep);
    }
}