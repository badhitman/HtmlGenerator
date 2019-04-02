////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.DOM.Bootstrap.Forms.Checkboxes
{
    public class CheckboxCustomInput : CheckboxInput
    {
        public CheckboxCustomInput(string Label, string InputID) : base(Label, InputID)
        {
            css_class = "custom-control custom-checkbox";
            Input.css_class = "custom-control-input";
            LabelInput.css_class = "custom-control-label";
        }
    }
}
