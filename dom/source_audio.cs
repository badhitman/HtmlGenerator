////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Определяет устройство, для которого будет воспроизводиться аудио или видеофайл. 
    /// </summary>
    public enum MediaDevices
    {
        /// <summary>
        /// Все устройства.
        /// </summary>
        all,

        /// <summary>
        /// Устройства, основанные на системе Брайля, предназначены для слепых людей.
        /// </summary>
        braille,

        /// <summary>
        /// Наладонники, смартфоны, устройства с малой шириной экрана.
        /// </summary>
        handheld,

        /// <summary>
        /// Печатающее устройство вроде принтера.
        /// </summary>
        print,

        /// <summary>
        /// Экран монитора.
        /// </summary>
        screen,

        /// <summary>
        /// Речевые синтезаторы, а также программы для воспроизведения текста вслух. Сюда же входят речевые браузеры.
        /// </summary>
        speech,

        /// <summary>
        /// Проектор.
        /// </summary>
        projection,

        /// <summary>
        /// Телетайпы, терминалы, портативные устройства с ограниченными возможностями экрана.
        /// </summary>
        tty,

        /// <summary>
        /// Телевизор.
        /// </summary>
        tv
    }

    public class source_audio : basic_html_dom
    {
        /// <summary>
        /// Определяет устройство, для которого будет воспроизводиться аудио или видеофайл. 
        /// </summary>
        public MediaDevices media = MediaDevices.all;

        /// <summary>
        /// Адрес аудио или видеофайла, который будет воспроизводиться на веб-странице.
        /// </summary>
        public string src = "#";

        public override string HTML(int deep = 0)
        {
            set_custom_name_tag = "source";
            return base.HTML(deep);
        }
    }
}
