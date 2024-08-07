﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.tables;

/// <summary>
///  Тег [colgroup] предназначен для задания ширины и стиля одной или нескольких колонок таблицы.
///  Этот тег позволяет уменьшить код таблицы за счет сокращения повторяющихся атрибутов, и при наличии этого тега браузер начинает показывать содержимое таблицы, не дожидаясь ее полной загрузки.
///  Тег [colgroup] можно использовать в комбинации с тегом [col], который определяет характеристики одной или нескольких колонок.
///  
///  Обычно закрывающий тег не требуется, но если [colgroup] выступает как контейнер для элементов [col], тогда следует добавить тег [/colgroup] в конце группы.
///  
///  Разница между свойствами тегов [colgroup] и [col] не очень велика и состоит в следующем:
///  [colgroup] позволяет объединять колонки в определенные группы, также при добавлении атрибута rules= "groups" к тегу [table] браузер будет рисовать линию только между колонками, созданными с помощью [colgroup].
///  В остальных случаях поведение колонок назначенных через элементы [colgroup] и [col] идентично.
/// </summary>
public class colgroup : col
{

}