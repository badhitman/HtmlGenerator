////////////////////////////////////////////////
// © https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using System.Collections.Generic;

namespace DataViewHtml.dom
{
    public class link : basic_html_dom
    {
        public link(Dictionary<string, string> in_custom_atributes = null)
        {
            SetAtribute(in_custom_atributes);
            inline = true;
            need_end_tag = false;
        }
    }
}
