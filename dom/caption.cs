////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using HtmlGenerator.set;
using System.Linq;

namespace HtmlGenerator.dom
{
    /// <summary>
    ///  Тег [caption] предназначен для создания заголовка к таблице и может размещаться только внутри контейнера [table], причем сразу после открывающего тега.
    ///  Такой заголовок представляет собой текст, по умолчанию отображаемый перед таблицей и описывающий ее содержание. 
    /// </summary>
    public class caption : basic_html_dom
    {
        /// <summary>
        /// Определяет выравнивание заголовка по горизонтали. 
        /// </summary>
        AlignEnum align = AlignEnum.NoSet;

        public override string HTML(int deep = 0)
        {
            if (new[] { AlignEnum.left, AlignEnum.right, AlignEnum.bottom, AlignEnum.top }.Contains(align))
                SetAtribute("align", align.ToString("g"));

            return base.HTML(deep);
        }
    }
}
