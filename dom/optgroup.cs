////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    public class optgroup : basic_html_dom
    {
        public class optgroup_set
        {
            /// <summary>
            /// Заголовок
            /// </summary>
            public string label_text;

            /// <summary>
            /// Признак. Отключён
            /// </summary>
            public bool disabled = false;
        }

        public optgroup_set set;

        /// <summary>
        /// Тег "optgroup" представляет собой контейнер, внутри которого располагаются теги "option" объединенные в одну группу.
        /// Особенностью тега "optgroup" является то, что он не выделяется как обычный элемент списка, акцентируется с помощью жирного начертания,
        /// а все элементы, входящие в этот контейнер, смещаются вправо от своего исходного положения.
        /// </summary>
        public optgroup(optgroup_set in_set)
        {
            set = in_set;
            inline = true;
        }

        public override string HTML(int deep = 0)
        {
            if (!(set is null))
            {
                SetAtribute("label", set.label_text);

                if (set.disabled)
                    SetAtribute("disabled", null);
            }
            return base.HTML(deep);
        }

    }
}
