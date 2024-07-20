////////////////////////////////////////////////
// https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.forms;

/// <summary>
/// Элемент [fieldset] предназначен для группирования элементов формы. Такая группировка облегчает работу с формами, содержащими большое число данных.
/// Например, один блок может быть предназначен для ввода текстовой информации, а другой — для флажков.
/// Браузеры для повышения наглядности отображают результат использования тега [fieldset] в виде рамки. Ее вид зависит от операционной системы, а также
/// используемого браузера
/// </summary>
public class fieldset : base_dom_root
{
    /// <summary>
    /// Связывает группу [fieldset] с формой по её идентификатору.
    /// Такая связь необходима в случае, когда элемент не располагается внутри [form], например, при создании её программно.
    /// Если установлено связывание [form] и [fieldset] между собой, то можно отправлять данные на сервер и работать с формой, как если бы элементы находились внутри формы.
    /// </summary>
    public string form;

    /// <summary>
    /// Блокирует доступ к элементам формы, расположенным внутри тега [fieldset]. Поля формы при этом отображаются так, словно к каждому из них добавлен атрибут [disabled].
    /// </summary>
    public bool disabled = false;

    /// <summary>
    /// Тег [legend] применяется для создания заголовка группы элементов формы, которая определяется с помощью тега [fieldset].
    /// Группа элементов обозначается в браузере с помощью рамки, а текст, который располагается внутри контейнера [legend], встраивается в эту рамку.
    /// </summary>
    public string legend_text;

    public fieldset(string in_legend_text, string in_form, bool in_disabled = false)
    {
        form = in_form;
        disabled = in_disabled;
        legend_text = in_legend_text;
    }

    public override string GetHTML(int deep = 0)
    {
        if (!string.IsNullOrEmpty(form))
            SetAttribute("form", form);

        if (disabled)
            SetAttribute("disabled", null);

        if (!string.IsNullOrEmpty(legend_text))
        {
            Childs ??= [];
            Childs.Insert(0, new legend(legend_text));
        }
        return base.GetHTML(deep);
    }
}