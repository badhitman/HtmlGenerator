////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom;
using HtmlGenerator.set;

namespace HtmlGenerator
{
    public static class predefined_elements
    {
        public static select GetSelectList(string id_dom_element, OptionList ListItems, string selected_option_id = null, bool input_readonly = false, bool required = false)
        {
            select.select_set select_set = new select.select_set();

            select ret_select = new select(select_set) { Id_DOM = id_dom_element, Name_DOM = id_dom_element };

            if (string.IsNullOrEmpty(selected_option_id))
            {
                selected_option_id = "0";
                ListItems.ListItems.Insert(0, new OptionItem() { Disabled = true, Tag = "элемент-заглушка", Title = "Выберете значение", Tooltip = "Выберете значение", Value = "0" });
            }

            optgroup option_dom;
            foreach (OptionItem o_item in ListItems.ListItems)
            {
                if (o_item.Childs.Count > 0)
                {
                    optgroup.optgroup_set optgroup_set = new optgroup.optgroup_set();
                    optgroup_set.TitleText = o_item.Title;
                    optgroup_set.Disabled = o_item.Disabled;
                    //
                    option_dom = new optgroup(optgroup_set);


                    foreach (OptionItem sub_o_item in o_item.Childs)
                    {
                        option.option_set option_set = new option.option_set();
                        option_set.Disabled = sub_o_item.Disabled;
                        option_set.TitleText = sub_o_item.Title;
                        option_set.Value = sub_o_item.Value;

                        if (option_set.Value == selected_option_id)
                            option_set.Selected = true;

                        option sub_item = new option(option_set);

                        if (!string.IsNullOrEmpty(sub_o_item.Tag))
                            option_dom.SetAtribute("tag", sub_o_item.Tag);

                        option_dom.Childs.Add(sub_item);
                    }

                }
                else
                {
                    option.option_set option_set = new option.option_set();
                    option_set.TitleText = o_item.Title;
                    option_set.Disabled = o_item.Disabled;
                    option_set.Value = o_item.Value;
                    if (option_set.Value == selected_option_id)
                        option_set.Selected = true;
                    //
                    option_dom = new option(new option.option_set());
                }
                if (!string.IsNullOrEmpty(o_item.Tag))
                    option_dom.SetAtribute("tag", o_item.Tag);

                ret_select.Childs.Add(option_dom);
            }

            if (required)
                ret_select.SetAtribute("required", null);

            if (input_readonly)
                ret_select.CustomAtributes.Add("disabled", null);

            return ret_select;
        }

        /*
        /// <summary>
        /// Стандартная карточка/панель для размещения информации
        /// </summary>
        /// <param name="card_head">Заголовок карточки</param>
        /// <param name="body_elements">Элементы содержимого</param>
        /// <param name="css_card">Стиль офрмления карточки</param>
        /// <returns>Готовая карточка информации</returns>
        public static HtmlDomGenerator Get_DIV_Bootstrap_Card(string card_head, List<HtmlDomGenerator> body_elements, string css_card = "bg-light")
        {
            HtmlDomGenerator card_header = new HtmlDomGenerator() { css_class = "card-header", text = card_head };

            HtmlDomGenerator card_body = new HtmlDomGenerator() { css_class = "card-body" };
            foreach (HtmlDomGenerator he in body_elements)
                card_body.Childs.Add(he);

            HtmlDomGenerator card_set = new HtmlDomGenerator() { css_class = ("card " + css_card).Trim() };

            card_set.Childs.Add(card_header);
            card_set.Childs.Add(card_body);

            return card_set;
        }*/

        /*public static HtmlDomGenerator Get_DIV_Bootstrap_Card(string card_head, HtmlDomGenerator body_elements, string css_card = "bg-light")
        {
            return Get_DIV_Bootstrap_Card(card_head, new List<HtmlDomGenerator>() { body_elements }, css_card);
        }*/

