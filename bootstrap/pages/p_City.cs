////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    public class p_City : base_page_tmpl
    {
        /*
        public p_City(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;

            user_form = new HTML_Dom();
            string card_head = "<strong>Город</strong>";
            exCityClass ec = new exCityClass();

            #region Отобразить форму для создания нового объекта
            if (sender.get_params["id"] == null)
            {
                card_head = "Создать " + card_head;
                user_form = get_form(ec);
            }
            #endregion

            #region Запись нового объекта
            else if (sender.get_params["id"] == null && sender.post_params.Count > 0)
            {
                ec.ParsePostParam(sender.post_params);
                if (!ec.isCorrectFilling)
                {
                    user_form = get_form(ec);
                    sender.AddRangeNotifications(StatusNote.Danger, ec.ErrorsOfCorrectness.ToArray());
                    
                    user_form.Childs.Insert(0, new HTML_Dom(html_types.div, new Dictionary<string, string>() { { "role", "alert" } }) { text = "Ошибка сохранения!", css_class = "alert alert-danger" });
                }
                else
                {
                    g.Cityes_col.Insert(ec);
                    user_form = new HTML_Dom() { css_class = "alert alert-light" };
                    user_form.custom_atributes.Add("role", "alert");
                    user_form.Childs.Add(new HTML_Dom(html_types.h3) { text = "Сохранено", css_class = "text-center text-success" });
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/delivery", "Вернуться в доставку"));
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/delivery/city?id=" + ec.ID, "Открыть объект"));
                }
            }
            #endregion

            #region Открыть/Сохранить существующий объект
            else
            {
                string id_city = "-1";
                if (Regex.IsMatch(sender.get_params["id"], @"^\d+$"))
                    id_city = sender.get_params["id"];

                ec = ServerController.getCityById(id_city);
                if (ec.ErrorsOfCorrectness.Count > 0)
                {
                    card_head = card_head + " !ERR!ERR!ERR!";
                    sender.AddRangeNotifications(StatusNote.Danger, ec.ErrorsOfCorrectness.ToArray());
                    user_form = new HTML_Dom() { css_class = "alert alert-light" };
                    user_form.custom_atributes.Add("role", "alert");
                    user_form.Childs.Add(new HTML_Dom(html_types.h4) { text = "ОШИБКА", css_class = "text-center text-danger" });
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/delivery", "Перейти в доставку"));
                }
                else
                {
                    ec.ParsePostParam(sender.post_params);

                    if (!ec.isCorrectFilling)
                    {
                        user_form = get_form(ec);
                        sender.AddRangeNotifications(StatusNote.Danger, ec.ErrorsOfCorrectness.ToArray());
                        ec.ErrorsOfCorrectness.Clear();

                        user_form.Childs.Insert(0, new HTML_Dom(html_types.div, new Dictionary<string, string>() { { "role", "alert" } }) { text = "Ошибка сохранения!", css_class = "alert alert-danger" });
                    }
                    else
                    {
                        if (sender.post_params.Count > 0)
                        {
                            g.Cityes_col.Update(ec);
                            sender.AddNotification(StatusNote.Success, card_head + " - Сохранён");
                        }
                        user_form = get_form(ec);
                        user_form.Childs.Add(new HTML_Dom(html_types.p));
                        user_form.Childs.Add(new HTML_Dom(html_types.hr));
                    }
                }
            }
            #endregion

            dom_elements.Add(HTML_Dom.Get_DIV_Bootstrap_Card(card_head, new List<HTML_Dom>() { user_form }));
        }*/
        /*
        HTML_Dom get_form(exCityClass e_city)
        {
            HTML_Dom city_form = new HTML_Dom(html_types.form) { form_method = "post" };
            //
            city_form.Childs.AddRange(HTML_Dom.GetBaseTextInput("Название", e_city.Name, "name", "Название города", false, "Наименование города"));
            city_form = SetDefInputs(city_form, e_city);
            //
            city_form.Childs.Add(HTML_Dom.GetButtonAsLink("/delivery", "Перейти в доставку"));
            return city_form;
        }*/
    }
}