////////////////////////////////////////////////
// https://github.com/badhitman 
////////////////////////////////////////////////

using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.forms;
using HtmlGenerator.set;

namespace HtmlGenerator.bootstrap
{
    /// <summary>
    /// Миниминизированый [Input]. В отличии от базового [Input]-а, у него нет подсказки снизу.
    /// К тому же тут Label прилеплен слева к [Input] образуя единый горизонтльный блок
    /// </summary>
    public class TextInputSecond : forms_dom_root
    {
        public string LabelText;
        public input Input = new input() { type = InputTypesEnum.text };

        public TextInputSecond(string Label, string InputID)
        {
            tag_custom_name = typeof(div).Name;
            LabelText = Label;

            Input.Name = InputID;
            Input.Id_DOM = InputID;
            Input.AddCSS("form-control");
            AddCSS("input-group");
        }

        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();
            div input_group_prepend = new div();
            input_group_prepend.AddCSS("input-group-prepend");
            using (div input_group_text = new div() { InnerText = LabelText })
            {
                input_group_text.AddCSS("input-group-text");
                input_group_prepend.Childs.Add(input_group_text);
            }
            Childs.Add(input_group_prepend);
            Childs.Add(Input);

            if (Input.required)
                Childs.AddRange(GetValidationAlerts(Input.Name));

            return base.GetHTML(deep);
        }
    }
}
