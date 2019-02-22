////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Тег "th" предназначен для создания одной ячейки таблицы, которая обозначается как заголовочная. Текст в такой ячейке отображается 
    /// браузером обычно жирным шрифтом и выравнивается по центру. Тег "th" должен размещаться внутри контейнера "tr", который в свою очередь располагается 
    /// внутри тега "table".
    /// </summary>
    public class th : basic_html_dom
    {
        public class th_set
        {
            /// <summary>
            /// Устанавливает число ячеек, которые должны быть объединены по горизонтали. Этот атрибут имеет смысл для таблиц, состоящих из нескольких колонок.
            /// </summary>
            public int colspan = 0;

            /// <summary>
            /// Устанавливает число ячеек, которые должны быть объединены по вертикали. Этот атрибут имеет смысл для таблиц, состоящих из нескольких строк.
            /// </summary>
            public int rowspan = 0;
        }
        public th_set set;
        public th(th_set in_set = null)
        {
            set = in_set is null ? new th_set() : in_set;
        }

        public override string HTML(int deep = 0)
        {
            if (!(set is null))
            {
                if (set.colspan > 0)
                    SetAtribute("colspan", set.colspan.ToString());

                if (set.rowspan > 0)
                    SetAtribute("rowspan", set.rowspan.ToString());
            }
            return base.HTML(deep);
        }
    }
}
