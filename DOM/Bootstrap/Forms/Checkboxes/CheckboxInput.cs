////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.DOM.extended;
using HtmlGenerator.DOM.forms;
using HtmlGenerator.DOM.textual;
using HtmlGenerator.set;

namespace HtmlGenerator.DOM.Bootstrap.Forms
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

        public input Input = new input() { css_class = "form-check-input", type = InputTypesEnum.checkbox };

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
            tag_custom_name = typeof(div).Name;
            css_class = "form-check";

            if (!string.IsNullOrEmpty(Label))
                LabelInput = new label(Label, InputID) { css_class = "form-check-label" };

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
            my_script.Childs.Add(new text("jQuery(document).ready(function () {"));
            my_script.Childs.Add(new text("\tjQuery('#" + Input.Id_DOM + "').change(function () {"));
            my_script.Childs.Add(new text("\t\tif (jQuery(this).prop('checked')) {"));
            my_script.Childs.Add(new text("\t\t\tjQuery('input[name=" + Input.Id_DOM + "').val('on');"));
            my_script.Childs.Add(new text("\t\t}"));
            my_script.Childs.Add(new text("\t\telse {"));
            my_script.Childs.Add(new text("\t\t\tjQuery('input[name=" + Input.Id_DOM + "').val('off');"));
            my_script.Childs.Add(new text("\t\t}"));
            my_script.Childs.Add(new text("\t});"));
            my_script.Childs.Add(new text("});"));
            Childs.Add(my_script);
            ///////////////////////////////////////////////
            ///
            return base.GetHTML(deep);
        }
    }
}
