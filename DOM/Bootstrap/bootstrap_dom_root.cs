////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.DOM.Bootstrap
{
    public class bootstrap_dom_root : base_dom_root
    {
        public div[] GetValidationAlerts(string validation_input_id, string invalid_text = "Укажите значение", string valid_text = null)
        {
            div valid_element = new div() { css_class = "valid-tooltip", InnerText = valid_text, Id_DOM = "valid-tooltip-" + validation_input_id };
            div invalid_element = new div() { css_class = "invalid-tooltip", InnerText = invalid_text, Id_DOM = "invalid-tooltip-" + validation_input_id };
            // 
            if (!string.IsNullOrEmpty(valid_text))
                return new div[] { valid_element, invalid_element };
            else
                return new div[] { invalid_element };
        }
    }
}
