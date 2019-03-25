////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    public class text : basic_html_dom
    {
        public text(string i_html_text)
        {
            inline = true;
            InnerText = i_html_text;
        }

        public override string HTML(int deep = 0)
        {
            ////////////////////////////
            // Вложеные элементы не предусмотрены
            Childs.Clear();
            return base.HTML(deep);
        }
    }
}
