////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    public class p_DeliverySettings : base_page_tmpl
    {
        /*

        public p_Delivery(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;
            HtmlDomGenerator city_create = new HtmlDomGenerator(TypesHtmlDom.a) { css_class = "btn btn-primary btn-lg btn-block", text = "Новый город", href = "/"+typeof(p_City).Name };
            HtmlDomGenerator type_create = new HtmlDomGenerator(TypesHtmlDom.a) { css_class = "btn btn-primary btn-lg btn-block", text = "Новые условия доставки", href = "/"+typeof(p_Delivery_Terms).Name };
            HtmlDomGenerator service_create = new HtmlDomGenerator(TypesHtmlDom.a) { css_class = "btn btn-primary btn-lg btn-block", text = "Новая служба доставки", href = "/" + typeof(p_Delivery_Service).Name };
            user_form = new HtmlDomGenerator();
            user_form.Childs.Add(city_create);
            user_form.Childs.Add(type_create);
            user_form.Childs.Add(service_create);

            user_form.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.p));
            string[] t_heads = new string[] { "Наименование" };
            List<string[]> table_body = new List<string[]>();
            string tmpl_format = "";
            foreach(exDeliveryService delivery_service in g.DeliveryServices_col.FindAll().OrderBy(x=>x.Name))
            {
                if (delivery_service.IsExist)
                    tmpl_format = "<a class='text-white' href='/" + typeof(p_Delivery_Service).Name + "?id=" + delivery_service.ID + "'>{0}</a>";
                else
                    tmpl_format = "<a class='text-white' href='/" + typeof(p_Delivery_Service).Name + "?id=" + delivery_service.ID + "'><del>{0}</del></a>";

                table_body.Add(new string[] { string.Format(tmpl_format, delivery_service.Name) + s_GoodsClass.GetStatOfDeliveryService(delivery_service.ID.ToString()).Badge.HTML() });
            }
            user_form.Childs.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card("<span class='text-light'>Службы доставки</span>", HtmlDomGenerator.GetTable(t_heads, table_body, "table-hover table-sm"), "bg-secondary"));
            user_form.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.p));

            
            foreach (exCity city in g.Cityes_col.FindAll().OrderBy(x => x.Name))
            {
               table_body = new List<string[]>();
                foreach (exDeliveryTerms delivery_terms in g.DeliveryTerms_col.Find(x => x.CityID == city.ID.ToString()).OrderBy(x => x.Name))
                {
                    if (delivery_terms.IsExist)
                        tmpl_format = "<a target='_blank' href='/"+ typeof(p_Delivery_Terms).Name + "?id=" + delivery_terms.ID + "'>{0}</a>";
                    else
                        tmpl_format = "<a target='_blank' class='text-secondary' href='/" + typeof(p_Delivery_Terms).Name + "?id=" + delivery_terms.ID + "'><del>{0}</del></a>";

                    table_body.Add(new string[] { string.Format(tmpl_format, delivery_terms.Name) + s_GoodsClass.GetStatOfDeliveryType(delivery_terms.ID.ToString()).Badge.HTML() });
                }

                string city_header = "";
                if (city.IsExist)
                    city_header = "<span class='text-secondary'>город</span> <h4><a target='_blank' href='/" + typeof(p_City).Name + "?id=" + city.ID + "'>" + city.Name + "</a></h4>";
                else
                    city_header = "<span class='text-secondary'>город</span> <h4><del><a target='_blank' href='/" + typeof(p_City).Name + "?id=" + city.ID + "'>" + city.Name + "</a></del></h4>";
                //html_response.Childs.Add();
                HtmlDomGenerator table_dom_obj = HtmlDomGenerator.GetTable(t_heads, table_body, "table-hover table-sm");
                user_form.Childs.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card(city_header, new List<HtmlDomGenerator>() { new HtmlDomGenerator(TypesHtmlDom.p) { text = "Условия доставки" }, table_dom_obj }));
                user_form.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.p));
             }

            dom_elements.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card("Доставка", user_form));
            
        }*/

    }
}
