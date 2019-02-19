////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    class p_Qiwi : base_page_tmpl
    {
        /*
        exQiwi eq = new exQiwi();
        public p_Qiwi(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;
            
            user_form = new HTML_Dom();

            string card_head = "<strong>QIWI</strong>";

            #region Отобразить форму для создания нового объекта
            if (sender.get_params["id"] == null && sender.post_params.Count == 0)
            {
                user_form = get_form();
                card_head = "Создание нового кошелька " + card_head;
            }
            #endregion

            #region Запись нового объекта
            else if (sender.get_params["id"] == null && sender.post_params.Count > 0)
            {
                eq.ParsePostParam(sender.post_params);
                if (!eq.isCorrectFilling)
                {
                    sender.AddRangeNotifications(StatusNote.Danger, eq.ErrorsOfCorrectness.ToArray());
                    user_form = get_form();
                    eq.ErrorsOfCorrectness.Clear();
                    user_form.Childs.Insert(0, new HTML_Dom(html_types.div, new Dictionary<string, string>() { { "role", "alert" } }) { text = "Ошибка сохранения!", css_class = "alert alert-danger" });
                }
                else
                {
                    g.Qiwi_col.Insert(eq);
                    UpdateQiwiOnline(eq.qiwi_api_key, ref sender);

                    user_form = new HTML_Dom() { css_class = "alert alert-light" };
                    user_form.custom_atributes.Add("role", "alert");
                    user_form.Childs.Add(new HTML_Dom(html_types.h3) { text = "Сохранено", css_class = "text-center text-success" });
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/finance-qiwi", "Вернуться в финансы"));
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/financ-qiwie/qiwi?id=" + eq.ID, "Открыть объект"));
                }
            }
            #endregion

            #region Открыть/Сохранить существующий объект
            else
            {
                string id_qiwi = null;
                if (Regex.IsMatch(sender.get_params["id"].Trim(), @"^\d+$"))
                    id_qiwi = sender.get_params["id"];
                eq = ServerController.getQiwiById(id_qiwi);
                if (!eq.IsActive)
                {
                    card_head = card_head + " [" + sender.get_params["id"] + "] не найден!";
                    sender.AddNotification(StatusNote.Danger, "Ошибка в запросе. Объект с таким ID не обнаружен");
                    user_form = new HTML_Dom() { css_class = "alert alert-light" };
                    user_form.custom_atributes.Add("role", "alert");
                    user_form.Childs.Add(new HTML_Dom(html_types.h4) { text = "ОШИБКА", css_class = "text-center text-danger" });
                    user_form.Childs.Add(HTML_Dom.GetButtonAsLink("/finance-qiwi", "Вернуться в финансы"));
                }
                else
                {
                    eq.ParsePostParam(sender.post_params);
                    if (!eq.isCorrectFilling)
                    {
                        user_form = get_form();
                        sender.AddRangeNotifications(StatusNote.Danger, eq.ErrorsOfCorrectness.ToArray());
                        eq.ErrorsOfCorrectness.Clear();

                        user_form.Childs.Insert(0, new HTML_Dom(html_types.div, new Dictionary<string, string>() { { "role", "alert" } }) { text = "Ошибка сохранения!", css_class = "alert alert-danger" });
                    }
                    else
                    {
                        if (sender.post_params.Count > 0)
                            UpdateQiwiOnline(eq.qiwi_api_key, ref sender);
                        user_form = get_form();
                        user_form.Childs.Add(new HTML_Dom(html_types.p));
                        user_form.Childs.Add(new HTML_Dom(html_types.hr));
                        user_form.Childs.Add(GetTransactions(eq.ID.ToString()));
                    }
                }
            }
            #endregion

            dom_elements.Add(HTML_Dom.Get_DIV_Bootstrap_Card(card_head, new List<HTML_Dom>() { user_form }));*/
        //}

        /// <summary>
        /// Прочитать из БД транзакции кошелька
        /// </summary>
        /// <param name="qiwi_id"></param>
        /// <returns></returns>
        //HtmlDomGenerator GetTransactions(string qiwi_id)
        //{
            //return null;
            //string[] t_heads = new string[] { "D/T/I", "<span class='glyphicon glyphicon-transfer'></spam>", "Sum", "Coment" };
            //List<string[]> table_body = new List<string[]>();
            //string tmpl_format;
            //foreach (QiwiPaymentClass transaction_item in g.Transactions_col.Find(Query.EQ(g.GetMemberName((QiwiPaymentClass c) => c.Qiwi_id), qiwi_id)).OrderByDescending(x => x.DatePayment))
            //{
            //    tmpl_format = "<a data-toggle='tooltip' title='" + transaction_item.Information + "' href='/finance-qiwi/qiwi/transaction?id=" + transaction_item.txnId + "'>{0}</a>";

            //    table_body.Add(new string[]
            //    {
            //        string.Format(tmpl_format, "<small>" + transaction_item.DatePayment.ToString(g.date_format) + "</small><br/><small class='text-secondary'>" + transaction_item.DatePayment.ToString(g.time_format) + "</small><br/><small class='text-info'>" + transaction_item.TxnId + "</small>"),
            //        string.Format(tmpl_format,  GetTypeOfPayment(transaction_item.PaymentType) + (transaction_item.PaymentStatus == exTransactionClass.PaymentStatuses.SUCCESS ? "" : "<span class='glyphicon glyphicon-alert text-danger' data-toggle='tooltip' title='[err:" + transaction_item.Error + "][code:" + transaction_item.StatusCodeTransaction.ToString() + "][status:" + transaction_item.StatusText + "]'></span>")),
            //        string.Format(tmpl_format, transaction_item.sum.ToString()),
            //        string.Format(tmpl_format, transaction_item.comment)

            //    });
            //}
            //return HtmlController.GetTable(t_heads, table_body, "table-hover");
        //}
        
        //string GetTypeOfPayment(exTransactionClass.TypeOfPayments t_pay)
        //{
        //    HtmlController ret_val = new HtmlController(html_types.span) { inline = true };
        //    ret_val.css_class = "glyphicon ";
        //    switch (t_pay)
        //    {
        //        case exTransactionClass.TypeOfPayments.IN:
        //            ret_val.css_class += "glyphicon-plus-sign text-success";
        //            break;
        //        case exTransactionClass.TypeOfPayments.OUT:
        //            ret_val.css_class += "glyphicon-minus-sign text-primary";
        //            break;
        //        case exTransactionClass.TypeOfPayments.QIWI_CARD:
        //            ret_val.css_class += "glyphicon glyphicon-credit-card text-secondary";
        //            break;
        //        default:
        //            break;
        //    }
        //    return ret_val.HTML(0);
        //}
        /*
        HTML_Dom get_form()
        {
            HTML_Dom qiwi_form = new HTML_Dom(html_types.form) { form_method = "post" };
            qiwi_form.Childs.AddRange(HTML_Dom.GetBaseTextInput("API ключ QIWI", eq.qiwi_api_key, g.GetMemberName((exQiwiClass c)=>c.qiwi_api_key), "Ключ API QIWI", false, "Получите свой ключ 'OAuth 2.0' тут https://qiwi.com/api"));
            qiwi_form.Childs.AddRange(HTML_Dom.GetBaseTextInput("Лимит на остаток", eq.max_balance.ToString(), g.GetMemberName((exQiwiClass c) => c.max_balance), "Максимальный допустимый баланс", false, "Установите максимальный допустимый остаток на счету QIWI"));
            qiwi_form.Childs.AddRange(HTML_Dom.GetBaseTextInput("Лимит на оборот", eq.total_limit.ToString(), g.GetMemberName((exQiwiClass c) => c.total_limit), "Максимальный оборот", false, "Установите максимальный разрешёный оборот поступлений на счёт QIWI"));

            qiwi_form.Childs.AddRange(HTML_Dom.GetBaseTextInput("Номер кошелька", eq.qiwi_num, "", "", true, "Номер телефона (Номер счёта QIWI)"));
            qiwi_form.Childs.AddRange(HTML_Dom.GetBaseTextInput("Баланс. " + eq.LastUpdateApiInfoAsString(false), eq.Balance.ToString(), "", "", true, "Баланс QIWI на момент последнего обновления"));
            qiwi_form.Childs.AddRange(HTML_Dom.GetBaseTextInput("Приход по кошельку", eq.TotalSum.ToString(), "", "", true, "Суммарный приход на кошелёк за всё время"));

            qiwi_form = SetDefInputs(qiwi_form, eq);
            qiwi_form.Childs.Add(HTML_Dom.GetButtonAsLink("/finance-qiwi", "Вернуться в финансы"));
            
            return qiwi_form;
        }*/
        /*
        void UpdateQiwiOnline(string qiwi_api_key, ref PageGeneratorClass sender)
        {
            //QIWI_API_Class q_raw = new QIWI_API_Class(eq.qiwi_api_key);
            
            //eq.Off = true;

            //if (q_raw.my_profile == null)
            //    sender.AddNotification(StatusNote.Danger, "QIWI API - не действительный");

            //else if (q_raw.my_profile.contractInfo.blocked)
            //    sender.AddNotification(StatusNote.Danger, "QIWI - заблокирован");

            //else
            //{
            //    eq.Balance = q_raw.CurrentBalance.GetQiwiBalance;
            //    eq.qiwi_num = q_raw.my_profile.contractInfo.contractId.ToString();
            //    eq.TotalSum = q_raw.PaymentsTotal(uniqueDateTime.NewDateTime.AddDays(-89), uniqueDateTime.NewDateTime).GetInByCurrency("643");
            //    eq.LastUpdateApi = uniqueDateTime.NewDateTime;
            //    eq.Off = false;
            //    QiwiPaymentsDataClass pay_data = q_raw.PaymentHistory();
            //    QiwiPaymentClass[] transactions_qiwi = pay_data.data;
            //    foreach (QiwiPaymentClass pay in transactions_qiwi)
            //    {
            //        exTransactionClass transaction = new exTransactionClass(eq.ID.ToString(), pay);
            //        exTransactionClass transaction_db = g.Transactions_col.FindOne(Query.EQ(g.GetMemberName((exTransactionClass c) => c.TxnId), transaction.TxnId));
            //        if (transaction_db == null)
            //        {
            //            g.Transactions_col.Insert(transaction);
            //            if(transaction.PaymentStatus == exTransactionClass.PaymentStatuses.SUCCESS && 
            //                transaction.PaymentType == exTransactionClass.TypeOfPayments.IN && 
            //                transaction.StatusCodeTransaction == exTransactionClass.QiwiPayErrorCode.OK)
            //            {

            //            }
            //        }
            //        else
            //        {
            //            if(!transaction.Equals(transaction_db))
            //            {
            //                //transaction.ID = transaction_db.ID;
            //                transaction.Information += "<транзакция изменилась " + customDateTime.NewDateTime.ToString() + ">";
            //                g.Transactions_col.Update(transaction);
            //            }
            //        }
            //    }
            //    sender.AddNotification(generator.StatusNote.Success, "QIWI - Сохранён");
            //}
            //g.Qiwi_col.Update(eq);
        }*/
    }
}
