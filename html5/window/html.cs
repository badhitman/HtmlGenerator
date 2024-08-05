////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.headers;

namespace HtmlGenerator.html5.window;

/// <summary>
/// Тег [html] является контейнером, который заключает в себе все содержимое веб-страницы, включая теги [head] и [body].
/// Открывающий и закрывающий теги [html] в документе необязательны, но хороший стиль диктует непременное их использование.
/// Как правило, тег [html] идет в документе вторым, после определения типа документа (Document Type Definition, DTD), устанавливаемого через элемент [!DOCTYPE].
/// Закрывающий тег [html] должен всегда стоять в документе последним. 
/// </summary>
public class html : base_dom_root
{
    /// <summary>
    /// Элемент [!DOCTYPE] предназначен для указания типа текущего документа — DTD (document type definition, описание типа документа).
    /// Это необходимо, чтобы браузер понимал, как следует интерпретировать текущую веб-страницу, поскольку HTML существует в нескольких версиях, кроме того, имеется XHTML (EXtensible HyperText Markup Language, расширенный язык разметки гипертекста), похожий на HTML, но различающийся с ним по синтаксису.
    /// Чтобы браузер «не путался» и понимал, согласно какому стандарту отображать веб-страницу и необходимо в первой строке кода задавать [!DOCTYPE].
    /// Существует несколько видов [!DOCTYPE], они различаются в зависимости от версии языка, на которого ориентированы.
    /// </summary>
    public enum DOCTYPES
    {
        #region HTML 5
        /// <summary>
        /// Для всех документов.
        /// </summary>
        HTML5, // <!DOCTYPE html> 
        #endregion

        #region HTML 4.01
        /// <summary>
        /// 4.01 - Строгий синтаксис HTML.
        /// </summary>
        HTML41_Strict, // <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

        /// <summary>
        /// 4.01 - Переходный синтаксис HTML.
        /// </summary>
        HTML41_Loose, // <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">

        /// <summary>
        /// 4.01 - В HTML-документе применяются фреймы.
        /// </summary>
        HTML41_Frameset, // <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN" "http://www.w3.org/TR/html4/frameset.dtd">
        #endregion

        #region XHTML 1.0
        /// <summary>
        /// Строгий синтаксис XHTML.
        /// </summary>
        XHTML1_strict, // <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

        /// <summary>
        /// Переходный синтаксис XHTML.
        /// </summary>
        XHTML1_transitional, // <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

        /// <summary>
        /// Документ написан на XHTML и содержит фреймы.
        /// </summary>
        XHTML1_frameset, // <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Frameset//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd">
        #endregion

        #region XHTML 1.1
        /// <inheritdoc/>
        XHTML11 // <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
        #endregion
    }

    /// <summary>
    /// Тип текущего документа — DTD (document type definition, описание типа документа).
    /// </summary>
    public DOCTYPES DOCTYPE = DOCTYPES.HTML5;

    /// <summary>
    /// Указывает файл манифеста, необходимый для создания оффлайнового приложения.
    /// 
    /// Атрибут [manifest] реализует механизм кэширования, который позволяет создавать оффлайновые приложения, т.е. работающие в автономном режиме без непосредственного подключения к Интернету.
    /// При первой загрузке страницы браузер обычно просит сохранить данные для своей работы, а затем уже обращается к ним при необходимости.
    /// 
    /// В качестве значения атрибута [manifest] указывается относительный или абсолютный путь к текстовому файлу, он называется «файл манифеста» или просто «манифест».
    /// Имя и расположение файла может быть любым, но он должен отдаваться сервером с заголовком text/cache-manifest.
    /// Например, для веб-сервера Apache в файле .htaccess расположенным в корне сайта следует прописать такую строку.
    /// AddType text/cache-manifest.cache
    /// 
    /// В этом случае файл манифеста имеет расширение cache. Сам манифест информирует браузер о том, какие ресурсы необходимо сохранить в локальном кэше.Этот список может содержать HTML и CSS-файлы, изображения, скрипты.
    /// </summary>
    public string? manifest;

    /// <summary>
    /// HTML заголовок
    /// </summary>
    public head HeadHtml { get; private set; } = new head();

    /// <summary>
    /// HTML тело
    /// </summary>
    public body BodyHtml { get; private set; } = new body();

    /// <inheritdoc/>
    public html()
    {
        HeadHtml.defTags.Add(new meta() { http_equiv = "content-type", content = "text/html; charset=UTF-8" });
        HeadHtml.defTags.Add(new meta() { charset = "utf-8" });
        HeadHtml.defTags.Add(new meta() { Name_DOM = "viewport", content = "width=device-width, initial-scale=1, maximum-scale=1" });
    }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        ClearNestedDom();

        if (!string.IsNullOrEmpty(manifest))
            SetAttribute("manifest", manifest);

        string doctype;
        switch (DOCTYPE)
        {
            case DOCTYPES.HTML41_Strict:
                doctype = "<!DOCTYPE HTML PUBLIC \" -//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">";
                break;
            case DOCTYPES.HTML41_Loose:
                doctype = "<!DOCTYPE HTML PUBLIC \" -//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">";
                break;
            case DOCTYPES.HTML41_Frameset:
                doctype = "<!DOCTYPE HTML PUBLIC \" -//W3C//DTD HTML 4.01 Frameset//EN\" \"http://www.w3.org/TR/html4/frameset.dtd\">";
                break;
            case DOCTYPES.XHTML1_strict:
                doctype = "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">";
                break;
            case DOCTYPES.XHTML1_transitional:
                doctype = "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
                break;
            case DOCTYPES.XHTML1_frameset:
                doctype = "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.0 Frameset//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd\">";
                break;
            default:
                doctype = "<!DOCTYPE html>";
                break;
        }

        AddDomNode(HeadHtml);
        AddDomNode(BodyHtml);
        return doctype + Environment.NewLine + base.GetHTML(deep);
    }
}