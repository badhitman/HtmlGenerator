////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    /// <summary>
    /// Управление финансовыми операциями
    /// </summary>
    public class p_List_Qiwi : base_page_tmpl
    {
        /*

        public p_List_Qiwi(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;


            string[] t_heads = new string[] { "Num", "$", "∑" };
            List<string[]> table_body = new List<string[]>();

            string tmpl_format;
            foreach (exQiwi qiwi_item in g.Qiwi_col.FindAll())
            {
                if (qiwi_item.IsAvailable)
                    tmpl_format = "<a data-toggle='tooltip' title='" + qiwi_item.AboutLimitsQiwi + "' href='/" + typeof(p_Qiwi).Name + "?id=" + qiwi_item.ID + "'>{0}</a>";
                else
                    tmpl_format = "<a data-toggle='tooltip' title='" + qiwi_item.AboutLimitsQiwi + "' class='text-secondary' href='/" + typeof(p_Qiwi).Name + "?id=" + qiwi_item.ID + "'><del>{0}</del></a>";

                string[] new_row = new string[7];

                table_body.Add(new string[]
                {
                    string.Format(tmpl_format, (qiwi_item.qiwi_num == null || qiwi_item.qiwi_num.Length < 5) ? "0 000 000 00 00" : qiwi_item.qiwi_num),
                    string.Format(tmpl_format, qiwi_item.Balance) + " " + qiwi_item.LastUpdateApiInfoAsString(true),
                    string.Format(tmpl_format, qiwi_item.TotalSum)

                });
            }

            HtmlDomGenerator qiwi_create = new HtmlDomGenerator(TypesHtmlDom.a) { css_class = "btn btn-primary btn-lg btn-block", text = "Новый QIWI", href = "./" + typeof(p_Qiwi).Name };
            //<a href="#" class="btn btn-primary btn-lg active" role="button" aria-pressed="true">Primary link</a>
            HtmlDomGenerator html_response = new HtmlDomGenerator();
            html_response.Childs.Add(qiwi_create);
            html_response.Childs.Add(HtmlDomGenerator.GetTable(t_heads, table_body, "table-hover"));


            dom_elements.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card("Финансы", new List<HtmlDomGenerator>() { html_response }));
        }*/
    }
}