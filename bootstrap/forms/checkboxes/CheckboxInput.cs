////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.forms;
using HtmlGenerator.set;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// Стандартный Checkbox в одну горизонтальную строку. Label - справа
/// </summary>
public class CheckboxInput : forms_dom_root
{
    /// <summary>
    /// Текстовая метка для Input-а
    /// </summary>
    public label? LabelInput;

    public input Input = new() { type = InputTypesEnum.checkbox };

    /// <summary>
    /// Текст, который будет выведен в случае установки Checkbox-а. (используется если Input.required = true)
    /// Если NullOrEmpty, то этот тип информатора не будет сформирован вовсе
    /// </summary>
    public string? valid_feedback_text = null;

    /// <summary>
    /// Текст, который будет выведен в случае отсутствия Checkbox-а. (используется если Input.required = true)
    /// Если NullOrEmpty, то этот тип информатора не будет сформирован вовсе
    /// </summary>
    public string invalid_feedback_text = "Пожалуйста, установите Checkbox";

    /// <inheritdoc/>
    public CheckboxInput(string Label, string InputID)
    {
        Input.AddCSS("form-check-input");
        tag_custom_name = typeof(div).Name;
        AddCSS("form-check");

        if (!string.IsNullOrEmpty(Label))
        {
            LabelInput = new label(Label, InputID);
            LabelInput.AddCSS("form-check-label");
        }
        Input.Id_DOM = InputID;
    }

    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        Childs.Add(Input);
        if (LabelInput is not null)
            Childs.Add(LabelInput);

        if (Input.required)
            Childs.AddRange(GetValidationAlerts(Input.Id_DOM, valid_feedback_text, invalid_feedback_text));

        return base.GetHTML(deep);
    }
}