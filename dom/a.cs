////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    public enum Targets
    {
        /// <summary>
        /// Атрибут не не используется совсем. 
        /// </summary>
        NoSet,

        /// <summary>
        /// Отменяет все фреймы и загружает страницу в полном окне браузера, если фреймов нет, то это значение работает как _self.
        /// </summary>
        _top,

        /// <summary>
        /// Загружает страницу во фрейм-родитель, если фреймов нет, то это значение работает как _self.
        /// </summary>
        _parent,

        /// <summary>
        /// Загружает страницу в новое окно браузера.
        /// </summary>
        _blank,

        /// <summary>
        /// Загружает страницу в текущее окно.
        /// </summary>
        _self
    }

    public class a : basic_html_dom
    {
        public class a_set
        {
            /// <summary>
            /// Текст ссылки
            /// </summary>
            public string text = "";

            /// <summary>
            /// Ссылка
            /// </summary>
            public string href = "#";

            /// <summary>
            /// По умолчанию, при переходе по ссылке документ открывается в текущем окне или фрейме.
            /// При необходимости, это условие может быть изменено атрибутом target тега "a". В XHTML применение этого атрибута запрещено. 
            /// </summary>
            public Targets target = Targets.NoSet;

            /// <summary>
            /// При наличии атрибута download браузер не переходит по ссылке, а предложит скачать документ, указанный в адресе ссылки.
            /// </summary>
            public bool download = false;
        }

        public a_set set;
        public a(a_set in_set)
        {
            set = in_set;
            InnerHtml = in_set.text;
        }

        public override string HTML(int deep = 0)
        {
            SetAtribute("href", set.href);
            if (set.target != Targets.NoSet)
                SetAtribute("target", set.target.ToString("g"));

            if (set.download)
                SetAtribute("download", null);
            return base.HTML(deep);
        }
    }
}
