////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

namespace HtmlGenerator.set.bootstrap;

/// <summary>
/// Justifying content mode`s enum
/// </summary>
public enum JustifyingContentModesEnum
{
    /// <summary>
    /// Вначале
    /// (конкретное поведение зависит от: flex-direction и реверса)
    /// </summary>
    justify_content_start,

    /// <summary>
    /// В конце
    /// (конкретное поведение зависит от: flex-direction и реверса)
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