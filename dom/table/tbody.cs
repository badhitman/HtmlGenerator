////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using System;
using System.Collections.Generic;

namespace HtmlGenerator.dom.table
{
    /// <summary>
    /// Элемент [tbody] предназначен для хранения одной или нескольких строк таблицы. Это позволяет создавать структурные блоки, 
    /// к которым можно применять единое оформление через стили, а также управлять их видом через скрипты.
    /// Допускается применять несколько тегов [tbody] внутри контейнера [table]. Доступны и другие виды группировок строк — [tfoot] и [thead], 
    /// ни один из них не должен перекрываться с элементом [tbody].
    /// </summary>
    public class tbody : basic_html_dom
    {
        /// <summary>
        /// Ширина таблицы. Равна размеру в колонках самой длинной строки
        /// </summary>
        public int WidthTable
        {
            get
            {
                int result = 0;
                if (Rows is null || Rows.Count == 0)
                    return 0;

                foreach (tr item in Rows)
                    result = Math.Max(result, item.Columns.Count);

                return result;
            }
        }
        public List<tr> Rows { get; private set; } = new List<tr>();
        public void AddRow(string[] td_cols)
        {
            tr my_tr = new tr();
            foreach (string s in td_cols)
                my_tr.AddColumn(s);
        }

        public override string HTML(int deep = 0)
        {
            Childs.Clear();
            Rows.ForEach(x => Childs.Add(x));
            return base.HTML(deep);
        }
    }
}