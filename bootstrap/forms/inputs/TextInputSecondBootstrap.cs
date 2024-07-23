////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.forms;
using HtmlGenerator.set;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// Минимизированный [Input]. В отличии от базового [Input]-а, у него нет подсказки снизу.
/// К тому же тут Label прилеплен слева к [Input] образуя единый горизонтальный блок
/// </summary>
public class TextInputSecondBootstrap : forms_dom_root_bootstrap
{
    /// <summary>
    /// LabelText
    /// </summary>
    public string LabelText;

    /// <summary>
    /// Input
    /// </summary>
    public input Input = new() { type = InputTypesEnum.text };

    /// <summary>
    /// div
    /// </summary>
    public override string? tag_custom_name => "div";

    /// <summary>
    /// Минимизированный [Input]. В отличии от базового [Input]-а, у него нет подсказки снизу.
    /// К тому же тут Label прилеплен слева к [Input] образуя единый горизонтальный блок
    /// </summary>
    public TextInputSecondBootstrap(string Label, string InputID)
    {
        LabelText = Label;

        Input.Name_DOM = InputID;
        Input.Id_DOM = InputID;
        Input.AddCSS("form-control");
        AddCSS("input-group");
    }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        Childs ??= [];
        Childs.Clear();
        div input_group_prepend = new();
        input_group_prepend.AddCSS("input-group-prepend");
        div input_group_text = new() { InnerText = LabelText };

        input_group_text.AddCSS("input-group-text");
        input_group_prepend.Childs ??= [];
        input_group_prepend.Childs.Add(input_group_text);

        Childs.Add(input_group_prepend);
        Childs.Add(Input);

        if (Input.required)
            Childs.AddRange(GetValidationAlerts(Input.Name_DOM));

        return base.GetHTML(deep);
    }
}