////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    /// <summary>
    /// Карточка пользователя
    /// </summary>
    public class p_UserProfile : base_page_tmpl
    {
        /*
public readonly exUser UserProfile;
public p_UserProfile(PageGeneratorClass sender)
: base(sender)
{
if (dom_elements.Count > 0)
return;

string user_profile_id;
if (sender.UserInitСalling.AccessLevel < AccessLevelUser.Manager || string.IsNullOrEmpty(sender.ID_Object_Сalling))
user_profile_id = sender.UserInitСalling.ID.ToString();
else
user_profile_id = sender.ID_Object_Сalling;

string card_head = "<strong>Профиль пользователя</strong>";
//
sender.head.js_sources.Add("jQuery(document).ready(function () {jQuery('div.attach-header').append(\"<input style = 'margin-left: 10px;' type = 'checkbox' class='form-check-input'/>\");});");

UserProfile = ServerController.getUserByID(user_profile_id);
if (!UserProfile.IsExist)
UserProfile = new exUser();

if (!UserProfile.IsExist)
{
card_head = card_head + " !!! can't find user by id [" + sender.ID_Object_Сalling + "] !";
sender.AddNotification(StatusNote.Danger, "Ошибка в запросе. Объект с таким ID не обнаружен в базе данных");
user_form = new HtmlDomGenerator() { css_class = "alert alert-light" };
user_form.CustomAtributes.Add("role", "alert");
user_form.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.h4) { text = "ОШИБКА", css_class = "text-center text-danger" });
user_form.Childs.Add(HtmlDomGenerator.GetButtonAsLink("/" + typeof(p_List_Users).Name, "Вернуться в список"));
}
else
{
if (sender.post_params.Count > 0 && sender.UserInitСalling.AccessLevel >= AccessLevelUser.Manager)
{
UserProfile.ParsePostParam(sender.post_params);
g.Users_col.Update(UserProfile);
sender.AddNotification(StatusNote.Success, "Объект сохранён!");
}

user_form = get_form();
card_head += ". Последний визит: <u>" + UserProfile.LastActiv.ToString("dd/MM/yy") + "</u> <small>" + UserProfile.LastActiv.ToString("H:mm:ss zzz") + "</small>";

if (UserProfile.AccessLevel >= g.Settings.AccessLevelSaveAttach)
{
user_form.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.hr));
//
user_form.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.p));
user_form.Childs.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card("Движения", GetOrders()));
user_form.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.p));
//
HtmlDomGenerator btn_group = new HtmlDomGenerator() { css_class = "btn-group" };
btn_group.CustomAtributes.Add("role", "group");
btn_group.CustomAtributes.Add("aria-label", "Управление вложениями");
btn_group.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.button) { obj_type = "button", css_class = "btn btn-primary", text = "Отправить", CustomAtributes = new Dictionary<string, string>() { { "data-toggle", "modal" }, { "data-target", "#" + GetPostParamsMetaClass.supply_form_id } } });
btn_group.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.button) { obj_type = "button", css_class = "btn btn-secondary", text = "Отмена", Id_DOM = GetPostParamsMetaClass.button_unchecked_all_id });
user_form.Childs.Add(btn_group);
user_form.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.p));
user_form.Childs.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card("Файлы", GetAttachments()));
}
}
sender.ClearParams();
dom_elements.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card(card_head, new List<HtmlDomGenerator>() { user_form }));
HtmlDomGenerator send_attach = new HtmlDomGenerator();
send_attach.Childs.Add(p_Supply.get_form(null, false, false));
send_attach.Childs.Add(new HtmlDomGenerator() { Id_DOM = GetPostParamsMetaClass.send_attach_body_id });
dom_elements.Add(HtmlDomGenerator.GetModalDialog("Создать документ", "Ок", "Отмена", send_attach, GetPostParamsMetaClass.supply_form_id));
}*/

        /*private HtmlDomGenerator GetOrders()
        {
            List<exSupply> supplies = ServerController.GetOrders(UserProfile.ID.ToString());
            return HtmlDomGenerator.GetOrdersAsTable(supplies);
        }*/

        /*private HtmlDomGenerator GetAttachments()
        {
            List<exTelegramLog> attachments = ServerController.GetAttachmentsByUser(UserProfile.ID.ToString());

            return HtmlDomGenerator.GetAttachmentsAsTable(attachments);
        }*/

        /*private HtmlDomGenerator get_form()
        {
            HtmlDomGenerator user_form = new HtmlDomGenerator(TypesHtmlDom.form) { form_method = "post" };
            HtmlDomGenerator row_input_groups = new HtmlDomGenerator() { css_class = "form-row" };

            HtmlDomGenerator col_input_groups = new HtmlDomGenerator() { css_class = "col" };

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            col_input_groups.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Web Login", UserProfile.WebLogin, g.GetMemberName((exUser c) => c.WebLogin), "WEB Login", true, "Login для входа на сайт"));
            row_input_groups.Childs.Add(col_input_groups);

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            col_input_groups.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Web Username", UserProfile.WebUserName, g.GetMemberName((exUser c) => c.WebUserName), "Username пользователя", true, "Username (публичный) пользователя на сайте"));
            row_input_groups.Childs.Add(col_input_groups);

            //////////////////////////////
            user_form.Childs.Add(row_input_groups);
            row_input_groups = new HtmlDomGenerator() { css_class = "form-row" };
            //////////////////////////////

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            col_input_groups.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Telegram ID", UserProfile.TelegramID, g.GetMemberName((exUser c) => c.TelegramID), "ID аккаунта Telegram", true, "Идентефикатор Telegram"));
            row_input_groups.Childs.Add(col_input_groups);

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            col_input_groups.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Telegram @Username", UserProfile.TelegramUsername, g.GetMemberName((exUser c) => c.TelegramUsername), "", true, "@Username пользователя Telegram"));
            row_input_groups.Childs.Add(col_input_groups);

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            col_input_groups.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Telegram Full name", UserProfile.TelegramFullName, g.GetMemberName((exUser c) => c.TelegramFullName), "", true, "First Last name Telegram"));
            row_input_groups.Childs.Add(col_input_groups);

            //////////////////////////////
            user_form.Childs.Add(row_input_groups);
            row_input_groups = new HtmlDomGenerator() { css_class = "form-row" };
            //////////////////////////////

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            col_input_groups.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Баланс фиат", UserProfile.Balance.ToString(), g.GetMemberName((exUser c) => c.Balance), "", true, "Баланс пользователя"));
            row_input_groups.Childs.Add(col_input_groups);

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            col_input_groups.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Добавить баланс", "0", g.GetMemberName((exUser c) => c.Balance) + "_edit", "Сумма изменения", false, "Добавить: 8 или 5. Убавить: -8 или -5"));
            row_input_groups.Childs.Add(col_input_groups);

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            col_input_groups.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Сумма покупок", UserProfile.AmountPurchases.ToString(), g.GetMemberName((exUser c) => c.AmountPurchases), "", true, "Общая сумма покупок"));
            row_input_groups.Childs.Add(col_input_groups);

            //////////////////////////////
            user_form.Childs.Add(row_input_groups);
            row_input_groups = new HtmlDomGenerator() { css_class = "form-row" };
            //////////////////////////////

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            col_input_groups.Childs.AddRange(HtmlDomGenerator.GetBaseTextInput("Bitcoin адрес", UserProfile.BitcoinAdress, g.GetMemberName((exUser c) => c.BitcoinAdress), "", true, "Адресс Bitcoin"));
            row_input_groups.Childs.Add(col_input_groups);

            //////////////////////////////
            user_form.Childs.Add(row_input_groups);
            row_input_groups = new HtmlDomGenerator() { css_class = "form-row" };
            //////////////////////////////

            col_input_groups = new HtmlDomGenerator() { css_class = "col" };
            //
            row_input_groups.Childs.Add(col_input_groups);

            List<OptionItem> types = new List<OptionItem>();
            foreach (AccessLevelUser l_item in Enum.GetValues(typeof(AccessLevelUser)))
                types.Add(new OptionItem() { Name = l_item.ToString("g"), Description = "Уровень: " + l_item.ToString("g"), value = ((int)l_item).ToString() });
            row_input_groups.Childs.Add(GetSelectList(g.GetMemberName((exUser c) => c.AccessLevel), "Уровень", "Уровень доступа пользователя", types, ((int)UserProfile.AccessLevel).ToString()));


            user_form.Childs.Add(row_input_groups);
            user_form = SetDefInputs(user_form, UserProfile);
            return user_form;
        }*/
    }
}