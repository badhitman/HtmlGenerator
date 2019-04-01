////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.DOM.forms;

namespace HtmlGenerator.DOM.Bootstrap.Forms
{
    public class CheckboxInput : bootstrap_dom_root
    {
        /// <summary>
        /// Текстова метка для Input-а
        /// </summary>
        public label LabelInput;

        public input Input = new input() { css_class = "form-check-input", type = HtmlGenerator.set.InputTypesEnum.checkbox };
        public CheckboxInput(string Label, string InputID)
        {
            set_custom_name_tag = typeof(div).Name;
            css_class = "form-check";

            if (!string.IsNullOrEmpty(Label))
                LabelInput = new label(Label, InputID);

            Input.Name_DOM = InputID;
            Input.Id_DOM = InputID;
        }

        /*
        <div class="form-check">
          <input class="form-check-input is-invalid" type="checkbox" value="" id="invalidCheck3" required>
          <label class="form-check-label" for="invalidCheck3">
            Agree to terms and conditions
          </label>
          <div class="invalid-feedback">
            You must agree before submitting.
          </div>
        </div>
         */

        /*
         public static p GetCheckboxInput(string label_text, string Id_DOM, bool is_cheked = false, bool required = false)
        {
            div ret_val = new div() { css_class = "form-check" };
            //
            input ret_input = new input() { type = InputTypesEnum.checkbox };
            ret_input.css_class = "form-check-input";
            ret_input.Id_DOM = Id_DOM;

            if (is_cheked)
                ret_input.SetAtribute("checked", "true");

            if (required)
                ret_input.SetAtribute("required", null);

            ret_val.Childs.Add(ret_input);
            //
            ret_input = new input() { type = InputTypesEnum.hidden, value = "off" };
            ret_input.Name_DOM = Id_DOM;
            ret_val.Childs.Add(ret_input);
            //
            label label = new label(label_text, Id_DOM);
            label.css_class = "form-check-label";
            ret_val.Childs.Add(label);

            return new p(null) { Childs = new List<base_dom_root>() { ret_val } };
        }
         */
    }
}
