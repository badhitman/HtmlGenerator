////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using HtmlGenerator.set;
using System.Collections.Generic;

namespace HtmlGenerator.DOM.head
{
    /// <summary>
    ///  Устанавливает связь с внешним документом вроде файла со стилями или со шрифтами. В отличие от тега [a], тег [link] размещается всегда внутри
    ///  контейнера [head] и не создает ссылку.
    /// </summary>
    public class link : base_dom_root
    {
        /// <summary>
        ///  Путь к файлу, на который делается ссылка (URL).
        /// </summary>
        public string href = null;

        /// <summary>
        /// Атрибут [rel] определяет отношения между текущим документом и файлом, на который делается ссылка.
        /// Это необходимо, чтобы браузер знал, как использовать подключаемый документ. 
        /// </summary>
        public RelationsEnum? rel = null;

        /// <summary>
        /// Определяет устройство, для которого следует применять стилевое оформление.
        /// Это позволяет сделать разный стиль для отображения документа на экране монитора и при его печати.
        /// Допускается писать несколько значений через запятую. 
        /// </summary>
        public List<MediaDevicesEnum> media = new List<MediaDevicesEnum>() { MediaDevicesEnum.all };

        /// <summary>
        /// Сообщает браузеру, какой MIME-тип данных используется для внешнего документа.
        /// Как правило, применяется для того, чтобы указать, что подключаемый файл содержит CSS. 
        /// </summary>
        public string mimetype = null;

        public link(Dictionary<string, string> in_custom_atributes = null)
        {
            SetAttribute(in_custom_atributes);
            inline = true;
            need_end_tag = false;
        }

        public override string GetHTML(int deep = 0)
        {
            SetAttribute("media", media, ", ");
            
            if (!string.IsNullOrEmpty(href))
            {
                SetAttribute("href", href);

                if (!string.IsNullOrEmpty(mimetype))
                    SetAttribute("type", mimetype);

                if (rel == RelationsEnum.stylesheet || rel == RelationsEnum.alternate)
                    SetAttribute("rel", rel?.ToString("g"));
            }

            if (rel == RelationsEnum.icon)
                SetAttribute("rel", "shortcut icon");

            return base.GetHTML(deep);
        }
    }
}
