////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.html5;
using HtmlGenerator.html5.areas;

namespace HtmlGenerator.bootstrap.forms
{
    public class forms_dom_root : base_dom_root
    {

        public div[] GetValidationAlerts(string validation_input_id, string invalid_text = "Укажите значение", string valid_text = null)
        {
            div valid_element = new div() { css_class = "valid-feedback", InnerText = valid_text, Id_DOM = "valid-tooltip-" + validation_input_id, inline = true };
            div invalid_element = new div() { css_class = "invalid-feedback", InnerText = invalid_text, Id_DOM = "invalid-tooltip-" + validation_input_id, inline = true };
            // 
            if (!string.IsNullOrEmpty(valid_text))
                return new div[] { valid_element, invalid_element };
            else
                return new div[] { invalid_element };
        }
    }
}
