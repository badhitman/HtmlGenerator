////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////

using System.Collections.Generic;

namespace DataViewHtml.bootstrap.pages
{
    public abstract class base_page_tmpl
    {
        /// <summary>
        /// Результат обработки запроса
        /// </summary>
        public List<basic_html_dom> PageBodyDomElements = new List<basic_html_dom>();

        /*protected HtmlDomGenerator user_form;*/
        /*protected BootstrapWebServer sender;
        /// <summary>
        /// Конструктор. Автоматическая проверка уровня доступа пользователя. Если Пользователь запроса не определён, то обработки запроса не произволим
        /// </summary>
        /// <param name="sender">Объект, который обрабатывает запрос/ответ</param>
        public base_page_tmpl(BootstrapWebServer _sender)
        {
            sender = _sender;
            sender.notifications.Clear();
            // Если пользователь запроса не определён, то не обрабатываем запрос
            dom_elements.Clear();

            if (sender.UserInitСalling == null)
                return;

            // Если требуется уровень выше Гостевого и при этом пользователь нективен/гость
            if (MinAccessLevel > AccessLevelUser.Guest && !sender.UserInitСalling.IsExist)
            {
                dom_elements.Add(new HtmlDomGenerator(HtmlDomGenerator.TypesHtmlDom.h3) { text = "Вы не авторизованы, либо Ваш акаунт не активен!" });
                sender.http_code = 401;
            }
            // Если требуемый уровень ниже текущего уровня достпу пользователя
            else if (sender.UserInitСalling.AccessLevel < MinAccessLevel)
            {
                dom_elements.Add(new HtmlDomGenerator(HtmlDomGenerator.TypesHtmlDom.h3) { text = "Отказано в доступе!" });
                dom_elements.Add(new HtmlDomGenerator(HtmlDomGenerator.TypesHtmlDom.hr));
                dom_elements.Add(new HtmlDomGenerator(HtmlDomGenerator.TypesHtmlDom.h4) { text = "Требуемый уровень: " + MinAccessLevel.ToString("g") });
                sender.http_code = 403;
            }
            // Если существуют ответные DOM элементы, значит есть ошибки доступа, а значит новая/повторная авторизация
            if (dom_elements.Count > 0)
                dom_elements.AddRange(HtmlDomGenerator.GetLoginForm());
        }*/

        /*public static HtmlDomGenerator SetDefInputs(HtmlDomGenerator _in_form, DataObj owner)
        {
            _in_form.Childs.Add(HtmlDomGenerator.GetCheckboxInput("Отключить объект?", g.GetMemberName((DataObj c) => c.Off), owner.Off));
            _in_form.Childs.Add(HtmlDomGenerator.GetCheckboxInput("Пометка удаления?", g.GetMemberName((DataObj c) => c.Delete), owner.Delete));
            _in_form.Childs.Add(HtmlDomGenerator.GetTextarea("Комментарий (технический)", owner.Information, g.GetMemberName((DataObj c) => c.Information), false));

            _in_form.Childs.Add(new HtmlDomGenerator(HtmlDomGenerator.TypesHtmlDom.button)
            {
                css_class = "btn btn-success btn-lg btn-block",
                text = "Сохранить"
            });
            return _in_form;
        }*/
    }
}