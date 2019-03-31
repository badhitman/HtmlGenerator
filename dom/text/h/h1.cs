////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
///
namespace HtmlGenerator.dom.text
{
    public class h1 : basic_html_dom
    {
        public h1(string h_text)
        {
            inline = true;
            InnerText = h_text;
        }
    }
}
