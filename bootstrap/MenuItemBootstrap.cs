////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

using HtmlGenerator.html5.collections;
using HtmlGenerator.html5.textual;
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5;
using HtmlGenerator.set;

namespace HtmlGenerator.bootstrap;

/// <summary>
/// Menu item
/// </summary>
/// <remarks>
/// Menu item
/// </remarks>
public class MenuItemBootstrap(string in_text, string in_href, string in_tool_tip) : safe_base_dom_root
{
    /// <summary>
    /// НЕ ИСПОЛЬЗУЙ ЭТО! При формировании HTML(int deep = 0) - этот список пере-заполняется.
    /// Для наполнения тела модального окна используется BodyElements
    /// </summary>
    public new List<base_dom_root>? Childs { get => base.Childs; set => base.Childs = value; }

    /// <summary>
    /// Вложенные элементы пунктов меню
    /// </summary>
    public List<MenuItemBootstrap> SubItems = [];

    /// <summary>
    /// CSS класс для [LI] контейнера
    /// </summary>
    public string li_class = "nav-item";

    /// <summary>
    /// CSS класс для [A] контейнера
    /// </summary>
    public string a_class = "nav-link";

    /// <summary>
    /// Ссылка пункта меню
    /// </summary>
    public string href_menu_item = in_href;

    /// <summary>
    /// Текст пункта меню
    /// </summary>
    public string text_menu_item = in_text;

    /// <summary>
    /// Подсказка для пункта меню
    /// </summary>
    public string tool_tip = in_tool_tip;

    /// <summary>
    /// li
    /// </summary>
    public override string tag_custom_name => "li";

    /// <inheritdoc/>
    /// <remarks>При вызове этого метода поле Childs очищается и заново заполняется</remarks>
    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        AddCSS(li_class, true);
        a a_dom_result = new() { href = href_menu_item, target = TargetsEnum._self, InnerText = text_menu_item };
        a_dom_result.AddCSS(a_class, true);
        if (SubItems.Count > 0)
        {
            AddCSS("dropdown");
            //
            a_dom_result.AddCSS("dropdown-toggle");
            a_dom_result.CustomAttributes.Add("data-toggle", "dropdown");
            a_dom_result.CustomAttributes.Add("aria-haspopup", "true");
            a_dom_result.CustomAttributes.Add("aria-expanded", "false");
            string id_a_parent = "dropdown_" + new Guid().ToString().Replace("-", "");
            a_dom_result.Id_DOM = id_a_parent;
            //
            div submenu = new();
            submenu.AddCSS("dropdown-menu");
            submenu.CustomAttributes.Add("aria-labelledby", id_a_parent);
            foreach (MenuItemBootstrap i in SubItems)
            {
                a dropdown_item = new() { Inline = true, href = i.href_menu_item, target = TargetsEnum._blank, InnerText = i.text_menu_item };
                dropdown_item.AddCSS("dropdown-item");
                submenu.Childs ??= [];
                submenu.Childs.Add(dropdown_item);
            }
            Childs.Add(submenu);
        }
        Childs.Add(a_dom_result);

        return base.GetHTML(deep);
    }
}