////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.forms
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
