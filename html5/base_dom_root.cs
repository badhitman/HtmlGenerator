////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

using System.Text.RegularExpressions;
using HtmlGenerator.html5.textual;
using HtmlGenerator.set;

namespace HtmlGenerator.html5;

/// <summary>
/// Базовый HTML.DOM
/// </summary>
public abstract partial class base_dom_root
{
    #region Поля
    /// <summary>
    /// Символ(ы) табуляции/отступа.
    /// Рекомендуется \t или [два пробела]
    /// </summary>
    public static string TabString { get; set; } = "\t";

    /// <summary>
    /// имя тега автоматически переводится в нижний регистр
    /// </summary>
    public virtual bool TagNameToLower { get; set; } = true;

    /// <summary>
    /// HTML Комментирование блока/элемента. Оборачивает текущий блок в два комментария (непосредственно до и после DOM блока).
    /// Если указать только начальный/верхний комментарий, то он же будет использоваться и в нижнем.
    /// </summary>
    public string before_comment_block = "";
    /// <inheritdoc/>
    public string after_comment_block = "";

    /// <summary>
    /// Ручное указание имени/типа элемента/тэга
    /// По умолчанию имя/тип определяется по имени типа класса, но в случае необходимости его можно изменить на собственный
    /// </summary>
    public virtual string? tag_custom_name { get; set; }

    /// <summary>
    /// Идентификатор/ID элемента в DOM
    /// </summary>
    public string? Id_DOM;

    /// <summary>
    /// Имя/Name элемента в DOM
    /// </summary>
    public string? Name_DOM;

    /// <summary>
    /// Позволяет получить доступ к элементу с помощью заданного сочетания клавиш. Браузеры при этом используют различные комбинации клавиш.
    /// </summary>
    public string? accesskey;

    /// <summary>
    /// Определяет "style" непосредственно для элемента
    /// </summary>
    public string css_style = "";

    /// <summary>
    /// Сообщает, что элемент доступен для редактирования пользователем — можно удалять текст и вводить новый.
    /// Также работают стандартные команды вроде отмены, вставки текста из буфера и др.
    /// </summary>
    public bool contenteditable = false;

    /// <summary>
    /// Скрывает содержимое элемента от просмотра. Такой элемент не отображается на странице, но доступен через скрипты
    /// </summary>
    public bool hidden = false;

    /// <summary>
    /// Устанавливает порядок получения фокуса при переходе между элементами с помощью клавиши Tab.
    /// В случае значения по умолчанию 0 - атрибут не выводится вовсе
    /// </summary>
    public int tabindex = 0;

    /// <summary>
    /// Текст HTML подсказки/tooltip
    /// </summary>
    public string title = "";

    /// <summary>
    /// Произвольный html текст внутри DOM блока/элемента
    /// </summary>
    public string? InnerText;

    /// <summary>
    /// Флаг/метка необходимости формировать HTML для элемента в одну строку
    /// </summary>
    public bool inline = false;

    /// <summary>
    /// Флаг/метка необходимости парного/закрывающего тега для элемента
    /// Если false, то тег не будет иметь завершающую/парную часть, а закроется в первой/открывающей части. В противном случае тег будет иметь и открывающую и закрывающую часть.
    /// </summary>
    public bool NeedEndTagSection = true;
    #endregion

