////////////////////////////////////////////////
// https://github.com/badhitman 
////////////////////////////////////////////////
using HtmlGenerator.html5;
using HtmlGenerator.html5.textual;
using HtmlGenerator.set.bootstrap;

namespace HtmlGenerator.bootstrap
{
    /// <summary>
    /// Компонент Bootstrap для формирования небольшого значка
    /// https://getbootstrap.com/docs/4.3/components/badge/
    /// </summary>
    public class Badge : safe_base_dom_root
    {
        public VisualBootstrapStylesEnum? StyleBadge = null;

        public Badge(string text_badge, VisualBootstrapStylesEnum? style_badge = null)
        {
            tag_custom_name = typeof(span).Name;
            InnerText = text_badge;
            StyleBadge = style_badge;
            AddCSS("badge");
        }

        public override string GetHTML(int deep = 0)
        {
            if (!(StyleBadge is null))
                AddCSS("badge-" + StyleBadge?.ToString("g"));

            return base.GetHTML(deep);
        }
    }
}
