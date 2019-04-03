////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Collections.Generic;

namespace HtmlGenerator.dom.set.entities
{
    public class DataTreeItem : DataObjectItem
    {
        /// <summary>
        /// Глубина вложености текущего элемента
        /// </summary>
        public int DeepNode;

        /// <summary>
        /// Дочерние/Вложеные элементы
        /// </summary>
        public List<DataTreeItem> Childs = new List<DataTreeItem>();

        /// <summary>
        /// Получить префикс узла исходя из глубины вложенности элемента/узла
        /// Расчитывается исходя из знаечния [DeepNode]
        /// </summary>
        public string TreePrefix
        {
            get
            {
                string prefix = "";
                for (int i = 0; i < DeepNode; i++)
                    prefix += "-";
                return prefix;
            }
        }
    }
}
