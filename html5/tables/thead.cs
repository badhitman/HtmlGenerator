////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.tables;

/// <summary>
/// Элемент [thead] предназначен для хранения одной или нескольких строк, которые представлены вверху таблицы. 
/// Допустимо использовать не более одного элемента [thead] в пределах одной таблицы, и он должен идти в исходном коде сразу после тега [table].
/// </summary>
public class thead : safe_base_dom_root
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
    public thead AddColumn(string text, bool unique = false)
    {
        if (!unique || !Columns.Exists(x => x.InnerText?.ToLower() == text.ToLower()))
            Columns.Add(new th() { InnerText = text });

        return this;
    }

    /// <summary>
    /// Пакетное добавление заголовков в таблицу
    /// </summary>
    public void AddColumn(string[] text, bool unique = false)
    {
        foreach (string s in text)
            AddColumn(s, unique);
    }

    /// <inheritdoc/>
    /// <remarks>При вызове этого метода поле Childs очищается и заново заполняется</remarks>
    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        tr my_tr = new();
        Columns.ForEach(x => my_tr.Columns.Add(x));
        Childs.Add(my_tr);
        return base.GetHTML(deep);
    }
}