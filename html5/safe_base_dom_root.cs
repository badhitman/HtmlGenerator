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
    public override void AddDomNode(base_dom_root child)
    {
        throw new NotImplementedException();
        //base.Add(child);
    }

    /// <summary>
    /// ЗАПРЕЩЕНО!
    /// В данном объекте нельзя {напрямую/вручную} манипулировать вложенными [dom] элементами.
    /// </summary>
    public override void AddRangeDomNode(List<base_dom_root> children)
    {
        throw new NotImplementedException();
        //base.AddRange(children);
    }

    /// <summary>
    /// ЗАПРЕЩЕНО!
    /// В данном объекте нельзя {напрямую/вручную} манипулировать вложенными [dom] элементами.
    /// </summary>
    public override void ClearNestedDom()
    {
        throw new NotImplementedException();
        //base.ClearNestedDom();
    }
}