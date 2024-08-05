////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

using HtmlGenerator.html5;
using HtmlGenerator.html5.textual;
using HtmlGenerator.set.bootstrap;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// Компонент Bootstrap для формирования небольшого значка
/// https://getbootstrap.com/docs/4.3/components/badge/
/// </summary>
public class Badge : safe_base_dom_root
{
    /// <inheritdoc/>
    public VisualBootstrapStylesEnum? StyleBadge = null;

    /// <summary>
    /// span
    /// </summary>
    public override string tag_custom_name => "span";

    /// <summary>
    /// Компонент Bootstrap для формирования небольшого значка
    /// https://getbootstrap.com/docs/4.3/components/badge/
    /// </summary>
    public Badge(string text_badge, VisualBootstrapStylesEnum? style_badge = null)
    {
        InnerText = text_badge;
        StyleBadge = style_badge;
        AddCSS("badge");
    }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        if (StyleBadge is not null)
            AddCSS("badge-" + StyleBadge?.ToString("g"));

        return base.GetHTML(deep);
    }
}