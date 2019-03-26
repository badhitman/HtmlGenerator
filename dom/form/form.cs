////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;

namespace HtmlGenerator.dom.form
{
    public class form : basic_html_dom
    {
        public class form_set
        {
            /// <summary>
            /// Атрибут сообщает браузеру, каким методом следует передавать данные формы на сервер. 
            /// </summary>
            public MethodsFormEnum method_form = MethodsFormEnum.POST;

            /// <summary>
            /// Способ кодирования данных формы.
            /// </summary>
            public EncTypesEnum EncType = EncTypesEnum.NoSet;

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
            public Targets target = Targets._self;

            /// <summary>
            /// Отменяет встроенную проверку данных введенных пользователем в форме на корректность.
            /// Такая проверка осуществляется браузером автоматически при отправке формы на сервер и происходит для полей [input type="email"], [input type="url"], а также при наличии атрибута pattern или required.
            /// </summary>
            public bool novalidate = false;

            /// <summary>
            /// Управляет автозаполнением полей форм. Значение может быть перекрыто атрибутом autocomplete у конкретных элементов формы.
            /// </summary>
            public bool autocomplete = false;
        }

        public form_set set;

        public form(form_set in_set)
        {
            set = in_set;
        }

        public override string HTML(int deep = 0)
        {
            if (!(set is null))
            {
                if (set.method_form != MethodsFormEnum.NoSet)
                    SetAtribute("method", set.method_form.ToString("g"));

                if (!string.IsNullOrEmpty(set.form_action))
                    SetAtribute("action", set.form_action);

                if (!string.IsNullOrEmpty(set.accept_charset))
                    SetAtribute("accept-charset", set.accept_charset);

                if (set.target != Targets.NoSet)
                    SetAtribute("target", set.target.ToString("g"));

                if (set.EncType != EncTypesEnum.NoSet)
                    SetAtribute("enctype", GetEnctypeHtmlForm(set.EncType));

                if (set.novalidate)
                    SetAtribute("novalidate", null);

                if (set.autocomplete)
                    SetAtribute("autocomplete", null);
            }
            return base.HTML(deep);
        }
    }
}