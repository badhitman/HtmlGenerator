////////////////////////////////////////////////
// https://github.com/badhitman
////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace HtmlGenerator.html5
{
    /// <summary>
    /// Перекрыты методы управления вложеными объектами
    /// </summary>
    public class safe_base_dom_root : base_dom_root
    {
        /// <summary>
        /// ЗАПРЕЩЕНО!
        /// В данном объекте нельзя {напрямую/вручную} манипулировать вложеными [dom] элементами.
        /// </summary>
        public override void AddDomNode(base_dom_root child)
        {
            throw new NotImplementedException();
            //base.Add(child);
        }

        /// <summary>
        /// ЗАПРЕЩЕНО!
        /// В данном объекте нельзя {напрямую/вручную} манипулировать вложеными [dom] элементами.
        /// </summary>
        public override void AddRangeDomNode(List<base_dom_root> childs)
        {
            throw new NotImplementedException();
            //base.AddRange(childs);
        }

        /// <summary>
        /// ЗАПРЕЩЕНО!
        /// В данном объекте нельзя {напрямую/вручную} манипулировать вложеными [dom] элементами.
        /// </summary>
        public override void ClearNestedDom()
        {
            throw new NotImplementedException();
            //base.ClearNestedDom();
        }
    }
}
