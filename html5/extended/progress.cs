////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.extended;

/// <summary>
/// Используется для отображения прогресса завершенности задачи. Изменение значения происходит через JavaScript.
/// </summary>
public class progress : base_dom_root
{
    /// <summary>
    /// Текущее значение прогресса.
    /// </summary>
    public int value = 0;

    /// <summary>
    /// Максимальное значение прогресса
    /// </summary>
    public int max = 100;

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        SetAttribute("value", value);
        SetAttribute("max", max);

        return base.GetHTML(deep);
    }
}