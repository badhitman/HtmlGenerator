////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using HtmlGenerator.set;
using System.Collections.Generic;

namespace HtmlGenerator.dom.head
{
    /// <summary>
    ///  Тег [style] применяется для определения стилей элементов веб-страницы.
    ///  Тег [style] необходимо использовать внутри контейнера [head]. Можно задавать более чем один тег [style].
    /// </summary>
    public class style : html_dom_root
    {
        /// <summary>
        ///  Устанавливает устройство вывода, для которого предназначена таблица стилей.
        ///  Для каждого устройства — от карманного компьютера до принтера можно определить свой собственный стиль, который бы учитывал специфику устройства и подгонял под него вид веб-страницы. 
        /// </summary>
        public List<MediaDevicesEnum> media = new List<MediaDevicesEnum>() { MediaDevicesEnum.all };

        /// <summary>
        ///  Сообщает браузеру, какой синтаксис использовать, чтобы правильно интерпретировать таблицу стилей.
        ///  Как правило, браузеры корректно работают со стилями и при отсутствии этого атрибута, он необходим для некоторых старых браузеров, которые могут не распознать содержимое контейнера [style].
        /// </summary>
        public string type = "text/css";

        public override string GetHTML(int deep = 0)
        {
            SetAtribute("media", media, ", ");

            if (!string.IsNullOrEmpty(type))
                SetAtribute("type", type);

            return base.GetHTML(deep);
        }
    }
}
