////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using System.Collections.Generic;

namespace HtmlGenerator.DOM.table
{
    /// <summary>
    /// Тег [tr] служит контейнером для создания строки таблицы. Каждая ячейка в пределах такой строки может задаваться с помощью тега [th] или [td].
    /// </summary>
    public class tr : thead
    {
        public new List<td> Columns
        {
            get
            {
                List<td> cols = new List<td>();
                base.Columns.ForEach(x => cols.Add((td)x));
                return cols;
            }
        }
    }
}
