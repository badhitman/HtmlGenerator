﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание позаимствовано с сайтов http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Используется для отображения прогресса завершенности задачи. Изменение значения происходит через JavaScript.
    /// </summary>
    public class progress : basic_html_dom
    {
        /// <summary>
        /// Текущее значение прогресса.
        /// </summary>
        public int value = 0;

        /// <summary>
        /// Максимальное значение прогресса
        /// </summary>
        public int max = 100;

        public override string GetHTML(int deep = 0)
        {
            SetAtribute("value", value);
            SetAtribute("max", max);

            return base.GetHTML(deep);
        }
    }
}