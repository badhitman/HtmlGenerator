////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
///
namespace HtmlGenerator.DOM.textual
{
    public class h1 : base_dom_root
    {
        public h1(string h_text)
        {
            inline = true;
            InnerText = h_text;
        }
    }
}
