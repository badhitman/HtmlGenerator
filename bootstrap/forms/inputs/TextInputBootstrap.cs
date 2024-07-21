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
    /// Текстовая метка для Input-а
    /// </summary>
    public TextInputBootstrap SetLabelInput(string label)
    {
        if (LabelInput is null)
            LabelInput = new(label, Id_DOM);
        else
            LabelInput.InnerText = label;

        return this;
    }

    /// <summary>
    /// Input
    /// </summary>
    public input Input = new() { type = InputTypesEnum.text };

    /// <summary>
    /// Установка html атрибута <c>type</c> для дочернего/подчинённого <c>input</c>`а
    /// </summary>
    public TextInputBootstrap SetTypeForInput(InputTypesEnum type)
    {
        Input.type = type;
        return this;
    }

    /// <summary>
    /// Установка html атрибута <c>placeholder</c> для дочернего/подчинённого <c>input</c>`а
    /// </summary>
    public TextInputBootstrap SetPlaceholderForInput(string placeholder)
    {
        Input.placeholder = placeholder;
        return this;
    }

    /// <summary>
    /// Установка html атрибута <c>placeholder</c> для дочернего/подчинённого <c>input</c>`а
    /// </summary>
    public TextInputBootstrap SetInputInfoFooter(string inputInfoFooter)
    {
        InputInfoFooter = inputInfoFooter;
        return this;
    }

    /// <summary>
    /// Текст подсказки, который отображается мелким шрифтом под Input-ом
    /// </summary>
    public string? InputInfoFooter;

    /// <summary>
    /// Добавочный CSS класс для родительского блока в который будет помещён Input со всеми своими сопутствующими элементами (Label, InfoFooter)
    /// </summary>
    public string? ClassInputGroup;

    /// <inheritdoc/>
    public TextInputBootstrap(string label, string inputID)
    {
        Input.AddCSS("form-control");
        tag_custom_name = typeof(div).Name.ToLower();
        if (!string.IsNullOrEmpty(label))
            LabelInput = new label(label, inputID);

        Id_DOM = inputID;

        Input.Name_DOM = inputID;
        Input.Id_DOM = inputID;
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