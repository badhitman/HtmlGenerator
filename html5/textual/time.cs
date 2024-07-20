////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.textual;

/// <summary>
/// Помечает текст внутри тега [time] как дата, время или оба значения.
/// Может указываться непосредственно внутри контейнера [time], либо задаваться через атрибут [datetime].
/// </summary>
public class time : base_dom_root
{
    /// <summary>
    /// Задает дату, время или оба значения для текста.
    /// Устанавливает дату, время или оба значения для текста. Содержимое атрибута напрямую в браузере не отображается.
    /// </summary>
    public DateTime datetime = DateTime.MinValue;

    public override string GetHTML(int deep = 0)
    {
        if (datetime > DateTime.MinValue)
            SetAttribute("datetime", datetime.ToString("yyyy-MM-dd HH:mm:ss"));

        return base.GetHTML(deep);
    }
}