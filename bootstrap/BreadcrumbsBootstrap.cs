////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5.collections;
using HtmlGenerator.html5.textual;
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// Указывает местоположение текущей страницы в навигационной иерархии, которая автоматически добавляет разделители через CSS.
/// https://getbootstrap.com/docs/4.3/components/breadcrumb/
/// </summary>
public class BreadcrumbsBootstrap : safe_base_dom_root
{
    /// <inheritdoc/>
    public List<BreadcrumbItemBootstrap> BreadcrumbsCol = [];

    /// <summary>
    /// nav
    /// </summary>
    public override string? tag_custom_name => "nav";

    /// <inheritdoc/>
    public void AddBreadcrumb(string in_text, string? in_href = null) => BreadcrumbsCol.Add(new BreadcrumbItemBootstrap() { text = in_text, href = in_href });

    /// <summary>
    /// НЕ ИСПОЛЬЗУЙ ЭТО! При формировании HTML(int deep = 0) - этот список пере-заполняется.
    /// Для наполнения тела используется BreadcrumbsCol (например через метод AddBreadcrumb)
    /// </summary>
    public new List<base_dom_root>? Childs { get => base.Childs; set => base.Childs = value; }

    /// <inheritdoc/>
    /// <remarks>При вызове этого метода поле Childs очищается и заново заполняется</remarks>
    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        ol my_ol = new(ol.TypesOL.None);
        my_ol.AddCSS("breadcrumb");

        if (BreadcrumbsCol.Count == 0)
            goto end;
        else
            BreadcrumbsCol[^1].href = null;

        li my_li;
        foreach (BreadcrumbItemBootstrap bi in BreadcrumbsCol)
        {
            my_li = new li();
            my_li.AddCSS("breadcrumb-item");

            if (string.IsNullOrEmpty(bi.href))
            {
                my_li.AddCSS("active");
                my_li.SetAttribute("aria-current", "page");
                my_li.InnerText = bi.text;
            }
            else
                my_li.AddDomNode(new a() { href = bi.href, InnerText = bi.text });

            my_ol.AddDomNode(my_li);
        }

    end:

        css_style = "margin-top: 3px;";
        SetAttribute("aria-label", "breadcrumb");
        Childs.Add(my_ol);
        return base.GetHTML(deep);
    }
}