        /*public static HtmlDomGenerator GetCheckboxInput(string label_text, string Id_DOM, bool is_cheked = false, bool required = false)
        {
            HtmlDomGenerator ret_val = new HtmlDomGenerator() { css_class = "form-check" };
            //
            HtmlDomGenerator input = new HtmlDomGenerator(TypesHtmlDom.input);
            input.obj_type = "checkbox";
            input.css_class = "form-check-input";
            input.Id_DOM = Id_DOM;

            if (is_cheked)
                input.CustomAtributes.Add("checked", "true");

            if (required)
                input.CustomAtributes.Add("required", null);

            ret_val.Childs.Add(input);
            //
            input = new HtmlDomGenerator(TypesHtmlDom.input);
            input.obj_type = "hidden";
            input.Name_DOM = Id_DOM;
            input.CustomAtributes.Add("value", "off");
            ret_val.Childs.Add(input);
            //
            HtmlDomGenerator label = new HtmlDomGenerator(TypesHtmlDom.label);
            label.css_class = "form-check-label";
            label._for = Id_DOM;
            label.text = label_text;
            ret_val.Childs.Add(label);

            return new HtmlDomGenerator(TypesHtmlDom.p) { Childs = new List<HtmlDomGenerator>() { ret_val } };
        }*/

        /*public static HtmlDomGenerator[] GetPassInput(string label_text, string Id_DOM, string placeholder, string input_info)
        {
            HtmlDomGenerator[] ret_val = GetBaseTextInput(label_text, "", Id_DOM, placeholder, false, input_info, null, null, null, true);
            foreach (HtmlDomGenerator _e in ret_val)
                foreach (HtmlDomGenerator e in _e.Childs)
                    if (e.TypeHtmlDom == TypesHtmlDom.input)
                        e.obj_type = "password";
            return ret_val;
        }*/

        /*public static HtmlDomGenerator[] GetBaseTextInput(string label_text, string value_input, string Id_DOM, string placeholder, bool input_readonly, string input_info, string class_div_group_wrap = null, string label_css_class = null, string input_css_class = null, bool required = false)
        {
            HtmlDomGenerator returned_input = new HtmlDomGenerator() { css_class = "form-group" + " " + class_div_group_wrap };

            if (!string.IsNullOrEmpty(label_text))
                returned_input.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.label) { text = label_text, _for = Id_DOM, css_class = label_css_class });

            HtmlDomGenerator input = new HtmlDomGenerator(TypesHtmlDom.input) { css_class = input_css_class };

            if (required)
                input.CustomAtributes.Add("required", null);

            if (input_readonly)
                input.CustomAtributes.Add("readonly", null);

            if (!string.IsNullOrEmpty(value_input))
                input.CustomAtributes.Add("value", value_input);

            input.Id_DOM = Id_DOM;
            input.Name_DOM = Id_DOM;
            input.inline = true;
            input.obj_type = "text";
            input.css_class = "form-control";

            if (!string.IsNullOrEmpty(placeholder))
                input.CustomAtributes.Add("placeholder", placeholder);


            //
            returned_input.Childs.Add(input);
            if (required)
                returned_input.Childs.AddRange(GetValidationAlerts(Id_DOM));

            if (!string.IsNullOrEmpty(input_info))
                returned_input.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.small)
                {
                    css_class = "form-text text-muted",
                    text = input_info,
                    Id_DOM = Id_DOM + "Help"
                });

            return new HtmlDomGenerator[] { returned_input };
        }*/

