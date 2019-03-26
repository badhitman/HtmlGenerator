////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.form
{
    public class textarea : basic_html_dom
    {
        public class set_textarea
        {
            public enum WrapsModes { soft, hard, off }

            /// <summary>
            /// Автоматическое получение фокуса.
            /// Автоматически устанавливает фокус в текстовое поле. В таком поле можно сразу набирать текст без переключения курсора в текстовое поле.
            /// </summary>
            public bool autofocus = false;

            /// <summary>
            /// Ширина поля в символах.
            /// Ширина текстового поля, которое определяется числом символов моноширинного шрифта. Иными словами, ширина задается количеством близстоящих букв одинаковой ширины по горизонтали. Если размер шрифта изменяется с помощью стилей, ширина также соответственно меняется.
            /// </summary>
            public int cols = 0;

            /// <summary>
            /// Высота поля в строках текста.
            /// Высота текстового поля, которое определяется количеством отображаемых строк без прокрутки содержимого. Если размер шрифта изменяется с помощью стилей, высота поля также соответственно меняется.
            /// </summary>
            public int rows = 0;

            /// <summary>
            /// Блокирует доступ и изменение текстового поля. Оно в таком случае отображается серым и недоступным для активации пользователем. Кроме того, такое поле не может получить фокус путем нажатия на клавишу Tab, мышью или другим способом. Тем не менее, такое состояние поля можно менять с помощью скриптов.
            /// </summary>
            public bool disabled = false;

            /// <summary>
            /// Обязательное для заполнения поле.
            /// Устанавливает текстовое поле обязательным для заполнения перед отправкой формы на сервер. Если в обязательном поле нет текста, браузер выведет сообщение, а форма отправлена не будет. Вид и содержание сообщения зависит от браузера и меняться пользователем не может.
            /// </summary>
            public bool required = false;

            /// <summary>
            /// Устанавливает, что поле не может изменяться пользователем.
            /// Когда к тегу "textarea" добавляется атрибут readonly, текстовое поле не может изменяться пользователем, в том числе вводиться новый текст или модифицироваться существующий. Тем не менее, состояние и содержимое поля можно менять с помощью скриптов.
            /// </summary>
            public bool Readonly = false;

            /// <summary>
            /// Связывает текстовое поле с формой по её идентификатору.
            /// Такая связь необходима в случае, когда поле по каким-либо причинам располагается за пределами "form"
            /// </summary>
            public string form = null;

            /// <summary>
            /// Максимальное число введенных символов.
            /// Устанавливает максимальное число символов, которое может быть введено пользователем в текстовом поле. Когда это количество достигается при наборе, дальнейший ввод становится невозможным.
            /// </summary>
            public int maxlength = 0;

            /// <summary>
            /// Указывает замещающийся текст.
            /// Выводит текст внутри текстового поля, который исчезает при получении фокуса.
            /// </summary>
            public string placeholder = null;

            /// <summary>
            /// Значение input-а
            /// </summary>
            public string TextValue = null;

            /// <summary>
            /// Параметры переноса строк.
            /// Атрибут wrap говорит браузеру, как осуществлять перенос текста в поле "textarea" и в каком виде отправлять данные на сервер.
            /// Если этот атрибут отсутствует, текст в поле набирается одной строкой, когда число введенных символов превышает ширину области,
            /// появляется горизонтальная полоса прокрутки. Нажатие кнопки Enter переносит текст на новую строку, и курсор устанавливается у левого края поля.
            /// </summary>
            public WrapsModes wrap = WrapsModes.soft;
        }

        public set_textarea set;

        /// <summary>
        /// Поле "textarea" представляет собой элемент формы для создания области, в которую можно вводить несколько строк текста.
        /// В отличие от тега "input" в текстовом поле допустимо делать переносы строк, они сохраняются при отправке данных на сервер.
        /// </summary>
        public textarea(string text_value, set_textarea in_set)
        {
            inline = true;
            set = in_set;
            InnerText = text_value;
        }

        public override string HTML(int deep = 0)
        {
            if (set != null)
            {
                SetAtribute("wrap", set.wrap.ToString("g"));

                if (set.autofocus)
                    SetAtribute("autofocus", null);

                if (set.cols > 0)
                    SetAtribute("cols", set.cols.ToString());

                if (set.disabled)
                    SetAtribute("disabled", null);

                if (!string.IsNullOrEmpty(set.form))
                    SetAtribute("form", set.form);

                if (set.maxlength > 0)
                    SetAtribute("maxlength", set.maxlength.ToString());

                if (!string.IsNullOrEmpty(set.TextValue))
                    InnerText = set.TextValue;

                if (!string.IsNullOrEmpty(set.placeholder))
                    SetAtribute("placeholder", set.placeholder);

                if (set.Readonly)
                    SetAtribute("readonly", null);

                if (set.required)
                    SetAtribute("required", null);

                if (set.rows > 0)
                    SetAtribute("rows", set.rows.ToString());
            }

            return base.HTML(deep);
        }
    }
}
