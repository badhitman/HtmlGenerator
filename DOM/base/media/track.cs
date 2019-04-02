////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using HtmlGenerator.set;

namespace HtmlGenerator.DOM.media
{
    /// <summary>
    /// Позволяет авторам указать текстовую дорожку для медийных элементов [audio] и [video].
    /// Такая дорожка обычно содержит субтитры на разных языках, комментарии, заголовки и др.
    /// </summary>
    public class track : base_dom_root
    {
        /// <summary>
        /// Указывает тип дорожки
        /// </summary>
        public TrackKindsEnum? kind = null;

        /// <summary>
        /// Путь к файлу с дорожкой.
        /// </summary>
        public string src;

        /// <summary>
        /// Язык дорожки.
        /// </summary>
        public LanguageCodesEnum? srclang = null;

        /// <summary>
        /// Отображаемое название дорожки. Если этот атрибут не указан, браузер станет использовать значение, которое применяется у него по умолчанию, например «untitled1».
        /// </summary>
        public string label;

        /// <summary>
        /// Наличие этого атрибута указывает, что данная дорожка предпочтительна и должна быть выбрана по умолчанию.
        /// Только одна дорожка может иметь атрибут [default].
        /// </summary>
        public bool @default;

        public track() => need_end_tag = false;

        public override string GetHTML(int deep = 0)
        {
            if (!(kind is null))
                SetAttribute("kind", kind?.ToString("g"));

            if (!string.IsNullOrEmpty(src))
                SetAttribute("src", src);

            if (!(srclang is null))
                SetAttribute("srclang", srclang?.ToString("g"));

            if (!string.IsNullOrEmpty(label))
                SetAttribute("label", label);

            if(@default)
                SetAttribute("default", null);

            return base.GetHTML(deep);
        }
    }
}
