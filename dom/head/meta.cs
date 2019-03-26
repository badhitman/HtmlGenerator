////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using System.Collections.Generic;

namespace HtmlGenerator.dom.head
{
    /// <summary>
    /// "meta" определяет метатеги, которые используются для хранения информации предназначенной для браузеров и поисковых систем.
    /// Например, механизмы поисковых систем обращаются к метатегам для получения описания сайта, ключевых слов и других данных.
    /// Разрешается использовать более чем один метатег, все они размещаются в контейнере "head". Как правило, атрибуты любого метатега сводятся к
    /// парам «имя=значение», которые определяются ключевыми словами content, name или http-equiv.
    /// </summary>
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
