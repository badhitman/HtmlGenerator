////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Collections.Generic;

namespace HtmlGenerator.set
{
    public class OptionItem
    {
        /// <summary>
        /// Значение переменной
        /// </summary>
        public string Value;

        /// <summary>
        /// Подсказка к элементу (всплывающая)
        /// </summary>
        public string Tooltip;

        /// <summary>
        /// Заголовок пункта меню
        /// </summary>
        public string Title;

        /// <summary>
        /// Флаг/признак, что элемент отключён
        /// </summary>
        public bool Disabled = false;

        /// <summary>
        /// Технический параметр для передачи дополнительных данных
        /// </summary>
        public string Tag = "";
        
        /// <summary>
        /// Дочерние элементы
        /// </summary>
        public List<OptionItem> Childs = new List<OptionItem>();
    }
}
