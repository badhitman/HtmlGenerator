////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.bootstrap.forms;
using HtmlGenerator.html5;
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.collections;
using HtmlGenerator.html5.forms;
using HtmlGenerator.html5.tables;
using HtmlGenerator.html5.textual;
using HtmlGenerator.set;
using HtmlGenerator.set.bootstrap;
using System.Collections.Generic;

namespace HtmlGenerator
{
    public static class predefined_elements_bootstrap
    {
        public static div GetBootstrapSelectList(string label, select select_body, string Tooltip = null, string wrap_class = "input-group mb-4 col-auto")
        {
            div ret_dom = new div() { css_class = wrap_class };

            if (!string.IsNullOrEmpty(label))
            {
                ret_dom.Add(new div { css_class = "input-group-prepend" });
                //ret_dom.Childs[0].Childs.Add(new label(label, select_body.Id_DOM) { css_class = "input-group-text" });
            }
            select_body.css_class = (select_body.css_class.Trim() + " custom-select").Trim();

            if (!string.IsNullOrEmpty(Tooltip))
                ret_dom.title = Tooltip;

            ret_dom.SetAttribute("data-toggle", "tooltip");
            ret_dom.Add(select_body);
            return ret_dom;
        }

        /// <summary>
        /// Стандартная карточка/панель для размещения информации
        /// </summary>
        /// <param name="card_head">Заголовок карточки</param>
        /// <param name="body_elements">Элементы содержимого</param>
        /// <param name="css_card">Стиль офрмления карточки</param>
        /// <returns>Готовая карточка информации</returns>
        public static div Get_DIV_Bootstrap_Card(string card_head, List<base_dom_root> body_elements, string css_card = "bg-light")
        {
            div card_header = new div() { css_class = "card-header", InnerText = card_head };

            div card_body = new div() { css_class = "card-body" };
            foreach (div he in body_elements)
                card_body.Add(he);

            div card_set = new div() { css_class = ("card " + css_card).Trim() };

            card_set.Add(card_header);
            card_set.Add(card_body);

            return card_set;
        }
        public static div Get_DIV_Bootstrap_Card(string card_head, base_dom_root body_element, string css_card = "bg-light") => Get_DIV_Bootstrap_Card(card_head, new List<base_dom_root>() { body_element }, css_card);

        public static div GetTextarea(string label_text, string value_input, string name_input, string placeholder, bool input_readonly = false, int rows = 2, bool required = false)
        {
            div returned_input = new div() { css_class = "form-group" };
            if (!string.IsNullOrEmpty(label_text))
                returned_input.Add(new label(label_text, name_input));

            textarea ret_textarea = new textarea() { css_class = "form-control", InnerText = value_input, required = required, @readonly = input_readonly };
            if (rows > 0)
                ret_textarea.rows = rows;

            if (!string.IsNullOrEmpty(value_input))
                ret_textarea.InnerText = value_input;

            ret_textarea.Name_DOM = name_input;

            returned_input.Add(ret_textarea);

            return returned_input;
        }

        /// <summary>
        /// Сформировать кнопку
        /// </summary>
        /// <param name="text">Текст кнопки</param>
        /// <param name="href">Ссылка (если требуетс кнопка-ссылка)</param>
        /// <param name="style">Стиль оформления кнопки</param>
        /// <param name="size">Размер кнопки</param>
        /// <param name="btn_block">Флаг режима заполнения родительского блока во всю ширину</param>
        /// <param name="outline_style">Флаг отключения цвета фона. В этом режиме стиль оформления будет использован для рамки и цвета, но не для фона</param>
        public static button GetButton(string text, string id_button = null, string href = null, VisualBootstrapStylesEnum? style = null, SizingBootstrap? size = null, bool btn_block = false, bool outline_style = false)
        {
            button ret_button = new button(text) { css_class = "btn", Id_DOM = id_button };

            if (!(style is null))
                ret_button.css_class += " btn" + (outline_style ? "-outline-" : "-") + style?.ToString("g");

            if (!(size is null))
                ret_button.css_class += " btn-" + size?.ToString("g").ToLower();

            ret_button.css_class += (btn_block ? " btn-block" : "") + " active";

            if (string.IsNullOrEmpty(href))
                ret_button.SetAttribute("type", "button");
            else
            {
                ret_button.tag_custom_name = "a";
                ret_button.SetAttribute("href", href);
                ret_button.SetAttribute("role", "button");
                ret_button.SetAttribute("aria-pressed", "true");
            }

            return ret_button;
        }

