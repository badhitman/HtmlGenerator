////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    /// <summary>
    /// Личный профиль пользователя
    /// </summary>
    public class p_Server_Config : base_page_tmpl
    {
        /*

        /// <summary>
        /// API ключ Telegram
        /// </summary>
        public static string telegram_api_key = "";

        /// <summary>
        /// Offline message
        /// </summary>
        public static string msg_offline_server = "";

        /// <summary>
        /// Период опроса Telegram сервера
        /// </summary>
        public static string period_pool_api_telegram = "";

        public p_Server_Config(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;
            
            if (sender.post_params["public-name-user"] != null && eu.WebUserName != sender.post_params["public-name-user"])
            {
                if (string.IsNullOrEmpty(sender.post_params["public-name-user"]))
                    sender.AddNotification(StatusNote.Danger, "Нельзя устанавливать пустой <strong>username</strong>!");
                else if (!Regex.IsMatch(sender.post_params["public-name-user"], @"^[\w\d][\d\w _]{3,}[\w\d]$"))
                    sender.AddNotification(StatusNote.Danger, "Ошибка в формате <strong>username</strong>. Можно использовать только буквы, цифры, пробел и символ подчёркивания. Первй и последние символы должны бить буквой или цифрой!");
                else if (g.Users_col.Exists(x => x.WebUserName == sender.post_params["public-name-user"]))
                    sender.AddNotification(StatusNote.Danger, "Такой <strong>username</strong> уже существует!");
                else
                {
                    sender.AddNotification(StatusNote.Success, "Ваш публичный <strong>username</strong> изменён с '" + HttpUtility.UrlEncode(eu.WebUserName) + "' на '" + HttpUtility.UrlEncode(sender.post_params["public-name-user"]) + "'");
                    eu.WebUserName = sender.post_params["public-name-user"];
                    if (eu.IsActive)
                        g.Users_col.Update(eu);
                }
            }
            if (sender.post_params["new-password"] != null && !string.IsNullOrEmpty(sender.post_params["new-password"].Trim()) && eu.WebPasswordHash != g.GetHashString(sender.post_params["new-password"]))
            {
                if (sender.post_params["new-password-r"] == null || sender.post_params["new-password-r"] != sender.post_params["new-password"])
                    sender.AddNotification(StatusNote.Danger, "Новый <strong>пароль</strong> не совпадает с повтором пароля!");

                else if (sender.post_params["old-password"] == null || g.GetHashString(sender.post_params["old-password"]) != eu.WebPasswordHash)
                    sender.AddNotification(StatusNote.Danger, "Вы не правильно указали текущий/действующий <strong>пароль</strong>!");

                else if (sender.post_params["new-password"].Length < 5)
                    sender.AddNotification(StatusNote.Danger, "Новый <strong>пароль</strong> не отвечает требованиям: <code>не менее 5 символов!</code>");

                else
                {
                    if (!(eu.ID is null))
                    {
                        eu.WebPasswordHash = g.GetHashString(sender.post_params["new-password"]);
                        g.Users_col.Update(eu);
                        sender.AddNotification(StatusNote.Success, "Ваш <strong>пароль</strong> изменён");
                    }
                }
            }


            TabsPanelGenerator tpg = new TabsPanelGenerator();
            tpg.TabItemsPanel.Add(new TabItem() { title_panel = "Персона", id_address_panel = "account_info" });
            //
            tpg.TabItemsPanel[0].body_panel_elements.AddRange(HTML_Dom.GetBaseTextInput("Приватный логин для входа", eu.WebLogin, "", "", true, "Логин для входа на сайт (ни где не отображается)"));
            tpg.TabItemsPanel[0].body_panel_elements.AddRange(HTML_Dom.GetBaseTextInput("Идентификатор", eu.ID.ToString(), "", "", true, "ID объекта"));
            tpg.TabItemsPanel[0].body_panel_elements.AddRange(HTML_Dom.GetBaseTextInput("Отображаемое для всех имя", eu.WebUserName, "public-name-user", "Публичное имя", false, "Имя, которое будет отображаться для всех"));
            //
            tpg.TabItemsPanel.Add(new TabItem() { title_panel = "Пароль", id_address_panel = "password_change" });
            //
            tpg.TabItemsPanel[1].body_panel_elements.AddRange(HTML_Dom.GetPassInput("Введите действующий пароль", "old-password", "Текущий пароль", "Введите старый (текущий) пароль"));
            tpg.TabItemsPanel[1].body_panel_elements.AddRange(HTML_Dom.GetPassInput("Введите новый пароль", "new-password", "Новый пароль", "Введите новый пароль"));
            tpg.TabItemsPanel[1].body_panel_elements.AddRange(HTML_Dom.GetPassInput("Введите повторно новый пароль", "new-password-r", "Повторите новый пароль", "Введите повторно новый пароль"));
            //
            //if (eu.AccessLevel >= AccessLevelUser._5_Manager)
            //{
            //    tpg.TabItemsPanel.Add(new TabItem() { title_panel = "Telegram", id_address_panel = "tbot_server_settings" });
                
            //    tpg.TabItemsPanel[2].body_panel_elements.Add(HtmlController.GetTextInput("Telegram key", telegram_api_key, "telegram-key", "API ключ Telegram", false, "Введите приватный API ключ для Telegram"));
            //    tpg.TabItemsPanel[2].body_panel_elements.Add(HtmlController.GetTextInput("Offline сообщение сервера", msg_offline_server, "offline-msg-server", "Offline message", false, "Введите текст сообщения, которое сервер будет выводить в режиме OffLine"));
            //    tpg.TabItemsPanel[2].body_panel_elements.Add(HtmlController.GetTextInput("Период опроса Telegram", period_pool_api_telegram, "period-pool-telegram", "Период опроса Telegram сервера", false, "Введите период опроса сервера API телеграмм бота"));
            //}
            HTML_Dom tabs_obj = tpg.GetDOM(new HTML_Dom(html_types.form) { Id_DOM = "settings", form_method = "post" }, "user-settings-form");
            tabs_obj.Childs.Add(new HTML_Dom() { css_class = "form-group", Childs = new List<HTML_Dom>() { new HTML_Dom(html_types.button) { css_class = "btn btn-primary btn-lg btn-block", Childs = new List<HTML_Dom>() { new HTML_Dom(html_types.text) { text = "СОХРАНИТЬ" } } } } });
            dom_elements.Add(HTML_Dom.Get_DIV_Bootstrap_Card("Настройки", new List<HTML_Dom>() { tabs_obj }));
        }*/
    }
}