////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom;
using System.Collections.Generic;

namespace HtmlGenerator
{
    public enum ElementsStyles { Primary, Secondary, Success, Danger, Warning, Info, Light, Dark }
    public enum ElementsSizes { Lg, Sm }

    public static class predefined_elements_bootstrap
    {
        public static div GetBootstrapSelectList(string label, select select_body, string Tooltip = null, string wrap_class = "input-group mb-4 col-auto")
        {
            div ret_dom = new div() { css_class = wrap_class };

            if (!string.IsNullOrEmpty(label))
            {
                ret_dom.Childs.Add(new div { css_class = "input-group-prepend" });
                ret_dom.Childs[0].Childs.Add(new label(label, select_body.Id_DOM) { css_class = "input-group-text" });
            }
            select_body.css_class = (select_body.css_class.Trim() + " custom-select").Trim();

            if (!string.IsNullOrEmpty(Tooltip))
                ret_dom.Tooltip = Tooltip;

            ret_dom.SetAtribute("data-toggle", "tooltip");
            ret_dom.Childs.Add(select_body);
            return ret_dom;
        }

        /// <summary>
        /// Стандартная карточка/панель для размещения информации
        /// </summary>
        /// <param name="card_head">Заголовок карточки</param>
        /// <param name="body_elements">Элементы содержимого</param>
        /// <param name="css_card">Стиль офрмления карточки</param>
        /// <returns>Готовая карточка информации</returns>
        public static div Get_DIV_Bootstrap_Card(string card_head, List<basic_html_dom> body_elements, string css_card = "bg-light")
        {
            div card_header = new div() { css_class = "card-header", InnerText = card_head };

            div card_body = new div() { css_class = "card-body" };
            foreach (div he in body_elements)
                card_body.Childs.Add(he);

            div card_set = new div() { css_class = ("card " + css_card).Trim() };

            card_set.Childs.Add(card_header);
            card_set.Childs.Add(card_body);

            return card_set;
        }

        public static div Get_DIV_Bootstrap_Card(string card_head, basic_html_dom body_element, string css_card = "bg-light")
        {
            return Get_DIV_Bootstrap_Card(card_head, new List<basic_html_dom>() { body_element }, css_card);
        }

        #region Text - input
        public static div GetBaseTextInput(string label_text, string value_input, string Id_DOM, string placeholder, string input_info, string class_div_group_wrap = null, string label_css_class = null, string input_css_class = null, bool input_readonly = false, bool required = false)
        {
            div returned_input = new div() { css_class = ("form-group" + " " + class_div_group_wrap).Trim() };

            input.input_set input_set = new input.input_set();
            input_set.type_input = InputTypes.text;
            input_set.value = value_input;

            input ret_input = new input(input_set) { css_class = input_css_class };

            if (!string.IsNullOrEmpty(label_text))
                returned_input.Childs.Add(new label(label_text, Id_DOM) { css_class = label_css_class });

            if (required)
                ret_input.set.i_required = true;

            if (input_readonly)
                ret_input.set.i_readonly = true;

            ret_input.Id_DOM = Id_DOM;
            ret_input.Name_DOM = Id_DOM;
            ret_input.inline = true;
            ret_input.css_class = "form-control";

            if (!string.IsNullOrEmpty(placeholder))
                ret_input.SetAtribute("placeholder", placeholder);

            //
            returned_input.Childs.Add(ret_input);
            if (required)
                returned_input.Childs.AddRange(GetValidationAlerts(Id_DOM));

            if (!string.IsNullOrEmpty(input_info))
                returned_input.Childs.Add(new small(input_info)
                {
                    css_class = "form-text text-muted",
                    Id_DOM = Id_DOM + "Help"
                });

            return returned_input;
        }

        public static div GetSecondTextInput(string label_text, string value_input, string Id_DOM, string placeholder, bool input_readonly, string class_div_group_wrap = null, bool required = false)
        {
            span input_group_text = new span(label_text) { css_class = "input-group-text" };
            div input_group_prepend = new div() { css_class = "input-group-prepend" };
            input_group_prepend.Childs.Add(input_group_text);
            div input_group = new div() { css_class = ("input-group " + class_div_group_wrap).Trim() };
            input_group.Childs.Add(input_group_prepend);

            input.input_set input_set = new input.input_set();
            input_set.type_input = InputTypes.text;
            input_set.i_required = required;
            input_set.value = value_input;
            input_set.i_readonly = input_readonly;
            input ret_input = new input(input_set) { css_class = "form-control" };

            if (!string.IsNullOrEmpty(Id_DOM))
                ret_input.Id_DOM = Id_DOM;

            if (!string.IsNullOrEmpty(placeholder))
                ret_input.SetAtribute("placeholder", placeholder);

            input_group.Childs.Add(ret_input);
            if (required)
                input_group.Childs.AddRange(GetValidationAlerts(Id_DOM));

            return input_group;
        }
        #endregion

