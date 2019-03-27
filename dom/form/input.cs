////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.form
{
    /// <summary>
    /// Доступные типы [input]
    /// </summary>
    public enum InputTypesEnum
    {
        /// <summary>
        /// Стандартные типы
        /// </summary>
        button, checkbox, file, hidden, image, password, radio, reset, submit, text, email, url
    }

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
        public InputTypesEnum? type;

        /// <summary>
        /// Значение/Value input-а
        /// </summary>
        public string value = null;

        /// <summary>
        /// флаг - только для чтения
        /// </summary>
        public bool @readonly = false;

        /// <summary>
        /// флаг - отключено
        /// </summary>
        public bool disabled = false;

        /// <summary>
        /// флаг - обязательно для заполнения
        /// </summary>
        public bool required = false;

        public input()
        {
            inline = true;
            need_end_tag = false;
        }

        public override string HTML(int deep = 0)
        {
            if (!(type is null))
                SetAtribute("type", type?.ToString("g"));

            if (!string.IsNullOrEmpty(value))
                SetAtribute("value", value);

            if (@readonly)
                SetAtribute("readonly", null);

            if (disabled)
                SetAtribute("disabled", null);

            if (required)
                SetAtribute("required", null);

            return base.HTML(deep);
        }
    }
}
