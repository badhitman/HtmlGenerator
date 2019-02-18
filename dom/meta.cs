////////////////////////////////////////////////
// © https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using System.Collections.Generic;

namespace DataViewHtml.dom
{
    public class meta : basic_html_dom
    {
        public meta(Dictionary<string, string> in_custom_atributes = null)
        {
            SetAtribute(in_custom_atributes);
            inline = true;
            need_end_tag = false;
        }
    }
}
