////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    /// <summary>
    ///  Тег "script" предназначен для описания скриптов, может содержать ссылку на программу или ее текст на определенном языке.
    ///  Скрипты могут располагаться во внешнем файле и связываться с любым HTML-документом. Такой подход позволяет использовать одни и те же общие
    ///  функции на многих веб-страницах и ускоряет их загрузку, т.к. внешний файл кэшируется при первой загрузке, и скрипт вызывается быстрее
    ///  при последующих вызовах.
    /// "script" может располагаться в заголовке или теле HTML-документа в неограниченном количестве.В большинстве случаев местоположение скрипта 
    /// никак не сказывается на работу программы. Однако скрипты, которые должны выполняться в первую очередь, обычно помещают в заголовок документа.
    /// </summary>
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
