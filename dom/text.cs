﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    public class text : basic_html_dom
    {
        public text(string i_html_text)
        {
            inline = true;
            InnerText = i_html_text;
        }
    }
}
