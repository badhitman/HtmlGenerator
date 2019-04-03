////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.dom.set.entities
{
    public class DataObjectItem : DataParticleItem
    {
        /// <summary>
        /// Подсказка для элемента
        /// </summary>
        public string Tooltip;

        /// <summary>
        /// Флаг/признак, что элемент отключён
        /// </summary>
        public bool Disabled = false;

        /// <summary>
        /// Технический параметр для передачи дополнительных данных
        /// </summary>
        public string Tag = "";

    }
}
