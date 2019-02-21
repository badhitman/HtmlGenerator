////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HtmlGenerator.bootstrap
{
    public abstract class base_page_tmpl
    {
        public virtual string PageTitle { get { return "Привет мир"; } }
        public virtual string PageHeader { get { return "Привет мир"; } }

        /// <summary>
        /// Результат обработки запроса
        /// </summary>
        public List<basic_html_dom> PageBodyDomElements = new List<basic_html_dom>();

        public static List<Type> GetTypes(string nspace)
        {
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nspace
                    select t;
            return q.ToList();
        }
    }
}