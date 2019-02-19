////////////////////////////////////////////////
// © https://github.com/badhitman
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Доступные типа input
    /// </summary>
    public enum InputTypes
    {
        /// <summary>
        /// Без указания типа
        /// </summary>
        NoSet,

        /// <summary>
        /// Стандартные типы
        /// </summary>
        button, checkbox, file, hidden, image, password, radio, reset, submit, text
    }

    public class input : basic_html_dom
    {
        public class input_set
        {
            public InputTypes type_input;
            public string value = null;
            public bool i_readonly = false;
            public bool i_disabled = false;
            public bool i_required = false;
        }

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
                if (set.type_input > InputTypes.NoSet)
                    SetAtribute("type", set.type_input.ToString("g"));

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

        public label GetLabel(string text_title)
        {
            return new label(text_title, Id_DOM);
        }
    }
}
