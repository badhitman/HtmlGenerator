////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.html5;

/// <summary>
/// Перекрыты методы управления вложенными объектами
/// </summary>
public class safe_base_dom_root : base_dom_root
{
    /// <summary>
    /// ЗАПРЕЩЕНО!
    /// В данном объекте нельзя {напрямую/вручную} манипулировать вложенными [dom] элементами.
    /// </summary>
    public override safe_base_dom_root AddDomNode(base_dom_root child)
    {
        throw new NotSupportedException("В данном объекте нельзя {напрямую/вручную} манипулировать вложенными [dom] элементами.");
        //base.Add(child);
    }

    /// <summary>
    /// ЗАПРЕЩЕНО!
    /// В данном объекте нельзя {напрямую/вручную} манипулировать вложенными [dom] элементами.
    /// </summary>
    public override safe_base_dom_root AddRangeDomNode(List<base_dom_root> children)
    {
        throw new NotSupportedException("В данном объекте нельзя {напрямую/вручную} манипулировать вложенными [dom] элементами.");
        //base.AddRange(children);
    }

    /// <summary>
    /// ЗАПРЕЩЕНО!
    /// В данном объекте нельзя {напрямую/вручную} манипулировать вложенными [dom] элементами.
    /// </summary>
    public override base_dom_root ClearNestedDom()
    {
        throw new NotSupportedException("В данном объекте нельзя {напрямую/вручную} манипулировать вложенными [dom] элементами.");
        //base.ClearNestedDom();
    }

    /// <inheritdoc/>
    public override bool TagNameToLower { get; set; } = false;
}