        /// <summary>
        /// Сформировать модальное окно
        /// </summary>
        /// <param name="title">Заголовок модального окна</param>
        /// <param name="text_ok_button">Текст конопки Ok (если null or empty), то кнопка не выводится вовсе</param>
        /// <param name="id_ok_button">ID атрибут конопки Ok</param>
        /// <param name="text_cansel_button">Текст конопки Cancel (если null or empty), то кнопка не выводится вовсе</param>
        /// <param name="body_html">Тело модального окна</param>
        /// <param name="id_modal_dialog">ID атрибут модального окна</param>
        public static div GetModalDialog(string title, string text_ok_button, string text_cansel_button, base_dom_root body_html, string id_modal_dialog = "exampleModal", string id_ok_button = "button_try_write")
        {
            span span_close_modal_header = new span("&times;");
            span_close_modal_header.SetAttribute("aria-hidden", "true");
            //
            button button_close_modal_header = new button(null) { css_class = "close" };
            button_close_modal_header.SetAttribute("data-dismiss", "modal");
            button_close_modal_header.SetAttribute("aria-label", "Close");
            button_close_modal_header.Add(span_close_modal_header);
            //
            h5 h5_modal_header = new h5(title) { css_class = "modal-title" };
            div div_modal_header = new div() { css_class = "modal-header" };
            div_modal_header.Add(h5_modal_header);
            div_modal_header.Add(button_close_modal_header);
            //
            div modal_footer = new div() { css_class = "modal-footer" };

            if (!string.IsNullOrEmpty(text_cansel_button))
            {
                button button_close_modal_footer = GetButton(text_cansel_button, null, null, VisualBootstrapStylesEnum.secondary);
                button_close_modal_footer.SetAttribute("data-dismiss", "modal");
                modal_footer.Add(button_close_modal_footer);
            }

            if (!string.IsNullOrEmpty(text_ok_button))
            {
                button button_send_modal_footer = GetButton(text_ok_button, null, "#", VisualBootstrapStylesEnum.primary);
                button_send_modal_footer.Id_DOM = id_ok_button;
                modal_footer.Add(button_send_modal_footer);
            }
            //
            div modal_content = new div() { css_class = "modal-content" };
            modal_content.Add(div_modal_header);
            //
            div modal_body = new div() { css_class = "modal-body" };
            modal_body.Add(body_html);
            modal_content.Add(modal_body);
            //
            modal_content.Add(modal_footer);
            //
            div modal_dialog_document = new div() { css_class = "modal-dialog" };


            modal_dialog_document.CustomAttributes.Add("role", "document");
            modal_dialog_document.Add(modal_content);
            //
            div ModalDialog = new div() { css_class = "modal fade", Id_DOM = id_modal_dialog };

            ModalDialog.CustomAttributes.Add("tabindex", "-1");
            ModalDialog.CustomAttributes.Add("role", "dialog");
            ModalDialog.CustomAttributes.Add("aria-labelledby", id_modal_dialog);
            ModalDialog.CustomAttributes.Add("aria-hidden", "true");

            ModalDialog.Add(modal_dialog_document);
            ModalDialog.before_coment_block = "Modal dialog";
            return ModalDialog;
        }

