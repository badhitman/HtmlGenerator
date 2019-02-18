////////////////////////////////////////////////
// © https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace DataViewHtml.dom
{
    /// <summary>
    /// Элемент "fieldset" предназначен для группирования элементов формы. Такая группировка облегчает работу с формами, содержащими большое число данных.
    /// Например, один блок может быть предназначен для ввода текстовой информации, а другой — для флажков.
    /// Браузеры для повышения наглядности отображают результат использования тега "fieldset" в виде рамки. Ее вид зависит от операционной системы, а также
    /// используемого браузера
    /// </summary>
    public class fieldset : basic_html_dom
    {
        public string form;
        public bool disabled = false;
        public string legend_text;
        public fieldset(string in_legend_text, string in_form, bool in_disabled = false)
        {
            form = in_form;
            disabled = in_disabled;
            legend_text = in_legend_text;
        }

        public override string HTML(int deep = 0)
        {
            if (!string.IsNullOrEmpty(form))
                SetAtribute("form", form);

            if(disabled)
                SetAtribute("disabled", null);

            if (!string.IsNullOrEmpty(legend_text))
                Childs.Add(new legend(legend_text));

            return base.HTML(deep);
        }
    }
}
