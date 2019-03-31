﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.media
{
    /// <summary>
    /// Добавляет, воспроизводит и управляет настройками видеоролика на веб-странице. Путь к файлу задается через атрибут [src] или вложенный тег [source].
    /// </summary>
    public class video : html_dom_root
    {
        /// <summary>
        /// Задает ширину области для воспроизведения видеоролика. 
        /// </summary>
        public int width = 0;

        /// <summary>
        /// Задает высоту области для воспроизведения видеоролика.
        /// </summary>
        public int height = 0;

        /// <summary>
        /// Указывает адрес картинки, которая будет отображаться, пока видео не доступно или не воспроизводится. 
        /// </summary>
        public string poster = null;

        public override string GetHTML(int deep = 0)
        {
            if (width > 0)
                SetAtribute("width", width);

            if (height > 0)
                SetAtribute("height", height);

            if (!string.IsNullOrEmpty(poster))
                SetAtribute("poster", poster);

            return base.GetHTML(deep);
        }
    }
}