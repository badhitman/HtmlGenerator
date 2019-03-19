////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Collections.Generic;

namespace HtmlGenerator.set
{
    public class OptionItem
    {
        /// <summary>
        /// Заголовок элемента
        /// </summary>
        public string Title;

        /// <summary>
        /// Флаг того что элемент является группой
        /// </summary>
        public bool IsGroup;

        /// <summary>
        /// Значимые данные контекста html.dom объекта
        /// </summary>
        public string Value;

        /// <summary>
        /// Подсказка к элементу
        /// </summary>
        public string Tooltip;

        /// <summary>
        /// Глубина вложености элемента
        /// </summary>
        public int DeepNode;

        /// <summary>
        /// Добавочные CSS слассы для html.dom объекта
        /// </summary>
        //public string CSS;

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
