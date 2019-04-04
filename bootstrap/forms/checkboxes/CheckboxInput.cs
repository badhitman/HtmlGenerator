////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.extended;
using HtmlGenerator.html5.forms;
using HtmlGenerator.html5.textual;
using HtmlGenerator.set;

namespace HtmlGenerator.bootstrap
{
    /// <summary>
    /// Стандартный Checkbox в одну горизонтальную строку. Label - справа
    /// </summary>
    public class CheckboxInput : forms_dom_root
    {
        /// <summary>
        /// Текстова метка для Input-а
        /// </summary>
        public label LabelInput;

        public input Input = new input() { type = InputTypesEnum.checkbox };

        /// <summary>
        /// Текст, который будет выведен в случае установки Checkbox-а. (используется если Input.required = true)
        /// Если NullOrEmty, то этот тип информатора не будет сформирован вовсе
        /// </summary>
        public string valid_feedback_text = null;

        /// <summary>
        /// Текст, который будет выведен в случае отсутствия Checkbox-а. (используется если Input.required = true)
        /// Если NullOrEmty, то этот тип информатора не будет сформирован вовсе
        /// </summary>
        public string invalid_feedback_text = "Пожалуйста, установите Checkbox";

        public CheckboxInput(string Label, string InputID)
        {
            Input.AddCSS("form-check-input");
            tag_custom_name = typeof(div).Name;
            AddCSS("form-check");

            if (!string.IsNullOrEmpty(Label))
            {
                LabelInput = new label(Label, InputID);
                LabelInput.AddCSS("form-check-label");
            }
            Input.Id_DOM = InputID;
        }

        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();

            Childs.Add(Input);
            if (!(LabelInput is null))
                Childs.Add(LabelInput);

            if (Input.required)
                Childs.AddRange(GetValidationAlerts(Input.Id_DOM, valid_feedback_text, invalid_feedback_text));

            ////////////////////////////////////////////////
            // Фиксим проблему кроссбраузерности отправок формой чекбокса.
            // Разные браузеры могут по разному отправлять чекбокс. Для стандартизации этой процедуры с чекбоксом в паре держим его "тень" в виде скрытого input-а и контролируем значение теневого значения синхронизируя с основным
            Childs.Add(new input() { type = InputTypesEnum.hidden, value = Input.@checked ? "on" : "off", Name_DOM = Id_DOM });
            //
            script my_script = new script();
            my_script.Add(new text("jQuery(document).ready(function () {"));
            my_script.Add(new text("  jQuery('#" + Input.Id_DOM + "').change(function () {"));
            my_script.Add(new text("    if (jQuery(this).prop('checked')) {"));
            my_script.Add(new text("      jQuery('input[name=" + Input.Id_DOM + "').val('on');"));
            my_script.Add(new text("    }"));
            my_script.Add(new text("    else {"));
            my_script.Add(new text("      jQuery('input[name=" + Input.Id_DOM + "').val('off');"));
            my_script.Add(new text("    }"));
            my_script.Add(new text("  });"));
            my_script.Add(new text("});"));
            Childs.Add(my_script);
            ///////////////////////////////////////////////
            ///
            return base.GetHTML(deep);
        }
    }
}
