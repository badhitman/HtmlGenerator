////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.DOM.forms;
using HtmlGenerator.set;

namespace HtmlGenerator.DOM.Bootstrap.TextInput
{
    /// <summary>
    /// Миниминизированый [Input]. В отличии от базового [Input]-а, у него нет подсказки снизу.
    /// К тому же тут Label прилеплен слева к [Input] образуя единый горизонтльный блок
    /// </summary>
    public class SecondTextInput : bootstrap_dom_root
    {
        public string LabelText;
        public input Input = new input() { type = InputTypesEnum.text, css_class = "form-control" };

        public SecondTextInput(string Label, string InputID)
        {
            set_custom_name_tag = typeof(div).Name;
            LabelText = Label;

            Input.Name_DOM = InputID;
            Input.Id_DOM = InputID;
            css_class = "input-group";
        }

        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();
            div input_group_prepend = new div() { css_class = "input-group-prepend" };
            input_group_prepend.Childs.Add(new div() { css_class = "input-group-text", InnerText = LabelText });
            Childs.Add(input_group_prepend);
            Childs.Add(Input);

            if (Input.required)
                Childs.AddRange(GetValidationAlerts(Input.Name_DOM));

            return base.GetHTML(deep);
        }
    }
}
