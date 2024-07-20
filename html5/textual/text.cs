////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.html5.textual;

public class text : base_dom_root
{
    public text(string i_html_text)
    {
        inline = true;
        InnerText = i_html_text;
    }

    public override string GetHTML(int deep = 0)
    {
        ////////////////////////////
        // Вложенные элементы не предусмотрены
        Childs?.Clear();
        return base.GetHTML(deep);
    }
}