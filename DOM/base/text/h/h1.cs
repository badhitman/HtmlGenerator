﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////
///
namespace HtmlGenerator.DOM.text
{
    public class h1 : base_dom_root
    {
        public h1(string h_text)
        {
            inline = true;
            InnerText = h_text;
        }
    }
}
