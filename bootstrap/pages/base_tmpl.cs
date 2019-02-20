////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////

using System.Collections.Generic;

namespace HtmlGenerator.bootstrap
{
    public abstract class base_page_tmpl
    {
        /// <summary>
        /// Результат обработки запроса
        /// </summary>
        public List<basic_html_dom> PageBodyDomElements = new List<basic_html_dom>();
    }
}