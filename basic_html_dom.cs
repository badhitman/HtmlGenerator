using System;
using System.Collections.Generic;
using System.Linq;

namespace DataViewHtml
{
    /// <summary>
    /// События HTML.DOM
    /// </summary>
    public enum UniversalEvents
    {
        /// <summary>
        /// Потеря фокуса.
        /// </summary>
        onblur,

        /// <summary>
        /// Изменение значения элемента формы.
        /// </summary>
        onchange,

        /// <summary>
        /// Щелчок левой кнопкой мыши на элементе.
        /// </summary>
        onclick,

        /// <summary>
        /// Двойной щелчок левой кнопкой мыши на элементе.
        /// </summary>
        ondblclick,

        /// <summary>
        /// Получение фокуса
        /// </summary>
        onfocus,

        /// <summary>
        /// Клавиша нажата, но не отпущена.
        /// </summary>
        onkeydown,

        /// <summary>
        /// Клавиша нажата и отпущена.
        /// </summary>
        onkeypress,

        /// <summary>
        /// Клавиша отпущена.
        /// </summary>
        onkeyup,

        /// <summary>
        /// Документ загружен.
        /// </summary>
        onload,

        /// <summary>
        /// Нажата левая кнопка мыши.
        /// </summary>
        onmousedown,

        /// <summary>
        /// Перемещение курсора мыши.
        /// </summary>
        onmousemove,

        /// <summary>
        /// Курсор покидает элемент.
        /// </summary>
        onmouseout,

        /// <summary>
        /// Курсор наводится на элемент.
        /// </summary>
        onmouseover,

        /// <summary>
        /// Левая кнопка мыши отпущена.
        /// </summary>
        onmouseup,

        /// <summary>
        /// Форма очищена.
        /// </summary>
        onreset,

        /// <summary>
        /// Выделен текст в поле формы.
        /// </summary>
        onselect,

        /// <summary>
        /// Форма отправлена.
        /// </summary>
        onsubmit,

        /// <summary>
        /// Закрытие окна.
        /// </summary>
        onunload
    }

    public abstract class basic_html_dom
    {
        private string custom_name_tag = "";

        /// <summary>
        /// Дочерние/вложеные элементы
        /// </summary>
        public List<basic_html_dom> Childs = new List<basic_html_dom>();
        
