////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Тег "ul" устанавливает маркированный список. Каждый элемент списка должен начинаться с тега "li".
    /// Если к тегу "ul" применяется таблица стилей, то элементы "li" наследуют эти свойства.
    /// </summary>
    public class ul : basic_html_dom
    {
        /// <summary>
        /// Устанавливает вид маркера.
        /// </summary>
        public enum TypesUL
        {
            disc,
            circle,
            square
        }

        public TypesUL TypeUL = TypesUL.disc;

        public ul(TypesUL in_TypeUL = TypesUL.disc)
        {
            TypeUL = in_TypeUL;
        }

        public override string HTML(int deep = 0)
        {
            SetAtribute("type", TypeUL.ToString("g"));
            return base.HTML(deep);
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
            li ret_val = new li(text_title);
            ret_val.Tooltip = tooltip;
            ret_val.SetAtribute("type", TypeUL.ToString("g"));
            ret_val.SetAtribute("value", value);

            if (disable)
                ret_val.SetAtribute("disable", null);

            if (!string.IsNullOrEmpty(tag))
                ret_val.SetAtribute("tag", tag);

            return ret_val;
        }
    }
}
