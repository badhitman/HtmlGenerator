////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
///
namespace HtmlGenerator.dom.text
{
    public class h1 : html_dom_root
    {
        public h1(string h_text)
        {
            inline = true;
            InnerText = h_text;
        }
    }
}
