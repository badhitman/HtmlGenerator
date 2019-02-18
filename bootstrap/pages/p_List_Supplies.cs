////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////

namespace DataViewHtml.bootstrap.pages
{
    /// <summary>
    /// Список поставок
    /// </summary>
    public class p_List_Supplies : base_page_tmpl
    {
        /*
        public readonly exGood sel_good;
        public readonly exDeliveryTerms sel_del_terms;
        public readonly exDeliveryService sel_del_service;
        public readonly StatusSupply selected_status_supply;
        //
        public readonly DateTime d_from_date = DateTime.MinValue;
        public readonly DateTime d_to_date = DateTime.MaxValue;

        public p_List_Supplies(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;

            // sender.head.js_sources.Add("jQuery(document).ready(function () {jQuery(\"#" + g.GetMemberName((exSupply c) => c.Good_id) + "\").change(function () {jQuery(\"#" + g.GetMemberName((exSupply c) => c.Quantity) + "Help\").text(jQuery(\"#" + g.GetMemberName((exSupply c) => c.Good_id) + " option:selected\").attr(\"tag\"))});});");
            // <input style='margin-left: 10px;' type='checkbox' class='form-check-input' tag='" + obj_id + "'/>

            ///////////////////////////////////////
            // goods // Номенклатура
            string prop_value = sender.get_params[g.GetMemberName((exSupply c) => c.Good_id)];
            if (string.IsNullOrEmpty(prop_value))
                sel_good = new exGood() { Name = "не выбрано", Information = "фильтр условий Номенклатуры не установлен" };
            else
                sel_good = ServerController.getGoodById(prop_value);

            ///////////////////////////////////////
            // delivery-terms // условия доставки
            prop_value = sender.get_params[g.GetMemberName((exSupply c) => c.Delivery_terms_id)];
            if (string.IsNullOrEmpty(prop_value))
                sel_del_terms = new exDeliveryTerms() { Name = "не выбрано", Information = "фильтр условий доставки не установлен" };
            else
                sel_del_terms = ServerController.getDeliveryTermById(prop_value);

            ///////////////////////////////////////
            // delivery-service // Службы доставки
            prop_value = sender.get_params[g.GetMemberName((exSupply c) => c.Delivery_service_id)];
            if (string.IsNullOrEmpty(prop_value))
                sel_del_service = new exDeliveryService() { Name = "не выбрано", Information = "фильтр служб доставки не установлен" };
            else
                sel_del_service = ServerController.getDeliveryServiceById(prop_value);

            ///////////////////////////////////////
            // status supply // статус документа {продано или нет}
            selected_status_supply = StatusSupply.All;
            string pre_value_string = sender.get_params[GetPostParamsMetaClass.status_supply_id];
            int pre_value_int = -1;

            if (!string.IsNullOrEmpty(pre_value_string) && int.TryParse(pre_value_string, out pre_value_int))
            {
                switch (pre_value_int)
                {
                    case 0:
                        selected_status_supply = StatusSupply.Available;
                        break;
                    case 1:
                        selected_status_supply = StatusSupply.Sold;
                        break;
                    default:
                        selected_status_supply = StatusSupply.All;
                        break;
                }

            }
            string format_date = "dd.MM.yyyy";
            //
            if (!string.IsNullOrEmpty(sender.get_params[GetPostParamsMetaClass.from_date_id]))
            {
                string from_date = sender.get_params[GetPostParamsMetaClass.from_date_id].Trim();
                if (!DateTime.TryParseExact(from_date, format_date, CultureInfo.InvariantCulture, DateTimeStyles.None, out d_from_date))
                    d_from_date = DateTime.MinValue;
            }

            if (!string.IsNullOrEmpty(sender.get_params[GetPostParamsMetaClass.to_date_id]))
            {
                string to_date = sender.get_params[GetPostParamsMetaClass.to_date_id].Trim();
                if (!DateTime.TryParseExact(to_date, format_date, CultureInfo.InvariantCulture, DateTimeStyles.None, out d_to_date))
                    d_to_date = DateTime.MaxValue;
            }

            if (d_from_date > d_to_date)
                d_from_date = d_to_date;

            string card_head = "<strong>Наличие товара</strong>";



            dom_elements.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card(card_head, GetCatalog()));
        }*/

