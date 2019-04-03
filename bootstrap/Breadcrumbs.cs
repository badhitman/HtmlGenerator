////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom.html;
using HtmlGenerator.dom.html.areas;
using HtmlGenerator.dom.html.collections;
using HtmlGenerator.dom.html.textual;
using System.Collections.Generic;

namespace HtmlGenerator.dom.bootstrap
{
    /// <summary>
    /// Указывает местоположение текущей страницы в навигационной иерархии, которая автоматически добавляет разделители через CSS.
    /// https://getbootstrap.com/docs/4.3/components/breadcrumb/
    /// </summary>
    public class Breadcrumbs : nav
    {
        public List<BreadcrumbItem> BreadcrumbsCol = new List<BreadcrumbItem>();
        public void AddBreadcrumb(string in_text, string in_href = null) => BreadcrumbsCol.Add(new BreadcrumbItem() { text = in_text, href = in_href });

        /// <summary>
        /// НЕ ИСПОЛЬЗУЙ ЭТО! При формировании HTML(int deep = 0) - этот спсиок пере-заполняется.
        /// Для наполнения тела используется BreadcrumbsCol (например через метод AddBreadcrumb)
        /// </summary>
        public new List<base_dom_root> Childs { get => base.Childs; set => base.Childs = value; }

        /// <summary>
        /// Меняем имя тега на nav
        /// </summary>
        public Breadcrumbs() => tag_custom_name = typeof(nav).Name;

        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();
            ol my_ol = new ol(ol.TypesOL.None) { css_class = "breadcrumb" };

            if (BreadcrumbsCol.Count == 0)
                goto end;
            else
                BreadcrumbsCol[BreadcrumbsCol.Count - 1].href = null;
            li my_li;
            foreach (BreadcrumbItem bi in BreadcrumbsCol)
            {
                my_li = new li() { css_class = "breadcrumb-item" };
                if (string.IsNullOrEmpty(bi.href))
                {
                    my_li.css_class += " active";
                    my_li.SetAttribute("aria-current", "page");
                    my_li.InnerText = bi.text;
                }
                else
                    my_li.Add(new a() { href = bi.href, InnerText = bi.text });

                my_ol.Add(my_li);
            }

            end:

            css_style = "margin-top: 3px;";
            SetAttribute("aria-label", "breadcrumb");
            Childs.Add(my_ol);
            return base.GetHTML(deep);
        }

        public class BreadcrumbItem
        {
            public string text;
            public string href;
        }
    }
}
