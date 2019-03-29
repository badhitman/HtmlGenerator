﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using HtmlGenerator.set;

namespace HtmlGenerator.dom.media
{

    /// <summary>
    /// Вставляет звуковой или видеофайл для тегов [audio] и [video]. Обобщенно такие файлы называются медийными.
    /// </summary>
    public class source : basic_html_dom
    {
        /// <summary>
        /// Определяет устройство, для которого будет воспроизводиться аудио или видеофайл. 
        /// </summary>
        public MediaDevicesEnum media = MediaDevicesEnum.all;

        /// <summary>
        /// Адрес медиа файла, который будет воспроизводиться на веб-странице.
        /// </summary>
        public string src = "#";

        /// <summary>
        /// Задает MIME-тип источника, а также аудио и видеокодек — так называется алгоритм хранения воспроизводимых данных.
        /// Вначале указывается MIME-тип, затем после точки с запятой пишется ключевое слово codecs и ему присваивается через запятую значение видео и аудиокодека. Если предполагается использовать только звук, видеокодек не пишется.
        /// Пример: type='video/mp4; codecs="avc1.42E01E, mp4a.40.2"'
        /// </summary>
        public string mimetype = null;

        public override string GetHTML(int deep = 0)
        {
            /// <summary>
            /// Вложеные элементы тут не допустимы
            /// </summary>
            Childs.Clear();
            SetAtribute("media", media.ToString("g"));
            if (!string.IsNullOrEmpty(src))
            {
                SetAtribute("src", src);
                if (!string.IsNullOrEmpty(mimetype))
                    SetAtribute("type", mimetype);
            }

            return base.GetHTML(deep);
        }
    }
}
