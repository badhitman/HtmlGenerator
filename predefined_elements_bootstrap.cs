////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom;

namespace HtmlGenerator
{
    public static class predefined_elements_bootstrap
    {
        public static div GetBootstrapSelectList(select select_body)
        {
            div ret_val = new div();
                //GetSelectList(id_dom_element, ListItems, selected_option_id, input_readonly, required);
            return ret_val;
        }


        //ListItems.ListItems.ForEach(x => ret_select.AddOption("label", "value"));

        /*

  

         */
        /*div wrap_selected_input = new div() { css_class = "input-group mb-4 col-auto" };
        wrap_selected_input.Childs.Add(new HtmlDomGenerator() { css_class = "input-group-prepend" });
        wrap_selected_input.Childs[0].Childs.Add(new HtmlDomGenerator(TypesHtmlDom.label) { text = label_text, css_class = "input-group-text", _for = id_dom_element });

        HtmlDomGenerator ret_dom = new HtmlDomGenerator(TypesHtmlDom.select) { Id_DOM = id_dom_element, Name_DOM = id_dom_element, css_class = "custom-select", title = placeholder };

        if (string.IsNullOrEmpty(selected_id))
        {
            selected_id = "0";
            ret_dom.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.option) { text = "Укажите значение", CustomAtributes = new Dictionary<string, string>() { { "value", selected_id }, { "selected", null }, { "disabled", null } } });
        }

        ret_dom.CustomAtributes.Add("data-toggle", "tooltip");
        if (required)
            ret_dom.CustomAtributes.Add("required", null);

        HtmlDomGenerator option_dom;
        foreach (OptionItem o_item in ListItems)
        {
            if (o_item.Childs.Count > 0)
                option_dom = new HtmlDomGenerator(TypesHtmlDom.optgroup) { CustomAtributes = new Dictionary<string, string>() { { "label", o_item.Name } } };
            else
                option_dom = new HtmlDomGenerator(TypesHtmlDom.option) { text = o_item.Name };

            if (!string.IsNullOrEmpty(o_item.Tag))
                option_dom.CustomAtributes.Add("tag", o_item.Tag);

            if (o_item.Disabled)
                option_dom.CustomAtributes.Add("disabled", "disabled");

            option_dom.title = o_item.Description;
            if (o_item.Childs.Count == 0)
                option_dom.CustomAtributes.Add("value", o_item.value.ToString());

            if (!(selected_id is null) && selected_id.ToLower() == o_item.value.ToLower())
                option_dom.CustomAtributes.Add("selected", "selected");

            if (o_item.Childs.Count > 0)
                foreach (OptionItem sub_o_item in o_item.Childs)
                {
                    option_dom.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.option) { text = sub_o_item.Name, CustomAtributes = new Dictionary<string, string>() { { "value", sub_o_item.value.ToString() } } });

                    if (!string.IsNullOrEmpty(sub_o_item.Tag))
                        option_dom.Childs[option_dom.Childs.Count - 1].CustomAtributes.Add("tag", sub_o_item.Tag);

                    if (sub_o_item.Disabled)
                        option_dom.Childs[option_dom.Childs.Count - 1].CustomAtributes.Add("disabled", "disabled");


                    if (!(selected_id is null) && selected_id.ToLower() == sub_o_item.value.ToLower())
                        option_dom.Childs[option_dom.Childs.Count - 1].CustomAtributes.Add("selected", "selected");
                }

            ret_dom.Childs.Add(option_dom);
        }
        if (input_readonly)
            ret_dom.CustomAtributes.Add("disabled", null);

        wrap_selected_input.Childs.Add(ret_dom);
        wrap_selected_input.Childs.AddRange(GetValidationAlerts(id_dom_element));
        // 

        return wrap_selected_input;*/
    }
}
