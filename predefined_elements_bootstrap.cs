////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom;
using System.Collections.Generic;

namespace HtmlGenerator
{
    public static class predefined_elements_bootstrap
    {
        public static div GetBootstrapSelectList(string label, select select_body, string Tooltip = null, string wrap_class = "input-group mb-4 col-auto")
        {
            div ret_dom = new div() { css_class = wrap_class };

            if (!string.IsNullOrEmpty(label))
            {
                ret_dom.Childs.Add(new div { css_class = "input-group-prepend" });
                ret_dom.Childs[0].Childs.Add(new label(label, select_body.Id_DOM) { css_class = "input-group-text" });
            }
            select_body.css_class = (select_body.css_class.Trim() + " custom-select").Trim();

            if (!string.IsNullOrEmpty(Tooltip))
                ret_dom.Tooltip = Tooltip;

            ret_dom.SetAtribute("data-toggle", "tooltip");
            ret_dom.Childs.Add(select_body);
            return ret_dom;
        }

        /// <summary>
        /// Стандартная карточка/панель для размещения информации
        /// </summary>
        /// <param name="card_head">Заголовок карточки</param>
        /// <param name="body_elements">Элементы содержимого</param>
        /// <param name="css_card">Стиль офрмления карточки</param>
        /// <returns>Готовая карточка информации</returns>
        public static div Get_DIV_Bootstrap_Card(string card_head, List<basic_html_dom> body_elements, string css_card = "bg-light")
        {
            div card_header = new div() { css_class = "card-header", inner_html = card_head };

            div card_body = new div() { css_class = "card-body" };
            foreach (div he in body_elements)
                card_body.Childs.Add(he);

            div card_set = new div() { css_class = ("card " + css_card).Trim() };

            card_set.Childs.Add(card_header);
            card_set.Childs.Add(card_body);

            return card_set;
        }

        public static div Get_DIV_Bootstrap_Card(string card_head, basic_html_dom body_element, string css_card = "bg-light")
        {
            return Get_DIV_Bootstrap_Card(card_head, new List<basic_html_dom>() { body_element }, css_card);
        }

        public static p GetCheckboxInput(string label_text, string Id_DOM, bool is_cheked = false, bool required = false)
        {
            div ret_val = new div() { css_class = "form-check" };
            //
            input.input_set input_set = new input.input_set();
            input_set.type_input = InputTypes.checkbox;

            input ret_input = new input(input_set);
            ret_input.css_class = "form-check-input";
            ret_input.Id_DOM = Id_DOM;

            if (is_cheked)
                ret_input.SetAtribute("checked", "true");

            if (required)
                ret_input.SetAtribute("required", null);

            ret_val.Childs.Add(ret_input);
            //
            input_set = new input.input_set();
            input_set.type_input = InputTypes.hidden;
            input_set.value = "off";
            ret_input = new input(input_set);
            ret_input.Name_DOM = Id_DOM;
            ret_val.Childs.Add(ret_input);
            //
            label label = new label(label_text, Id_DOM);
            label.css_class = "form-check-label";
            ret_val.Childs.Add(label);

            return new p(null) { Childs = new List<basic_html_dom>() { ret_val } };
        }

        public static div GetBaseTextInput(string label_text, string value_input, string Id_DOM, string placeholder, bool input_readonly, string input_info, string class_div_group_wrap = null, string label_css_class = null, string input_css_class = null, bool required = false)
        {
            div returned_input = new div() { css_class = "form-group" + " " + class_div_group_wrap };

            if (!string.IsNullOrEmpty(label_text))
                returned_input.Childs.Add(new label(label_text, Id_DOM) { css_class = label_css_class });

            input.input_set input_set = new input.input_set();
            input_set.type_input = InputTypes.text;
            input_set.value = value_input;
            
            input ret_input = new input(input_set) { css_class = input_css_class };

            if (required)
                ret_input.set.i_required = true;

            if (input_readonly)
                ret_input.set.i_readonly = true;
            
            ret_input.Id_DOM = Id_DOM;
            ret_input.Name_DOM = Id_DOM;
            ret_input.inline = true;
            ret_input.css_class = "form-control";

            if (!string.IsNullOrEmpty(placeholder))
                ret_input.SetAtribute("placeholder", placeholder);
            
            //
            returned_input.Childs.Add(ret_input);
            if (required)
                returned_input.Childs.AddRange(GetValidationAlerts(Id_DOM));

            if (!string.IsNullOrEmpty(input_info))
                returned_input.Childs.Add(new small(input_info)
                {
                    css_class = "form-text text-muted",
                    Id_DOM = Id_DOM + "Help"
                });

            return returned_input;
        }