        public static div GetPassInput(string label_text, string Id_DOM, string placeholder, string input_info)
        {
            div ret_val = GetBaseTextInput(label_text, "", Id_DOM, placeholder, input_info, null, null, null, false, true);
            foreach (basic_html_dom e in ret_val.Childs)
                if (e is input)
                {
                    ((input)e).set.type_input = InputTypes.password;
                    break;
                }
            return ret_val;
        }

        public static div GetTextarea(string label_text, string value_input, string Id_DOM, bool input_readonly, int rows = 2, bool required = false)
        {
            div returned_input = new div() { css_class = "form-group" };
            if (!string.IsNullOrEmpty(label_text))
                returned_input.Childs.Add(new label(label_text, Id_DOM));

            textarea.set_textarea set_textarea = new textarea.set_textarea();
            set_textarea.required = required;
            set_textarea.Readonly = input_readonly;

            if (rows > 0)
                set_textarea.rows = rows;

            textarea ret_textarea = new textarea(value_input, set_textarea) { css_class = "form-control" };

            if (!string.IsNullOrEmpty(value_input))
                ret_textarea.InnerText = value_input;



            ret_textarea.Id_DOM = Id_DOM;
            ret_textarea.Name_DOM = Id_DOM;

            returned_input.Childs.Add(ret_textarea);

            return returned_input;
        }

        public static p GetCheckboxInput(string label_text, string Id_DOM, bool is_cheked = false, bool required = false)
        {
            div ret_val = new div() { css_class = "form-check" };
            //
            input.input_set input_set = new input.input_set();
            input_set.type_input = InputTypes.checkbox;

            input ret_input = new input(input_set);
            ret_input.css_class = "form-check-input";
            ret_input.Id_DOM = Id_DOM;

            if (is_cheked)
                ret_input.SetAtribute("checked", "true");

            if (required)
                ret_input.SetAtribute("required", null);

            ret_val.Childs.Add(ret_input);
            //
            input_set = new input.input_set();
            input_set.type_input = InputTypes.hidden;
            input_set.value = "off";
            ret_input = new input(input_set);
            ret_input.Name_DOM = Id_DOM;
            ret_val.Childs.Add(ret_input);
            //
            label label = new label(label_text, Id_DOM);
            label.css_class = "form-check-label";
            ret_val.Childs.Add(label);

            return new p(null) { Childs = new List<basic_html_dom>() { ret_val } };
        }

