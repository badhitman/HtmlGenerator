////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.bootstrap.pages
{
    /// <summary>
    /// Управление финансовыми операциями
    /// </summary>
    public class p_List_Btc : base_page_tmpl
    {
        /*

        public p_List_Btc(PageGeneratorClass sender)
            : base(sender)
        {
            if (dom_elements.Count > 0)
                return;


            if (g.ElectrumClient is null)
            {
                dom_elements.Add(new HtmlDomGenerator(TypesHtmlDom.h2) { text = "Electrum client is null" });
                return;
            }
            Electrum.Response.Model.BalanceResponseClass wallet_balance = g.ElectrumClient.GetBalanceWallet();
            HtmlDomGenerator walet_balance = new HtmlDomGenerator() { css_class = "btn btn-primary btn-lg btn-block" };

            if (wallet_balance == null)
                walet_balance.text = "Ошибка! Результат запроса к Electrum API = null";
            else if (wallet_balance.error != null)
                walet_balance.text = "Ошибка запроса баланса кошелька => code:" + wallet_balance.error.code + "; message:" + wallet_balance.error.message;
            else
                walet_balance.text = "confirmed=> " + wallet_balance.result.confirmed + "; unconfirmed=> " + wallet_balance.result.unconfirmed;

            HtmlDomGenerator html_response = new HtmlDomGenerator();
            html_response.Childs.Add(walet_balance);

            dom_elements.Add(HtmlDomGenerator.Get_DIV_Bootstrap_Card("Bitcoin кошелёк", new List<HtmlDomGenerator>() { html_response }));
        }*/
    }
}