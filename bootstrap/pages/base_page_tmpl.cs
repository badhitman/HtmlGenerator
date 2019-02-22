////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace HtmlGenerator.bootstrap
{
    [DataContract]
    public abstract class base_page_tmpl
    {
        public enum EchoMode {json, html }

        [DataMember]
        public string PageTitle { get; set; } = "Привет мир";

        [DataMember]
        public string PageHeader { get; set; } = "Привет мир";

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

        public string ToString(EchoMode echo_mode, int deep_dom_html = 2)
        {
            if(echo_mode == EchoMode.json)
                return MultiTool.glob_tools.SerialiseJSON(this);

            string ret_val = "";
            foreach (basic_html_dom item in PageBodyDomElements)
                ret_val += item.HTML(deep_dom_html);

            return ret_val;
        }
    }
}