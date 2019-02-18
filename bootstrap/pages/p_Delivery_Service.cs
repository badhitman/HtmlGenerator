////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////

namespace DataViewHtml.bootstrap.pages
{
    public class p_Delivery_Service : base_page_tmpl
    {
        /*

        public p_Delivery_Service(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;

            user_form = new HTML_Dom();
            string card_head = "<strong>Служба доставки</strong>";
            exDeliveryServiceClass ed = new exDeliveryServiceClass();

            #region Отобразить форму для создания нового объекта
            if (sender.get_params["id"] == null && sender.post_params.Count == 0)
            {
                card_head = "Создать " + card_head;
                user_form = get_form(ed);
            }
            #endregion

            #region Запись нового объекта
            else if (sender.get_params["id"] == null && sender.post_params.Count > 0)
            {
                ed.ParsePostParam(sender.post_params);
                if (!ed.isCorrectFilling)
                {
                    user_form = get_form(ed);
                    foreach (string s in ed.ErrorsOfCorrectness)
                        sender.AddNotification(StatusNote.Danger, s);

                    user_form.Childs.Insert(0, new HTML_Dom(html_types.div, new Dictionary<string, string>() { { "role", "alert" } }) { text = "Ошибка сохранения!", css_class = "alert alert-danger" });
                }
                else
                {
                    g.DeliveryServices_col.Insert(ed);
                    user_form = new HTML_Dom() { css_class = "alert alert-light" };
                    user_form.custom_atributes.Add("role", "alert");
                    user_form.Childs.Add(new HTML_Dom(html_types.h3) { text = "Сохранено", css_class = "text-center text-success" });
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/delivery", "Вернуться в доставку"));
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/delivery/delivery-service?id=" + ed.ID, "Открыть объект"));
                }
            }
            #endregion

            #region Открыть/Сохранить существующий объект
            else
            {
                string id_delivery = "-1";
                if (Regex.IsMatch(sender.get_params["id"], @"^\d+$"))
                    id_delivery = sender.get_params["id"];

                ed = ServerController.getDeliveryServiceById(id_delivery);
                if (ed.ErrorsOfCorrectness!= null && ed.ErrorsOfCorrectness.Count > 0)
                {
                    card_head = card_head + " !ERR!ERR!ERR!";
                    sender.AddRangeNotifications(StatusNote.Danger, ed.ErrorsOfCorrectness.ToArray());
                    user_form = new HTML_Dom() { css_class = "alert alert-light" };
                    user_form.custom_atributes.Add("role", "alert");
                    user_form.Childs.Add(new HTML_Dom(html_types.h4) { text = "ОШИБКА", css_class = "text-center text-danger" });
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/delivery", "Перейти в доставку"));
                }
                else
                {
                    ed.ParsePostParam(sender.post_params);
                    if (!ed.isCorrectFilling)
                    {
                        user_form = get_form(ed);
                        foreach (string s in ed.ErrorsOfCorrectness)
                            sender.AddNotification(StatusNote.Danger, s);

                        user_form.Childs.Insert(0, new HTML_Dom(html_types.div, new Dictionary<string, string>() { { "role", "alert" } }) { text = "Ошибка сохранения!", css_class = "alert alert-danger" });
                    }
                    else
                    {
                        if (sender.post_params.Count > 0)
                        {
                            g.DeliveryServices_col.Update(ed);
                            sender.AddNotification(StatusNote.Success, card_head + " - Сохранён");
                        }
                        user_form = get_form(ed);
                        user_form.Childs.Add(new HTML_Dom(html_types.p));
                        user_form.Childs.Add(new HTML_Dom(html_types.hr));
                    }
                }
            }
            #endregion

            dom_elements.Add(HTML_Dom.Get_DIV_Bootstrap_Card(card_head, new List<HTML_Dom>() { user_form }));
        }*/

        /*HTML_Dom get_form(exDeliveryServiceClass ed)
        {

            HTML_Dom delivery_form = new HTML_Dom(html_types.form) { form_method = "post" };
            delivery_form.Childs.AddRange(HTML_Dom.GetBaseTextInput("Наименование", ed.Name, "name", "Название", false, "Укажите наименование. Используйте короткие, простые и понятные имена"));
            delivery_form = SetDefInputs(delivery_form, ed);

            delivery_form.Childs.Add(HTML_Dom.GetButtonAsLink("/delivery", "Перейти в доставку"));

            return delivery_form;
        }*/
    }
}
