////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;

namespace HtmlGenerator.html5.forms;

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
public class input : base_dom_root
{
    /// <summary>
    /// Сообщает браузеру, к какому типу относится элемент формы. 
    /// </summary>
    public InputTypesEnum type = InputTypesEnum.text;

    /// <summary>
    /// Определяет значение элемента формы, которое будет отправлено на сервер или получено с помощью клиентских скриптов.
    /// На сервер отправляется пара «имя=значение», где имя задается атрибутом name тега [input], а значение — атрибутом [value].
    /// 
    /// В зависимости от типа элемента атрибут [value] выступает в следующей роли:
    /// 
    /// для кнопок(input type = "button | reset | submit") устанавливает текстовую надпись на них;
    /// для текстовых полей(input type = "password | text") указывает предварительно введенную строку. Пользователь может стирать текст и вводить свои символы, но при использовании в форме кнопки Reset пользовательский текст очищается и восстанавливается введенный в атрибуте [value];
    /// для флажков и переключателей(input type = "checkbox | radio") уникально определяет каждый элемент, с тем, чтобы клиентская или серверная программа могла однозначно установить, какой пункт выбрал пользователь.
    /// для файлового поля(input type = "file") не оказывает влияние.
    /// </summary>
    public string? value;

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
    public string? accept;

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
    public string? form;

    /// <summary>
    /// Определяет адрес обработчика формы — это программа, которая получает данные формы и производит с ними желаемые действия.
    /// Атрибут [formaction] по своему действию аналогично атрибуту [action] тега [form]. 
    /// </summary>
    public string? formaction;

    /// <summary>
    /// Устанавливает способ кодирования данных формы при их отправке на сервер.
    /// Обычно явно указывается в случае, когда используется поле для отправки файла (input type="file").
    /// Этот атрибут по своему действию аналогичен атрибуту [enctype] тега [form], при совместном использовании formenctype и enctype последний игнорируется.
    /// </summary>
    public string? formenctype;

    /// <summary>
    /// Атрибут сообщает браузеру, каким методом следует передавать данные формы на сервер. 
    /// </summary>
    public MethodsFormEnum? formmethod = null;

    /// <summary>
    /// Отменяет встроенную проверку данных введенных пользователем в форме на корректность перед отправкой формы.
    /// Такая проверка делается браузером автоматически для полей [input type="email"], [input type="url"], а также при наличии атрибута [pattern] или [required] у тега [input].
    /// </summary>
    public bool formnovalidate = false;

    /// <summary>
    /// Определяет окно или фрейм в которое будет загружаться результат, возвращаемый обработчиком формы, в виде HTML-документа.
    /// </summary>
    public TargetsEnum? formtarget = null;

    /// <summary>
    /// Указывает на список вариантов, созданный с помощью тега [datalist], которые можно выбирать при наборе текста.
    /// Изначально этот список скрыт и становится доступным при получении полем фокуса.
    /// </summary>
    public string? list;

    /// <summary>
    /// Устанавливает верхнее значение для ввода числа или даты в поле формы.
    /// 
    /// Допустимые значения:
    ///   Целое положительное или отрицательное число(для type = "number", type= "range").
    ///   Дата в формате ГГГГ-ММ-ДД(например: 2012-12-22) для type = "date".
    /// </summary>
    public string? max;

    /// <summary>
    /// Устанавливает нижнее значение для ввода числа или даты в поле формы. 
    /// 
    /// Допустимые значения:
    ///   Целое положительное или отрицательное число(для type = "number", type= "range").
    ///   Дата в формате ГГГГ-ММ-ДД(например: 2012-12-22) для type = "date".
    /// </summary>
    public string? min;

    /// <summary>
    /// Устанавливает максимальное число символов, которое может быть введено пользователем в текстовом поле.
    /// Когда это количество достигается при наборе, дальнейший ввод становится невозможным.
    /// </summary>
    public int maxlength = 0;

