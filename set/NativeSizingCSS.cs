////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.set;

/// <summary>
/// Универсальный класс для задания размеров в HTML разметке
/// 
/// Для задания размеров различных элементов, в CSS используются абсолютные и относительные единицы измерения.
/// Абсолютные единицы не зависят от устройства вывода, а относительные единицы определяют размер элемента относительно значения другого размера.
/// 
/// </summary>
public class NativeSizingCSS
{
    /// <summary>
    /// Типы применяемых размеров
    /// </summary>
    public enum TypeSize
    {
        // Относительные единицы обычно используют для работы с текстом, либо когда надо вычислить процентное соотношение между элементами.

        /// <summary>
        /// Пиксел
        /// </summary>
        px,

        /// <summary>
        /// Высота шрифта текущего элемента
        /// </summary>
        em,

        /// <summary>
        /// Единица rem задаёт размер относительно размера шрифта элемента [html].
        /// </summary>
        rem,

        /// <summary>
        /// Высота символа x
        /// </summary>
        ex,

        /// <summary>
        /// Процент
        /// </summary>
        percent,

        // Абсолютные единицы применяются реже, чем относительные и, как правило, при работе с текстом.

        /// <summary>
        /// Дюйм (1 дюйм равен 2,54 см)
        /// </summary>
        @in,

        /// <summary>
        /// Сантиметр
        /// </summary>
        cm,

        /// <summary>
        /// Миллиметр
        /// </summary>
        mm,

        /// <summary>
        /// Пункт (1 пункт равен 1/72 дюйма)
        /// </summary>
        pt,

        /// <summary>
        /// Пика (1 пика равна 12 пунктам)
        /// </summary>
        pc,

        // Специальные

        /// <summary>
        /// Flexible
        /// </summary>
        fr,

        auto
    }

    /// <summary>
    /// Тип используемого размера: в пикселях, процентах и т.п.
    /// </summary>
    public TypeSize type = TypeSize.auto;

    /// <summary>
    /// Размер в выбранных единицах
    /// </summary>
    public int size = 0;

    /// <summary>
    /// Строковое представление размера для вставки в HTML разметку
    /// </summary>
    /// <returns>Возвращает строковое представление размера для использования в HTML разметке</returns>
    public override string ToString()
    {
        switch (type)
        {
            case TypeSize.percent:
                return size.ToString() + "%";
            case TypeSize.auto:
                return "auto";
            default:
                return size.ToString() + type.ToString("g");
        }
    }
}