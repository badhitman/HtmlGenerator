////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom;

namespace HtmlGenerator
{
    public static class predefined_elements_bootstrap
    {
        public static div GetBootstrapSelectList(string label, select select_body, string Tooltip = null, string wrap_class = "input-group mb-4 col-auto")
        {
            div ret_dom = new div() { css_class = wrap_class };

            if (!string.IsNullOrEmpty(label))
            {
                ret_dom.Childs.Add(new div { css_class = "input-group-prepend" });
                ret_dom.Childs[0].Childs.Add(new label(label, select_body.Id_DOM) { css_class = "input-group-text" });
            }
            select_body.css_class = (select_body.css_class.Trim() + " custom-select").Trim();

            if (!string.IsNullOrEmpty(Tooltip))
                ret_dom.Tooltip = Tooltip;

            ret_dom.SetAtribute("data-toggle", "tooltip");
            ret_dom.Childs.Add(select_body);
            return ret_dom;
        }
    }
}