        /*public static HtmlDomGenerator GetSecondTextInput(string label_text, string value_input, string Id_DOM, string placeholder, bool input_readonly, string class_div_group_wrap = null, bool required = false)
        {
            HtmlDomGenerator input_group_text = new HtmlDomGenerator(TypesHtmlDom.span) { css_class = "input-group-text", text = label_text };
            HtmlDomGenerator input_group_prepend = new HtmlDomGenerator() { css_class = "input-group-prepend" };
            input_group_prepend.Childs.Add(input_group_text);
            HtmlDomGenerator input_group = new HtmlDomGenerator() { css_class = ("input-group " + class_div_group_wrap).Trim() };
            input_group.Childs.Add(input_group_prepend);
            HtmlDomGenerator input = new HtmlDomGenerator(TypesHtmlDom.input) { obj_type = "text", css_class = "form-control" };
            if (required)
                input.CustomAtributes.Add("required", null);

            input.CustomAtributes.Add("value", value_input);

            if (!string.IsNullOrEmpty(Id_DOM))
                input.Id_DOM = Id_DOM;

            if (!string.IsNullOrEmpty(placeholder))
                input.CustomAtributes.Add("placeholder", placeholder);

            if (input_readonly)
                input.CustomAtributes.Add("readonly", "");

            input_group.Childs.Add(input);
            if (required)
                input_group.Childs.AddRange(GetValidationAlerts(Id_DOM));

            return input_group;
        }*/

        /// <summary>
        /// Сформировать таблицу
        /// </summary>
        /*public static HtmlDomGenerator GetTable(string[] table_heads, List<string[]> table_data, string css_table_class = "table table-hover")
        {
            HtmlDomGenerator tr = new HtmlDomGenerator(TypesHtmlDom.tr);
            foreach (string s in table_heads)
                tr.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.th, new Dictionary<string, string>() { { "scope", "col" } }) { text = s });

            HtmlDomGenerator thead = new HtmlDomGenerator(TypesHtmlDom.thead);
            thead.Childs.Add(tr);

            HtmlDomGenerator table = new HtmlDomGenerator(TypesHtmlDom.table) { css_class = ("table " + css_table_class).Trim() };
            table.Childs.Add(thead);

            HtmlDomGenerator t_body = new HtmlDomGenerator(TypesHtmlDom.tbody);

            foreach (string[] row_item in table_data)
            {
                tr = new HtmlDomGenerator(TypesHtmlDom.tr);
                foreach (string s in row_item)
                {
                    //if (tr.Childs.Count == 0)
                    //    tr.Childs.Add(new HtmlController(html_types.th, new Dictionary<string, string>() { { "scope", "row" } }) { text = s });
                    //else
                    tr.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.td) { text = s });
                }
                t_body.Childs.Add(tr);
            }


            table.Childs.Add(t_body);

            return table;
        }*/

        /// <summary>
        /// Проверка состояния чекбокса
        /// </summary>
        /// <param name="str_state">Строковое представление состояния чекбокса</param>
        /// <returns>return (str_state == "on" || str_state == "yes" || str_state == "true" || str_state == "check" || str_state == "checked")</returns>
        /*public static bool CheckboxState(string str_state)
        {
            str_state = str_state.Trim().ToLower();
            return (str_state == "on" || str_state == "yes" || str_state == "true" || str_state == "check" || str_state == "checked");
        }*/

        /*public static HtmlDomGenerator GetTextarea(string label_text, string value_input, string Id_DOM, bool input_readonly, int rows = 2, bool required = false)
        {
            HtmlDomGenerator returned_input = new HtmlDomGenerator() { css_class = "form-group" };
            if (!string.IsNullOrEmpty(label_text))
                returned_input.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.label) { text = label_text, _for = Id_DOM });


            HtmlDomGenerator input = new HtmlDomGenerator(TypesHtmlDom.textarea) { css_class = "form-control" };
            if (required)
                input.CustomAtributes.Add("required", null);

            if (input_readonly)
                input.CustomAtributes.Add("readonly", null);

            if (rows > 0)
                input.CustomAtributes.Add("rows", rows.ToString());

            if (!string.IsNullOrEmpty(value_input))
                input.text = value_input;

            input.Id_DOM = Id_DOM;
            input.Name_DOM = Id_DOM;

            returned_input.Childs.Add(input);
            if (required)
                returned_input.Childs.AddRange(GetValidationAlerts(Id_DOM));
            return returned_input;
        }*/

