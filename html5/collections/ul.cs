////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;

namespace HtmlGenerator.html5.collections;

/// <summary>
/// Тег [ul] устанавливает маркированный список. Каждый элемент списка должен начинаться с тега [li].
/// Если к тегу [ul] применяется таблица стилей, то элементы [li] наследуют эти свойства.
/// </summary>
public class ul(TypesULEnum in_TypeUL = TypesULEnum.disc) : base_dom_root
{

    /// <summary>
    /// Устанавливает вид маркера списка. 
    /// </summary>
    public TypesULEnum TypeUL = in_TypeUL;

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        SetAttribute("type", TypeUL.ToString("g"));
        return base.GetHTML(deep);
    }

    /// <summary>
    /// Добавить текущему "ul" вложенный "li"
    /// </summary>
    public void AddLi(string value, string name, string tooltip, bool disable = false, string tag = "")
    {
        Childs ??= [];
        Childs.Add(GetLi(value, name, tooltip, disable, tag));
    }

    /// <summary>
    /// получить li элемент того же типа (ul.type)
    /// </summary>
    /// <param name="value">value - Число, с которого будет начинаться нумерованный список.</param>
    /// <param name="text_title">text</param>
    /// <param name="tooltip">tooltip</param>
    /// <param name="disable">disable</param>
    /// <param name="tag">tag</param>
    public li GetLi(string value, string text_title, string tooltip, bool disable = false, string tag = "")
    {
        li ret_val = new()
        {
            InnerText = text_title,
            title = tooltip
        };
        ret_val.SetAttribute("type", TypeUL.ToString("g"));
        ret_val.SetAttribute("value", value);

        if (disable)
            ret_val.SetAttribute("disable", null);

        if (!string.IsNullOrEmpty(tag))
            ret_val.SetAttribute("tag", tag);

        return ret_val;
    }
}