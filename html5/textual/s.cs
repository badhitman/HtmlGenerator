////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.textual;

/// <summary>
/// Тег [s] отображает текст как перечеркнутый. Этот тег аналогичен тегу [strike], но в отличие от него имеет сокращенную форму записи подобно тегам [b], [i] и [u].
/// Взамен этого тега рекомендуется использовать стили. 
/// </summary>
public class s : base_dom_root
{
    /// <inheritdoc/>
    public s()
    {
        Inline = true;
    }
}