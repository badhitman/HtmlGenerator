////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    public class p_Supply : base_page_tmpl
    {
        /*
        public readonly exSupply SelectedSupply;
        public readonly bool is_bulk_insert = false;
        public p_Supply(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;
            
            is_bulk_insert = ServerController.CheckboxState(sender.post_params[GetPostParamsMetaClass.bulk_add_checkbox_input_id]);
            string selected_supply_id = sender.ID_Object_Сalling;

            string card_head = "<strong>Поступление на склад</strong>";

            SelectedSupply = ServerController.getSupplyById(selected_supply_id);

            user_form = new HtmlDomGenerator();

            sender.head.js_sources.Add("jQuery(document).ready(function () {jQuery(\"#" + g.GetMemberName((exSupply c) => c.Good_id) + "\").change(function () {jQuery(\"#" + g.GetMemberName((exSupply c) => c.Quantity) + "Help\").text(jQuery(\"#" + g.GetMemberName((exSupply c) => c.Good_id) + " option:selected\").attr(\"tag\"))});});");

            if (string.IsNullOrEmpty(selected_supply_id))
            {
                if (sender.post_params.Count == 0)
                {
                    #region Отобразить форму для создания нового объекта
                    card_head = "Создать " + card_head;
                    user_form = get_form(SelectedSupply, true);
                    #endregion
                }
                else if (sender.post_params.Count > 0)
                {
                    #region Запись нового объекта
                    SelectedSupply.ParsePostParam(sender.post_params);
                    if (!SelectedSupply.isCorrectFilling)
                    {
                        user_form = get_form(SelectedSupply);
                        //
                        sender.AddRangeNotifications(StatusNote.Danger, SelectedSupply.ErrorsOfCorrectness.ToArray());
                        SelectedSupply.ErrorsOfCorrectness.Clear();

                        user_form.Childs.Insert(0, new HtmlDomGenerator(HtmlDomGenerator.TypesHtmlDom.div, new Dictionary<string, string>() { { "role", "alert" } }) { text = "Ошибка сохранения!", css_class = "alert alert-danger" });
                    }
                    else
                    {
                        string[] bulk_supplies = new string[0];
                        if (!is_bulk_insert)
                            g.Supplyes_col.Insert(SelectedSupply);
                        else
                        {
                            bulk_supplies = SelectedSupply.Description.Split("\n");
                            foreach (string s in bulk_supplies)
                            {
                                SelectedSupply.ID = null;
                                SelectedSupply.Description = s.Trim();
                                g.Supplyes_col.Insert(SelectedSupply);
                                sender.AddNotification(StatusNote.Success, "Создан документ поступления <a href='/" + typeof(p_Supply).Name + "?id=" + SelectedSupply.ID.ToString() + "'>" + SelectedSupply.getFullName() + "</a>");
                            }
                        }
                        user_form = new HtmlDomGenerator() { css_class = "alert alert-light" };
                        user_form.CustomAtributes.Add("role", "alert");
                        user_form.Childs.Add(new HtmlDomGenerator(HtmlDomGenerator.TypesHtmlDom.h3) { text = "Сохранено", css_class = "text-center text-success" });
                        user_form.Childs.Add(HtmlDomGenerator.GetButtonAsLink("/" + typeof(p_List_Supplies).Name, "Вернуться в список"));

                        if (!is_bulk_insert)
                            user_form.Childs.Add(HtmlDomGenerator.GetButtonAsLink("/" + typeof(p_Supply).Name + "?id=" + SelectedSupply.ID.ToString(), "Открыть объект"));
                        else
                            user_form.Childs.Add(new HtmlDomGenerator(HtmlDomGenerator.TypesHtmlDom.h3) { text = "Добавлено объектов: " + bulk_supplies.Length.ToString() });
                    }
                    #endregion
                }
            }
            else
            {
                    #region Открыть/Сохранить существующий объект
                    if (!SelectedSupply.IsExist)
                    {
                        card_head = card_head + " [" + sender.ID_Object_Сalling + "] не найден!";
                        sender.AddNotification(StatusNote.Danger, "Ошибка в запросе. Объект с таким ID не обнаружен");
                        user_form = new HtmlDomGenerator() { css_class = "alert alert-light" };
                        user_form.CustomAtributes.Add("role", "alert");
                        user_form.Childs.Add(new HtmlDomGenerator(HtmlDomGenerator.TypesHtmlDom.h4) { text = "ОШИБКА", css_class = "text-center text-danger" });
                        user_form.Childs.Add(HtmlDomGenerator.GetButtonAsLink("/" + typeof(p_List_Supplies).Name, "Вернуться в список"));
                    }
                    else
                    {
                        SelectedSupply.ParsePostParam(sender.post_params);
                        if (!SelectedSupply.isCorrectFilling)
                            user_form.Childs.Insert(0, new HtmlDomGenerator(HtmlDomGenerator.TypesHtmlDom.div, new Dictionary<string, string>() { { "role", "alert" } }) { text = "Заполните все необходимые поля!", css_class = "alert alert-danger" });
                        else if (sender.post_params.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(SelectedSupply.Buyer_id))
                                SelectedSupply.Off = true;
                            g.Supplyes_col.Update(SelectedSupply);
                            sender.AddNotification(StatusNote.Success, "Объект сохранён!");
                        }

                        user_form = get_form(SelectedSupply);
                        
                        card_head += " - <u title='дата'>" + SelectedSupply.DateCreate().ToString("dd/MM/yy") + "</u> <small><sup title='время'>" + SelectedSupply.DateCreate().ToString("H:mm:ss") + " <abbr class='text-muted' title='часовой пояс'>" + SelectedSupply.DateCreate().ToString("zzz") + "</abbr></sup></small>";
                        if (!string.IsNullOrEmpty(SelectedSupply.Buyer_id))
                            card_head += " <a target='_blank' class='badge badge-primary' href='/" + typeof(p_List_Users).Name + "?id=" + SelectedSupply.Buyer_id + "'>Покупатель [#" + SelectedSupply.Buyer_id + "] // Продано: " + SelectedSupply.Sell_date.ToLongDateString() + "</a>";
                    }
                    #endregion
            }

            dom_elements.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card(card_head, new List<HtmlDomGenerator>() { user_form }));
        }/*

        /*public static HtmlDomGenerator get_form(exSupply SelectedSupply, bool bulk_add = false, bool def_elements = true)
        {
            if (SelectedSupply is null)
                SelectedSupply = new exSupply();

            HtmlDomGenerator good_form = new HtmlDomGenerator(HtmlDomGenerator.TypesHtmlDom.form) { form_method = "post", Id_DOM = GetPostParamsMetaClass.supply_form_id };
            good_form.CustomAtributes.Add("novalidate", null);
            HtmlDomGenerator row_input_groups = new HtmlDomGenerator() { css_class = "form-row" };

            HtmlDomGenerator col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            col_input_groups.Childs.Add(HtmlDomGenerator.GetSelectList(g.GetMemberName((exSupply c) => c.Good_id), "Товар", "Номенклатура", s_GoodsClass.GetCatalogTree, SelectedSupply.Good_id, false, true));
            row_input_groups.Childs.Add(col_input_groups);

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            col_input_groups.Childs.Add(HtmlDomGenerator.GetSelectList(g.GetMemberName((exSupply c) => c.Delivery_terms_id), "Город", "Город/Тип...", s_DeliveryClass.GetTreeDeliveryes, SelectedSupply.Delivery_terms_id, false, true));
            row_input_groups.Childs.Add(col_input_groups);

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            col_input_groups.Childs.Add(HtmlDomGenerator.GetSelectList(g.GetMemberName((exSupply c) => c.Delivery_service_id), "Курьер", "Служба...", s_DeliveryClass.GetListDeliveryesServices, SelectedSupply.Delivery_service_id, false, true));
            row_input_groups.Childs.Add(col_input_groups);

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };

            good_form.Childs.Add(row_input_groups);
            /////////////////////////
            //
            row_input_groups = new HtmlDomGenerator() { css_class = "form-row" };
            //
            row_input_groups.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Количество", SelectedSupply.Quantity.ToString(), g.GetMemberName((exSupply c) => c.Quantity), "", false, "Еденица измерения устанавливается в товаре", "col-md-3", null, null, true));
            row_input_groups.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Сумма", SelectedSupply.Price.ToString(), g.GetMemberName((exSupply c) => c.Price), "", false, "Цена <strong class='text-danger'>*</strong> Количество <strong class='text-danger'>+</strong> Доставка", "col-md-3", null, null, true));
            row_input_groups.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Цена доставки", SelectedSupply.Delivery_price.ToString(), g.GetMemberName((exSupply c) => c.Delivery_price), "", false, "Включена в цену товара", "col-md-3", null, null, true));
            good_form.Childs.Add(row_input_groups);
            //
            ////////////////////////
            good_form.Childs.Add(HtmlDomGenerator.GetTextarea("Описание (приватное)", SelectedSupply.Description, g.GetMemberName((exSupply c) => c.Description), false, 3, true));
            if (SelectedSupply.IsExist)
            {
                good_form.Childs.Add(HtmlDomGenerator.GetAttachmentsAsTable(ServerController.GetAttachmentsBySupply(SelectedSupply.ID.ToString())));
            }

            //
            if (def_elements)
            {
                good_form = SetDefInputs(good_form, SelectedSupply);
                good_form.Childs.Add(HtmlDomGenerator.GetButtonAsLink("/" + typeof(p_List_Supplies).Name, "Вернуться в список"));
            }
            if (bulk_add)
                good_form.Childs.Add(HtmlDomGenerator.GetCheckboxInput("Пакетное добавление", GetPostParamsMetaClass.bulk_add_checkbox_input_id));

            return good_form;
        }*/
    }
}