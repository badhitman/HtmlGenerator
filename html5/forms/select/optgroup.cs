////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.forms
{
    public class optgroup : base_dom_root
    {
        public class optgroup_set
        {
            /// <summary>
            /// Заголовок
            /// </summary>
            public string TitleText;

            /// <summary>
            /// Признак. Отключён
            /// </summary>
            public bool Disabled = false;
        }

        public optgroup_set set;

        /// <summary>
        /// Тег [optgroup] представляет собой контейнер, внутри которого располагаются теги [option] объединенные в одну группу.
        /// Особенностью тега [optgroup] является то, что он не выделяется как обычный элемент списка, акцентируется с помощью жирного начертания,
        /// а все элементы, входящие в этот контейнер, смещаются вправо от своего исходного положения.
        /// </summary>
        public optgroup(optgroup_set in_set)
        {
            set = in_set;
            inline = true;
        }

        public override string GetHTML(int deep = 0)
        {
            if (!(set is null))
            {
                SetAttribute("label", set.TitleText);

                if (set.Disabled)
                    SetAttribute("disabled", null);
            }
            return base.GetHTML(deep);
        }

    }
}
