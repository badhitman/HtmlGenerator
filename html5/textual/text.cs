////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.html5.textual;

/// <summary>
/// text
/// </summary>
public class text : base_dom_root
{
    /// <inheritdoc/>
    public text(string i_html_text)
    {
        inline = true;
        InnerText = i_html_text;
    }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        ////////////////////////////
        // Вложенные элементы не предусмотрены
        Childs?.Clear();
        return base.GetHTML(deep);
    }
}