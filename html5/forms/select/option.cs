////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.forms;

/// <summary>
/// Тег [option] определяет отдельные пункты списка, создаваемого с помощью контейнера [select].
/// Ширина списка определяется самым широким текстом, указанным в теге [option], а также может 
/// изменяться с помощью стилей. Если планируется отправлять данные списка на сервер, то требуется 
/// поместить элемент [select] внутрь формы. Это также необходимо, когда к данным списка идет обращение через скрипты.
/// </summary>
public class option : optgroup
{
    /// <inheritdoc/>
    public class option_set : optgroup_set
    {
        /// <inheritdoc/>
        public string? Value;

        /// <inheritdoc/>
        public bool Selected = false;
    }

    /// <inheritdoc/>
    public new option_set set;

    /// <inheritdoc/>
    public option(option_set in_set) : base(new optgroup_set() { TitleText = in_set.TitleText, Disabled = in_set.Disabled })
    {
        set = in_set;
        inline = true;
    }

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        if (set is not null)
        {
            SetAttribute("label", set.TitleText);
            SetAttribute("value", set.Value);

            if (set.Selected)
                SetAttribute("selected", null);

            if (set.Disabled)
                SetAttribute("disabled", null);
        }
        return base.GetHTML(deep);
    }
}