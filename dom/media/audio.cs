////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using System.Linq;

namespace HtmlGenerator.dom.media
{
    /// <summary>
    /// Используется для загрузки аудиофайла вместе с загрузкой веб-страницы.
    /// </summary>
    public enum PreloadModes
    {
        /// <summary>
        /// Не загружать аудиофайл.
        /// </summary>
        none,

        /// <summary>
        /// Загрузить только служебную информацию (продолжительность звучания и др.).
        /// </summary>
        metadata,

        /// <summary>
        /// Загрузить аудиофайл целиком при загрузке страницы.
        /// </summary>
        auto
    }

    /// <summary>
    /// Добавляет, воспроизводит и управляет настройками аудиозаписи на веб-странице.
    /// Путь к файлу задается через атрибут [src] или вложенный тег [source]. Внутри контейнера [audio] можно написать текст, который будет выводиться в браузерах, не работающих с этим тегом. 
    /// </summary>
    public class audio : basic_html_dom
    {
        /// <summary>
        /// При наличии этого атрибута аудио начинает воспроизводиться автоматически после загрузки страницы. Атрибут autoplay отменяет действие preload.
        /// </summary>
        public bool autoplay = false;

        /// <summary>
        /// Добавляет панель управления к аудиотреку. Вид панели и ее содержимое зависит от браузера и может в себя включать: кнопку воспроизведения, паузы, перемотки, ползунок для изменения уровня громкости и др.
        /// </summary>
        public bool controls = false;

        /// <summary>
        /// Зацикливает воспроизведение аудио, чтобы оно повторялось с начала после завершения.
        /// </summary>
        public bool loop = false;

        /// <summary>
        /// Используется для загрузки аудиофайла вместе с загрузкой веб-страницы. Этот атрибут игнорируется, если установлен autoplay.
        /// Пустое значение атрибута воспринимается как auto.
        /// </summary>
        public PreloadModes preload = PreloadModes.none;

        /// <summary>
        /// Указывает путь к воспроизводимому аудиофайлу.
        /// Для этой же цели также можно использовать вложеный(ые) тег(и) "source".
        /// </summary>
        public string src = "#";

        public override string GetHTML(int deep = 0)
        {
            /// <summary>
            /// Вложеные элементы могут быть только source
            /// </summary>
            Childs = Childs.Where(x => x is source).ToList();
            if (Childs.Count == 0)
                SetAtribute("src", src);

            if (autoplay)
                SetAtribute("autoplay", "autoplay");
            else
                SetAtribute("preload", preload.ToString("g"));

            if(controls)
                SetAtribute("controls", "controls");

            if (loop)
                SetAtribute("loop", "loop");

            return base.GetHTML(deep);
        }
    }
}
