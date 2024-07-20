////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace HtmlGenerator.set.entities;

/// <summary>
/// Объект сущности с минимальной схемой данных
/// </summary>
public class DataParticleItem
{
    /// <summary>
    /// Заголовок/Наименование элемента
    /// </summary>
    public required string Title;

    /// <summary>
    /// Нагрузка (значимые данные контекста) html.dom объекта
    /// </summary>
    public required string Value;

}