////////////////////////////////////////////////
// © https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using System.Collections.Generic;

namespace HtmlGenerator.dom
{
    /// <summary>
    ///  Устанавливает связь с внешним документом вроде файла со стилями или со шрифтами. В отличие от тега "a", тег "link" размещается всегда внутри
    ///  контейнера "head" и не создает ссылку.
    /// </summary>
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
