////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
////////////////////////////////////////////////

namespace HtmlGenerator.set.entities;

/// <summary>
/// Data tree item
/// </summary>
public class DataTreeItem : DataObjectItem
{
    /// <summary>
    /// Дочерние/Вложенные элементы
    /// </summary>
    public List<DataTreeItem> Childs = [];
}