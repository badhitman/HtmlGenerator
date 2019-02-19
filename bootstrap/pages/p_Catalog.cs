////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    /// <summary>
    /// Каталог/Витрина
    /// </summary>
    class p_Catalog : base_page_tmpl
    {
        /*

        public readonly exDeliveryTerms sel_del_terms;
        public readonly exGood sel_good;

        public p_Catalog(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;

            ///////////////////////////////////////
            // delivery-terms // условия доставки
            string prop_value = sender.get_params[g.GetMemberName((exSupply c) => c.Delivery_terms_id)];
            if (string.IsNullOrEmpty(prop_value))
                sel_del_terms = new exDeliveryTerms() { Name = "не выбрано", Information = "фильтр условий доставки не установлен" };
            else
                sel_del_terms = ServerController.getDeliveryTermById(prop_value);

            ///////////////////////////////////////
            // goods // номенклатура // selected_good
            string prop_name = g.GetMemberName((exSupply c) => c.Good_id);
            prop_value = sender.get_params[prop_name];
            if (string.IsNullOrEmpty(prop_value))
                sel_good = new exGood() { Name = "не выбрано", Information = "фильтр условий доставки не установлен" };
            else
                sel_good = ServerController.getGoodById(sender.get_params[prop_name]);


            string card_head = "<strong>Для уточнения поиска настройте фильтр</strong>";
            dom_elements.Add(Get_DIV_Bootstrap_Card(card_head, GetCatalog()));

            //
            HtmlDomGenerator form_modal_dialog = new HtmlDomGenerator(TypesHtmlDom.form) { Name_DOM = GetPostParamsMetaClass.buy_form_id };
            form_modal_dialog.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.strong));
            form_modal_dialog.Childs.AddRange(GetBaseTextInput("Заказ", "-", GetPostParamsMetaClass.order_info_id, "", true, "Для покупки нажмите на кнопку Купить"));

            dom_elements.Add(GetModalDialog("Подтверждение покупки", "Купить", "Отмена", form_modal_dialog, GetPostParamsMetaClass.cart_modal_form_id));
        }*/

        /*public List<HtmlDomGenerator> GetCatalog()
        {
            List<HtmlDomGenerator> added_dom = new List<HtmlDomGenerator>();
            added_dom.Add(new HtmlDomGenerator(TypesHtmlDom.p));

            HtmlDomGenerator filter_form = new HtmlDomGenerator(TypesHtmlDom.form) { form_method = "GET", css_class = "form-inline" };
            HtmlDomGenerator diw_row = new HtmlDomGenerator() { css_class = "form-row align-items-left" };

            List<OptionItem> DeliveryesTree = s_DeliveryClass.GetTreeDeliveryes;
            DeliveryesTree.Insert(0, new OptionItem() { Name = "Все", value = "-1", Disabled = false, Description = "Все города и условия доставки" });

            diw_row.Childs.Add(HtmlDomGenerator.GetSelectList(g.GetMemberName((exSupply c) => c.Delivery_terms_id), "Город", "Условия", DeliveryesTree, sel_del_terms.ID is null ? "" : sel_del_terms.ID.ToString()));
            ///////////////////////////////////////////////////
            List<OptionItem> goods = s_GoodsClass.GetCatalogTree;
            OptionItem o_item = new OptionItem() { Name = "Все", value = "-1", Disabled = false, Description = "Отобразить все товары" };

            goods.Insert(0, o_item);

            diw_row.Childs.Add(HtmlDomGenerator.GetSelectList(g.GetMemberName((exSupply c) => c.Good_id), "Товар", "Номенклатура", goods, sel_good.ID is null ? "" : sel_good.ID.ToString()));

            ///////////////////////////////////////
            // Кнопка Поиск
            HtmlDomGenerator button_submit = new HtmlDomGenerator() { css_class = "col-auto" };
            button_submit.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.button) { css_class = "btn btn-sm btn-primary", text = "Поиск", CustomAtributes = new Dictionary<string, string>() { { "type", "submit" } } });
            diw_row.Childs.Add(button_submit);
            //
            ///////////////////////////////////////
            //
            filter_form.Childs.Add(diw_row);
            added_dom.Add(filter_form);

            List<exSupply> supplies = ServerController.GetSupplies(sel_del_terms, sel_good, null);

            sender.Paginations.ReloadDataList(ref supplies);
            sender.Paginations.CountElementsOfPage = 99999; // таким образом отключим вывод инструментов пагинатора

            string[] t_heads = new string[] { "Наименование", "<span class='glyphicon glyphicon-piggy-bank'></span>" };
            List<string[]> table_body = new List<string[]>();

            List<exSupply> supplyes_2 = new List<exSupply>();
            foreach (IGrouping<string, exSupply> supplyes_by_city in supplies.GroupBy(x => x.City().Name))
            {
                table_body.Clear();
                foreach (IGrouping<string, exSupply> supplyes_by_good in supplyes_by_city.ToList().GroupBy(x => x.DeliveryTerms().Name))
                {
                    foreach (IGrouping<string, exSupply> supplyes_by_type in supplyes_by_good.ToList().GroupBy(x => x.getFullName()))
                    {
                        string pre_control_name = "";
                        string control_name = "";
                        supplyes_2.Clear();
                        foreach (exSupply supplyes_item in supplyes_by_type.OrderBy(x => x.OrderIndex))
                        {
                            pre_control_name = ServerController.getGoodById(supplyes_item.Good_id.ToString()).Name + supplyes_item.Quantity.ToString() + supplyes_item.Price.ToString();
                            if (control_name == pre_control_name)
                                continue;
                            supplyes_2.Add(supplyes_item);
                            control_name = pre_control_name;
                        }
                        foreach (exSupply ex_supply in supplyes_2)
                        {
                            exGood curr_good = ex_supply.Good();
                            OptionItem unit_good = s_GoodUnitsClass.GetUnit(curr_good.Unit);
                            table_body.Add(new string[]
                            {
                                "<h6><span class='badge badge-light'>" + curr_good.Name + " " + ex_supply.Quantity.ToString() + " <abbr title='" + unit_good.Description + "'>" + unit_good.Name + "</abbr></span> <span class='badge badge-info'>" + ex_supply.DeliveryTerms().Name + "</span></h6><!-- " + ex_supply.OrderIndex.ToString() + " -->",
                                "<button tag='" + ex_supply.ID + "' title='" + curr_good.Name + " " + ex_supply.Quantity.ToString() + " "+unit_good.Name + " за " + ex_supply.Price + " руб.' data-price='"+ex_supply.Price+"' type='button' data-toggle='modal' data-target='#"+ GetPostParamsMetaClass.cart_modal_form_id +"' class='btn btn-outline-primary btn-sm'>Купить " + ex_supply.Price + " руб.</button>"
                            });
                        }
                    }
                }

                added_dom.Add(Get_DIV_Bootstrap_Card("<h4>" + supplyes_by_city.Key + "</h4>", GetTable(t_heads, table_body)));
                added_dom.Add(new HtmlDomGenerator(TypesHtmlDom.p));
            }
            return added_dom;
        }*/
    }
}