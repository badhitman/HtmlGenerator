﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
////////////////////////////////////////////////

namespace HtmlGenerator.set.entities;

public class DataTreeItem : DataObjectItem
{
    /// <summary>
    /// Дочерние/Вложенные элементы
    /// </summary>
    public List<DataTreeItem> Childs = new List<DataTreeItem>();
}