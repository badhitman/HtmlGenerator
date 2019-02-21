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
