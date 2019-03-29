////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.details
{
    /// <summary>
    /// Элемент [details] (от англ. details — подробности, данные) используется для хранения информации, которую можно скрыть или показать по требованию пользователя.
    /// По умолчанию содержимое элемента не отображается, для изменения статуса применяется атрибут [open].
    /// 
    /// Исходно содержимое [details] скрыто, вместо него выводится текст «Подробнее», щелчок по которому прячет или показывает содержимое элемента.
    /// </summary>
    public class details : basic_html_dom
    {
        public summary Summary = null;

        /// <summary>
        /// Признак - показывать информацию внутри элемента или нет
        /// </summary>
        public bool open = false;

        public override string GetHTML(int deep = 0)
        {
            if (!(Summary is null))
                Childs.Insert(0, Summary);

            if (open)
                SetAtribute("open", null);

            return base.GetHTML(deep);
        }
    }
}
