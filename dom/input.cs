////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Доступные типа input
    /// </summary>
    public enum InputTypes
    {
        /// <summary>
        /// Стандартные типы
        /// </summary>
        button, checkbox, file, hidden, image, password, radio, reset, submit, text
    }

    public class input : basic_html_dom
    {
        /// <summary>
        /// Пакетные настройки для input-а
        /// </summary>
        public class input_set
        {
            /// <summary>
            /// Тип input-а
            /// </summary>
            public InputTypes? type_input;

            /// <summary>
            /// Значение/Value input-а
            /// </summary>
            public string value = null;

            /// <summary>
            /// флаг - только для чтения
            /// </summary>
            public bool i_readonly = false;

            /// <summary>
            /// флаг - отключено
            /// </summary>
            public bool i_disabled = false;

            /// <summary>
            /// флаг - обязательно для заполнения
            /// </summary>
            public bool i_required = false;
        }

        /// <summary>
        /// Пакетные настройки для input-а
        /// </summary>
        public input_set set;

        public input(input_set in_set)
        {
            set = in_set;
            inline = true;

        }

        public override string HTML(int deep = 0)
        {
            if (!(set is null))
            {
                if (!(set.type_input is null))
                    SetAtribute("type", set.type_input?.ToString("g"));

                if (!string.IsNullOrEmpty(set.value))
                    SetAtribute("value", set.value);

                if (set.i_readonly)
                    SetAtribute("readonly", null);

                if (set.i_disabled)
                    SetAtribute("disabled", null);

                if (set.i_required)
                    SetAtribute("required", null);

            }
            return base.HTML(deep);
        }
    }
}
