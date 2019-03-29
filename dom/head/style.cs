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
    public class style : basic_html_dom
    {
        public List<MediaDevicesEnum> media = new List<MediaDevicesEnum>() { MediaDevicesEnum.all };

        public override string GetHTML(int deep = 0)
        {
            SetAtribute("media", media, ", ");

            return base.GetHTML(deep);
        }
    }
}
