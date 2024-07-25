////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.mud;

/// <summary>
/// MudSelect (for Enum)
/// </summary>
public class MudSelectProvider : MudBaseFieldLowProvider
{
    /// <summary>
    /// Options
    /// </summary>
    public IEnumerable<(string id, string name)>? Options { get; set; }

    /// <inheritdoc/>
    public override bool Inline => false;

    /// <inheritdoc/>
    /// <remarks>MudSelect</remarks>
    public override string tag_custom_name => "MudSelect";

    /// <summary>
    /// Имя типа данных (перечисление)
    /// </summary>
    public required string TypeNameEnum { get; set; }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        base.GetHTML();
        Childs = [];

        SetAttribute("T", "EntryModel");

        if (Options?.Any() == true)
            foreach ((string id, string name) in Options)
                Childs.Add(new MudSelectItemProvider() { Value = id, Title = name });

        return base.GetHTML(deep);
    }
}