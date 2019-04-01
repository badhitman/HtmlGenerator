////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.DOM.collections
{
    /// <summary>
    /// Тег [option] определяет отдельные пункты списка, создаваемого с помощью контейнера [select].
    /// Ширина списка определяется самым широким текстом, указанным в теге [option], а также может 
    /// изменяться с помощью стилей. Если планируется отправлять данные списка на сервер, то требуется 
    /// поместить элемент [select] внутрь формы. Это также необходимо, когда к данным списка идет обращение через скрипты.
    /// </summary>
    public class option : optgroup
    {
        public class option_set : optgroup_set
        {
            public string Value;
            public bool Selected = false;
        }
        public new option_set set;

        public option(option_set in_set) : base(new optgroup_set() { TitleText = in_set.TitleText, Disabled = in_set.Disabled })
        {
            set = in_set;
            inline = true;
        }

        public override string GetHTML(int deep = 0)
        {
            if (!(set is null))
            {
                SetAtribute("label", set.TitleText);
                SetAtribute("value", set.Value);

                if (set.Selected)
                    SetAtribute("selected", null);

                if (set.Disabled)
                    SetAtribute("disabled", null);
            }
            return base.GetHTML(deep);
        }
    }
}
