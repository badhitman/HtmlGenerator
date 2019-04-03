////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using HtmlGenerator.set;

namespace HtmlGenerator.html5.collections
{

    /// <summary>
    /// Тег [ul] устанавливает маркированный список. Каждый элемент списка должен начинаться с тега [li].
    /// Если к тегу [ul] применяется таблица стилей, то элементы [li] наследуют эти свойства.
    /// </summary>
    public class ul : base_dom_root
    {

        /// <summary>
        /// Устанавливает вид маркера списка. 
        /// </summary>
        public TypesULEnum TypeUL = TypesULEnum.disc;

        public ul(TypesULEnum in_TypeUL = TypesULEnum.disc)=> TypeUL = in_TypeUL;

        public override string GetHTML(int deep = 0)
        {
            SetAttribute("type", TypeUL.ToString("g"));
            return base.GetHTML(deep);
        }

        /// <summary>
        /// Добавить текущему "ul" вложеный "li"
        /// </summary>
        public void AddLi(string value, string name, string tooltip, bool disable = false, string tag = "") => Childs.Add(GetLi(value, name, tooltip, disable, tag));

        /// <summary>
        /// получить li элемент того же типа (ul.type)
        /// </summary>
        /// <param name="value">value - Число, с которого будет начинаться нумерованный список.</param>
        public li GetLi(string value, string text_title, string tooltip, bool disable = false, string tag = "")
        {
            li ret_val = new li() { InnerText = text_title };
            ret_val.title = tooltip;
            ret_val.SetAttribute("type", TypeUL.ToString("g"));
            ret_val.SetAttribute("value", value);

            if (disable)
                ret_val.SetAttribute("disable", null);

            if (!string.IsNullOrEmpty(tag))
                ret_val.SetAttribute("tag", tag);

            return ret_val;
        }
    }
}
