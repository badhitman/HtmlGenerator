////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;

namespace HtmlGenerator.dom.form
{
    public class form : basic_html_dom
    {
        /// <summary>
        /// Атрибут сообщает браузеру, каким методом следует передавать данные формы на сервер. 
        /// </summary>
        public MethodsFormEnum? method_form = MethodsFormEnum.POST;

        /// <summary>
        /// Способ кодирования данных формы.
        /// </summary>
        public EncTypesEnum? EncType = null;

        /// <summary>
        /// Адрес программы или документа, который обрабатывает данные формы. 
        /// </summary>
        public string form_action = null;

        /// <summary>
        /// Устанавливает кодировку, в которой сервер может принимать и обрабатывать данные (по умолчанию: utf-8)
        /// </summary>
        public string accept_charset = "utf-8";

        /// <summary>
        /// Имя окна или фрейма, куда обработчик будет загружать возвращаемый результат.
        ///  В качестве значения используется имя окна или фрейма, заданное атрибутом name. Если установлено несуществующее имя, то будет открыто новое окно. В качестве зарезервированных имен можно указывать следующие.
        /// _blank - Загружает страницу в новое окно браузера. 
        /// _self - Загружает страницу в текущее окно.
        /// _parent - Загружает страницу во фрейм-родитель, если фреймов нет, то это значение работает как _self.
        /// _top - Отменяет все фреймы и загружает страницу в полном окне браузера, если фреймов нет, то это значение работает как _self.
        /// </summary>
        public TargetsEnum? target = TargetsEnum._self;

        /// <summary>
        /// Отменяет встроенную проверку данных введенных пользователем в форме на корректность.
        /// Такая проверка осуществляется браузером автоматически при отправке формы на сервер и происходит для полей [input type="email"], [input type="url"], а также при наличии атрибута pattern или required.
        /// </summary>
        public bool novalidate = false;

        /// <summary>
        /// Управляет автозаполнением полей форм. Значение может быть перекрыто атрибутом autocomplete у конкретных элементов формы.
        /// </summary>
        public bool autocomplete = false;

        public override string HTML(int deep = 0)
        {
            if (!(method_form is null))
                SetAtribute("method", method_form?.ToString("g"));

            if (!string.IsNullOrEmpty(form_action))
                SetAtribute("action", form_action);

            if (!string.IsNullOrEmpty(accept_charset))
                SetAtribute("accept-charset", accept_charset);

            if (!(target is null))
                SetAtribute("target", target?.ToString("g"));

            if (!(EncType is null))
                SetAtribute("enctype", GetEnctypeHtmlForm(EncType));

            if (novalidate)
                SetAtribute("novalidate", null);

            if (autocomplete)
                SetAtribute("autocomplete", null);

            return base.HTML(deep);
        }
    }
}