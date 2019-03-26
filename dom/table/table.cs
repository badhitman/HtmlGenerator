////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.table
{
    /// <summary>
    /// Элемент "table" служит контейнером для элементов, определяющих содержимое таблицы. Любая таблица состоит из строк и ячеек, 
    /// которые задаются с помощью тегов "tr" и "td". Внутри "table" допустимо использовать следующие элементы: "caption", "col", 
    /// "colgroup", "tbody", "td", "tfoot", "th", "thead" и "tr".
    /// Таблицы с невидимой границей долгое время использовались для верстки веб-страниц, позволяя разделять документ на модульные блоки.
    /// Подобный способ применения таблиц нашел воплощение на многих сайтах, пока ему на смену не пришел более современный способ верстки с помощью слоев.
    /// </summary>
    public class table : basic_html_dom
    {
        public thead Thead { get; private set; } = new thead();
        public tbody Tbody { get; private set; } = new tbody();
        public override string HTML(int deep = 0)
        {
            Childs.Clear();
            Childs.Add(Thead);
            Childs.Add(Tbody);
            return base.HTML(deep);
        }
    }
}
