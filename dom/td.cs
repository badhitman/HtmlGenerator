////////////////////////////////////////////////
// © https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace DataViewHtml.dom
{
    /// <summary>
    /// Предназначен для создания одной ячейки таблицы. Тег "td" должен размещаться внутри контейнера "tr",
    /// который в свою очередь располагается внутри тега "table".
    /// </summary>
    public class td : basic_html_dom
    {
        public class td_set : th.th_set
        {
            /// <summary>
            /// Позволяет связать ячейки таблицы с заголовками. Этот атрибут предназначен для повышения доступности таблицы пользователям речевых браузеров,
            /// в обычных браузерах результат применения атрибута headers не заметен.
            /// Для связывания ячеек между собой одной ячейке в теге "td" или "th" задается атрибут id, а второй ячейке — атрибут headers со значением,
            /// совпадающим со значением id.
            /// </summary>
            public string headers = null;
        }

        public td_set set;

        public td(td_set in_set = null)
        {
            set = in_set;
        }

        public override string HTML(int deep = 0)
        {
            if (!(set is null))
            {
                if (set.colspan > 0)
                    SetAtribute("colspan", set.colspan.ToString());

                if (set.rowspan > 0)
                    SetAtribute("rowspan", set.rowspan.ToString());

                if (!string.IsNullOrEmpty(set.headers))
                    SetAtribute("headers", set.headers);
            }
            return base.HTML(deep);
        }
    }
}
