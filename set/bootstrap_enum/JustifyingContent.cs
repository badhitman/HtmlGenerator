////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.set.bootstrap
{
    public enum JustifyingContent
    {
        /// <summary>
        /// Вначале
        /// (кокнретное поведение зависит от: flex-direction и реверса)
        /// </summary>
        justify_content_start,

        /// <summary>
        /// В конце
        /// (кокнретное поведение зависит от: flex-direction и реверса)
        /// </summary>
        justify_content_end,

        /// <summary>
        /// В центре
        /// </summary>
        justify_content_center,

        /// <summary>
        /// Заполнить всю ширину
        /// </summary>
        justify_content_between,

        /// <summary>
        /// Распределить равномерно по оси
        /// </summary>
        justify_content_around
    }
}
