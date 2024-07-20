////////////////////////////////////////////////
// https://github.com/badhitman
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.media;

/// <summary>
/// Добавляет, воспроизводит и управляет настройками видеоролика на веб-странице. Путь к файлу задается через атрибут [src] или вложенный тег [source].
/// </summary>
public class video : base_dom_root
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
    public string? poster;

    public override string GetHTML(int deep = 0)
    {
        if (width > 0)
            SetAttribute("width", width);

        if (height > 0)
            SetAttribute("height", height);

        if (!string.IsNullOrEmpty(poster))
            SetAttribute("poster", poster);

        return base.GetHTML(deep);
    }
}