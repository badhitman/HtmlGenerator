////////////////////////////////////////////////
// © https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
namespace DataViewHtml.dom
{
    public class script : basic_html_dom
    {
        public enum MimeTypes { JavaScript, VBScript }
        public class script_set
        {
            public string src;
            public MimeTypes mimeType = MimeTypes.JavaScript;
        }
        public script_set set;
        public script(script_set in_set)
        {
            set = in_set;
            
        }

        public override string HTML(int deep = 0)
        {
            SetAtribute("type", "text/" + set.mimeType.ToString("g").ToLower());

            if (!string.IsNullOrEmpty(set.src))
                SetAtribute("src", set.src);

            return base.HTML(deep);
        }
    }
}
