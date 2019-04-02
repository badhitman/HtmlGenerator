using HtmlGenerator.dom.set.bootstrap_enum;
using HtmlGenerator.DOM.forms;

namespace HtmlGenerator.dom.bootstrap.forms.buttons
{
    public class Button : button
    {
        /// <summary>
        /// Тип контейнера, который выполняет роль кнопки в Bootstrap
        /// </summary>
        public new TypesBootstrapButton TypeButton = TypesBootstrapButton.button;

        public Button(string text_button) : base(text_button)
        {
            tag_custom_name = typeof(button).Name;

        }

        public override string GetHTML(int deep = 0)
        {
            if (TypeButton == TypesBootstrapButton.a)
                RemoveAttribute("type");

            return base.GetHTML(deep);
        }
    }
}
