////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using HtmlGenerator.set;
using System.Collections.Generic;

namespace HtmlGenerator.dom
{
    /// <summary>
    ///  Определяет форму «горячей области», координаты которой задаются с помощью атрибута coords. 
    /// </summary>
    public enum Shapes
    {
        /// <summary>
        /// Область в виде окружности.
        /// </summary>
        circle,

        /// <summary>
        /// Указывает всю область.
        /// </summary>
        @default,

        /// <summary>
        /// Область в виде полигона (многоугольника).
        /// </summary>
        poly,

        /// <summary>
        /// Прямоугольная область.
        /// </summary>
        rect
    }

    /// <summary>
    ///  Каждый элемент "area" определяет активные области изображения, которые являются ссылками.
    ///  Рисунок с привязанными к нему активными областями называется в совокупности картой-изображением.
    ///  Такая карта по внешнему виду ничем не отличается от обычного изображения, но при этом оно может быть разбито на невидимые зоны разной формы, где каждая из областей служит ссылкой.
    ///  Тег "area" задает форму области, ее размеры, устанавливает адрес документа, на который следует сделать ссылку, а также имя окна или фрейма, куда браузер будет загружать документ.
    ///  Этот тег всегда располагается в контейнере "map", который связывает координаты областей с изображением.
    ///  Несколько областей могут перекрывать друг друга, сверху будет та, которая в коде HTML располагается выше.
    /// </summary>
    public class area : basic_html_dom
    {
        public class area_set
        {
            /// <summary>
            /// Атрибут alt устанавливает альтернативный текст для области изображения.
            /// Такой текст отображается в виде всплывающей подсказки при наведении курсора мыши на область.
            /// </summary>
            public string alt = "";

            /// <summary>
            /// Устанавливает координаты области, она также называется «горячая область». Такая область может быть ссылкой на файл или связана с действием, определяемым скриптом.
            ///  Набор координат определяется формой «горячей области», которая задается атрибутом shape. Отсчет координат обычно ведется от левого верхнего угла изображения и указывается в пикселах. 
            /// </summary>
            public List<int> coords { get; private set; } = new List<int>();

            /// <summary>
            /// Ссылка
            /// </summary>
            public string href = "#";

            /// <summary>
            ///  Определяет форму «горячей области», координаты которой задаются с помощью атрибута coords. 
            /// </summary>
            public Shapes shape = Shapes.rect;

            /// <summary>
            /// Устанавливает MIME-тип документа, на который указывает ссылка. Этот атрибут носит рекомендательный характер и может использоваться для стилизации ссылок с заданным типом документа.
            /// Атрибут type должен добавляться только при наличии атрибута href.
            /// </summary>
            public string mimetype = null;

            /// <summary>
            /// По умолчанию, при переходе по ссылке документ открывается в текущем окне или фрейме.
            /// При необходимости, это условие может быть изменено атрибутом target тега "a". В XHTML применение этого атрибута запрещено. 
            /// </summary>
            public TargetsEnum? target = null;
        }

        public area_set set;
        public area(area_set in_set) => set = in_set;

        public override string HTML(int deep = 0)
        {
            if (!(set.alt is null))
                SetAtribute("alt", set.alt);

            if (!(set.href is null))
            {
                SetAtribute("href", set.href);
                if (!string.IsNullOrEmpty(set.mimetype))
                    SetAtribute("type", set.mimetype);
            }

            if (!(set.target is null))
                SetAtribute("target", set.target?.ToString("g"));

            SetAtribute("shape", set.shape.ToString("g"));

            string s_coords = "";
            set.coords.ForEach(x => s_coords += " " + x.ToString());
            s_coords = s_coords.Trim();
            s_coords = s_coords.Replace(" ", ", ");
            if (!string.IsNullOrEmpty(s_coords))
                SetAtribute("coords", s_coords);

            return base.HTML(deep);
        }

    }
}
