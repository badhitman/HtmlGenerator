////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom;
using HtmlGenerator.set;
using System;
using System.Collections.Generic;

namespace HtmlGenerator
{
    public static class Predefined_elements
    {
        #region html.dom.select
        public static select GetSelectList(string id_dom_element, OptionList ListItems, string selected_option_id = null, bool input_readonly = false, bool required = false) => GetSelectList(id_dom_element, ListItems, new string[] { selected_option_id }, input_readonly, required);
        public static select GetSelectList(string id_dom_element, OptionList ListItems, string[] selected_option_id = null, bool input_readonly = false, bool required = false)
        {
            select.select_set select_set = new select.select_set();

            select ret_select = new select(select_set) { Id_DOM = id_dom_element, Name_DOM = id_dom_element };

            if (selected_option_id is null)
            {
                selected_option_id = new string[] { "0" };
                ListItems.ListItems.Insert(0, new OptionItem() { Disabled = true, Tag = "элемент-заглушка", Title = "Выбор значения...", Tooltip = "Выберете значение", Value = "0" });
            }
            write_select_list(ref ret_select.Childs, ListItems.ListItems, selected_option_id);

            if (required)
                ret_select.SetAtribute("required", null);

            if (input_readonly)
                ret_select.CustomAtributes.Add("readonly", null);

            return ret_select;
        }
        private static void write_select_list(ref List<basic_html_dom> ret_options, List<OptionItem> ListItems, string[] selected_options_id = null)
        {
            optgroup option_dom;
            optgroup.optgroup_set optgroup_set;

            foreach (OptionItem o_item in ListItems)
            {
                if (o_item.Childs.Count == 0)
                {
                    option.option_set option_set = new option.option_set();
                    option_set.TitleText = o_item.Title;
                    option_set.Disabled = o_item.Disabled;
                    option_set.Value = o_item.Value;
                    
                    if (!(selected_options_id is null) && Array.IndexOf(selected_options_id, option_set.Value) >= 0)
                        option_set.Selected = true;
                    //
                    option_dom = new option(new option.option_set());
                    if (!string.IsNullOrEmpty(o_item.CSS))
                        option_dom.css_class += " "+ o_item.CSS;
                }
                else
                {
                    optgroup_set = new optgroup.optgroup_set();
                    optgroup_set.TitleText = o_item.Title;
                    optgroup_set.Disabled = o_item.Disabled;
                    //
                    option_dom = new optgroup(optgroup_set);
                    write_select_list(ref option_dom.Childs, o_item.Childs, selected_options_id);
                }

                if (!string.IsNullOrEmpty(o_item.Tag))
                    option_dom.SetAtribute("tag", o_item.Tag);

                ret_options.Add(option_dom);
            }
        }
        #endregion

        #region html.dom.ul
        public static ul GetTreeView(string id_dom_element, string ul_class,string li_class, OptionList ListItems)
        {
            ul ret_ul = new ul();
            if (!string.IsNullOrEmpty(ul_class))
                ret_ul.css_class = ul_class;

            write_ul_list(ref ret_ul.Childs, ListItems.ListItems, li_class);

            return ret_ul;
        }
        private static void write_ul_list(ref List<basic_html_dom> ret_options, List<OptionItem> ListItems, string li_class)
        {
            foreach (OptionItem o_item in ListItems)
            {
                li li_item = new li(o_item.Title);

                if (o_item.Disabled)
                    li_item.css_class += " disabled";

                if (!string.IsNullOrEmpty(o_item.Tag))
                    li_item.SetAtribute("tag", o_item.Tag);

                if (!string.IsNullOrEmpty(o_item.Tooltip))
                    li_item.Tooltip = o_item.Tooltip;

                if (!string.IsNullOrEmpty(o_item.Value))
                    li_item.Id_DOM = o_item.Value;

                if (!string.IsNullOrEmpty(o_item.CSS))
                    li_item.css_class += " " + o_item.CSS;

                if (!string.IsNullOrEmpty(li_class))
                    li_item.css_class += " " + li_class;

                if (o_item.Childs.Count > 0)
                    write_ul_list(ref li_item.Childs, o_item.Childs, li_class);

                ret_options.Add(li_item);
            }
        }
        #endregion
    }
}