    /// <summary>
    /// HtmlController -> HTML (text)
    /// </summary>
    /// <param name="deep">Глубина вложенности html блока/элемента (для отступов/табуляторов)</param>
    /// <returns>Возвращает готовый html</returns>
    public virtual string GetHTML(int deep = 0)
    {
        /////////////////////////////////////////////
        // Вычищаем недопустимый текст из комментария  
        before_comment_block = before_comment_block.Replace("<", "[").Replace(">", "]");
        after_comment_block = after_comment_block.Replace("<", "[").Replace(">", "]");

        string ret_val = "";

        if (!string.IsNullOrEmpty(before_comment_block))
            ret_val += GetTabPrefix(TabString, deep) + "<!-- " + before_comment_block + " -->";

        ret_val += GetTabPrefix(TabString, deep);
        if (this is not text)
            ret_val += "<" + (string.IsNullOrEmpty(tag_custom_name) ? (TagNameToLower ? GetType().Name.ToLower() : GetType().Name) : tag_custom_name);

        if (!string.IsNullOrEmpty(Id_DOM))
            SetAttribute("id", Id_DOM);

        if (!string.IsNullOrEmpty(Name_DOM))
            SetAttribute("name", Name_DOM);

        if (!string.IsNullOrEmpty(title))
            SetAttribute("title", title);

        if (CSS.Count > 0)
            SetAttribute("class", StringCSS());

        if (!string.IsNullOrEmpty(css_style))
            SetAttribute("style", css_style);

        if (!string.IsNullOrEmpty(accesskey))
            SetAttribute("accesskey", accesskey);

        if (contenteditable)
            SetAttribute("contenteditable", null);

        if (hidden)
            SetAttribute("hidden", null);

        if (tabindex != 0)
            SetAttribute("tabindex", tabindex.ToString());

        foreach (KeyValuePair<string, string?> kvp in CustomAttributes)
            if (!string.IsNullOrEmpty(kvp.Key))
                ret_val += " " + kvp.Key + (kvp.Value is null ? "" : "=\"" + kvp.Value + "\"");

        if (!NeedEndTagSection && this is not text)
            ret_val += " >";
        else if (this is text)
        {
            // * * *
        }
        else
            ret_val += ">";

        if (this is not text && Childs is not null)
            foreach (base_dom_root h in Childs)
                ret_val += h.GetHTML(deep + 1);

        if (!string.IsNullOrEmpty(InnerText))
            ret_val += (inline ? "" : GetTabPrefix(TabString, deep)) + InnerText;

        if (NeedEndTagSection && this is not text)
            ret_val += (inline ? "" : GetTabPrefix(TabString, deep)) + "</" + (string.IsNullOrEmpty(tag_custom_name) ? (TagNameToLower ? GetType().Name.ToLower() : GetType().Name) : tag_custom_name) + ">";

        after_comment_block = after_comment_block.Replace("<", "[").Replace(">", "]");

        if (!string.IsNullOrEmpty(after_comment_block))
            ret_val += GetTabPrefix(TabString, deep) + "<!-- " + after_comment_block + " /-->";
        else if (!string.IsNullOrEmpty(before_comment_block))
            ret_val += GetTabPrefix(TabString, deep) + "<!-- " + before_comment_block + " /-->";
        return ret_val;
    }

    /// <summary>
    /// Получить префикс/отступ/табулятор
    /// </summary>
    /// <param name="stamp">Символ из которого образуется префикс/отступ/табулятор</param>
    /// <param name="count">Длина префикса/отступа/табулятора</param>
    /// <param name="new_line">Требуется ли в начале перевод строки</param>
    /// <returns></returns>
    string GetTabPrefix(string stamp, int count, bool new_line = true)
    {
        string tmpl = stamp;
        stamp = "";
        for (int i = 0; i < count; i++)
            stamp += tmpl;
        return (new_line ? Environment.NewLine : "") + stamp;
    }

    /// <summary>
    /// Получить в виде строки тип кодирования отправляемых данных HTML формы
    /// </summary>
    public static string GetEnctypeHtmlForm(EncTypesEnum? EncType)
    {
        switch (EncType)
        {
            // Данные не кодируются. Это значение применяется при отправке файлов.
            case EncTypesEnum.MultipartFormData:
                return "multipart/form-data";
            // Пробелы заменяются знаком +, буквы и другие символы не кодируются.
            case EncTypesEnum.Plain:
                return "text/plain";
            // EncTypes.WwwFormUrlEncoded: Вместо пробелов ставится +, символы вроде русских букв кодируются их шестнадцатеричными значениями (например, %D0%9F%D0%B5%D1%82%D1%8F вместо Петя).
            default:
                return "application/x-www-form-urlencoded";
        }
    }

    #region Управление атрибутами (и событиями) объекта
    /// <summary>
    /// Пользовательские атрибуты текущего HTML элемента
    /// </summary>
    public Dictionary<string, string?> CustomAttributes { get; private set; } = [];

    /// <summary>
    /// Установить или добавить атрибут.
    /// </summary>
    /// <param name="attr_name">Имя атрибута dom объекта</param>
    /// <param name="attr_value">Если значение атрибута IS NULL, то генератор объявит имя атрибута у объекта, но не будет указывать значение этого атрибута (т.е. будет пропущен знак = и его значение)</param>
    public base_dom_root SetAttribute(string attr_name, string? attr_value)
    {
        if (!CustomAttributes.TryAdd(attr_name, attr_value))
            CustomAttributes[attr_name] = attr_value;

        return this;
    }
    /// <inheritdoc/>
    public base_dom_root SetAttribute(string attr_name, int attr_value) => SetAttribute(attr_name, attr_value.ToString());
    /// <inheritdoc/>
    public base_dom_root SetAttribute(string attr_name, double attr_value) => SetAttribute(attr_name, attr_value.ToString());

    /// <summary>
    /// Установить DOM объекту составное значение атрибута
    /// </summary>
    /// <param name="attr_name">Имя атрибута</param>
    /// <param name="attributes">Список значений атрибутов, которые нужно объединить в одно составное значение</param>
    /// <param name="separator">Символ-разделитель значений в составном значении атрибута</param>
    /// <param name="check_duplicates_attributes">если true - то дубли значений будут исключены из конечного составного значения</param>
    public base_dom_root SetAttribute<T>(string attr_name, List<T> attributes, string separator, bool check_duplicates_attributes = true)
    {
        string attr_as_string = "";
        if (check_duplicates_attributes)
            (from attr in attributes group attr by attr.ToString()).ToList().ForEach(e => attr_as_string += " " + e.Key);
        else
            attributes.ForEach(e => { if (e is not null) { attr_as_string += " " + e.ToString(); } });

        attr_as_string = attr_as_string.Trim().Replace(" ", separator);
        if (!string.IsNullOrEmpty(attr_as_string))
            SetAttribute(attr_name, attr_as_string);

        return this;
    }

