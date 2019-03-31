////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Collections.Generic;

namespace HtmlGenerator.set
{
    public class OptionItem
    {
        /// <summary>
        /// Заголовок/Наименование элемента
        /// </summary>
        public string Title;

        /// <summary>
        /// Флаг того что элемент является группой
        /// </summary>
        public bool IsGroup;

        /// <summary>
        /// Нагрузка (значимые данные контекста) html.dom объекта
        /// </summary>
        public string Value;

        /// <summary>
        /// Подсказка для элемента
        /// </summary>
        public string Tooltip;

        /// <summary>
        /// Глубина вложености текущего элемента
        /// </summary>
        public int DeepNode;

        /// <summary>
        /// Флаг/признак, что элемент отключён
        /// </summary>
        public bool Disabled = false;

        /// <summary>
        /// Технический параметр для передачи дополнительных данных
        /// </summary>
        public string Tag = "";

        /// <summary>
        /// Дочерние/Вложеные элементы
        /// </summary>
        public List<OptionItem> Childs = new List<OptionItem>();

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
