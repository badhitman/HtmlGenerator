////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.textual;

/// <summary>
///  Устанавливает жирное начертание шрифта. Допустимо использовать этот тег совместно с другими тегами, которые определяют начертание текста.
/// </summary>
public class b : base_dom_root
{
    /// <inheritdoc/>
    public b()
    {
        Inline = true;
    }
}