        public static div[] GetValidationAlerts(string validation_input_id, string invalid_text = "Укажите значение", string valid_text = null)
        {
            div valid_element = new div() { css_class = "valid-tooltip", InnerText = valid_text, Id_DOM = "valid-tooltip-" + validation_input_id };
            div invalid_element = new div() { css_class = "invalid-tooltip", InnerText = invalid_text, Id_DOM = "invalid-tooltip-" + validation_input_id };
            // 
            if (!string.IsNullOrEmpty(valid_text))
                return new div[] { valid_element, invalid_element };
            else
                return new div[] { invalid_element };
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
        public static button GetButton(string text, string id_button = null, string href = null, ElementsStyles? style = null, ElementsSizes? size = null, bool btn_block = false, bool outline_style = false)
        {
            button ret_button = new button(text) { css_class = "btn", Id_DOM = id_button };

            if (!(style is null))
                ret_button.css_class += " btn" + (outline_style ? "-outline-" : "-") + style?.ToString("g").ToLower();

            if (!(size is null))
                ret_button.css_class += " btn-" + size?.ToString("g").ToLower();

            ret_button.css_class += (btn_block ? " btn-block" : "") + " active";

            if (string.IsNullOrEmpty(href))
                ret_button.SetAtribute("type", "button");
            else
            {
                ret_button.SetTagName("a");
                ret_button.SetAtribute("href", href);
                ret_button.SetAtribute("role", "button");
                ret_button.SetAtribute("aria-pressed", "true");
            }

            return ret_button;
        }

        /// <summary>
        /// Сформировать модальное окно
        /// </summary>
        /// <param name="title">Заголовок модального окна</param>
        /// <param name="text_ok_button">Текст конопки Ok (если null or empty), то кнопка не выводится вовсе</param>
        /// <param name="id_ok_button">ID атрибут конопки Ok</param>
        /// <param name="text_cansel_button">Текст конопки Cansel (если null or empty), то кнопка не выводится вовсе</param>
        /// <param name="body_html">Тело модального окна</param>
        /// <param name="id_modal_dialog">ID атрибут модального окна</param>
        public static div GetModalDialog(string title, string text_ok_button, string text_cansel_button, basic_html_dom body_html, string id_modal_dialog = "exampleModal", string id_ok_button = "button_try_write")
        {
            span span_close_modal_header = new span("&times;");
            span_close_modal_header.SetAtribute("aria-hidden", "true");
            //
            button button_close_modal_header = new button(null) { css_class = "close" };
            button_close_modal_header.SetAtribute("data-dismiss", "modal");
            button_close_modal_header.SetAtribute("aria-label", "Close");
            button_close_modal_header.Childs.Add(span_close_modal_header);
            //
            h5 h5_modal_header = new h5(title) { css_class = "modal-title" };
            div div_modal_header = new div() { css_class = "modal-header" };
            div_modal_header.Childs.Add(h5_modal_header);
            div_modal_header.Childs.Add(button_close_modal_header);
            //
            div modal_footer = new div() { css_class = "modal-footer" };

            if (!string.IsNullOrEmpty(text_cansel_button))
            {
                button button_close_modal_footer = GetButton(text_cansel_button, null, null, ElementsStyles.Secondary);
                button_close_modal_footer.SetAtribute("data-dismiss", "modal");
                modal_footer.Childs.Add(button_close_modal_footer);
            }

            if (!string.IsNullOrEmpty(text_ok_button))
            {
                button button_send_modal_footer = GetButton(text_ok_button, null, "#", ElementsStyles.Primary);
                button_send_modal_footer.Id_DOM = id_ok_button;
                modal_footer.Childs.Add(button_send_modal_footer);
            }
            //
            div modal_content = new div() { css_class = "modal-content" };
            modal_content.Childs.Add(div_modal_header);
            //
            div modal_body = new div() { css_class = "modal-body" };
            modal_body.Childs.Add(body_html);
            modal_content.Childs.Add(modal_body);
            //
            modal_content.Childs.Add(modal_footer);
            //
            div modal_dialog_document = new div() { css_class = "modal-dialog" };


            modal_dialog_document.CustomAtributes.Add("role", "document");
            modal_dialog_document.Childs.Add(modal_content);
            //
            div ModalDialog = new div() { css_class = "modal fade", Id_DOM = id_modal_dialog };

            ModalDialog.CustomAtributes.Add("tabindex", "-1");
            ModalDialog.CustomAtributes.Add("role", "dialog");
            ModalDialog.CustomAtributes.Add("aria-labelledby", id_modal_dialog);
            ModalDialog.CustomAtributes.Add("aria-hidden", "true");

            ModalDialog.Childs.Add(modal_dialog_document);
            ModalDialog.prew_block_coment = "Modal dialog";
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
        public static List<basic_html_dom> GetLoginForm(string re_captcha_key = null, string user_password_input_id = "user_password_input_id", string user_password_repeat_input_id = "user_password_repeat_input_id", string user_login_input_id = "user_login_input_id", string reg_new_user_chekbox_id = "reg_new_user_chekbox_id", string button_send_login_form_id = "button_send_login_form_id", string collapse_info_new_user_input_css = "collapse_info_new_user_input")
        {
            List<basic_html_dom> dom_elements = new List<basic_html_dom>();
            form.form_set form_set = new form.form_set();
            form_set.method_form = MethodsForm.POST;
            form_set.target = Targets._self;

            form html_response = new form(form_set)
            {
                Id_DOM = "login_form_id",
                css_class = "was-validated"
            };
            html_response.SetAtribute("novalidate", null);

            html_response.Childs.Add(GetBaseTextInput("Ваш логин", "", user_login_input_id, "Логин", "Введите логин для входа", null, null, null, false, true));
            html_response.Childs.Add(GetPassInput("Ваш пароль", user_password_input_id, "Пароль", "Пароль для входа"));
            html_response.Childs.Add(GetPassInput("Повторите пароль", user_password_repeat_input_id, "Повтор пароля", "Повторно введите пароль"));
            html_response.Childs[html_response.Childs.Count - 1].css_class += " panel-collapse collapse " + collapse_info_new_user_input_css;
            html_response.Childs.Add(GetCheckboxInput("Зарегистрироваться", reg_new_user_chekbox_id));

            p reg_new_user_info = new p("") { css_class = "clearfix" };
            reg_new_user_info.Childs.Add(new ul() { css_class = "panel-collapse collapse " + collapse_info_new_user_input_css });
            reg_new_user_info.Childs[0].Childs.Add(new li("Придумайте/запомните надёжный логин/пароль и входите"));
            reg_new_user_info.Childs[0].Childs.Add(new li("Учётная запись будет создана автоматически"));

            html_response.Childs.Add(reg_new_user_info);
            if (!string.IsNullOrEmpty(re_captcha_key))
            {
                html_response.Childs.Add(new hr());
                html_response.Childs.Add(new h4("Пройдите проверку reCAPTCHA"));
                div sitekey = new div() { css_class = "g-recaptcha" };
                sitekey.SetAtribute("data-size", "compact");
                sitekey.SetAtribute("data-sitekey", re_captcha_key);
                html_response.Childs.Add(sitekey);
            }
            html_response.Childs.Add(GetButton("Войти", button_send_login_form_id, null, ElementsStyles.Primary, ElementsSizes.Lg, true));


            dom_elements.Add(Get_DIV_Bootstrap_Card("Вход/Регистрация", html_response));
            return dom_elements;
        }

        /// <summary>
        /// Сформировать таблицу
        /// </summary>
        public static table GetTable(string[] table_heads, List<string[]> table_data, string css_table_class = "table table-hover")
        {
            table table = new table() { css_class = ("table " + css_table_class).Trim() };

            foreach (string s in table_heads)
                table.Thead.AddColumn(s);

            foreach (string[] row_item in table_data)
                table.Tbody.AddRow(row_item);

            return table;
        }
    }
}
