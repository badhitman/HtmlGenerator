////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.extended;

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
    /// <inheritdoc/>
    public enum MimeTypes 
    { 
        /// <summary>
        /// JavaScript
        /// </summary>
        JavaScript,

        /// <summary>
        /// VBScript
        /// </summary>
        VBScript 
    }

    /// <summary>
    ///  Атрибут [defer] откладывает выполнение скрипта до тех пор, пока вся страница не будет загружена полностью. 
    /// </summary>
    public bool defer = false;
    
    /// <inheritdoc/>
    public string? src;
    
    /// <inheritdoc/>
    public MimeTypes mimeType = MimeTypes.JavaScript;

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        if (defer)
            SetAttribute("defer", null);

        SetAttribute("type", "text/" + mimeType.ToString("g").ToLower());

        if (!string.IsNullOrEmpty(src))
            SetAttribute("src", src);

        return base.GetHTML(deep);
    }
}