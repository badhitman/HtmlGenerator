////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace HtmlGenerator.html5
{
    /// <summary>
    /// Перекрыты методы добавления вложеных объектов
    /// </summary>
    public class safe_base_dom_root : base_dom_root
    {
        /// <summary>
        /// ЗАПРЕЩЕНО!
        /// В данный объект нельзя {напрямую/вручную} добавлять вложеные [dom] объекты.
        /// </summary>
        public override void Add(base_dom_root child)
        {
            //base.Add(child);
            throw new NotImplementedException();
        }

        /// <summary>
        /// ЗАПРЕЩЕНО!
        /// В данный объект нельзя {напрямую/вручную} добавлять вложеные [dom] объекты
        /// </summary>
        public override void AddRange(List<base_dom_root> childs)
        {
            //base.AddRange(childs);
            throw new NotImplementedException();
        }
    }
}
