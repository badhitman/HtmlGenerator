////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using System.Collections.Generic;

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Элемент "thead" предназначен для хранения одной или нескольких строк, которые представлены вверху таблицы. 
    /// Допустимо использовать не более одного элемента "thead" в пределах одной таблицы, и он должен идти в исходном коде сразу после тега "table".
    /// </summary>
    public class thead : basic_html_dom
    {
        public virtual List<th> Columns { get; private set; } = new List<th>();

        public void AddColumn(string text, bool unique = false)
        {
            if (!unique || !Columns.Exists(x => x.InnerText.ToLower() == text.ToLower()))
                Columns.Add(new th() { InnerText = text });
        }

        public void AddColumn(string[] text, bool unique = false)
        {
            foreach (string s in text)
                AddColumn(s, unique);
        }

        public override string HTML(int deep = 0)
        {
            Childs.Clear();
            tr my_tr = new tr();
            Columns.ForEach(x => my_tr.Childs.Add(x));
            Childs.Add(my_tr);
            return base.HTML(deep);
        }
    }
}
