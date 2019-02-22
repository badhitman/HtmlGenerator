////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom;
using System.Collections.Generic;

namespace HtmlGenerator
{
    public enum StylesElements { Primary, Secondary, Success, Danger, Warning, Info, Light, Dark }
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

        public static div GetBaseTextInput(string label_text, string value_input, string Id_DOM, string placeholder, bool input_readonly, string input_info, string class_div_group_wrap = null, string label_css_class = null, string input_css_class = null, bool required = false)
        {
            div returned_input = new div() { css_class = "form-group" + " " + class_div_group_wrap };

            if (!string.IsNullOrEmpty(label_text))
                returned_input.Childs.Add(new label(label_text, Id_DOM) { css_class = label_css_class });

            input.input_set input_set = new input.input_set();
            input_set.type_input = InputTypes.text;
            input_set.value = value_input;

            input ret_input = new input(input_set) { css_class = input_css_class };

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

        public static div GetPassInput(string label_text, string Id_DOM, string placeholder, string input_info)
        {
            div ret_val = GetBaseTextInput(label_text, "", Id_DOM, placeholder, false, input_info, null, null, null, true);
            foreach (basic_html_dom e in ret_val.Childs)
                if (e is input)
                {
                    ((input)e).set.type_input = InputTypes.password;
                    break;
                }
            return ret_val;
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

        public static button GetButton(string href, string text, StylesElements style = StylesElements.Primary)
        {
            button ret_button = new button(text) { css_class = "btn btn-" + style.ToString("g").ToLower() + " btn-lg btn-block active" };
            ret_button.SetAtribute("href", href);
            ret_button.SetAtribute("role", "button");
            ret_button.SetAtribute("aria-pressed", "true");

            return ret_button;
        }

        public static a GetButtonAsLink(string href, string text, StylesElements style = StylesElements.Primary)
        {
            a.a_set a_set = new a.a_set();
            a_set.href = href;
            a_set.target = Targets._self;
            a_set.text = text;
            a ret_button = new a(a_set);
            ret_button.SetAtribute("role", "button");
            ret_button.SetAtribute("aria-pressed", "true");
            ret_button.css_class = "btn btn-" + style.ToString("g").ToLower() + " btn-lg btn-block active";
            return ret_button;
        }

        public static div GetModalDialog(string title, string text_ok_button, string text_cansel_button, basic_html_dom body_html, string id_modal_dialog = "exampleModal", string id_ok_button = "button_try_create_document_id")
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
            button button_close_modal_footer = new button(text_cansel_button) { css_class = "btn btn-secondary" };
            button_close_modal_footer.SetAtribute("data-dismiss", "modal");
            //
            a.a_set a_set = new a.a_set();
            a_set.text = text_ok_button;
            a button_send_modal_footer = new a(a_set) { css_class = "btn btn-primary", Id_DOM = id_ok_button };
            button_send_modal_footer.SetAtribute("type", "button");
            //
            div modal_footer = new div() { css_class = "modal-footer" };

            if (!string.IsNullOrEmpty(text_cansel_button))
                modal_footer.Childs.Add(button_close_modal_footer);

            if (!string.IsNullOrEmpty(text_ok_button))
                modal_footer.Childs.Add(button_send_modal_footer);
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

        public static List<basic_html_dom> GetLoginForm(string re_captcha_key = null)
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

            html_response.Childs.Add(GetBaseTextInput("Ваш логин", "", glob_const.user_login_input_id, "Логин", false, "Введите логин для входа", null, null, null, true));
            html_response.Childs.Add(GetPassInput("Ваш пароль", glob_const.user_password_input_id, "Пароль", "Пароль для входа"));
            html_response.Childs.Add(GetPassInput("Повторите пароль", glob_const.user_password_repeat_input_id, "Повтор пароля", "Повторно введите пароль"));
            html_response.Childs[html_response.Childs.Count - 1].css_class += " panel-collapse collapse " + glob_const.collapse_info_new_user_input_css;
            html_response.Childs.Add(GetCheckboxInput("Зарегистрироваться", glob_const.reg_new_user_chekbox_id));

            p reg_new_user_info = new p("") { css_class = "clearfix" };
            reg_new_user_info.Childs.Add(new ul() { css_class = "panel-collapse collapse " + glob_const.collapse_info_new_user_input_css });
            reg_new_user_info.Childs[0].Childs.Add(new li("Придумайте/запомните надёжный логин/пароль и входите"));
            reg_new_user_info.Childs[0].Childs.Add(new li("Учётная запись будет создана автоматически"));

            html_response.Childs.Add(reg_new_user_info);
            if (!string.IsNullOrEmpty(re_captcha_key))
            {
                html_response.Childs.Add(new hr());
                html_response.Childs.Add(new h4("Пройдите проверку reCAPTCHA"));
                div sitekey = new div() { css_class = "g-recaptcha"};
                sitekey.SetAtribute("data-size", "compact");
                sitekey.SetAtribute("data-sitekey", re_captcha_key);
                html_response.Childs.Add(sitekey);
            }
            html_response.Childs.Add(new button("Войти")
            {
                css_class = "btn btn-primary btn-lg btn-block",
                Id_DOM = glob_const.button_send_login_form_id
            });


            dom_elements.Add(Get_DIV_Bootstrap_Card("Вход/Регистрация", html_response));
            return dom_elements;
        }

        /// <summary>
        /// Сформировать таблицу
        /// </summary>
        public static table GetTable(string[] table_heads, List<string[]> table_data, string css_table_class = "table table-hover")
        {
            table table = new table() { css_class = ("table " + css_table_class).Trim() };
            tbody t_body = new tbody();
            tr ret_tr = new tr();

            foreach (string s in table_heads)
                table.Thead.SetTableHeader(s);

            foreach (string[] row_item in table_data)
            {
                ret_tr = new tr();
                foreach (string s in row_item)
                    ret_tr.Childs.Add(new td() { InnerText = s });

                t_body.Childs.Add(ret_tr);
            }
            table.Childs.Add(t_body);

            return table;
        }

        /*public static HtmlDomGenerator GetOrdersAsTable(List<exSupply> supplies)
        {
            string[] t_heads = new string[] { "<span class='glyphicon glyphicon-calendar'></span>", "<span class='glyphicon glyphicon-transfer'></span>", "Документ" };
            List<string[]> table_body = new List<string[]>();

            exGood curr_good_item;
            exDeliveryTerms curr_del_terms_item;
            OptionItem curr_unit_good_item;
            //
            foreach (exSupply supply_item in supplies)
            {
                curr_good_item = ServerController.getGoodById(supply_item.Good_id.ToString());
                curr_del_terms_item = ServerController.getDeliveryTermById(supply_item.Delivery_terms_id);
                curr_unit_good_item = s_GoodUnitsClass.GetUnit(curr_good_item.Unit);
                table_body.Add(new string[]
                {
                        "<a title='Дата продажи' href='./" + typeof(p_Orders).Name + "?buy" + "=" + supply_item.ID + "'>" + supply_item.Sell_date.ToString(g.date_format) + " <small style='color:#838383;'>" + supply_item.Sell_date.ToString(g.time_format) + "</small>",
                        "<span class='glyphicon glyphicon-minus'></span> " + supply_item.Price,
                        "<a href='./" + typeof(p_Orders).Name + "?buy" + "=" + supply_item.ID + "'>" + curr_good_item.Name + " " + supply_item.Quantity + " " + s_GoodUnitsClass.GetUnit(curr_good_item.Unit).Name + " // " + supply_item.Price.ToString() + " " + supply_item.City().Name + " " + supply_item.DeliveryTerms().Name + "</a>"

                });
            }
            return GetTable(t_heads, table_body, "table-hover");
        }*/

        /*public static HtmlDomGenerator GetAttachmentsAsTable(List<exTelegramLog> Attachments)
        {
            string attach_item_data_html;
            //
            HtmlDomGenerator filter_form = new HtmlDomGenerator(TypesHtmlDom.form) { form_method = "GET", css_class = "form-inline" };
            HtmlDomGenerator diw_row = new HtmlDomGenerator() { css_class = "form-row align-items-left" };
            string[] t_heads = new string[] { "\t<span class='glyphicon glyphicon-calendar'></span>", "\tВложение" };
            List<string[]> table_body = new List<string[]>();

            TelegramDataTypes typeRow;
            string obj_id = "";
            foreach (exTelegramLog attach_item in Attachments)
            {
                typeRow = attach_item.typeRow;
                attach_item_data_html = "";
                //
                obj_id = attach_item.ID.ToString();
                switch (typeRow)
                {
                    case TelegramDataTypes.Photo:
                        PhotoSizeClass[] photos = ((PhotoSizeClass[])g.DeSerialiseJSON(typeof(PhotoSizeClass[]), attach_item.Attachment)).OrderBy(c => c.file_size).ToArray();
                        PhotoSizeClass meta_photo_small = photos[0];
                        PhotoSizeClass meta_photo_big = photos[photos.Length - 1];
                        attach_item_data_html += "\t<span class='glyphicon glyphicon-picture'></span> \n\t<img id='" + attach_item.ID + "' class='img-thumbnail telegram-attach' type-attach='photo' full-image-id=\"" + meta_photo_big.file_id + "\" class='img-thumbnail telegram-attach' src='/photos-storage/" + meta_photo_small.file_id + ".jpeg?" + GetPostParamsMetaClass.is_cloud + "=true' /> \n\t<span class='badge badge-light'> " + meta_photo_big.file_size + " bytes</span>";
                        break;
                    case TelegramDataTypes.Video:
                        VideoClass telegram_video = (VideoClass)g.DeSerialiseJSON(typeof(VideoClass), attach_item.Attachment);
                        attach_item_data_html += "\t<span class='glyphicon glyphicon-facetime-video'></span> \n\t<img id='" + attach_item.ID + "' class='img-thumbnail telegram-attach' type-attach='video' video-height='" + telegram_video.height + "' video-width='" + telegram_video.width + "' video-file-id='" + telegram_video.file_id + "' class='img-thumbnail telegram-attach' src='./" + telegram_video.thumb.file_id + ".jpeg?" + GetPostParamsMetaClass.is_cloud + "=true' /> \n\t<span class='badge badge-light'> " + telegram_video.file_size + " bytes</span>";
                        break;
                    case TelegramDataTypes.Location:
                        LocationClass curr_location = (LocationClass)g.DeSerialiseJSON(typeof(LocationClass), attach_item.Attachment);
                        attach_item_data_html += "\t<span class='glyphicon glyphicon-map-marker'></span> \n\t<a id='" + attach_item.ID + "' class='img-thumbnail telegram-attach' href='https://yandex.ru/maps/?mode=search&z=7&text=" + curr_location.ToString() + "' target='_blank' type-attach='location' location='" + curr_location.ToString() + "' class='img-thumbnail telegram-attach'>" + curr_location.ToString() + "</a>";
                        break;
                    case TelegramDataTypes.Text:
                        attach_item_data_html += "\t<span class='glyphicon glyphicon-font'></span> \n\t<strong id='" + attach_item.ID + "' class='img-thumbnail telegram-attach' type-attach='text' class='telegram-attach'>" + attach_item.Attachment + "</strong>";
                        break;
                    default:
                        DocumentClass curr_document = (DocumentClass)g.DeSerialiseJSON(typeof(DocumentClass), attach_item.Attachment);
                        attach_item_data_html += "\t<span class='glyphicon glyphicon-floppy-disk'></span> \n\t<img id='" + attach_item.ID + "' style='max-width: 100px;' class='img-thumbnail telegram-attach' type-attach='file' file-id='" + curr_document.file_id + "' class='img-thumbnail telegram-attach' src='" + (curr_document.thumb != null ? "./" + curr_document.thumb.file_id + ".jpeg?" + GetPostParamsMetaClass.is_cloud + "=true" : ASSystem.Properties.Resources.mushroom_image_bade64) + "' /> - " + curr_document.file_name + " \n\t<span class='badge badge-light'>" + curr_document.file_size + " bytes</span> \n\t<a href='./file-storage/" + curr_document.file_id + ".bin?" + GetPostParamsMetaClass.is_cloud + "=true'>Скачать файл</a>";
                        break;
                }
                bool file_is_saved = g.db.FileStorage.Exists(obj_id); ;
                // import

                table_body.Add(new string[]
                {
                    "\t<div tag='" + attach_item.ID + "' class='attach-header'><span title='Дата поступления вложения'>" + attach_item.DateCreate().ToString(g.date_format) + "</span> \n\t<small style='color:#838383;'>" + attach_item.DateCreate().ToString(g.time_format) + "</small>" + " \n\t<sup style='color: #7b7d3e;' title='с даты создания прошло дней'>~ " + ((int)DateTime.Now.Subtract(attach_item.DateCreate()).TotalDays).ToString() + "</sup> <button type='button' class='btn btn-" + (file_is_saved ? "success" : "outline-secondary") + " btn-sm glyphicon glyphicon-" + (file_is_saved ? "export" : "import") + "' title='" + (file_is_saved ? "выгрузить файл из базы данных" : "загрузить файл в базу данных") + "'> </button> </div>",
                    attach_item_data_html
                });
            }
            int count_rows = Attachments.Count;
            return GetTable(t_heads, table_body, "table-hover" + (count_rows > 0 ? "" : " text-muted"));
        }*/
    }
}
