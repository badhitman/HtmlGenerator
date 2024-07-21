﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.tables;

/// <summary>
/// Элемент [tbody] предназначен для хранения одной или нескольких строк таблицы. Это позволяет создавать структурные блоки, 
/// к которым можно применять единое оформление через стили, а также управлять их видом через скрипты.
/// Допускается применять несколько тегов [tbody] внутри контейнера [table]. Доступны и другие виды группировок строк — [tfoot] и [thead], 
/// ни один из них не должен перекрываться с элементом [tbody].
/// </summary>
public class tbody : safe_base_dom_root
{
    /// <summary>
    /// Ширина таблицы. Равна размеру (в колонках) самой "длинной" строки
    /// </summary>
    public int WidthTable
    {
        get
        {
            int result = 0;
            if (Rows is null || Rows.Count == 0)
                return 0;

            Rows.ForEach(r => Math.Max(result, r.Columns.Count));

            return result;
        }
    }

    /// <summary>
    /// Строки таблицы
    /// </summary>
    public List<tr> Rows { get; private set; } = [];

    /// <summary>
    /// Добавить строку в таблицу
    /// </summary>
    /// <param name="td_cols">значения ячеек в строке</param>
    public tbody AddRow(string[] td_cols)
    {
        tr my_tr = new();
        foreach (string s in td_cols)
            my_tr.Columns.Add(new td() { InnerText = s });
        Rows.Add(my_tr);
        return this;
    }

    /// <inheritdoc/>
    /// <remarks>При вызове этого метода поле Childs очищается и заново заполняется</remarks>
    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        Rows.ForEach(x => Childs.Add(x));
        return base.GetHTML(deep);
    }
}