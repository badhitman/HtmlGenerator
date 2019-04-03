////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////
using HtmlGenerator.dom.html.forms;
using System.Linq;

namespace HtmlGenerator.dom.html.collections
{
    /// <summary>
    /// Создает список вариантов, которые можно выбирать при наборе в текстовом поле.
    /// Изначально этот список скрыт и становится доступным при получении полем фокуса или наборе текста.
    /// </summary>
    public class datalist : base_dom_root
    {
        public override string GetHTML(int deep = 0)
        {
            Childs = Childs.Where(x => x is option).ToList();
            return base.GetHTML(deep);
        }
    }
}
