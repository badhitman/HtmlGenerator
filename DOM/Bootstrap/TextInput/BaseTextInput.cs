////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.DOM.forms;
using HtmlGenerator.DOM.text;
using HtmlGenerator.set;

namespace HtmlGenerator.DOM.Bootstrap
{
    /// <summary>
    /// Базовый [Input] в [div] обёртке. [Label] сверху над [Input]-ом и текст описания [InputInfoFooter] под [Input]-ом
    /// </summary>
    public class BaseTextInput : div
    {
        /// <summary>
        /// Текстова метка для Input-а
        /// </summary>
        public label LabelInput;

        public input Input = new input() { type = InputTypesEnum.text, css_class = "form-control" };

        /// <summary>
        /// Текст подсказки, который отображается мелким шрифтом под Input-ом
        /// </summary>
        public string InputInfoFooter;

        /// <summary>
        /// Добавочный CSS класс для родительского блока в который будет помещён Input со всеми своими сопутсвующими элементами (Label, InfoFooter)
        /// </summary>
        public string ClassInputGroup = null;

        public BaseTextInput(string Label, string InputID)
        {
            set_custom_name_tag = typeof(div).Name;
            if (!string.IsNullOrEmpty(Label))
                LabelInput = new label(Label, InputID);

            Input.Name_DOM = InputID;
            Input.Id_DOM = InputID;
        }

        public override string GetHTML(int deep = 0)
        {
            css_class = ("form-group " + ClassInputGroup).Trim();

            if (!(LabelInput is null))
                Childs.Add(LabelInput);

            Childs.Add(Input);

            if (Input.required)
                Childs.AddRange(GetValidationAlerts(Input.Name_DOM));

            if (!string.IsNullOrEmpty(InputInfoFooter))
                Childs.Add(new small(InputInfoFooter)
                {
                    css_class = "form-text text-muted",
                    Id_DOM = Input.Name_DOM + "Help"
                });
            return base.GetHTML(deep);
        }

        public static div[] GetValidationAlerts(string validation_input_id, string invalid_text = "Укажите значение", string valid_text = null)
        {
            div valid_element = new div() { css_class = "valid-tooltip", InnerText = valid_text, Id_DOM = "valid-tooltip-" + validation_input_id };
            div invalid_element = new div() { css_class = "invalid-tooltip", InnerText = invalid_text, Id_DOM = "invalid-tooltip-" + validation_input_id };
            // 
            if (!string.IsNullOrEmpty(valid_text))
                return new div[] { valid_element, invalid_element };
            else
                return new div[] { invalid_element };
        }
    }
}
