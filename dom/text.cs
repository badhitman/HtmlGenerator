////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    public class text : basic_html_dom
    {
        public text(string i_html_text)
        {
            inline = true;
            inner_html = i_html_text;
        }
    }
}
