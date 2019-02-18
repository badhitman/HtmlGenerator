////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////
///
namespace DataViewHtml.dom
{
    public class h1 : basic_html_dom
    {
        public h1(string h_text)
        {
            inline = true;
            inner_html = h_text;
        }
    }
}
