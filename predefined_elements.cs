////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom;
using HtmlGenerator.set;

namespace HtmlGenerator
{
    public static class predefined_elements
    {
        public static select GetSelectList(string id_dom_element, OptionList ListItems, string selected_option_id = null, bool input_readonly = false, bool required = false)
        {
            select.select_set select_set = new select.select_set();

            select ret_select = new select(select_set) { Id_DOM = id_dom_element, Name_DOM = id_dom_element };

            if (string.IsNullOrEmpty(selected_option_id))
            {
                selected_option_id = "0";
                ListItems.ListItems.Insert(0, new OptionItem() { Disabled = true, Tag = "элемент-заглушка", Title = "Выберете значение", Tooltip = "Выберете значение", Value = "0" });
            }

            optgroup option_dom;
            foreach (OptionItem o_item in ListItems.ListItems)
            {
                if (o_item.Childs.Count > 0)
                {
                    optgroup.optgroup_set optgroup_set = new optgroup.optgroup_set();
                    optgroup_set.TitleText = o_item.Title;
                    optgroup_set.Disabled = o_item.Disabled;
                    //
                    option_dom = new optgroup(optgroup_set);

                    foreach (OptionItem sub_o_item in o_item.Childs)
                    {
                        option.option_set option_set = new option.option_set();
                        option_set.Disabled = sub_o_item.Disabled;
                        option_set.TitleText = sub_o_item.Title;
                        option_set.Value = sub_o_item.Value;

                        if (option_set.Value == selected_option_id)
                            option_set.Selected = true;

                        option sub_item = new option(option_set);

                        if (!string.IsNullOrEmpty(sub_o_item.Tag))
                            option_dom.SetAtribute("tag", sub_o_item.Tag);

                        option_dom.Childs.Add(sub_item);
                    }
                }
                else
                {
                    option.option_set option_set = new option.option_set();
                    option_set.TitleText = o_item.Title;
                    option_set.Disabled = o_item.Disabled;
                    option_set.Value = o_item.Value;
                    if (option_set.Value == selected_option_id)
                        option_set.Selected = true;
                    //
                    option_dom = new option(new option.option_set());
                }
                if (!string.IsNullOrEmpty(o_item.Tag))
                    option_dom.SetAtribute("tag", o_item.Tag);

                ret_select.Childs.Add(option_dom);
            }

            if (required)
                ret_select.SetAtribute("required", null);

            if (input_readonly)
                ret_select.CustomAtributes.Add("disabled", null);

            return ret_select;
        }
    }
}
