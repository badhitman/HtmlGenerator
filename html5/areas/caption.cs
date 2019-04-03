////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using HtmlGenerator.set;
using System.Collections.Generic;

namespace HtmlGenerator.html5.areas
{
    /// <summary>
    ///  Тег [caption] предназначен для создания заголовка к таблице и может размещаться только внутри контейнера [table], причем сразу после открывающего тега.
    ///  Такой заголовок представляет собой текст, по умолчанию отображаемый перед таблицей и описывающий ее содержание. 
    /// </summary>
    public class caption : base_dom_root
    {
        /// <summary>
        /// Определяет выравнивание заголовка. 
        /// </summary>
        AlignmentEnum? align = null;

        public override string GetHTML(int deep = 0)
        {
            List<AlignmentEnum?> AllowedAligned = new List<AlignmentEnum?>() { AlignmentEnum.left, AlignmentEnum.right, AlignmentEnum.bottom, AlignmentEnum.top };
            if (AllowedAligned.Contains(align))
                SetAttribute("align", align?.ToString("g"));

            return base.GetHTML(deep);
        }
    }
}
