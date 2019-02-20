////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    public enum Targets
    {
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
            public Targets target = Targets._self;
        }

        public a_set set;
        public a(a_set in_set)
        {
            set = in_set;
            inner_html = in_set.text;
        }

        public override string HTML(int deep = 0)
        {
            SetAtribute("href", set.href);
            SetAtribute("target", set.target.ToString("g"));

            return base.HTML(deep);
        }
    }
}
