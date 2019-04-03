////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.set
{
    /// <summary>
    ///  Определяет форму «горячей области», координаты которой задаются с помощью атрибута [coords]. 
    /// </summary>
    public enum ShapesEnum
    {
        /// <summary>
        /// Область в виде окружности.
        /// </summary>
        circle,

        /// <summary>
        /// Указывает всю область.
        /// </summary>
        @default,

        /// <summary>
        /// Область в виде полигона (многоугольника).
        /// </summary>
        poly,

        /// <summary>
        /// Прямоугольная область.
        /// </summary>
        rect
    }
}
