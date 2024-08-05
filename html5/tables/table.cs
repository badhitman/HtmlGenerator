////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.tables;

/// <summary>
/// Элемент [table] служит контейнером для элементов, определяющих содержимое таблицы. Любая таблица состоит из строк и ячеек, 
/// которые задаются с помощью тегов [tr] и [td]. Внутри [table] допустимо использовать следующие элементы: [caption], [col], 
/// [colgroup], [tbody], [td], [tfoot], [th], [thead] и [tr].
/// Таблицы с невидимой границей долгое время использовались для верстки веб-страниц, позволяя разделять документ на модульные блоки.
/// Подобный способ применения таблиц нашел воплощение на многих сайтах, пока ему на смену не пришел более современный способ верстки с помощью слоев.
/// </summary>
public class table : safe_base_dom_root
{
    /// <summary>
    /// Заголовок таблицы с указанием заголовков колонок
    /// </summary>
    public thead THead { get; private set; } = new thead();

    /// <summary>
    /// Тело таблицы (без заголовочной части)
    /// </summary>
    public tbody TBody { get; private set; } = new tbody();

    /// <inheritdoc/>
    /// <remarks>При вызове этого метода поле Childs очищается и заново заполняется</remarks>
    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        Childs.Add(THead);
        Childs.Add(TBody);
        return base.GetHTML(deep);
    }
}