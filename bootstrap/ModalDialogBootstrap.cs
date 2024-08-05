////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

using HtmlGenerator.set.bootstrap;
using HtmlGenerator.html5.textual;
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.forms;
using HtmlGenerator.html5;
using HtmlGenerator.set;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// Модальный диалог
/// </summary>
public class ModalDialogBootstrap : safe_base_dom_root
{
    /// <summary>
    /// НЕ ИСПОЛЬЗУЙ ЭТО! При формировании HTML(int deep = 0) - этот список пере-заполняется.
    /// Для наполнения тела модального окна используется BodyElements
    /// </summary>
    public new List<base_dom_root>? Childs { get => base.Childs; set => base.Childs = value; }

    /// <summary>
    /// Элементы тела модального диалога
    /// </summary>
    public List<base_dom_root> BodyElements { get; private set; } = [];

    /// <summary>
    /// Адрес программы или документа, который обрабатывает данные формы
    /// </summary>
    public string FormAction = "./";

    /// <summary>
    /// Имя окна или фрейма, куда обработчик будет загружать возвращаемый результат.
    /// </summary>
    public TargetsEnum FormTarget = TargetsEnum._self;

    /// <summary>
    /// Заголовок модального диалога
    /// </summary>
    public required string TitleDialog;

    /// <summary>
    /// Текст кнопки подтверждения на форме (например: ок, записать, применить, согласен)
    /// (если null or empty, то кнопка не выводится вовсе)
    /// </summary>
    public string TextOkButton = "OK";

    /// <summary>
    /// Класс для добавления кнопке подтверждения на форме
    /// </summary>
    public string CssOkButton = "button_try_write";

    /// <summary>
    /// Текст кнопки Cancel. Если (null or empty), то кнопка не выводится вовсе
    /// </summary>
    public string TextCancelButton = "Cancel";

    /// <summary>
    /// div
    /// </summary>
    public override string tag_custom_name => "div";

    /// <inheritdoc/>
    /// <remarks>При вызове этого метода поле Childs очищается и заново заполняется</remarks>
    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        span span_close_modal_header = new("&times;");
        span_close_modal_header.SetAttribute("aria-hidden", "true");
        //
        button button_close_modal_header = new(null);
        button_close_modal_header.AddCSS("close");
        button_close_modal_header.SetAttribute("data-dismiss", "modal");
        button_close_modal_header.SetAttribute("aria-label", "Close");
        button_close_modal_header.AddDomNode(span_close_modal_header);
        //
        h5 h5_modal_header = new(TitleDialog);
        h5_modal_header.AddCSS("modal-title");
        div div_modal_header = new();
        div_modal_header.AddCSS("modal-header");
        div_modal_header.AddDomNode(h5_modal_header);
        div_modal_header.AddDomNode(button_close_modal_header);
        //
        div modal_footer = new();
        modal_footer.AddCSS("modal-footer");
        if (!string.IsNullOrEmpty(TextCancelButton))
        {
            button button_close_modal_footer = demo_bootstrap.GetButton(TextCancelButton, null, null, VisualBootstrapStylesEnum.secondary);
            button_close_modal_footer.SetAttribute("data-dismiss", "modal");
            modal_footer.AddDomNode(button_close_modal_footer);
        }

        if (!string.IsNullOrEmpty(TextOkButton))
        {
            button button_send_modal_footer = demo_bootstrap.GetButton(TextOkButton, null, null, VisualBootstrapStylesEnum.primary);
            button_send_modal_footer.TypeButton = TypesButton.submit;
            button_send_modal_footer.AddCSS(CssOkButton, true);
            modal_footer.AddDomNode(button_send_modal_footer);
        }
        //
        div modal_content = new();
        modal_content.AddCSS("modal-content");
        modal_content.AddDomNode(div_modal_header);
        //
        div modal_body = new();
        modal_body.AddCSS("modal-body");
        modal_body.AddRangeDomNode(BodyElements);
        modal_content.AddDomNode(modal_body);
        //
        modal_content.AddDomNode(modal_footer);
        form my_form = new() { EncType = EncTypesEnum.WwwFormUrlEncoded, method_form = MethodsFormEnum.POST, target = FormTarget, form_action = FormAction };
        my_form.AddDomNode(modal_content);
        //
        div modal_dialog_document = new();
        modal_dialog_document.AddCSS("modal-dialog");
        modal_dialog_document.CustomAttributes.Add("role", "document");
        modal_dialog_document.AddDomNode(my_form);
        //
        AddCSS("modal fade", true);
        CustomAttributes.Add("tabindex", "-1");
        CustomAttributes.Add("role", "dialog");
        CustomAttributes.Add("aria-labelledby", Id_DOM);
        CustomAttributes.Add("aria-hidden", "true");

        Childs.Add(modal_dialog_document);
        before_comment_block = "Modal dialog";

        return base.GetHTML(deep);
    }
}