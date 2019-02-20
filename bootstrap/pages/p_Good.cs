////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    /// <summary>
    /// Карточка товара
    /// </summary>
    public class p_Good : base_page_tmpl
    {
        /*
        public p_Good(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;

            exGoodClass eg = new exGoodClass();
            eg.IsGroup = sender.url_request.EndsWith("/good.group");
            user_form = new HTML_Dom();
            string card_head = "<strong>Товар</strong>";
            if (eg.IsGroup)
                card_head = "<strong>Группу</strong>";

            #region Отобразить форму для создания нового объекта
            if (sender.get_params["id"] == null && sender.post_params.Count == 0)
            {
                card_head = "Создать " + card_head;
                user_form = get_form(eg);
            }
            #endregion
            
            #region Запись нового объекта
            else if (sender.get_params["id"] == null && sender.post_params.Count > 0)
            {
                eg.ParsePostParam(sender.post_params);
                eg.IsGroup = sender.url_request.EndsWith("/good.group");
                if (!eg.isCorrectFilling)
                {
                    user_form = get_form(eg);
                    sender.AddRangeNotifications(StatusNote.Danger, eg.ErrorsOfCorrectness.ToArray());
                    eg.ErrorsOfCorrectness.Clear();
                    user_form.Childs.Insert(0, new HTML_Dom(html_types.div, new Dictionary<string, string>() { { "role", "alert" } }) { text = "Ошибка сохранения!", css_class = "alert alert-danger" });
                }
                else
                {
                    g.Goods_col.Insert(eg);
                    eg.OrderIndex = eg.GetHashCode();
                    g.Goods_col.Update(eg);
                    user_form = new HTML_Dom() { css_class = "alert alert-light" };
                    user_form.custom_atributes.Add("role", "alert");
                    user_form.Childs.Add(new HTML_Dom(html_types.h3) { text = "Сохранено", css_class = "text-center text-success" });
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/storage", "Вернуться на склад"));
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/storage/good" + (eg.IsGroup ? ".group" : "") + "?id=" + eg.ID, "Открыть объект"));
                }
            }
            #endregion

            #region Открыть/Сохранить существующий объект
            else
            {
                string id_good = null;
                if (Regex.IsMatch(sender.get_params["id"].Trim(), @"^\d+$"))
                    id_good = sender.get_params["id"];
                eg = ServerController.getGoodById(id_good);
                if (eg == null)
                {
                    card_head = card_head + " с идентефикатором [" + sender.get_params["id"] + "] не удалось найти!";
                    sender.AddNotification(StatusNote.Danger, "Ошибка в запросе. Объект с таким ID не обнаружен");
                    user_form = new HTML_Dom() { css_class = "alert alert-light" };
                    user_form.custom_atributes.Add("role", "alert");
                    user_form.Childs.Add(new HTML_Dom(html_types.h4) { text = "ОШИБКА", css_class = "text-center text-danger" });
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/storage", "Перейти на склад"));
                }
                else
                {
                    eg.ParsePostParam(sender.post_params);
                    eg.IsGroup = sender.url_request.EndsWith("/good.group");
                    if (!eg.isCorrectFilling)
                    {
                        user_form = get_form(eg);
                        sender.AddRangeNotifications(StatusNote.Danger, eg.ErrorsOfCorrectness.ToArray());
                        eg.ErrorsOfCorrectness.Clear();

                        user_form.Childs.Insert(0, new HTML_Dom(html_types.div, new Dictionary<string, string>() { { "role", "alert" } }) { text = "Ошибка сохранения!", css_class = "alert alert-danger" });
                    }
                    else
                    {
                        if (sender.post_params.Count > 0)
                        {
                            g.Goods_col.Update(eg);
                            sender.AddNotification(StatusNote.Success, card_head + " - Сохранён");
                        }
                        //
                        user_form = get_form(eg);
                        user_form.Childs.Add(new HTML_Dom(html_types.p));
                        user_form.Childs.Add(new HTML_Dom(html_types.hr));
                    }
                }
            }
            #endregion

            dom_elements.Add(HTML_Dom.Get_DIV_Bootstrap_Card(card_head, new List<HTML_Dom>() { user_form }));*/
        //}

        /*HTML_Dom get_form(exGoodClass eg)
        {

            HTML_Dom good_form = new HTML_Dom(html_types.form) { form_method = "post" };
            good_form.Childs.AddRange(HTML_Dom.GetBaseTextInput("Наименование", eg.Name, "name", "Название", false, "Укажите наименование. Используйте короткие, простые и понятные имена"));
            
            if (!eg.IsGroup)
            {
                good_form.Childs.Add(HTML_Dom.GetSelectList("unit", "Единица изм.", "Еденица измерения...", s_GoodUnitsClass.GetListUnits, new LiteDB.ObjectId(eg.Unit)));
                good_form.Childs.Add(HTML_Dom.GetSelectList("parent", "Группа.", "Родительская группа...", s_GoodParentGroupsClass.GetListGroups, eg.ParentGroup));
            }

            good_form.Childs.Add(HTML_Dom.GetTextarea("Описание", eg.Description, "desc", false, 3));

            good_form = SetDefInputs(good_form, eg);
            good_form.Childs.Add(HTML_Dom.GetButtonAsLink("/storage", "Вернуться на склад"));

            return good_form;
        }*/
    }
}