        /*public static HtmlDomGenerator GetButton(string href, string text, StylesElements style = StylesElements.Primary)
        {
            return new HtmlDomGenerator(TypesHtmlDom.button)
            {
                href = href,
                css_class = "btn btn-" + style.ToString("g").ToLower() + " btn-lg btn-block active",
                text = text,
                CustomAtributes = new Dictionary<string, string>()
                {
                    { "role", "button" },
                    { "aria-pressed", "true" }
                }
            };
        }*/

        /*public static HtmlDomGenerator GetButtonAsLink(string href, string text, StylesElements style = StylesElements.Primary)
        {
            HtmlDomGenerator ret_button = GetButton(href, text, style);
            ret_button.TypeHtmlDom = TypesHtmlDom.a;
            return new HtmlDomGenerator(TypesHtmlDom.a)
            {
                href = href,
                css_class = "btn btn-" + style.ToString("g").ToLower() + " btn-lg btn-block active",
                text = text,
                CustomAtributes = new Dictionary<string, string>()
                {
                    { "role", "button" },
                    { "target", "_blank" },
                    { "aria-pressed", "true" }
                }
            };
        }*/

        /*public static HtmlDomGenerator GetModalDialog(string title, string text_ok_button, string text_cansel_button, HtmlDomGenerator body_html, string id_modal_dialog = "exampleModal")
        {
            HtmlDomGenerator span_close_modal_header = new HtmlDomGenerator(TypesHtmlDom.span) { text = "&times;" };
            span_close_modal_header.CustomAtributes.Add("aria-hidden", "true");
            //
            HtmlDomGenerator button_close_modal_header = new HtmlDomGenerator(TypesHtmlDom.button) { obj_type = "button", css_class = "close" };
            button_close_modal_header.CustomAtributes.Add("data-dismiss", "modal");
            button_close_modal_header.CustomAtributes.Add("aria-label", "Close");
            button_close_modal_header.Childs.Add(span_close_modal_header);
            //
            HtmlDomGenerator h5_modal_header = new HtmlDomGenerator(TypesHtmlDom.h5) { text = title, css_class = "modal-title" };
            HtmlDomGenerator div_modal_header = new HtmlDomGenerator() { css_class = "modal-header" };
            div_modal_header.Childs.Add(h5_modal_header);
            div_modal_header.Childs.Add(button_close_modal_header);

            //
            HtmlDomGenerator button_close_modal_footer = new HtmlDomGenerator(TypesHtmlDom.button) { obj_type = "button", css_class = "btn btn-secondary", text = text_cansel_button };
            button_close_modal_footer.CustomAtributes.Add("data-dismiss", "modal");
            //
            HtmlDomGenerator button_send_modal_footer = new HtmlDomGenerator(TypesHtmlDom.a) { obj_type = "button", css_class = "btn btn-primary", text = text_ok_button, Id_DOM = GetPostParamsMetaClass.button_try_create_document_id };
            //
            HtmlDomGenerator modal_footer = new HtmlDomGenerator() { css_class = "modal-footer" };

            if (!string.IsNullOrEmpty(text_cansel_button))
                modal_footer.Childs.Add(button_close_modal_footer);

            if (!string.IsNullOrEmpty(text_ok_button))
                modal_footer.Childs.Add(button_send_modal_footer);
            //
            HtmlDomGenerator modal_content = new HtmlDomGenerator() { css_class = "modal-content" };
            modal_content.Childs.Add(div_modal_header);
            //
            HtmlDomGenerator modal_body = new HtmlDomGenerator() { css_class = "modal-body" };
            modal_body.Childs.Add(body_html);
            modal_content.Childs.Add(modal_body);
            //
            modal_content.Childs.Add(modal_footer);
            //
            HtmlDomGenerator modal_dialog_document = new HtmlDomGenerator() { css_class = "modal-dialog" };


            modal_dialog_document.CustomAtributes.Add("role", "document");
            modal_dialog_document.Childs.Add(modal_content);
            //
            HtmlDomGenerator ModalDialog = new HtmlDomGenerator() { css_class = "modal fade", Id_DOM = id_modal_dialog };

            ModalDialog.CustomAtributes.Add("tabindex", "-1");
            ModalDialog.CustomAtributes.Add("role", "dialog");
            ModalDialog.CustomAtributes.Add("aria-labelledby", id_modal_dialog);
            ModalDialog.CustomAtributes.Add("aria-hidden", "true");

            ModalDialog.Childs.Add(modal_dialog_document);
            ModalDialog.coment = "Modal dialog";
            return ModalDialog;
        }*/

