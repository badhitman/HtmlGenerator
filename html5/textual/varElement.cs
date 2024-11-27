////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.textual;

/// <summary>
/// Тег [var] используется для выделения переменных компьютерных программ.
/// Браузеры обычно помечают текст в контейнере [var] курсивным начертанием. 
/// </summary>
public class varElement : base_dom_root
{
    /// <inheritdoc/>
    public override string? tag_custom_name { get => "var";  }
}