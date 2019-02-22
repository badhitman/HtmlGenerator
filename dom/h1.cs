////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////
///
namespace HtmlGenerator.dom
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