        /// <summary>
        /// Получить форму регистрации/авторизации
        /// </summary>
        /// <param name="user_login_input_id">html dom id/name - идентификатор/имя input-a ввода логина</param>
        /// <param name="user_password_input_id">html dom id/name - идентификатор/имя input-a ввода пароля</param>
        /// <param name="user_password_repeat_input_id">html dom id/name - идентификатор/имя input-a ввода повтора пороля</param>
        /// <param name="reg_new_user_chekbox_id">html dom id/name - идентификатор/имя chekbox-a для регистрации нового пользователя</param>
        /// <param name="button_send_login_form_id">html dom id/name - идентификатор/имя button-a </param>
        /// <param name="re_captcha_key">api - ключ reCaptcha</param>
        /// <param name="collapse_info_new_user_input_css">css класс - области сворачивания и разворачивания для регистрации</param>
        /// <returns></returns>
        public static List<base_dom_root> GetLoginForm(
            string re_captcha_key = null,
            string user_password_input_id = "user_password_input_id",
            string user_password_repeat_input_id = "user_password_repeat_input_id",
            string user_login_input_id = "user_login_input_id",
            string reg_new_user_chekbox_id = "reg_new_user_chekbox_id",
            string button_send_login_form_id = "button_send_login_form_id",
            string collapse_info_new_user_input_css = "collapse_info_new_user_input")
        {
            List<base_dom_root> dom_elements = new List<base_dom_root>();

            form html_response = new form()
            {
                Id_DOM = "login_form_id",
                css_class = "was-validated",
                target = TargetsEnum._self,
                method_form = MethodsFormEnum.POST
            };
            html_response.SetAttribute("novalidate", null);

            BaseTextInput textInput = new BaseTextInput("Ваш логин", user_login_input_id) { InputInfoFooter = "Введите логин для входа" };
            textInput.Input.placeholder = "Логин";
            textInput.Input.required = true;
            html_response.Add(textInput);

            textInput = new BaseTextInput("Ваш пароль", user_password_input_id) { InputInfoFooter = "Пароль для входа" };
            textInput.Input.type = InputTypesEnum.password;
            textInput.Input.placeholder = "Пароль";
            html_response.Add(textInput);

            textInput = new BaseTextInput("Повторите пароль", user_password_repeat_input_id) { InputInfoFooter = "Повторно введите пароль" };
            textInput.Input.type = InputTypesEnum.password;
            textInput.Input.placeholder = "Повтор";
            textInput.css_class += " panel-collapse collapse " + collapse_info_new_user_input_css;
            html_response.Add(textInput);




            html_response.Childs[html_response.Childs.Count - 1].css_class += " panel-collapse collapse " + collapse_info_new_user_input_css;
            html_response.Childs.Add(new CheckboxInput("Зарегистрироваться", reg_new_user_chekbox_id));

            p reg_new_user_info = new p("") { css_class = "clearfix" };
            reg_new_user_info.Childs.Add(new ul() { css_class = "panel-collapse collapse " + collapse_info_new_user_input_css });
            reg_new_user_info.Childs[0].Childs.Add(new li() { InnerText = "Придумайте/запомните надёжный логин/пароль и входите" });
            reg_new_user_info.Childs[0].Childs.Add(new li() { InnerText = "Учётная запись будет создана автоматически" });

            html_response.Childs.Add(reg_new_user_info);
            if (!string.IsNullOrEmpty(re_captcha_key))
            {
                html_response.Childs.Add(new hr());
                html_response.Childs.Add(new h4("Пройдите проверку reCAPTCHA"));
                div sitekey = new div() { css_class = "g-recaptcha" };
                sitekey.SetAttribute("data-size", "compact");
                sitekey.SetAttribute("data-sitekey", re_captcha_key);
                html_response.Childs.Add(sitekey);
            }
            html_response.Childs.Add(GetButton("Войти", button_send_login_form_id, null, VisualBootstrapStylesEnum.primary, SizingBootstrap.Lg, true));

            dom_elements.Add(Get_DIV_Bootstrap_Card("Вход/Регистрация", html_response));
            return dom_elements;
        }

        /// <summary>
        /// Сформировать таблицу
        /// </summary>
        public static table GetTable(string[] table_heads, List<string[]> table_data, string css_table_class = "table table-hover")
        {
            table table = new table() { css_class = css_table_class.Trim() };

            foreach (string s in table_heads)
                table.Thead.AddColumn(s);

            foreach (string[] row_item in table_data)
                table.Tbody.AddRow(row_item);

            return table;
        }
    }
}
