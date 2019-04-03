////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.DOM;
using HtmlGenerator.DOM.forms;
using HtmlGenerator.DOM.set.bootstrap_enum;
using HtmlGenerator.DOM.textual;
using HtmlGenerator.set;
using System.Collections.Generic;

namespace HtmlGenerator.bootstrap
{
    /// <summary>
    /// Модальный диалог
    /// </summary>
    public class ModalDialog : div
    {
        /// <summary>
        /// НЕ ИСПОЛЬЗУЙ ЭТО! При формировании HTML(int deep = 0) - этот спсиок пере-заполняется.
        /// Для наполнения тела модального окна используется BodyElements
        /// </summary>
        public new List<base_dom_root> Childs { get => base.Childs; set => base.Childs = value; }

        /// <summary>
        /// Элементы тела модального диалога
        /// </summary>
        public List<base_dom_root> BodyElements { get; private set; } = new List<base_dom_root>();

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
        public string TitleDialog;

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
        /// Текст конопки Cancel. Если (null or empty), то кнопка не выводится вовсе
        /// </summary>
        public string TextCancelButton = "Cancel";

        /// <summary>
        /// Меняем имя тега на div
        /// </summary>
        public ModalDialog() => tag_custom_name = typeof(div).Name;

        /// <summary>
        /// При вызове этого метода поле Childs очищается и заново заполняется
        /// </summary>
        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();

            span span_close_modal_header = new span("&times;");
            span_close_modal_header.SetAttribute("aria-hidden", "true");
            //
            button button_close_modal_header = new button(null) { css_class = "close" };
            button_close_modal_header.SetAttribute("data-dismiss", "modal");
            button_close_modal_header.SetAttribute("aria-label", "Close");
            button_close_modal_header.Childs.Add(span_close_modal_header);
            //
            h5 h5_modal_header = new h5(TitleDialog) { css_class = "modal-title" };
            div div_modal_header = new div() { css_class = "modal-header" };
            div_modal_header.Childs.Add(h5_modal_header);
            div_modal_header.Childs.Add(button_close_modal_header);
            //
            div modal_footer = new div() { css_class = "modal-footer" };

            if (!string.IsNullOrEmpty(TextCancelButton))
            {
                button button_close_modal_footer = predefined_elements_bootstrap.GetButton(TextCancelButton, null, null, VisualBootstrapStylesEnum.secondary);
                button_close_modal_footer.SetAttribute("data-dismiss", "modal");
                modal_footer.Childs.Add(button_close_modal_footer);
            }

            if (!string.IsNullOrEmpty(TextOkButton))
            {
                button button_send_modal_footer = predefined_elements_bootstrap.GetButton(TextOkButton, null, null, VisualBootstrapStylesEnum.primary);
                button_send_modal_footer.TypeButton = TypesButton.submit;
                button_send_modal_footer.css_class += " " + CssOkButton;
                modal_footer.Childs.Add(button_send_modal_footer);
            }
            //
            div modal_content = new div() { css_class = "modal-content" };
            modal_content.Childs.Add(div_modal_header);
            //
            div modal_body = new div() { css_class = "modal-body" };
            modal_body.Childs.AddRange(BodyElements);
            modal_content.Childs.Add(modal_body);
            //
            modal_content.Childs.Add(modal_footer);
            form my_form = new form() { EncType = EncTypesEnum.WwwFormUrlEncoded, method_form = MethodsFormEnum.POST, target = FormTarget, form_action = FormAction };
            my_form.Childs.Add(modal_content);
            //
            div modal_dialog_document = new div() { css_class = "modal-dialog" };
            modal_dialog_document.CustomAttributes.Add("role", "document");
            modal_dialog_document.Childs.Add(my_form);
            //
            this.css_class = "modal fade";
            CustomAttributes.Add("tabindex", "-1");
            CustomAttributes.Add("role", "dialog");
            CustomAttributes.Add("aria-labelledby", Id_DOM);
            CustomAttributes.Add("aria-hidden", "true");

            Childs.Add(modal_dialog_document);
            before_coment_block = "Modal dialog";

            return base.GetHTML(deep);
        }
    }
}