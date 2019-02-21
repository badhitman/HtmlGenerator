////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    /// <summary>
    /// Страница заказов
    /// </summary>
    public class p_Orders : base_page_tmpl
    {
        /*
        public p_Orders(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;

            if (sender.get_params["buy"] != null)
            {
                exSupply buy_new = ServerController.getSupplyById(sender.get_params["buy"]);

                if (!buy_new.IsExist || (!(buy_new.Buyer_id is null) && buy_new.Buyer_id != sender.UserInitСalling.ID.ToString()))
                {
                    sender.notifications.Add(new WebNotificationClass(StatusNote.Danger, "Что-то пошло не так. Сделка отменена. Деньги не списаны. Попробуйте ещё раз сначала!"));
                }
                else if (buy_new.Price > sender.UserInitСalling.Balance && buy_new.Buyer_id != sender.UserInitСalling.ID.ToString())
                {
                    sender.notifications.Add(new WebNotificationClass(StatusNote.Danger, "Ошибка. У вас не достаточно средств для покупки!"));
                }
                else
                {
                    exGood good = ServerController.getGoodById(buy_new.Good_id);
                    if (buy_new.Buyer_id is null)
                    {
                        sender.UserInitСalling.Balance = sender.UserInitСalling.Balance - buy_new.Price;
                        sender.UserInitСalling.AmountPurchases = sender.UserInitСalling.AmountPurchases + buy_new.Price;
                        g.Users_col.Update(sender.UserInitСalling);

                        buy_new.Buyer_id = sender.UserInitСalling.ID.ToString();
                        buy_new.Sell_date = DateTime.Now;
                        g.Supplyes_col.Update(buy_new);
                    }
                    sender.notifications.Add(new WebNotificationClass(StatusNote.Success, "<fieldset><legend>Покупка " + buy_new.Sell_date.ToString(g.date_format) + " " + buy_new.Sell_date.ToString("H:mm:ss") + "</legend>" +
                        "<ul>" +
                        "<li>" + good.Name + " " + buy_new.Quantity + " " + s_GoodUnitsClass.GetUnit(good.Unit).Name + " за " + buy_new.Price + "руб</li>" +
                        "<li>" + buy_new.City().Name + " " + buy_new.DeliveryTerms().Name + "</li>" +
                        "</ul>" +
                        "<hr>" +
                        good.Name + buy_new.Description + "</fieldset>"));
                }
            }
            string card_head = "<strong>Заказы</strong>";
            dom_elements.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card(card_head, GetOrders() ));
        }*/


        /*public HtmlDomGenerator GetOrders()
        {
            bool is_moderator = sender.UserInitСalling.AccessLevel > AccessLevelUser.Buyer;
            
            List<exSupply> supplies = ServerController.GetOrders(sender.UserInitСalling.ID.ToString());
            sender.Paginations.ReloadDataList(ref supplies);

            return HtmlDomGenerator.GetOrdersAsTable(supplies);
        }*/
    }
}