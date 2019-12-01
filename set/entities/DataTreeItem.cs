////////////////////////////////////////////////
// https://github.com/badhitman 
////////////////////////////////////////////////
using System.Collections.Generic;

namespace HtmlGenerator.set.entities
{
    public class DataTreeItem : DataObjectItem
    {
        /// <summary>
        /// Дочерние/Вложеные элементы
        /// </summary>
        public List<DataTreeItem> Childs = new List<DataTreeItem>();
    }
}