        /*public List<HtmlDomGenerator> GetCatalog()
        {
            List<HtmlDomGenerator> added_dom = new List<HtmlDomGenerator>();
            HtmlDomGenerator filter_form = new HtmlDomGenerator(TypesHtmlDom.form) { form_method = "GET", css_class = "form-inline" };

            HtmlDomGenerator diw_row = new HtmlDomGenerator() { css_class = "form-row align-items-left" };

            ///////////////////////////////////////
            // goods // Номенклатура
            List<OptionItem> goods = s_GoodsClass.GetCatalogTree;
            goods.Insert(0, new OptionItem() { Name = "Все", value = "-1", Disabled = false, Description = "Отобразить все товары" });
            //
            diw_row.Childs.Add(HtmlDomGenerator.GetSelectList(g.GetMemberName((exSupply c) => c.Good_id), "Товар", "Номенклатура", goods, sel_good.ID is null ? "" : sel_good.ID.ToString()));

            ///////////////////////////////////////
            // delivery-terms // Условия доставки
            List<OptionItem> Deliveryes = s_DeliveryClass.GetTreeDeliveryes;
            Deliveryes.Insert(0, new OptionItem() { Name = "Все", value = g.int_to_hex_24_string(-1), Disabled = false, Description = "Отобразить все Города/Типы" });
            //
            diw_row.Childs.Add(HtmlDomGenerator.GetSelectList(g.GetMemberName((exSupply c) => c.Delivery_terms_id), "Город", "Город/Условия", Deliveryes, sel_del_terms.ID is null ? "" : sel_del_terms.ID.ToString()));

            ///////////////////////////////////////
            // delivery-service //
            List<OptionItem> d_services = s_DeliveryClass.GetListDeliveryesServices;
            d_services.Insert(0, new OptionItem() { Name = "Все", value = g.int_to_hex_24_string(-1), Disabled = false, Description = "Отобразить все службы доставки" });
            //
            diw_row.Childs.Add(HtmlDomGenerator.GetSelectList(g.GetMemberName((exSupply c) => c.Delivery_service_id), "Доставка", "Служба доставки", d_services, sel_del_service.ID is null ? "" : sel_del_service.ID.ToString()));

            ///////////////////////////////////////
            // status supply //
            List<OptionItem> filter_statuses = new List<OptionItem>();
            filter_statuses.Add(new OptionItem() { value = "-1", Name = "Все", Description = "Отобразить все" });
            filter_statuses.Add(new OptionItem() { value = "0", Name = "Наличие", Description = "Отобразить не проданое" });
            filter_statuses.Add(new OptionItem() { value = "1", Name = "Продано", Description = "Отобразить проданое" });

            diw_row.Childs.Add(HtmlDomGenerator.GetSelectList(GetPostParamsMetaClass.status_supply_id, "Статус", "Фильтр", filter_statuses, ((int)selected_status_supply).ToString()));
            filter_form.Childs.Add(diw_row);
            diw_row = new HtmlDomGenerator() { css_class = "form-row align-items-left" };

            ///////////////////////////////////////
            // Текстовый поиск по всем полям
            HtmlDomGenerator query_input = HtmlDomGenerator.GetBaseTextInput("", sender.QuerySearchUser, GetPostParamsMetaClass.user_search_query, "Поиск по всем полям", false, "Описание/Комментарий/Покупатель", "")[0];
            query_input.css_class = "col-auto";
            diw_row.Childs.Add(query_input);

            ///////////////////////////////////////
            // Интервал дат
            query_input = HtmlDomGenerator.GetBaseTextInput("", sender.get_params[GetPostParamsMetaClass.from_date_id], GetPostParamsMetaClass.from_date_id, "01.01.1990", false, "дата создания 'от'", "")[0];
            query_input.css_class = "col-auto";
            diw_row.Childs.Add(query_input);
            //
            query_input = HtmlDomGenerator.GetBaseTextInput("", sender.get_params[GetPostParamsMetaClass.to_date_id], GetPostParamsMetaClass.to_date_id, "31.12.3010", false, "дата создания 'до'", "")[0];
            query_input.css_class = "col-auto";
            diw_row.Childs.Add(query_input);

            ///////////////////////////////////////
            // Кнопка поиска
            HtmlDomGenerator button_submit = new HtmlDomGenerator() { css_class = "col-auto" };
            button_submit.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.button) { css_class = "btn btn-primary mb-4", text = "Поиск", CustomAtributes = new Dictionary<string, string>() { { "type", "submit" } } });
            diw_row.Childs.Add(button_submit);
            //
            filter_form.Childs.Add(diw_row);

            string[] t_heads = new string[] { "Дата", "Товар", "<span class='glyphicon glyphicon-piggy-bank'></span>" };
            List<string[]> table_body = new List<string[]>();
            //
            List<exSupply> supplyes = ServerController.GetSupplies(sel_del_terms, sel_good, sel_del_service, selected_status_supply);
            if (!string.IsNullOrEmpty(sender.QuerySearchUser))
                supplyes = new List<exSupply>(supplyes.Where(x => x.ContainsString(sender.QuerySearchUser)));

            supplyes = new List<exSupply>(supplyes.Where(x => x.DateCreate() >= d_from_date && x.DateCreate() <= d_to_date).OrderByDescending(x => x.OrderIndex));

            sender.Paginations.ReloadDataList(ref supplyes);



            string tmpl_format;
            foreach (exSupply ex_supply in supplyes)
            {
                if (ex_supply.IsAvailable)
                    tmpl_format = "<a data-toggle='tooltip' title='" + ex_supply.Description + "' href='/" + typeof(p_Supply).Name + "?id=" + ex_supply.ID.ToString() + "'>{0}</a>";
                else
                    tmpl_format = "<a data-toggle='tooltip' title='" + ex_supply.Description + "' class='text-secondary' href='/" + typeof(p_Supply).Name + "?id=" + ex_supply.ID.ToString() + "'><del>{0}</del></a>";
                //
                exGood curr_good = ServerController.getGoodById(ex_supply.Good_id);
                exDeliveryTerms curr_del_terms = ServerController.getDeliveryTermById(ex_supply.Delivery_terms_id);
                OptionItem unit_good = s_GoodUnitsClass.GetUnit(curr_good.Unit);
                int count_attachments = 0;
                if (!(ex_supply.Attachments is null))
                    count_attachments = ex_supply.Attachments.Count;

                table_body.Add(new string[]
                {
                   "<table class='table-borderless'><tbody><tr><td><a type_data='" + typeof(exSupply).Name + "' set='" + JsonCommandsMetaClass.moving_up + "' tag='" + ex_supply.ID + "' style='padding: 0;' class='btn glyphicon glyphicon-arrow-up moving' title='UP'></a> </td> <td><kbd data-toggle='tooltip' title='" + curr_del_terms.Name + "'> <a style='color: #dfff00;' href='/"+typeof(p_Supply).Name+"?id=" + ex_supply.ID + "'>" + ex_supply.DateCreate().ToString("dd.MM") + "</a> </kbd> </td> <td> <a type_data='" + typeof(exSupply).Name + "' set='" + JsonCommandsMetaClass.moving_down + "' tag='" + ex_supply.ID + "' style='padding: 0;' class='btn glyphicon glyphicon-arrow-down moving' title='DOWN'></a> </td>" + (count_attachments == 0 ? "" : "<td><span class='glyphicon glyphicon-paperclip'></span> x" + count_attachments.ToString()) + "</td></tr></tbody></table>",
                   string.Format(tmpl_format, curr_good.Name) + " " + ex_supply.Quantity.ToString() + " <abbr title='"+unit_good.Description + "'>" + unit_good.Name+"</abbr>",
                   "<em data-toggle='tooltip' title='" + ServerController.getUserByID(ex_supply.Buyer_id).ToString() + "'>" + ex_supply.Price + "</em>"
                });
            }

            added_dom.Add(new HtmlDomGenerator(TypesHtmlDom.a) { css_class = "btn btn-success btn-lg btn-block", text = "Добавить наличие", href = "/" + typeof(p_Supply).Name });
            added_dom.Add(new HtmlDomGenerator(TypesHtmlDom.p));

            added_dom.Add(filter_form);
            added_dom.Add(new HtmlDomGenerator(TypesHtmlDom.br));
            added_dom.Add(HtmlDomGenerator.GetTable(t_heads, table_body, "table-hover"));

            return added_dom;
        }*/
    }
}