////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using System.Collections.Generic;

namespace HtmlGenerator.dom.html.tables
{
    /// <summary>
    /// Элемент [thead] предназначен для хранения одной или нескольких строк, которые представлены вверху таблицы. 
    /// Допустимо использовать не более одного элемента [thead] в пределах одной таблицы, и он должен идти в исходном коде сразу после тега [table].
    /// </summary>
    public class thead : base_dom_root
    {
        /// <summary>
        /// Колонки заголовочной части
        /// </summary>
        public virtual List<th> Columns { get; private set; } = new List<th>();

        /// <summary>
        /// Добавить колонку в заголовочную часть таблицы
        /// </summary>
        /// <param name="text">Текст заголовка колонки</param>
        /// <param name="unique">Проверять или нет - уникальность заголовков таблицы</param>
        public void AddColumn(string text, bool unique = false)
        {
            if (!unique || !Columns.Exists(x => x.InnerText.ToLower() == text.ToLower()))
                Columns.Add(new th() { InnerText = text });
        }

        /// <summary>
        /// Пакетное добавление заголовков в таблицу
        /// </summary>
        /// <param name="text">Пакет заголовков</param>
        public void AddColumn(string[] text, bool unique = false)
        {
            foreach (string s in text)
                AddColumn(s, unique);
        }

        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();
            tr my_tr = new tr();
            Columns.ForEach(x => my_tr.Columns.Add(x));
            Childs.Add(my_tr);
            return base.GetHTML(deep);
        }
    }
}
