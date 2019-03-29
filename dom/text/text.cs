////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.dom.text
{
    public class text : basic_html_dom
    {
        public text(string i_html_text)
        {
            inline = true;
            InnerText = i_html_text;
        }

        public override string GetHTML(int deep = 0)
        {
            ////////////////////////////
            // Вложеные элементы не предусмотрены
            Childs.Clear();
            return base.GetHTML(deep);
        }
    }
}
