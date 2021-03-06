﻿////////////////////////////////////////////////
// https://github.com/badhitman 
////////////////////////////////////////////////
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.forms;
using HtmlGenerator.html5.textual;
using HtmlGenerator.set;

namespace HtmlGenerator.bootstrap
{
    /// <summary>
    /// Базовый [Input] в [div] обёртке. [Label] сверху над [Input]-ом и текст описания [InputInfoFooter] под [Input]-ом
    /// </summary>
    public class TextInput : forms_dom_root
    {
        /// <summary>
        /// Текстова метка для Input-а
        /// </summary>
        public label LabelInput;

        public input Input = new input() { type = InputTypesEnum.text };

        /// <summary>
        /// Текст подсказки, который отображается мелким шрифтом под Input-ом
        /// </summary>
        public string InputInfoFooter;

        /// <summary>
        /// Добавочный CSS класс для родительского блока в который будет помещён Input со всеми своими сопутсвующими элементами (Label, InfoFooter)
        /// </summary>
        public string ClassInputGroup = null;

        public TextInput(string Label, string InputID)
        {
            Input.AddCSS("form-control");
            tag_custom_name = typeof(div).Name;
            if (!string.IsNullOrEmpty(Label))
                LabelInput = new label(Label, InputID);

            Input.Name = InputID;
            Input.Id_DOM = InputID;
        }

        public override string GetHTML(int deep = 0)
        {
            AddCSS("form-group " + ClassInputGroup, true);

            if (!(LabelInput is null))
                Childs.Add(LabelInput);

            Childs.Add(Input);

            if (Input.required)
                Childs.AddRange(GetValidationAlerts(Input.Name));

            if (!string.IsNullOrEmpty(InputInfoFooter))
            {
                string input_info_id = Input.Name + "Help";
                using (small info_text = new small(InputInfoFooter) { inline = true, Id_DOM = input_info_id })
                {
                    info_text.AddCSS("form-text text-muted", true);
                    Childs.Add(info_text);
                }
                Input.SetAttribute("aria-describedby", input_info_id);
            }
            return base.GetHTML(deep);
        }
    }
}
