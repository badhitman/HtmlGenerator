////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.html5.textual;

/// <summary>
/// H1
/// </summary>
public class h1 : base_dom_root
{
    /// <inheritdoc/>
    public h1(string h_text)
    {
        Inline = true;
        InnerText = h_text;
    }
}