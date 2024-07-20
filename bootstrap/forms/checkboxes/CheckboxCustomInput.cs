////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap;

/// <summary>
/// CheckboxCustomInput
/// </summary>
public class CheckboxCustomInput : CheckboxInput
{
    /// <summary>
    /// CheckboxCustomInput
    /// </summary>
    public CheckboxCustomInput(string Label, string InputID) : base(Label, InputID)
    {
        AddCSS("custom-control custom-checkbox", true);
        Input.AddCSS("custom-control-input");
        LabelInput ??= new(Label, InputID);
        LabelInput.AddCSS("custom-control-label");
    }
}