////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.DOM.table
{
    /// <summary>
    /// Элемент [table] служит контейнером для элементов, определяющих содержимое таблицы. Любая таблица состоит из строк и ячеек, 
    /// которые задаются с помощью тегов [tr] и [td]. Внутри [table] допустимо использовать следующие элементы: [caption], [col], 
    /// [colgroup], [tbody], [td], [tfoot], [th], [thead] и [tr].
    /// Таблицы с невидимой границей долгое время использовались для верстки веб-страниц, позволяя разделять документ на модульные блоки.
    /// Подобный способ применения таблиц нашел воплощение на многих сайтах, пока ему на смену не пришел более современный способ верстки с помощью слоев.
    /// </summary>
    public class table : html_dom_root
    {
        /// <summary>
        /// Заголовок таблицы с указанием заголовоков колонок
        /// </summary>
        public thead Thead { get; private set; } = new thead();

        /// <summary>
        /// Тело таблицы (без заголовочной части)
        /// </summary>
        public tbody Tbody { get; private set; } = new tbody();

        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();
            Childs.Add(Thead);
            Childs.Add(Tbody);
            return base.GetHTML(deep);
        }
    }
}
