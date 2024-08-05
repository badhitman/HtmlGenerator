////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap;

/// <summary>
/// CheckboxCustomInput
/// </summary>
public class CheckboxCustomInputBootstrap : CheckboxInputBootstrap
{
    /// <summary>
    /// CheckboxCustomInput
    /// </summary>
    public CheckboxCustomInputBootstrap(string Label, string InputID) : base(Label, InputID)
    {
        AddCSS("custom-control custom-checkbox", true);
        Input.AddCSS("custom-control-input");
        LabelInput ??= new(Label, InputID);
        LabelInput.AddCSS("custom-control-label");
    }
}