        /*public static HtmlDomGenerator[] GetValidationAlerts(string validation_input_id, string invalid_text = "Укажите значение", string valid_text = null)
        {
            HtmlDomGenerator valid_element = new HtmlDomGenerator() { css_class = "valid-tooltip", text = valid_text, Id_DOM = "valid-tooltip-" + validation_input_id };
            HtmlDomGenerator invalid_element = new HtmlDomGenerator() { css_class = "invalid-tooltip", text = invalid_text, Id_DOM = "invalid-tooltip-" + validation_input_id };
            // 
            if (!string.IsNullOrEmpty(valid_text))
                return new HtmlDomGenerator[] { valid_element, invalid_element };
            else
                return new HtmlDomGenerator[] { invalid_element };
        }*/

        /*public static List<HtmlDomGenerator> GetLoginForm()
        {
            List<HtmlDomGenerator> dom_elements = new List<HtmlDomGenerator>();
            HtmlDomGenerator html_response = new HtmlDomGenerator(TypesHtmlDom.form)
            {
                Id_DOM = GetPostParamsMetaClass.login_form_id,
                form_method = "POST",
                css_class = "was-validated"
            };
            html_response.CustomAtributes.Add("novalidate", null);

            html_response.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Ваш логин", "", GetPostParamsMetaClass.user_login, "Логин", false, "Введите логин для входа", null, null, null, true));
            html_response.Childs.AddRange(HtmlDomGenerator.GetPassInput("Ваш пароль", GetPostParamsMetaClass.user_password, "Пароль", "Пароль для входа"));
            html_response.Childs.AddRange(HtmlDomGenerator.GetPassInput("Повторите пароль", GetPostParamsMetaClass.user_password_r, "Повтор пароля", "Повторно введите пароль"));
            html_response.Childs[html_response.Childs.Count - 1].css_class += " panel-collapse collapse " + GetPostParamsMetaClass.collapse_info_new_user;
            html_response.Childs.Add(HtmlDomGenerator.GetCheckboxInput("Зарегистрироваться", GetPostParamsMetaClass.reg_new_user_chekbox_id));

            HtmlDomGenerator reg_new_user_info = new HtmlDomGenerator(TypesHtmlDom.p) { css_class = "clearfix" };
            reg_new_user_info.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.ul) { css_class = "panel-collapse collapse " + GetPostParamsMetaClass.collapse_info_new_user });
            reg_new_user_info.Childs[0].Childs.Add(new HtmlDomGenerator(TypesHtmlDom.li) { text = "Придумайте/запомните надёжный логин/пароль и входите" });
            reg_new_user_info.Childs[0].Childs.Add(new HtmlDomGenerator(TypesHtmlDom.li) { text = "Учётная запись будет создана автоматически" });

            html_response.Childs.Add(reg_new_user_info);
            if (g.Settings.enable_captcha)
            {
                html_response.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.hr));
                html_response.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.h4) { text = "Пройдите проверку reCAPTCHA" });
                html_response.Childs.Add(new HtmlDomGenerator()
                {
                    css_class = "g-recaptcha",
                    CustomAtributes = new Dictionary<string, string>() { { "data-sitekey", g.Settings.re_captcha_key }, { "data-size", "compact" } }
                });
            }
            html_response.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.button)
            {
                css_class = "btn btn-primary btn-lg btn-block",
                Id_DOM = GetPostParamsMetaClass.button_send_login_form_id,
                text = "Войти"
            });


            dom_elements.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card("Вход/Регистрация", new List<HtmlDomGenerator>() { html_response }));
            return dom_elements;
        }*/

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
