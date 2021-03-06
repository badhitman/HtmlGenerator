﻿////////////////////////////////////////////////
// https://github.com/badhitman 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap
{
    public class CheckboxCustomInput : CheckboxInput
    {
        public CheckboxCustomInput(string Label, string InputID) : base(Label, InputID)
        {
            AddCSS("custom-control custom-checkbox", true);
            Input.AddCSS("custom-control-input");
            LabelInput.AddCSS("custom-control-label");
        }
    }
}
