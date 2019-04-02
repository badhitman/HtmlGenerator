////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.DOM.extended
{
    /// <summary>
    ///  Тег [script] предназначен для описания скриптов, может содержать ссылку на программу или ее текст на определенном языке.
    ///  Скрипты могут располагаться во внешнем файле и связываться с любым HTML-документом. Такой подход позволяет использовать одни и те же общие
    ///  функции на многих веб-страницах и ускоряет их загрузку, т.к. внешний файл кэшируется при первой загрузке, и скрипт вызывается быстрее
    ///  при последующих вызовах.
    /// [script] может располагаться в заголовке или теле HTML-документа в неограниченном количестве. В большинстве случаев местоположение скрипта 
    /// никак не сказывается на работу программы. Однако скрипты, которые должны выполняться в первую очередь, обычно помещают в заголовок документа.
    /// </summary>
    public class script : base_dom_root
    {
        public enum MimeTypes { JavaScript, VBScript }

        /// <summary>
        ///  Атрибут [defer] откладывает выполнение скрипта до тех пор, пока вся страница не будет загружена полностью. 
        /// </summary>
        public bool defer = false;
        public string src;
        public MimeTypes mimeType = MimeTypes.JavaScript;

        public override string GetHTML(int deep = 0)
        {
            if (defer)
                SetAtribute("defer", null);

            SetAtribute("type", "text/" + mimeType.ToString("g").ToLower());

            if (!string.IsNullOrEmpty(src))
                SetAtribute("src", src);

            return base.GetHTML(deep);
        }
    }
}
