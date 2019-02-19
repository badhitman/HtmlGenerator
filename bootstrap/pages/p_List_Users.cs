////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    /// <summary>
    /// Список пользователей
    /// </summary>
    class p_List_Users : base_page_tmpl
    {
        /*
        public readonly AccessLevelUser sel_level_users;
        public p_List_Users(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;

            ///////////////////////////////////////
            // User access type // уровень доступа пользователя
            string prop_value = sender.get_params[g.GetMemberName((exUser c) => c.AccessLevel)];
            sel_level_users = ServerController.DetectAccessLevelUser(prop_value);



            dom_elements.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card("Пользователи", GetCatalog()));

        }*/

        /*public List<HtmlDomGenerator> GetCatalog()
        {
            List<HtmlDomGenerator> added_dom = new List<HtmlDomGenerator>();
            added_dom.Add(new HtmlDomGenerator(TypesHtmlDom.p));

            HtmlDomGenerator filter_form = new HtmlDomGenerator(TypesHtmlDom.form) { form_method = "GET", css_class = "form-inline" };

            HtmlDomGenerator diw_row = new HtmlDomGenerator() { css_class = "form-row align-items-center" };

            List<OptionItem> types = new List<OptionItem>();
            foreach (AccessLevelUser l_item in Enum.GetValues(typeof(AccessLevelUser)))
                types.Add(new OptionItem() { Name = l_item.ToString("g"), Description = "Уровень: " + l_item.ToString("g"), value = ((int)l_item).ToString() });

            types[0].value = "-1";
            types[0].Name = "Все";
            types[0].Description = "Отобразить всех пользователей";

            diw_row.Childs.Add(GetSelectList(g.GetMemberName((exUser c) => c.AccessLevel), "Уровень", "Уровень доступа пользователя", types, ((int)sel_level_users).ToString()));

            List<OptionItem> page_sizes = s_PaginationSizeClass.GetListSizes;
            diw_row.Childs.Add(HtmlDomGenerator.GetSelectList(GetPostParamsMetaClass.page_size, "Огр", "Количество выводимых элементов на странице", page_sizes, sender.Paginations.CountElementsOfPage.ToString()));

            ///////////////////////////////////////
            // поле запроса
            HtmlDomGenerator wrap = new HtmlDomGenerator() { css_class = "input-group mb-4 col-auto" };
            HtmlDomGenerator input = new HtmlDomGenerator(TypesHtmlDom.input) { css_class = "form-control", obj_type = "text", Id_DOM = GetPostParamsMetaClass.user_search_query };
            input.CustomAtributes.Add("placeholder", "Поиск по всем полям");
            if (!string.IsNullOrEmpty(sender.QuerySearchUser))
            {
                input.CustomAtributes.Add("value", sender.QuerySearchUser);
            }

            wrap.Childs.Add(input);
            diw_row.Childs.Add(wrap);

            ///////////////////////////////////////
            // Кнопка Поиск
            HtmlDomGenerator button_submit = new HtmlDomGenerator() { css_class = "col-auto" };
            button_submit.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.button) { css_class = "btn btn-primary mb-4", text = "Поиск", CustomAtributes = new Dictionary<string, string>() { { "type", "submit" } } });
            diw_row.Childs.Add(button_submit);
            filter_form.Childs.Add(diw_row);

            added_dom.Add(filter_form);

            List<exUser> users = ServerController.GetUsers(sel_level_users);

            if (!string.IsNullOrEmpty(sender.QuerySearchUser))
                users = new List<exUser>(users.Where(x => x.ContainsString(sender.QuerySearchUser)));

            users = new List<exUser>(users.OrderByDescending(x => x.ID));

            sender.Paginations.ReloadDataList(ref users);

            string[] t_heads = new string[] { "Acces", "Login", "$" };
            List<string[]> table_body = new List<string[]>();

            string tmpl_format;
            HtmlDomGenerator badge = new HtmlDomGenerator(TypesHtmlDom.span) { inline = true };
            foreach (exUser e_user in users)
            {
                if (e_user.IsAvailable)
                    tmpl_format = "<a data-toggle='tooltip' title='" + e_user.Information + "' href='/" + typeof(p_User).Name + "?id=" + e_user.ID + "'>{0}</a> <span class='glyphicon glyphicon-envelope'></span> {1}";
                else
                    tmpl_format = "<a data-toggle='tooltip' title='" + e_user.Information + "' class='text-secondary' href='/" + typeof(p_User).Name + "?id=" + e_user.ID + "'><del>{0}</del></a> <span class='glyphicon glyphicon-envelope'></span> {1}";

                badge.css_class = "badge badge-";
                badge.text = e_user.AccessLevel.ToString("g");

                switch (e_user.AccessLevel)
                {
                    case AccessLevelUser.Admin:
                        badge.css_class += StylesElements.Warning.ToString("g");
                        break;
                    case AccessLevelUser.Manager:
                        badge.css_class += StylesElements.Success.ToString("g");
                        break;
                    case AccessLevelUser.ROOT:
                        badge.css_class += StylesElements.Danger.ToString("g");
                        break;
                    case AccessLevelUser.Buyer:
                        badge.css_class += StylesElements.Info.ToString("g");
                        break;
                    case AccessLevelUser.Auth:
                        badge.css_class += StylesElements.Secondary.ToString("g");
                        break;
                    default:
                        badge.css_class += StylesElements.Light.ToString("g");
                        break;
                }
                badge.css_class = badge.css_class.ToLower();
                table_body.Add(new string[]
                {
                    badge.HTML(0).Trim(),
                    string.Format(tmpl_format, e_user.FullName, e_user.GetAttachments().Count().ToString()),
                    "<abbr title='Баланс'>" + e_user.Balance + "</abbr>"

                });
            }

            added_dom.Add(GetTable(t_heads, table_body));
            added_dom.Add(new HtmlDomGenerator(TypesHtmlDom.p));

            return added_dom;
        }*/
    }
}