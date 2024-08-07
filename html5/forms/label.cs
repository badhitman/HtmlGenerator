﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.forms;

/// <summary>
/// Тег [label] устанавливает связь между определенной меткой, в качестве которой обычно выступает текст, и элементом формы
/// ([input], [select], [textarea]). Такая связь необходима, чтобы изменять значения элементов формы при нажатии курсором мыши на текст.
/// Кроме того, с помощью [label] можно устанавливать горячие клавиши на клавиатуре и переходить на активный элемент подобно ссылкам.
/// Существует два способа связывания объекта и метки. Первый заключается в использовании идентификатора [id] внутри элемента формы и указании
/// его имени в качестве атрибута [for] тега [label]. При втором способе элемент формы помещается внутрь контейнера [label].
/// </summary>
public class label : base_dom_root
{
    /// <inheritdoc/>
    public string? @for;

    /// <inheritdoc/>
    public label(string i_text, string? i_for)
    {
        Inline = true;
        InnerText = i_text;
        @for = i_for;
    }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        SetAttribute("for", @for);
        return base.GetHTML(deep);
    }
}