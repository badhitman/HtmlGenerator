////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Тег "option" определяет отдельные пункты списка, создаваемого с помощью контейнера "select".
    /// Ширина списка определяется самым широким текстом, указанным в теге "option", а также может 
    /// изменяться с помощью стилей. Если планируется отправлять данные списка на сервер, то требуется 
    /// поместить элемент "select" внутрь формы. Это также необходимо, когда к данным списка идет обращение через скрипты.
    /// </summary>
    public class option : basic_html_dom
    {
        public class option_set
        {
            public string label_text;
            public string value_option;
            public bool selected = false;
            public bool disabled = false;
        }
        public option_set set;
        public option(option_set in_set)
        {
            set = in_set;
            inline = true;
        }
        public override string HTML(int deep = 0)
        {
            if (!(set is null))
            {
                SetAtribute("label", set.label_text);
                SetAtribute("value", set.value_option);

                if (set.selected)
                    SetAtribute("selected", null);

                if (set.disabled)
                    SetAtribute("disabled", null);
            }
            return base.HTML(deep);
        }
    }
}
