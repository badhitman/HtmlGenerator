﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.html5.textual;

/// <summary>
///  Тег [br] устанавливает перевод строки в том месте, где этот тег находится. В отличие от тега абзаца [p], использование тега [br] не добавляет
///  пустой отступ перед строкой. Если текст, в котором используется перевод строки, обтекает плавающий элемент, то с помощью атрибута [clear] тега [br]
///  можно сделать так, чтобы следующая строка начиналась ниже элемента.
/// </summary>
public class br : base_dom_root
{
    public br()
    {
        inline = true;
        need_end_tag = false;
    }
}