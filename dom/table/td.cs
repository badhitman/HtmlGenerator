////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.table
{
    /// <summary>
    /// Предназначен для создания одной ячейки таблицы. Тег [td] должен размещаться внутри контейнера [tr],
    /// который в свою очередь располагается внутри тега [table].
    /// </summary>
    public class td : th
    {
        /// <summary>
        /// Устанавливает число ячеек, которые должны быть объединены по горизонтали. Этот атрибут имеет смысл для таблиц, состоящих из нескольких строк
        /// </summary>
        public int colspan = 0;

        public override string GetHTML(int deep = 0)
        {
            if (colspan > 0)
                SetAtribute("colspan", colspan);

            return base.GetHTML(deep);
        }
    }
}
