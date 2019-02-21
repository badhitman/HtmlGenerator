////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    /// <summary>
    /// Справочник товаров
    /// </summary>
    public class p_Storage : base_page_tmpl
    {

        /*
        public p_Storage(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;

            HtmlDomGenerator user_form = new HtmlDomGenerator(TypesHtmlDom.a) { css_class = "btn btn-primary btn-lg btn-block", text = "Новая группа", href = "/" + typeof(p_Good).Name + ".group" };
            HtmlDomGenerator item_create = new HtmlDomGenerator(TypesHtmlDom.a) { css_class = "btn btn-primary btn-lg btn-block", text = "Новый товар", href = "/" + typeof(p_Good).Name };

            HtmlDomGenerator html_response = new HtmlDomGenerator();
            html_response.Childs.Add(user_form);
            html_response.Childs.Add(item_create);
            //
            html_response.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.p));
            string[] t_heads = new string[] { "Наименование", "Ед" };
            string tmpl_format = "";


            foreach (exGood group in g.Goods_col.Find(x => x.IsGroup).OrderBy(x => x.Name))
            {
                List<string[]> table_body = new List<string[]>();
                foreach (exGood good in g.Goods_col.Find(x => x.ParentGroup == group.ID).OrderBy(x => x.Name))
                {
                    if (good.IsExist)
                        tmpl_format = "<a target='_blank' data-toggle='tooltip' title='" + good.Description + "' href='/" + typeof(p_Good).Name + "?id=" + good.ID + "'>{0}</a>";
                    else
                        tmpl_format = "<a target='_blank' data-toggle='tooltip' title='" + good.Description + "' class='text-secondary' href='/" + typeof(p_Good).Name + "?id=" + good.ID + "'><del>{0}</del></a>";

                    table_body.Add(new string[]
                    {
                            string.Format(tmpl_format, good.Name) + s_GoodsClass.GetStatOfGood(good.ID.ToString()).Badge.HTML(),
                            string.Format(tmpl_format, s_GoodUnitsClass.GetUnit(good.Unit).Name)
                    });
                }

                string group_header = "";
                if (group.IsExist)
                    group_header = "<span class='text-secondary'>группа</span> <h4><a target='_blank' data-toggle='tooltip' title='" + group.Description + "' href='/storage/good.group?id=" + group.ID + "'>" + group.Name + "</a></h4>";
                else
                    group_header = "<span class='text-secondary'>группа</span> <h4><del><a target='_blank' href='/storage/good.group?id=" + group.ID + "'>" + group.Name + "</a></del></h4>";

                html_response.Childs.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card(group_header, HtmlDomGenerator.GetTable(t_heads, table_body, "table-hover table-sm")));
                html_response.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.p));
            }

            dom_elements.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card("Склад", html_response));
        }*/
    }
}
