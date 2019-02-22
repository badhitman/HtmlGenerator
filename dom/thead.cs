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
        tr my_tr = new tr();
        List<th> Headers = new List<th>();

        public void SetTableHeader(string text_header, bool unique = true)
        {
            if (!unique || Headers.Exists(x => x.InnerText.ToLower() == text_header.ToLower()))
                Headers.Add(new th() { InnerText = text_header });
        }

        public void SetTableHeader(string[] text_headers, bool unique = true)
        {
            foreach (string s in text_headers)
                SetTableHeader(s, unique);
        }

        public override string HTML(int deep = 0)
        {
            if (Headers.Count > 0)
            {
                tr my_tr = new tr();
                Headers.ForEach(x=> my_tr.Childs.Add(x));
                Childs.Add(my_tr);
            }
            return base.HTML(deep);
        }
    }
}
