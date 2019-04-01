////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using HtmlGenerator.DOM.forms;
using HtmlGenerator.DOM.text;

namespace HtmlGenerator.DOM.Bootstrap.TextInput
{
    /// <summary>
    /// Миниминизированый Input. В отличии от базового Input-а, у него нет подсказки снизу. К тому же тут Label прилеплен слева к Input образуе литой горизонтльный блок
    /// </summary>
    public class SecondTextInput : div
    {
        string LabelText;



        public SecondTextInput(string label)
        {
            set_custom_name_tag = typeof(div).Name;
        }



        /*public static div GetSecondTextInput(string label_text, string value_input, string Id_DOM, string placeholder, bool input_readonly, string class_div_group_wrap = null, bool required = false)
        {
            span input_group_text = new span(label_text) { css_class = "input-group-text" };
            div input_group_prepend = new div() { css_class = "input-group-prepend" };
            input_group_prepend.Childs.Add(input_group_text);
            div input_group = new div() { css_class = ("input-group " + class_div_group_wrap).Trim() };
            input_group.Childs.Add(input_group_prepend);

            input ret_input = new input() { css_class = "form-control", type = InputTypesEnum.text, required = required, value = value_input, @readonly = input_readonly };

            if (!string.IsNullOrEmpty(Id_DOM))
                ret_input.Id_DOM = Id_DOM;

            if (!string.IsNullOrEmpty(placeholder))
                ret_input.SetAtribute("placeholder", placeholder);

            input_group.Childs.Add(ret_input);
            if (required)
                input_group.Childs.AddRange(BaseTextInput.GetValidationAlerts(Id_DOM));

            return input_group;
        }*/
    }
}