        /*public static HtmlDomGenerator[] GetValidationAlerts(string validation_input_id, string invalid_text = "Укажите значение", string valid_text = null)
        {
            HtmlDomGenerator valid_element = new HtmlDomGenerator() { css_class = "valid-tooltip", text = valid_text, Id_DOM = "valid-tooltip-" + validation_input_id };
            HtmlDomGenerator invalid_element = new HtmlDomGenerator() { css_class = "invalid-tooltip", text = invalid_text, Id_DOM = "invalid-tooltip-" + validation_input_id };
            // 
            if (!string.IsNullOrEmpty(valid_text))
                return new HtmlDomGenerator[] { valid_element, invalid_element };
            else
                return new HtmlDomGenerator[] { invalid_element };
        }*/

        //public static HtmlDomGenerator[] GetPassInput(string label_text, string Id_DOM, string placeholder, string input_info)
        //{
        //    HtmlDomGenerator[] ret_val = GetBaseTextInput(label_text, "", Id_DOM, placeholder, false, input_info, null, null, null, true);
        //    foreach (HtmlDomGenerator _e in ret_val)
        //        foreach (HtmlDomGenerator e in _e.Childs)
        //            if (e.TypeHtmlDom == TypesHtmlDom.input)
        //                e.obj_type = "password";
        //    return ret_val;
        //}

        /*public static HtmlDomGenerator GetSecondTextInput(string label_text, string value_input, string Id_DOM, string placeholder, bool input_readonly, string class_div_group_wrap = null, bool required = false)
        {
            HtmlDomGenerator input_group_text = new HtmlDomGenerator(TypesHtmlDom.span) { css_class = "input-group-text", text = label_text };
            HtmlDomGenerator input_group_prepend = new HtmlDomGenerator() { css_class = "input-group-prepend" };
            input_group_prepend.Childs.Add(input_group_text);
            HtmlDomGenerator input_group = new HtmlDomGenerator() { css_class = ("input-group " + class_div_group_wrap).Trim() };
            input_group.Childs.Add(input_group_prepend);
            HtmlDomGenerator input = new HtmlDomGenerator(TypesHtmlDom.input) { obj_type = "text", css_class = "form-control" };
            if (required)
                input.CustomAtributes.Add("required", null);

            input.CustomAtributes.Add("value", value_input);

            if (!string.IsNullOrEmpty(Id_DOM))
                input.Id_DOM = Id_DOM;

            if (!string.IsNullOrEmpty(placeholder))
                input.CustomAtributes.Add("placeholder", placeholder);

            if (input_readonly)
                input.CustomAtributes.Add("readonly", "");

            input_group.Childs.Add(input);
            if (required)
                input_group.Childs.AddRange(GetValidationAlerts(Id_DOM));

            return input_group;
        }*/

        /*public static HtmlDomGenerator GetTextarea(string label_text, string value_input, string Id_DOM, bool input_readonly, int rows = 2, bool required = false)
        {
            HtmlDomGenerator returned_input = new HtmlDomGenerator() { css_class = "form-group" };
            if (!string.IsNullOrEmpty(label_text))
                returned_input.Childs.Add(new HtmlDomGenerator(TypesHtmlDom.label) { text = label_text, _for = Id_DOM });


            HtmlDomGenerator input = new HtmlDomGenerator(TypesHtmlDom.textarea) { css_class = "form-control" };
            if (required)
                input.CustomAtributes.Add("required", null);

            if (input_readonly)
                input.CustomAtributes.Add("readonly", null);

            if (rows > 0)
                input.CustomAtributes.Add("rows", rows.ToString());

            if (!string.IsNullOrEmpty(value_input))
                input.text = value_input;

            input.Id_DOM = Id_DOM;
            input.Name_DOM = Id_DOM;

            returned_input.Childs.Add(input);
            if (required)
                returned_input.Childs.AddRange(GetValidationAlerts(Id_DOM));
            return returned_input;
        }*/


