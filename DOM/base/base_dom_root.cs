////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
using HtmlGenerator.dom.textual;
using HtmlGenerator.set;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlGenerator
{
    public abstract class base_dom_root : IDisposable
    {
        /// <summary>
        /// Символ(ы) табуляции/оступа.
        /// Рекомендуется \t или [два пробела]
        /// </summary>
        public static string TabString = "\t";

        /// <summary>
        /// HTML Комментирование блока/элемента. Оборачивает текущий блок в два коментария (непосредственно до и после DOM блока).
        /// Если указать только начальный/верхний коментарий, то он же будет использоваться и в нижнем.
        /// </summary>
        public string before_coment_block = "";
        public string after_coment_block = "";

        /// <summary>
        /// Ручное указание имени/типа элемента/тэга
        /// По умолчанию имя/тип определяется по имени типа класса, но в случае необходимости его можно изменить на собственный
        /// </summary>
        public string tag_custom_name = null;

        /// <summary>
        /// Дочерние/вложеные элементы
        /// </summary>
        protected internal List<base_dom_root> Childs = new List<base_dom_root>();

        /// <summary>
        /// Прямое добавление дочернего/вложеного элемента.
        /// </summary>
        /// <param name="child">Элемент для вложения</param>
        public virtual void Add(base_dom_root child) => Childs.Add(child);

        /// <summary>
        /// Пакетное добавление дочерних/вложеных элементов.
        /// </summary>
        /// <param name="childs"></param>
        public virtual void AddRange(List<base_dom_root> childs) => Childs.AddRange(childs);

        /// <summary>
        /// Пользовательские атрибуты текущего HTML элемента
        /// </summary>
        public Dictionary<string, string> CustomAttributes { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// Идентификатор/ID элемента в DOM
        /// </summary>
        public string Id_DOM = "";

        /// <summary>
        /// Имя/Name элемента в DOM
        /// </summary>
        public string Name_DOM = "";

        /// <summary>
        /// Позволяет получить доступ к элементу с помощью заданного сочетания клавиш. Браузеры при этом используют различные комбинации клавиш.
        /// </summary>
        public string accesskey = null;

        /// <summary>
        /// Определяет имя класса, которое позволяет связать тег со стилевым оформлением.
        /// </summary>
        public string css_class = "";

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
        public string InnerText = "";

        /// <summary>
        /// Флаг/метка необходимости формировать HTML для элемента в одну строку
        /// </summary>
        public bool inline = false;

        /// <summary>
        /// Флаг/метка необходимости парного/закрывающего тега для элемента
        /// Если false, то тег закроется: />
        /// </summary>
        public bool need_end_tag = true;

        /// <summary>
        /// HtmlController -> HTML (text)
        /// </summary>
        /// <param name="deep">Глубина вложености html блока/элемента (для отступов/табуляторов)</param>
        /// <returns>Возвращает готовый html</returns>
        public virtual string GetHTML(int deep = 0)
        {
            /////////////////////////////////////////////
            // Вычещаем недопустимый текст из коментария  
            before_coment_block = before_coment_block.Replace("<", "[").Replace(">", "]");
            after_coment_block = after_coment_block.Replace("<", "[").Replace(">", "]");

            string ret_val = "";

            if (!string.IsNullOrEmpty(before_coment_block))
                ret_val += GetTabPrefix(TabString, deep) + "<!-- " + before_coment_block + " -->";

            ret_val += GetTabPrefix(TabString, deep);
            if (!(this is text))
                ret_val += "<" + (string.IsNullOrEmpty(tag_custom_name) ? GetType().Name.ToLower() : tag_custom_name);

            if (!string.IsNullOrEmpty(Id_DOM))
                SetAttribute("id", Id_DOM);

            if (!string.IsNullOrEmpty(Name_DOM))
                SetAttribute("name", Name_DOM);

            if (!string.IsNullOrEmpty(title))
                SetAttribute("title", title);

            if (!string.IsNullOrEmpty(css_class?.Trim()))
                SetAttribute("class", css_class.Trim());

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

            foreach (KeyValuePair<string, string> kvp in CustomAttributes)
                if (!string.IsNullOrEmpty(kvp.Key))
                    ret_val += " " + kvp.Key + (kvp.Value is null ? "" : "=\"" + kvp.Value + "\"");

            if (!need_end_tag && !(this is text))
                ret_val += " >";
            else if (this is text)
            {
                // * * *
            }
            else
                ret_val += ">";

            if (!(this is text))
                foreach (base_dom_root h in Childs)
                    ret_val += h.GetHTML(deep + 1);

            if (!string.IsNullOrEmpty(InnerText))
                ret_val += (inline ? "" : GetTabPrefix(TabString, deep)) + InnerText;

            if (need_end_tag && !(this is text))
                ret_val += (inline ? "" : GetTabPrefix(TabString, deep)) + "</" + (string.IsNullOrEmpty(tag_custom_name) ? this.GetType().Name.ToLower() : tag_custom_name) + ">";

            after_coment_block = after_coment_block.Replace("<", "[").Replace(">", "]");

            if (!string.IsNullOrEmpty(after_coment_block))
                ret_val += GetTabPrefix(TabString, deep) + "<!-- " + after_coment_block + " /-->";
            else if (!string.IsNullOrEmpty(before_coment_block))
                ret_val += GetTabPrefix(TabString, deep) + "<!-- " + before_coment_block + " /-->";
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
        /// Установить или добавить атрибут.
        /// </summary>
        /// <param name="attr_name">Имя атрибута dom объекта</param>
        /// <param name="attr_value">Если знаение атрибута IS NULL, то генератор объявит имя атрибута у объекта, но не будет указывать значение этого атрибута (т.е. будет пропущен знак = и его значение)</param>
        public void SetAttribute(string attr_name, string attr_value)
        {
            if (!CustomAttributes.ContainsKey(attr_name))
                CustomAttributes.Add(attr_name, attr_value);
            else
                CustomAttributes[attr_name] = attr_value;
        }
        public void SetAttribute(string attr_name, int attr_value) => SetAttribute(attr_name, attr_value.ToString());
        public void SetAttribute(string attr_name, double attr_value) => SetAttribute(attr_name, attr_value.ToString());
        /// <summary>
        /// Установить DOM объекту составное значение атрибута
        /// </summary>
        /// <param name="attr_name">Имя атрибута</param>
        /// <param name="attributes">Список значений атрибутов, которые нужно объеденить в одно составное значение</param>
        /// <param name="separator">Символ-разделитель значений в составном значении атрибута</param>
        /// <param name="check_duplicates_attributes">если true - то дубли значений будут исключены из конечного составного значения</param>
        public void SetAttribute<T>(string attr_name, List<T> attributes, string separator, bool check_duplicates_attributes = true)
        {
            string media_as_string = "";
            if (check_duplicates_attributes)
                (from attr in attributes group attr by attr.ToString()).ToList().ForEach(e => media_as_string += " " + e.Key);
            else
                attributes.ForEach(e => media_as_string += " " + e.ToString());

            media_as_string = media_as_string.Trim().Replace(" ", separator);
            if (!string.IsNullOrEmpty(media_as_string))
                SetAttribute(attr_name, media_as_string);
        }

        /// <summary>
        /// Пакетная установка атрибутов
        /// </summary>
        public void SetAttribute(Dictionary<string, string> in_custom_atributes)
        {
            foreach (KeyValuePair<string, string> kvp in in_custom_atributes)
                SetAttribute(kvp.Key, kvp.Value);
        }

        /// <summary>
        /// Получить значение атрибута
        /// </summary>
        public string GetAttribute(string attr_name)
        {
            if (CustomAttributes.ContainsKey(attr_name))
                return CustomAttributes[attr_name];

            return null;
        }

        /// <summary>
        /// Удалить атрибу (если существует)
        /// </summary>
        public void RemoveAttribute(string attr_name)
        {
            if (CustomAttributes.ContainsKey(attr_name))
                CustomAttributes.Remove(attr_name);
        }

        /// <summary>
        /// Установить DOM элементу обработчик события.
        /// Если "event_src" IsNullOrEmpty, то событие удаляется
        /// </summary>
        public void SetEvent(UniversalEventsEnum my_event, string event_src)
        {
            if (string.IsNullOrEmpty(event_src))
            {
                if (CustomAttributes.ContainsKey(my_event.ToString("g")))
                    CustomAttributes.Remove(my_event.ToString("g"));
            }
            else
                SetAttribute(my_event.ToString("g"), event_src);
        }

        /// <summary>
        /// Получить в виде строки тип кодирования отпарвляемых данных HTML формы
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

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        public void Dispose()
        {
            if (!disposedValue)
            {
                Childs = null;
                CustomAttributes = null;
                disposedValue = true;
            }
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
