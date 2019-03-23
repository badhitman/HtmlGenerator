////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    /// <summary>
    ///  Определяет тип кнопки, который устанавливает ее поведение в форме. По внешнему виду кнопки разного типа никак не различаются, но у каждой такой кнопки свои функции. 
    /// </summary>
    public enum TypesButton
    {
        /// <summary>
        /// Обычная кнопка. 
        /// </summary>
        button,

        /// <summary>
        /// Кнопка для очистки введенных данных формы и возвращения значений в первоначальное состояние.
        /// </summary>
        reset,

        /// <summary>
        /// Кнопка для отправки данных формы на сервер. 
        /// </summary>
        submit
    }
    public class button : basic_html_dom
    {
        public TypesButton TypeButton;
        public button(string text_button, TypesButton type_button = TypesButton.button)
        {
            InnerHtml = text_button;
            TypeButton = type_button;
        }

        public override string HTML(int deep = 0)
        {
            SetAtribute("type", TypeButton.ToString("g"));
            return base.HTML(deep);
        }
    }
}
