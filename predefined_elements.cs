////////////////////////////////////////////////
// https://github.com/badhitman 
////////////////////////////////////////////////

using HtmlGenerator.html5;
using HtmlGenerator.html5.collections;
using HtmlGenerator.html5.forms;
using HtmlGenerator.set.entities;

namespace HtmlGenerator;

public static class Predefined_elements
{
    #region html.select
    //public static select GetSelectDom(string name_dom_object, OptionList ListItems, string selected_option_value = null, bool input_readonly = false, bool required = false, bool groups_only = true, bool groups_clickable = true) => GetSelectDom(name_dom_object, ListItems, new string[] { selected_option_value }, input_readonly, required);
    public static select GetSelectDom(string name_dom_object, OptionList ListItems, string[]? selected_option_values = null, bool input_readonly = false, bool required = false, bool groups_only = true, bool groups_clickable = true)
    {
        select ret_select = new() { Name_DOM = name_dom_object };

        if (selected_option_values is null)
        {
            selected_option_values = ["0"];
            ListItems.ListItems.Insert(0, new DataTreeItem() { Disabled = true, Tag = "элемент-заглушка", Title = "Выбор значения...", Tooltip = "Выберете значение", Value = "0" });
        }
        ret_select.Childs ??= [];
        WriteSelectDom(ref ret_select.Childs, ListItems.ListItems, selected_option_values, groups_only, groups_clickable);

        if (required)
            ret_select.SetAttribute("required", null);

        if (input_readonly)
            ret_select.CustomAttributes.Add("readonly", null);

        return ret_select;
    }
    private static void WriteSelectDom(ref List<base_dom_root> ret_options, List<DataTreeItem> ListItems, string[]? selected_option_values = null, bool groups_only = true, bool groups_clickable = true)
    {
        if (ListItems.Count == 0)
            return;

        optgroup.optgroup_set opt_set;
        optgroup option_dom;

        option.option_set option_set;

        foreach (DataTreeItem o_item in ListItems)
        {
            if (groups_only && !o_item.IsGroup)
                continue;

            if (o_item.IsGroup && !groups_clickable)
            {
                opt_set = new optgroup.optgroup_set
                {
                    TitleText = o_item.Title,
                    Disabled = o_item.Disabled
                };
                option_dom = new optgroup(opt_set);
            }
            else
            {
                option_set = new option.option_set
                {
                    TitleText = o_item.Title,
                    Disabled = o_item.Disabled,
                    Value = o_item.Value
                };
                option_dom = new option(option_set);
                if (selected_option_values is not null && Array.IndexOf(selected_option_values, option_set.Value) > -1)
                    option_set.Selected = true;
            }
            option_dom.AddCSS("tree-" + (o_item.IsGroup ? "group" : "item"));
            option_dom.Childs ??= [];
            WriteSelectDom(ref option_dom.Childs, o_item.Childs, selected_option_values, groups_only, groups_clickable);

            if (!string.IsNullOrEmpty(o_item.Tag))
                option_dom.SetAttribute("tag", o_item.Tag);

            ret_options.Add(option_dom);
        }
    }
    #endregion

    #region html.ul
    public static ul GetTreeViewDom(string id_dom_element, string ul_class, string li_class, OptionList ListItems)
    {
        ul ret_ul = new() { Id_DOM = id_dom_element };
        if (!string.IsNullOrEmpty(ul_class))
            ret_ul.AddCSS(ul_class, true);
        ret_ul.Childs ??= [];
        WriteUl(ref ret_ul.Childs, ListItems.ListItems, li_class);

        return ret_ul;
    }
    private static void WriteUl(ref List<base_dom_root> ret_options, List<DataTreeItem> ListItems, string li_class)
    {
        foreach (DataTreeItem o_item in ListItems)
        {
            li li_item = new() { InnerText = o_item.Title };

            if (o_item.Disabled)
                li_item.AddCSS("disabled");

            if (!string.IsNullOrEmpty(o_item.Tag))
                li_item.SetAttribute("tag", o_item.Tag);

            if (!string.IsNullOrEmpty(o_item.Tooltip))
                li_item.title = o_item.Tooltip;

            if (!string.IsNullOrEmpty(o_item.Value))
                li_item.Id_DOM = o_item.Value;

            if (o_item.IsGroup)
                li_item.AddCSS("tree-" + (o_item.IsGroup ? "group" : "item"));

            if (!string.IsNullOrEmpty(li_class))
                li_item.AddCSS(li_class, true);

            if (o_item.Childs.Count > 0)
            {
                li_item.Childs ??= [];
                WriteUl(ref li_item.Childs, o_item.Childs, li_class);
            }
            ret_options.Add(li_item);
        }
    }
    #endregion
}