        /*public static HtmlDomGenerator GetButton(string href, string text, StylesElements style = StylesElements.Primary)
        {
            return new HtmlDomGenerator(TypesHtmlDom.button)
            {
                href = href,
                css_class = "btn btn-" + style.ToString("g").ToLower() + " btn-lg btn-block active",
                text = text,
                CustomAtributes = new Dictionary<string, string>()
                {
                    { "role", "button" },
                    { "aria-pressed", "true" }
                }
            };
        }*/

        /*public static HtmlDomGenerator GetButtonAsLink(string href, string text, StylesElements style = StylesElements.Primary)
        {
            HtmlDomGenerator ret_button = GetButton(href, text, style);
            ret_button.TypeHtmlDom = TypesHtmlDom.a;
            return new HtmlDomGenerator(TypesHtmlDom.a)
            {
                href = href,
                css_class = "btn btn-" + style.ToString("g").ToLower() + " btn-lg btn-block active",
                text = text,
                CustomAtributes = new Dictionary<string, string>()
                {
                    { "role", "button" },
                    { "target", "_blank" },
                    { "aria-pressed", "true" }
                }
            };
        }*/

        /*public static HtmlDomGenerator GetModalDialog(string title, string text_ok_button, string text_cansel_button, HtmlDomGenerator body_html, string id_modal_dialog = "exampleModal")
        {
            HtmlDomGenerator span_close_modal_header = new HtmlDomGenerator(TypesHtmlDom.span) { text = "&times;" };
            span_close_modal_header.CustomAtributes.Add("aria-hidden", "true");
            //
            HtmlDomGenerator button_close_modal_header = new HtmlDomGenerator(TypesHtmlDom.button) { obj_type = "button", css_class = "close" };
            button_close_modal_header.CustomAtributes.Add("data-dismiss", "modal");
            button_close_modal_header.CustomAtributes.Add("aria-label", "Close");
            button_close_modal_header.Childs.Add(span_close_modal_header);
            //
            HtmlDomGenerator h5_modal_header = new HtmlDomGenerator(TypesHtmlDom.h5) { text = title, css_class = "modal-title" };
            HtmlDomGenerator div_modal_header = new HtmlDomGenerator() { css_class = "modal-header" };
            div_modal_header.Childs.Add(h5_modal_header);
            div_modal_header.Childs.Add(button_close_modal_header);

            //
            HtmlDomGenerator button_close_modal_footer = new HtmlDomGenerator(TypesHtmlDom.button) { obj_type = "button", css_class = "btn btn-secondary", text = text_cansel_button };
            button_close_modal_footer.CustomAtributes.Add("data-dismiss", "modal");
            //
            HtmlDomGenerator button_send_modal_footer = new HtmlDomGenerator(TypesHtmlDom.a) { obj_type = "button", css_class = "btn btn-primary", text = text_ok_button, Id_DOM = GetPostParamsMetaClass.button_try_create_document_id };
            //
            HtmlDomGenerator modal_footer = new HtmlDomGenerator() { css_class = "modal-footer" };

            if (!string.IsNullOrEmpty(text_cansel_button))
                modal_footer.Childs.Add(button_close_modal_footer);

            if (!string.IsNullOrEmpty(text_ok_button))
                modal_footer.Childs.Add(button_send_modal_footer);
            //
            HtmlDomGenerator modal_content = new HtmlDomGenerator() { css_class = "modal-content" };
            modal_content.Childs.Add(div_modal_header);
            //
            HtmlDomGenerator modal_body = new HtmlDomGenerator() { css_class = "modal-body" };
            modal_body.Childs.Add(body_html);
            modal_content.Childs.Add(modal_body);
            //
            modal_content.Childs.Add(modal_footer);
            //
            HtmlDomGenerator modal_dialog_document = new HtmlDomGenerator() { css_class = "modal-dialog" };


            modal_dialog_document.CustomAtributes.Add("role", "document");
            modal_dialog_document.Childs.Add(modal_content);
            //
            HtmlDomGenerator ModalDialog = new HtmlDomGenerator() { css_class = "modal fade", Id_DOM = id_modal_dialog };

            ModalDialog.CustomAtributes.Add("tabindex", "-1");
            ModalDialog.CustomAtributes.Add("role", "dialog");
            ModalDialog.CustomAtributes.Add("aria-labelledby", id_modal_dialog);
            ModalDialog.CustomAtributes.Add("aria-hidden", "true");

            ModalDialog.Childs.Add(modal_dialog_document);
            ModalDialog.coment = "Modal dialog";
            return ModalDialog;
        }*/



    }
}
