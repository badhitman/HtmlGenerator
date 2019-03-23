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

    public enum Relations
    {
        /// <summary>
        /// Атрибут не не используется совсем. 
        /// </summary>
        NoSet,

        /// <summary>
        /// Ссылка на архив сайта.
        /// </summary>
        archives,
        /// <summary>
        /// Ссылка на страницу об авторе на том же домене.
        /// </summary>
        author,

        /// <summary>
        /// Постоянная ссылка на раздел или запись. 
        /// </summary>
        bookmark,

        /// <summary>
        /// Ссылка на первую страницу.
        /// </summary>
        first,

        /// <summary>
        /// Ссылка на документ со справкой. 
        /// </summary>
        help,

        /// <summary>
        /// Ссылка на содержание. 
        /// </summary>
        index,

        /// <summary>
        /// Ссылка на последнюю страницу.
        /// </summary>
        last,

        /// <summary>
        /// Ссылка на страницу с лицензионным соглашением или авторскими правами.
        /// </summary>
        license,

        /// <summary>
        /// Ссылка на страницу автора на другом домене. 
        /// </summary>
        me,

        /// <summary>
        /// Ссылка на следующую страницу или раздел.
        /// </summary>
        next,

        /// <summary>
        /// Не передавать по ссылке ТИЦ и PR. 
        /// </summary>
        nofollow,

        /// <summary>
        /// Не передавать по ссылке HTTP-заголовки. 
        /// </summary>
        noreferrer,

        /// <summary>
        /// Указывает, что надо заранее кэшировать указанный ресурс. 
        /// </summary>
        prefetch,

        /// <summary>
        /// Ссылка на предыдущую страницу или раздел. 
        /// </summary>
        prev,

        /// <summary>
        /// Ссылка на поиск. 
        /// </summary>
        search,

        /// <summary>
        /// Добавить ссылку в избранное браузера. 
        /// </summary>
        sidebar,

        /// <summary>
        /// Указывает, что метка (тег) имеет отношение к текущему документу. 
        /// </summary>
        tag,

        /// <summary>
        /// Ссылка на родительскую страницу. 
        /// </summary>
        up
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
            /// Устанавливает MIME-тип документа, на который указывает ссылка. Этот атрибут носит рекомендательный характер и может использоваться для стилизации ссылок с заданным типом документа.
            /// Атрибут type должен добавляться только при наличии атрибута href.
            /// </summary>
            public string mimetype = null;

            /// <summary>
            /// По умолчанию, при переходе по ссылке документ открывается в текущем окне или фрейме.
            /// При необходимости, это условие может быть изменено атрибутом target тега "a". В XHTML применение этого атрибута запрещено. 
            /// </summary>
            public Targets target = Targets.NoSet;

            /// <summary>
            /// При наличии атрибута download браузер не переходит по ссылке, а предложит скачать документ, указанный в адресе ссылки.
            /// </summary>
            public bool download = false;

            /// <summary>
            /// Атрибут rel определяет отношения между текущим документом и документом, на который ведет ссылка, заданная атрибутом href.
            /// Несмотря на то, что браузеры в большинстве своем игнорируют атрибут rel, на сайтах часто можно встретить код rel="nofollow", предназначенный для поисковых систем Google и Яндекс. Ссылки, помеченные таким образом, не передают PageRank и ТИЦ. 
            /// </summary>
            public Relations rel = Relations.NoSet;
        }

        public a_set set;
        public a(a_set in_set)
        {
            set = in_set;
            InnerHtml = in_set.text;
        }

        public override string HTML(int deep = 0)
        {
            if (!(set.href is null))
            {
                SetAtribute("href", set.href);
                if(!string.IsNullOrEmpty(set.mimetype))
                    SetAtribute("type", set.mimetype);
            }

            if (set.target != Targets.NoSet)
                SetAtribute("target", set.target.ToString("g"));

            if (set.rel !=  Relations.NoSet)
                SetAtribute("rel", set.rel.ToString("g"));

            if (set.download)
                SetAtribute("download", null);

            return base.HTML(deep);
        }
    }
}
