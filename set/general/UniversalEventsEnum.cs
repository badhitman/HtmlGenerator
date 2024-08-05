////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.set;

/// <summary>
/// События HTML.dom
/// </summary>
public enum UniversalEventsEnum
{
    /// <summary>
    /// Потеря фокуса.
    /// </summary>
    onblur,

    /// <summary>
    /// Изменение значения элемента формы.
    /// </summary>
    onchange,

    /// <summary>
    /// Щелчок левой кнопкой мыши на элементе.
    /// </summary>
    onclick,

    /// <summary>
    /// Двойной щелчок левой кнопкой мыши на элементе.
    /// </summary>
    ondblclick,

    /// <summary>
    /// Получение фокуса
    /// </summary>
    onfocus,

    /// <summary>
    /// Клавиша нажата, но не отпущена.
    /// </summary>
    onkeydown,

    /// <summary>
    /// Клавиша нажата и отпущена.
    /// </summary>
    onkeypress,

    /// <summary>
    /// Клавиша отпущена.
    /// </summary>
    onkeyup,

    /// <summary>
    /// Документ загружен.
    /// </summary>
    onload,

    /// <summary>
    /// Нажата левая кнопка мыши.
    /// </summary>
    onmousedown,

    /// <summary>
    /// Перемещение курсора мыши.
    /// </summary>
    onmousemove,

    /// <summary>
    /// Курсор покидает элемент.
    /// </summary>
    onmouseout,

    /// <summary>
    /// Курсор наводится на элемент.
    /// </summary>
    onmouseover,

    /// <summary>
    /// Левая кнопка мыши отпущена.
    /// </summary>
    onmouseup,

    /// <summary>
    /// Форма очищена.
    /// </summary>
    onreset,

    /// <summary>
    /// Выделен текст в поле формы.
    /// </summary>
    onselect,

    /// <summary>
    /// Форма отправлена.
    /// </summary>
    onsubmit,

    /// <summary>
    /// Закрытие окна.
    /// </summary>
    onunload
}