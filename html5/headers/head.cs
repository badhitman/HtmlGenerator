////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.headers;

/// <summary>
/// Тег [head] предназначен для хранения других элементов, цель которых — помочь браузеру в работе с данными.
/// Также внутри контейнера [head] находятся метатеги, которые используются для хранения информации предназначенной для браузеров и поисковых систем.
/// Например, механизмы поисковых систем обращаются к метатегам для получения описания сайта, ключевых слов и других данных.
/// Содержимое тега [head] не отображается напрямую на веб-странице, за исключением тега [title] устанавливающего заголовок окна веб-страницы.
/// Внутри контейнера [head] допускается размещать следующие элементы: [base], [basefont], [bgsound], [link], [meta], [script], [style], [title].
/// </summary>
public class head : base_dom_root
{
    /// <summary>
    /// Заголовок [title] вкладки браузера
    /// </summary>
    public string? PageTitle;

    /// <summary>
    /// Элементы (по умолчанию). Т.е. элементы, которые будут в шапке при каждом построении
    /// </summary>
    public List<base_dom_root> defTags { get; private set; } = [];

    /// <summary>
    /// Динамические (одноразовые) элементы. Т.е. элементы будут удалены после построения шапки
    /// </summary>
    public List<base_dom_root> dynTags { get; private set; } = [];

    /// <summary>
    /// Базовый адрес (тег [base]) текущего документа
    /// </summary>
    public @base? Base;

    public override string GetHTML(int deep = 0)
    {
        ClearNestedDom();

        if (!string.IsNullOrEmpty(PageTitle))
            AddDomNode(new title(PageTitle));

        Childs ??= [];
        Childs.AddRange(defTags);
        Childs.AddRange(dynTags);
        dynTags.Clear();

        if (Base is not null)
            Childs.Add(Base);

        return base.GetHTML(deep);
    }
}