////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    public class p_DeliveryTerms : base_page_tmpl
    {
        /*

        public p_Delivery_Terms(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;
            
            user_form = new HTML_Dom();
            string card_head = "<strong>Тип доставки</strong>";
            exDeliveryTypeClass delivery_obj = new exDeliveryTypeClass();

            #region Отобразить форму для создания нового объекта
            if (sender.get_params["id"] == null && sender.post_params.Count == 0)
            {
                card_head = "Создать " + card_head;
                user_form = get_form(delivery_obj);
            }
            #endregion

            #region Запись нового объекта
            else if (sender.get_params["id"] == null && sender.post_params.Count > 0)
            {
                delivery_obj.ParsePostParam(sender.post_params);

                if (!delivery_obj.isCorrectFilling)
                {
                    user_form = get_form(delivery_obj);
                    sender.AddRangeNotifications(StatusNote.Danger, delivery_obj.ErrorsOfCorrectness.ToArray());
                    delivery_obj.ErrorsOfCorrectness.Clear();
                    user_form.Childs.Insert(0, new HTML_Dom(html_types.div, new Dictionary<string, string>() { { "role", "alert" } }) { text = "Ошибка сохранения!", css_class = "alert alert-danger" });
                }
                else
                {
                    g.DeliveryTypes_col.Insert(delivery_obj);
                    user_form = new HTML_Dom() { css_class = "alert alert-light" };
                    user_form.custom_atributes.Add("role", "alert");
                    user_form.Childs.Add(new HTML_Dom(html_types.h3) { text = "Сохранено", css_class = "text-center text-success" });
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/delivery", "Вернуться в доставку"));
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/delivery/delivery-type?id=" + delivery_obj.ID, "Открыть объект"));
                }
            }
            #endregion

            #region Открыть/Сохранить существующий объект
            else
            {
                string id_delivery = "";
                if (Regex.IsMatch(sender.get_params["id"].Trim(), @"^\d+$"))
                    id_delivery = sender.get_params["id"];

                delivery_obj = ServerController.getTypeDeliveryById(id_delivery);
                if (!delivery_obj.IsActive)
                {
                    card_head = card_head + " с идентефикатором [" + sender.get_params["id"] + "] не удалось найти!";
                    sender.AddNotification(StatusNote.Danger, "Ошибка в запросе. Объект с таким ID не обнаружен");
                    user_form = new HTML_Dom() { css_class = "alert alert-light" };
                    user_form.custom_atributes.Add("role", "alert");
                    user_form.Childs.Add(new HTML_Dom(html_types.h4) { text = "ОШИБКА", css_class = "text-center text-danger" });
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/delivery", "Перейти в доставку"));
                }
                else
                {
                    delivery_obj.ParsePostParam(sender.post_params);

                    if (!delivery_obj.isCorrectFilling)
                    {
                        user_form = get_form(delivery_obj);
                        sender.AddRangeNotifications(StatusNote.Danger, delivery_obj.ErrorsOfCorrectness.ToArray());
                        delivery_obj.ErrorsOfCorrectness.Clear();

                        user_form.Childs.Insert(0, new HTML_Dom(html_types.div, new Dictionary<string, string>() { { "role", "alert" } }) { text = "Ошибка сохранения!", css_class = "alert alert-danger" });
                    }
                    else
                    {
                        g.DeliveryTypes_col.Update(delivery_obj);
                        sender.AddNotification(StatusNote.Success, card_head + " - Сохранён");
                        //
                        user_form = get_form(delivery_obj);
                        user_form.Childs.Add(new HTML_Dom(html_types.p));
                        user_form.Childs.Add(new HTML_Dom(html_types.hr));
                    }
                }
            }
            #endregion

            dom_elements.Add(HTML_Dom.Get_DIV_Bootstrap_Card(card_head, new List<HTML_Dom>() { user_form }));
        }*/

        /*HTML_Dom get_form(exDeliveryTypeClass ed)
        {

            HTML_Dom delivery_form = new HTML_Dom(html_types.form) { form_method = "post" };
            delivery_form.Childs.AddRange(HTML_Dom.GetBaseTextInput("Наименование", ed.Name, "name", "Название", false, "Укажите наименование. Используйте короткие, простые и понятные имена"));

            delivery_form.Childs.Add(HTML_Dom.GetSelectList("city", "Город", "Город доставки...", s_CityClass.GetListCityes, ed.CityID));

            delivery_form = SetDefInputs(delivery_form, ed);
            delivery_form.Childs.Add(HTML_Dom.GetButtonAsLink("/delivery", "Вернуться в доставку"));

            return delivery_form;
        }*/
    }
}
