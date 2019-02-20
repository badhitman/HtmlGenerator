////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    public class img : basic_html_dom
    {
        public class img_set
        {
            public string src;
            public string alt = null;
        }
        public img_set set;
        public img(img_set in_set)
        {
            set = in_set;
            inline = true;

        }
        public override string HTML(int deep = 0)
        {
            SetAtribute("src", set.src);
            if (!string.IsNullOrEmpty(set.alt))
                SetAtribute("alt", set.alt);

            return base.HTML(deep);
        }
    }
}
