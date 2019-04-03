////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom.set.bootstrap_enum;
using HtmlGenerator.dom.textual;

namespace HtmlGenerator.dom.Bootstrap
{
    /// <summary>
    /// Компонент Bootstrap для формирования небольшого значка
    /// https://getbootstrap.com/docs/4.3/components/badge/
    /// </summary>
    public class Badge : span
    {
        public VisualBootstrapStylesEnum? StyleBadge = null;

        public Badge(string text_badge, VisualBootstrapStylesEnum? style_badge = null)
        {
            tag_custom_name = typeof(span).Name;
            InnerText = text_badge;
            StyleBadge = style_badge;
            css_class = "badge";
        }

        public override string GetHTML(int deep = 0)
        {
            if (!(StyleBadge is null))
                css_class = (css_class + " badge-" + StyleBadge?.ToString("g")).Trim();

            return base.GetHTML(deep);
        }
    }
}
