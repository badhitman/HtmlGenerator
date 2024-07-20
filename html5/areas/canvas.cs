////////////////////////////////////////////////
// https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.areas;

/// <summary>
/// Создает область, в которой при помощи JavaScript можно рисовать разные объекты, выводить изображения, трансформировать их и менять свойства.
/// При помощи тега [canvas] можно создавать рисунки, анимацию, игры и др. 
/// </summary>
public class canvas : base_dom_root
{
    /// <summary>
    /// Задает высоту холста. По умолчанию 300 пикселов.
    /// </summary>
    public int height = -1;

    /// <summary>
    /// Задает ширину холста. По умолчанию 150 пикселов.
    /// </summary>
    public int width = -1;

    public override string GetHTML(int deep = 0)
    {
        if (height > 0)
            SetAttribute("height", height);

        if (width > 0)
            SetAttribute("width", width);

        return base.GetHTML(deep);
    }
}