    /// <summary>
    /// Пакетная установка атрибутов
    /// </summary>
    public base_dom_root SetAttribute(Dictionary<string, string> in_custom_attributes)
    {
        foreach (KeyValuePair<string, string> kvp in in_custom_attributes)
            SetAttribute(kvp.Key, kvp.Value);

        return this;
    }

    /// <summary>
    /// Получить значение атрибута
    /// </summary>
    public string? GetAttribute(string attr_name)
    {
        if (CustomAttributes.TryGetValue(attr_name, out string? value))
            return value;

        return null;
    }

    /// <summary>
    /// Удалить атрибут (если существует)
    /// </summary>
    public base_dom_root RemoveAttribute(string attr_name)
    {
        CustomAttributes.Remove(attr_name);

        return this;
    }

    /// <summary>
    /// Установить DOM элементу обработчик события.
    /// Если "event_src" IsNullOrEmpty, то событие удаляется
    /// </summary>
    public base_dom_root SetEvent(UniversalEventsEnum my_event, string event_src)
    {
        if (string.IsNullOrEmpty(event_src))
            CustomAttributes.Remove(my_event.ToString("g"));
        else
            SetAttribute(my_event.ToString("g"), event_src);

        return this;
    }
    #endregion

    #region Вложеные/Дочерние элементы
    /// <summary>
    /// Дочерние/вложенные элементы
    /// </summary>
    protected internal List<base_dom_root>? Childs;

    /// <summary>
    /// Прямое добавление дочернего/вложенного элемента.
    /// </summary>
    public virtual base_dom_root AddDomNode(base_dom_root child)
    {
        Childs ??= [];
        Childs.Add(child);
        return this;
    }

    /// <summary>
    /// Пакетное добавление дочерних/вложенных элементов.
    /// </summary>
    public virtual base_dom_root AddRangeDomNode(IEnumerable<base_dom_root> children)
    {
        Childs ??= [];
        Childs.AddRange(children);
        return this;
    }

    /// <summary>
    /// Удалить все вложенные DOM элементы
    /// </summary>
    public virtual base_dom_root ClearNestedDom()
    {
        Childs ??= [];
        Childs.Clear();

        return this;
    }
    #endregion

    #region CSS классы стилей
    /// <summary>
    /// Для поиска пробелов в передаваемых CSS классах
    /// </summary>
    private Regex regex_spice = MyRegexSpices();

    /// <summary>
    /// CSS стили для элемента
    /// </summary>
    private readonly List<string> CSS = [];

    /// <summary>
    /// Добавить CSS класс (если его нет у объекта)
    /// </summary>
    public base_dom_root AddCSS(string css_class, bool CheckSpices = false, bool low_and_trim_name_class = true)
    {
        if (low_and_trim_name_class)
            css_class = css_class.Trim().ToLower();

        if (CheckSpices && regex_spice.IsMatch(css_class))
            foreach (string s in regex_spice.Split(css_class))
                AddCSS(s, false, false);
        else if (!string.IsNullOrEmpty(css_class) && !CSS.Contains(css_class))
            CSS.Add(css_class);

        return this;
    }

    /// <summary>
    /// Удалить класс CSS
    /// </summary>
    public base_dom_root RemoveCSS(string css_class, bool CheckSpices = false)
    {
        if (CheckSpices && regex_spice.IsMatch(css_class))
        {
            foreach (string s in regex_spice.Split(css_class))
                RemoveCSS(s, false);
        }
        else if (!string.IsNullOrEmpty(css_class))
            CSS.Remove(css_class);

        return this;
    }

    /// <summary>
    /// Если класса нет, то будет добавлен. Если класс есть, то будет удалён
    /// </summary>
    public base_dom_root ToggleCSS(string css_class)
    {
        if (!string.IsNullOrEmpty(css_class))
        {
            if (!CSS.Remove(css_class))
                CSS.Add(css_class);
        }

        return this;
    }

    /// <summary>
    /// Получить CSS классы одной строкой (разделитель пробел)
    /// </summary>
    public string StringCSS()
    {
        string css_as_string = "";
        CSS.ForEach(x => css_as_string += " " + x);
        return css_as_string.Trim();
    }

    [GeneratedRegex(@"\s+", RegexOptions.Compiled)]
    private static partial Regex MyRegexSpices();
    #endregion
}