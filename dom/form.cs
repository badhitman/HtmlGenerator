////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    public enum MethodsForm
    {
        /// <summary>
        /// Без указания метода
        /// </summary>
        NoSet,

        /// <summary>
        /// Стандартные методы
        /// </summary>
        POST, GET
    }

    public enum EncTypes
    {
        /// <summary>
        /// Вместо пробелов ставится +, символы вроде русских букв кодируются их шестнадцатеричными значениями (например, %D0%90%D0%BD%D1%8F вместо Аня).
        /// </summary>
        WwwFormUrlEncoded,

        /// <summary>
        /// Данные не кодируются. Это значение применяется при отправке файлов.
        /// </summary>
        MultipartFormData,

        /// <summary>
        /// Пробелы заменяются знаком +, буквы и другие символы не кодируются.
        /// </summary>
        Plain,

        /// <summary>
        /// Признак того, что указывать атрибут не нужно
        /// </summary>
        NoSet
    }

    public class form : basic_html_dom
    {
        public class form_set
        {
            /// <summary>
            /// Метод протокола HTTP.
            /// </summary>
            public MethodsForm method_form = MethodsForm.POST;

            /// <summary>
            /// Способ кодирования данных формы.
            /// </summary>
            public EncTypes EncType = EncTypes.NoSet;

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
                if (set.method_form > MethodsForm.NoSet)
                    SetAtribute("method", set.method_form.ToString("g"));

                if (!string.IsNullOrEmpty(set.form_action))
                    SetAtribute("action", set.form_action);

                if (!string.IsNullOrEmpty(set.accept_charset))
                    SetAtribute("accept-charset", set.accept_charset);

                SetAtribute("target", set.target.ToString("g"));

                if (set.EncType != EncTypes.NoSet)
                    switch (set.EncType)
                    {
                        case EncTypes.WwwFormUrlEncoded:
                            SetAtribute("enctype", "application/x-www-form-urlencoded");
                            break;
                        case EncTypes.MultipartFormData:
                            SetAtribute("enctype", "multipart/form-data");
                            break;
                        case EncTypes.Plain:
                            SetAtribute("enctype", "text/plain");
                            break;
                        default:
                            SetAtribute("enctype", "application/x-www-form-urlencoded");
                            break;
                    }
            }
            return base.HTML(deep);
        }
    }
}