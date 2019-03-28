﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;

namespace HtmlGenerator.dom.form
{
    /// <summary>
    ///  Тег [input] является одним из разносторонних элементов формы и позволяет создавать разные элементы интерфейса и обеспечить взаимодействие с пользователем.
    ///  Главным образом [input] предназначен для создания текстовых полей, различных кнопок, переключателей и флажков.
    ///  Хотя элемент [input] не требуется помещать внутрь контейнера [form], определяющего форму, но если введенные пользователем данные должны быть отправлены на сервер, где их обрабатывает серверная программа, то указывать [form] обязательно.
    ///  То же самое обстоит и в случае обработки данных с помощью клиентских приложений, например, скриптов на языке JavaScript.
    ///  
    ///  Основной атрибут тега [input], определяющий вид элемента — [type].
    ///  Он позволяет задавать следующие элементы формы: текстовое поле(text), поле с паролем(password), переключатель(radio), флажок(checkbox), скрытое поле(hidden), кнопка(button), кнопка для отправки формы(submit), кнопка для очистки формы(reset), поле для отправки файла(file) и кнопка с изображением(image).
    ///  Для каждого элемента существует свой список атрибутов, которые определяют его вид и характеристики.Кроме того, в HTML5 добавлено еще более десятка новых элементов.
    /// </summary>
    public class input : basic_html_dom
    {
        /// <summary>
        /// Тип input-а
        /// </summary>
        public InputTypesEnum type = InputTypesEnum.text;

        public string value = null;

        /// <summary>
        /// Устанавливает фильтр на типы файлов, которые вы можете отправить через поле загрузки файлов.
        /// Тип файла указывается как MIME-тип, при нескольких значениях они перечисляются через запятую.
        /// Если файл не подходит под установленный фильтр, он не показывается в окне выбора файлов.
        /// 
        /// Имя MIME-типа в любом регистре, несколько значений перечисляются через запятую.
        /// В HTML5 также допустимо в качестве значения указывать audio/* для выбора всех звуковых файлов, video/* для видеофайлов и image/* для всех графических файлов.
        /// 
        /// Пример: accept="image/jpeg,image/png,image/gif"
        /// </summary>
        public string accept = null;

        /// <summary>
        /// флаг/признак - только для чтения
        /// </summary>
        public bool @readonly = false;

        /// <summary>
        /// флаг/признак - отключено
        /// </summary>
        public bool disabled = false;

        /// <summary>
        /// флаг/признак - обязательно для заполнения
        /// </summary>
        public bool required = false;

        /// <summary>
        /// Этот атрибут помогает заполнять поля форм текстом, который был введён в них ранее.
        /// Значения сохраняет и подставляет браузер, при этом автозаполнение по соображениям безопасности может отключаться пользователем в настройках и не может в таком случае управляться атрибутом [autocomplete].
        /// </summary>
        public bool? autocomplete = null;

        /// <summary>
        /// Автоматически устанавливает фокус в поле формы. В таком поле можно сразу набирать текст без явного щелчка по нему курсором мыши.
        /// </summary>
        public bool autofocus = false;

        /// <summary>
        ///  Этот атрибут определяет, помечен ли заранее такой элемент формы, как флажок или переключатель.
        ///  В случае использования переключателей (radiobutton), может быть отмечен только один элемент группы, для флажков (checkbox) допустимо пометить хоть все элементы. 
        /// </summary>
        public bool @checked = false;

        /// <summary>
        /// Связывает поле с формой по её идентификатору.
        /// Такая связь необходима в случае, когда поле располагается за пределами [form], например, при создании её программно или по соображениям дизайна.
        /// </summary>
        public string form = null;

        /// <summary>
        /// Определяет адрес обработчика формы — это программа, которая получает данные формы и производит с ними желаемые действия.
        /// Атрибут [formaction] по своему действию аналогично атрибуту [action] тега [form]. 
        /// </summary>
        public string formaction = null;

        /// <summary>
        /// Устанавливает способ кодирования данных формы при их отправке на сервер.
        /// Обычно явно указывается в случае, когда используется поле для отправки файла (input type="file").
        /// Этот атрибут по своему действию аналогичен атрибуту [enctype] тега [form], при совместном использовании formenctype и enctype последний игнорируется.
        /// </summary>
        public string formenctype = null;

        /// <summary>
        /// Атрибут сообщает браузеру, каким методом следует передавать данные формы на сервер. 
        /// </summary>
        public MethodsFormEnum formmethod = MethodsFormEnum.POST;

        /// <summary>
        /// Отменяет встроенную проверку данных введенных пользователем в форме на корректность перед отправкой формы.
        /// Такая проверка делается браузером автоматически для полей [input type="email"], [input type="url"], а также при наличии атрибута [pattern] или [required] у тега [input].
        /// </summary>
        public bool formnovalidate = false;

        /// <summary>
        /// Определяет окно или фрейм в которое будет загружаться результат, возвращаемый обработчиком формы, в виде HTML-документа.
        /// </summary>
        public TargetsEnum formtarget = TargetsEnum._self;

        /// <summary>
        /// Указывает на список вариантов, созданный с помощью тега [datalist], которые можно выбирать при наборе текста.
        /// Изначально этот список скрыт и становится доступным при получении полем фокуса.
        /// </summary>
        public string list = null;

        public int max = 0;









        public input()
        {
            inline = true;
            need_end_tag = false;
        }

        public override string HTML(int deep = 0)
        {
            SetAtribute("type", type.ToString("g"));
            if (type == InputTypesEnum.file && !string.IsNullOrEmpty(accept))
                SetAtribute("accept", accept);

            if (!string.IsNullOrEmpty(value))
                SetAtribute("value", value);

            if (@readonly)
                SetAtribute("readonly", null);

            if (disabled)
                SetAtribute("disabled", null);

            if (required)
                SetAtribute("required", null);

            if (!(autocomplete is null))
                SetAtribute("autocomplete", autocomplete == true ? "on" : "off");

            return base.HTML(deep);
        }
    }
}