        /// <summary>
        /// Пользовательские атрибуты текущего HTML элемента
        /// </summary>
        public Dictionary<string, string> CustomAtributes { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// Идентификатор/ID элемента в DOM
        /// </summary>
        public string Id_DOM = "";

        /// <summary>
        /// Позволяет получить доступ к элементу с помощью заданного сочетания клавиш. Браузеры при этом используют различные комбинации клавиш.
        /// </summary>
        public string accesskey = null;

        /// <summary>
        /// Имя/Name элемента в DOM
        /// </summary>
        public string Name_DOM = "";

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
        /// </summary>
        public int tabindex = -1;

        /// <summary>
        /// Текст HTML подсказки/tooltip
        /// </summary>
        public string title = "";

        /// <summary>
        /// HTML Комментирование блока/элемента. Оборачивает текущий блок в два коментария (в самом начале и самом конце DOM блока)
        /// </summary>
        public string prew_block_coment = "";
        public string post_block_coment = "";

        /// <summary>
        /// Inner HTML text
        /// </summary>
        public string inner_html = "";

        /// <summary>
        /// Флаг/метка необходимости формировать HTML для элемента в одну строку
        /// </summary>
        public bool inline = false;

        /// <summary>
        /// Флаг/метка необходимости закрывающего тега для элемента
        /// </summary>
        public bool need_end_tag = true;

        /// <summary>
        /// HtmlController -> HTML (text)
        /// </summary>
        /// <param name="deep">Глубина вложености html блока/элемента (для отступов/табуляторов)</param>
        /// <returns>Возвращает готовый html</returns>
        public virtual string HTML(int deep = 0)
        {
            prew_block_coment = prew_block_coment.Replace("<", "[").Replace(">", "]");
            string ret_val = "";

            if (!string.IsNullOrEmpty(prew_block_coment))
                ret_val += GetTabPrefix("\t", deep) + "<!-- " + prew_block_coment + " -->";

            ret_val += GetTabPrefix("\t", deep);
            if (!(this is dom.text))
                ret_val += "<" + (string.IsNullOrEmpty(custom_name_tag) ? this.GetType().Name.ToLower() : custom_name_tag);

            if (!string.IsNullOrEmpty(accesskey))
                SetAtribute("accesskey", accesskey);

            if (contenteditable)
                SetAtribute("contenteditable", null);

            if (hidden)
                SetAtribute("hidden", null);

            if (tabindex > -1)
                SetAtribute("tabindex", tabindex.ToString());

            if (!string.IsNullOrEmpty(title))
                SetAtribute("title", title);

            if (!string.IsNullOrEmpty(Id_DOM))
                SetAtribute("id", Id_DOM);

            if (!string.IsNullOrEmpty(Name_DOM))
                SetAtribute("name", Name_DOM);

            if (!string.IsNullOrEmpty(css_class))
                SetAtribute("class", css_class);

            if (!string.IsNullOrEmpty(css_style))
                SetAtribute("style", css_style);

            foreach (KeyValuePair<string, string> kvp in CustomAtributes)
                if (!string.IsNullOrEmpty(kvp.Key))
                    ret_val += " " + kvp.Key + (string.IsNullOrEmpty(kvp.Value) ? "" : "=\"" + kvp.Value + "\"");

            if (!need_end_tag && !(this is dom.text))
                ret_val += " />";
            else if (this is dom.text)
            {
                // * * *
            }
            else
                ret_val += ">";

            if (!(this is dom.text))
                foreach (basic_html_dom h in Childs)
                    ret_val += h.HTML(deep + 1);

            if (!string.IsNullOrEmpty(inner_html))
                ret_val += (inline ? "" : GetTabPrefix("\t", deep)) + inner_html;

            if (need_end_tag && !(this is dom.text))
                ret_val += (inline ? "" : GetTabPrefix("\t", deep)) + "</" + (string.IsNullOrEmpty(custom_name_tag) ? this.GetType().Name.ToLower() : custom_name_tag) + ">";


            post_block_coment = post_block_coment.Replace("<", "[").Replace(">", "]");

            if (!string.IsNullOrEmpty(post_block_coment))
                ret_val += GetTabPrefix("\t", deep) + "<!-- " + post_block_coment + " /-->";
            else if (!string.IsNullOrEmpty(prew_block_coment))
                ret_val += GetTabPrefix("\t", deep) + "<!-- " + prew_block_coment + " /-->";
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
        /// Установить или добавить атрибут
        /// </summary>
        /// <param name="attr_name"></param>
        /// <param name="attr_value"></param>
        public void SetAtribute(string attr_name, string attr_value)
        {
            if (!CustomAtributes.ContainsKey(attr_name))
                CustomAtributes.Add(attr_name, attr_value);
            else
                CustomAtributes[attr_name] = attr_value;
        }

        /// <summary>
        /// Получить значение атрибута
        /// </summary>
        public string GetAtribute(string attr_name)
        {
            if (CustomAtributes.ContainsKey(attr_name))
                return CustomAtributes[attr_name];

            return null;
        }

        /// <summary>
        /// Удалить атрибу (если существует)
        /// </summary>
        public void RemoveAtribute(string attr_name)
        {
            if (CustomAtributes.ContainsKey(attr_name))
                CustomAtributes.Remove(attr_name);
        }

        /// <summary>
        /// Пакетная установка атрибутов
        /// </summary>
        public void SetAtribute(Dictionary<string, string> in_custom_atributes)
        {
            if (!(in_custom_atributes is null))
                foreach (KeyValuePair<string, string> kvp in in_custom_atributes)
                    SetAtribute(kvp.Key, kvp.Value);
        }

        /// <summary>
        /// Установить объекту пользовательское имя HTML.DOM. По умолчанию имя берётся из имени типа класса.
        /// Если передать пустую строку или null, то имя тега будет представлено как имя типа класса
        /// </summary>
        public void SetTagName(string in_custom_name_tag = null) => custom_name_tag = in_custom_name_tag;

        /// <summary>
        /// Установить DOM элементу обработчик события.
        /// Если "event_src" IsNullOrEmpty, то событие удаляется
        /// </summary>
        public void SetEvent(UniversalEvents my_event, string event_src)
        {
            if (string.IsNullOrEmpty(event_src))
                if (CustomAtributes.ContainsKey(my_event.ToString("g")))
                    CustomAtributes.Remove(my_event.ToString("g"));
                else
                    SetAtribute(my_event.ToString("g"), event_src);
        }
    }
}
