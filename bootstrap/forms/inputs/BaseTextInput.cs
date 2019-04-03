////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.forms;
using HtmlGenerator.html5.textual;
using HtmlGenerator.set;

namespace HtmlGenerator.bootstrap.forms
{
    /// <summary>
    /// Базовый [Input] в [div] обёртке. [Label] сверху над [Input]-ом и текст описания [InputInfoFooter] под [Input]-ом
    /// </summary>
    public class BaseTextInput : forms_dom_root
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
            tag_custom_name = typeof(div).Name;
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
            {
                string input_info_id = Input.Name_DOM + "Help";
                Childs.Add(new small(InputInfoFooter)
                {
                    inline = true,
                    css_class = "form-text text-muted",
                    Id_DOM = input_info_id
                });
                Input.SetAttribute("aria-describedby", input_info_id);
            }
            return base.GetHTML(deep);
        }
    }
}