    /// <summary>
    /// Атрибут [multiple] позволяет указывать одновременно несколько файлов в поле для загрузки файлов, а также несколько адресов электронной почты.
    /// При использовании двух и более почтовых адресов они должны перечисляться через запятую.
    /// </summary>
    public bool multiple = false;

    /// <summary>
    /// Указывает регулярное выражение, согласно которому требуется вводить и проверять данные в поле формы.
    /// Если присутствует атрибут [pattern], то форма не будет отправляться, пока поле не будет заполнено правильно.
    /// </summary>
    public string? pattern;

    /// <summary>
    /// Выводит текст внутри поля формы, который исчезает при получении фокуса.
    /// Если внутри строки предполагается пробел, ее необходимо брать в двойные или одинарные кавычки.
    /// </summary>
    public string? placeholder;

    /// <summary>
    /// Ширина текстового поля, которое определяется числом символов моноширинного шрифта.
    /// Иными словами, ширина задается количеством близстоящих букв одинаковой ширины по горизонтали.
    /// Если размер шрифта изменяется с помощью стилей, ширина также соответственно меняется. 
    /// </summary>
    public int size = 0;

    /// <summary>
    /// Устанавливает шаг изменения числа для ползунков и полей ввода чисел.
    /// Любое целое или дробное число.
    /// </summary>
    public double step = 0;

    public input()
    {
        inline = true;
        need_end_tag = false;
    }

    public override string GetHTML(int deep = 0)
    {
        SetAttribute("type", type.ToString("g"));
        if (type == InputTypesEnum.file)
        {
            if (!string.IsNullOrEmpty(accept))
                SetAttribute("accept", accept);

            if (!string.IsNullOrEmpty(formenctype))
                SetAttribute("formenctype", formenctype);
        }
        else if (@checked && new[] { InputTypesEnum.radio, InputTypesEnum.checkbox }.Contains(type))
            SetAttribute("checked", "checked");
        else if (new[] { InputTypesEnum.range, InputTypesEnum.number, InputTypesEnum.date }.Contains(type))
        {
            if (!string.IsNullOrEmpty(max))
                SetAttribute("max", max);

            if (!string.IsNullOrEmpty(min))
                SetAttribute("min", min);

            if (step > 0 && type != InputTypesEnum.date)
                SetAttribute("step", step);
        }
        else if (new[] { InputTypesEnum.text, InputTypesEnum.password }.Contains(type))
        {
            if (maxlength > 0)
                SetAttribute("maxlength", maxlength);
            if (size > 0)
                SetAttribute("size", size.ToString("g"));
        }
        else if (new[] { InputTypesEnum.email, InputTypesEnum.tel, InputTypesEnum.text, InputTypesEnum.search, InputTypesEnum.url }.Contains(type))
        {
            if (!string.IsNullOrEmpty(pattern))
                SetAttribute("pattern", pattern);

            if (!string.IsNullOrEmpty(placeholder))
                SetAttribute("placeholder", placeholder);
        }

        if (!string.IsNullOrEmpty(value))
            SetAttribute("value", value);

        if (@readonly)
            SetAttribute("readonly", null);

        if (disabled)
            SetAttribute("disabled", null);

        if (required)
            SetAttribute("required", null);

        if (!(autocomplete is null))
            SetAttribute("autocomplete", autocomplete == true ? "on" : "off");

        if (autofocus)
            SetAttribute("autofocus", null);

        if (!string.IsNullOrEmpty(form))
            SetAttribute("form", form);

        if (!string.IsNullOrEmpty(formaction))
            SetAttribute("formaction", formaction);

        if (!string.IsNullOrEmpty(formaction))
            SetAttribute("formaction", formaction);

        if (formmethod is not null)
            SetAttribute("formmethod", formmethod?.ToString("g"));

        if (formnovalidate)
            SetAttribute("formnovalidate", null);

        if (formtarget is not null)
            SetAttribute("formtarget", formtarget?.ToString("g"));

        if (!string.IsNullOrEmpty(list))
            SetAttribute("list", list);

        if (multiple)
            SetAttribute("multiple", null);

        return base.GetHTML(deep);
    }
}