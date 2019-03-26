////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Создает область, в которой при помощи JavaScript можно рисовать разные объекты, выводить изображения, трансформировать их и менять свойства.
    /// При помощи тега [canvas] можно создавать рисунки, анимацию, игры и др. 
    /// </summary>
    public class canvas : basic_html_dom
    {
        /// <summary>
        /// Задает высоту холста. По умолчанию 300 пикселов.
        /// </summary>
        public int height = -1;

        /// <summary>
        /// Задает ширину холста. По умолчанию 150 пикселов.
        /// </summary>
        public int width = -1;

        public override string HTML(int deep = 0)
        {
            if (height > 0)
                SetAtribute("height", height.ToString());

            if (width > 0)
                SetAtribute("width", width.ToString());

            return base.HTML(deep);
        }
    }
}
