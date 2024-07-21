////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using HtmlGenerator.html5.textual;
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.forms;
using HtmlGenerator.set;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// Базовый [Input] в [div] обёртке. [Label] сверху над [Input]-ом и текст описания [InputInfoFooter] под [Input]-ом
/// </summary>
public class TextInputBootstrap : forms_dom_root_bootstrap
{
    /// <summary>
    /// Текстовая метка для Input-а
    /// </summary>
    public label? LabelInput;

    /// <summary>
    /// Input
    /// </summary>
    public input Input = new() { type = InputTypesEnum.text };

    /// <summary>
    /// Текст подсказки, который отображается мелким шрифтом под Input-ом
    /// </summary>
    public string? InputInfoFooter;

    /// <summary>
    /// Добавочный CSS класс для родительского блока в который будет помещён Input со всеми своими сопутствующими элементами (Label, InfoFooter)
    /// </summary>
    public string? ClassInputGroup;

    /// <inheritdoc/>
    public TextInputBootstrap(string Label, string InputID)
    {
        Input.AddCSS("form-control");
        tag_custom_name = typeof(div).Name;
        if (!string.IsNullOrEmpty(Label))
            LabelInput = new label(Label, InputID);

        Input.Name_DOM = InputID;
        Input.Id_DOM = InputID;
    }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        AddCSS("form-group " + ClassInputGroup, true);
        Childs ??= [];
        if (LabelInput is not null)
            Childs.Add(LabelInput);

        Childs.Add(Input);

        if (Input.required)
            Childs.AddRange(GetValidationAlerts(Input.Name_DOM));

        if (!string.IsNullOrEmpty(InputInfoFooter))
        {
            string input_info_id = Input.Name_DOM + "Help";
            small info_text = new(InputInfoFooter) { inline = true, Id_DOM = input_info_id };

            info_text.AddCSS("form-text text-muted", true);
            Childs.Add(info_text);

            Input.SetAttribute("aria-describedby", input_info_id);
        }
        return base.GetHTML(deep);
    }
}