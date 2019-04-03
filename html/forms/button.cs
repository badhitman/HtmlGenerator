////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using HtmlGenerator.dom.set;

namespace HtmlGenerator.dom.html.forms
{
    /// <summary>
    ///  Определяет тип кнопки, который устанавливает ее поведение в форме. По внешнему виду кнопки разного типа никак не различаются, но у каждой такой кнопки свои функции. 
    /// </summary>
    public enum TypesButton
    {
        /// <summary>
        /// Обычная кнопка. 
        /// </summary>
        button,

        /// <summary>
        /// Кнопка для очистки введенных данных формы и возвращения значений в первоначальное состояние.
        /// </summary>
        reset,

        /// <summary>
        /// Кнопка для отправки данных формы на сервер. 
        /// </summary>
        submit
    }

    public class button : base_dom_root
    {
        /// <summary>
        ///  Определяет тип кнопки, который устанавливает ее поведение в форме. По внешнему виду кнопки разного типа никак не различаются, но у каждой такой кнопки свои функции. 
        /// </summary>
        public TypesButton? TypeButton;

        /// <summary>
        /// Атрибут [autofocus] устанавливает, что кнопка получает фокус после загрузки страницы. Такую кнопку можно нажать сразу без перевода на неё фокуса, например, с помощью клавиатуры.
        /// </summary>
        public bool autofocus = false;

        /// <summary>
        /// Блокирует доступ и изменение кнопки. Она в таком случае отображается серой и недоступной для активации пользователем.
        /// Кроме того, такая кнопка не может получить фокус путем нажатия на клавишу Tab, мышью или другим способом.
        /// Тем не менее, такое состояние кнопки можно изменять через скрипты. Значение блокированной кнопки не передается на сервер.
        /// </summary>
        public bool disabled = false;

        /// <summary>
        /// Связывает кнопку с формой по её идентификатору. Такая связь необходима в случае, когда кнопка не располагается внутри [form], например, при создании её программно. 
        /// </summary>
        public string form = null;

        /// <summary>
        /// Определяет адрес обработчика формы — это программа, которая получает данные формы и производит с ними желаемые действия.
        /// Атрибут [formaction] по своему действию аналогично атрибуту action тега [form].
        /// Если одновременно указать [action] и [formaction], то при нажатии на кнопку атрибут [action] игнорируется и данные пересылаются по адресу, указанному в [formaction].
        /// </summary>
        public string formaction = null;

        /// <summary>
        /// Устанавливает способ кодирования данных формы при их отправке на сервер. Обычно явно указывается в случае, когда используется поле для отправки файла (input type="file").
        /// Этот атрибут по своему действию аналогичен атрибуту enctype тега [form].
        /// </summary>
        public EncTypesEnum? formenctype = null;

        /// <summary>
        /// Атрибут сообщает браузеру, каким методом следует передавать данные формы на сервер. 
        /// </summary>
        public MethodsFormEnum? formmethod = null;

        /// <summary>
        /// Отменяет встроенную проверку данных введенных пользователем в форме на корректность при нажатии на кнопку.
        /// Такая проверка делается браузером автоматически при отправке формы на сервер для полей [input type="email"], [input type="url"], а также при наличии атрибута [pattern] или [required] у тега [input].
        /// </summary>
        public bool formnovalidate = false;

        /// <summary>
        /// Определяет окно или фрейм в которое будет загружаться результат, возвращаемый обработчиком формы, в виде HTML-документа.
        /// </summary>
        public TargetsEnum? formtarget = null;

        public button(string text_button, TypesButton type_button = TypesButton.button)
        {
            InnerText = text_button;
            TypeButton = type_button;
        }

        public override string GetHTML(int deep = 0)
        {
            if (!(TypeButton is null))
                SetAttribute("type", TypeButton?.ToString("g"));

            if (autofocus)
                SetAttribute("autofocus", null);

            if (disabled)
                SetAttribute("disabled", "disabled");

            if (!string.IsNullOrEmpty(form) && form.Length > 0)
                SetAttribute("form", form);

            if (!string.IsNullOrEmpty(formaction) && formaction.Length > 0)
                SetAttribute("formaction", formaction);

            if (!(formenctype is null))
                SetAttribute("formenctype", GetEnctypeHtmlForm(formenctype));

            if (!(formmethod is null))
                SetAttribute("formmethod", formmethod?.ToString("g"));

            if (formnovalidate)
                SetAttribute("formnovalidate", null);

            if (!(formtarget is null))
                SetAttribute("formtarget", formtarget?.ToString("g"));

            return base.GetHTML(deep);
        }
    }
}
