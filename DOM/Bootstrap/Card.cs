////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.Collections.Generic;

namespace HtmlGenerator.DOM.Bootstrap
{
    /// <summary>
    /// Карточки Bootstrap - предоставляют собой гибкий и расширяемый контейнер контента в различных вариантамах и с разными опциями.
    /// Карточки включает в себя опции для верхних и нижних колонтитулов, широкий спектр контента, контекстные цвета фона и мощные параметры отображения.
    /// Если вы знакомы с Bootstrap 3, карточки заменяют наши старые панели, колодцы и эскизы.
    /// Аналогичная функциональность этих компонентов доступна в качестве классов модификаторов для карточек.
    /// </summary>
    public class Card : div
    {
        /// <summary>
        /// Дополнительный CSS класс для карточки
        /// </summary>
        public string adding_card_css_class;

        /// <summary>
        /// Дополнительный CSS класс для заголовка карточки
        /// </summary>
        public string adding_header_css_class;

        /// <summary>
        /// Дополнительный CSS класс для тела карточки
        /// </summary>
        public string adding_body_css_class;

        /// <summary>
        /// Дополнительный CSS класс для подвала карточки
        /// </summary>
        public string adding_footer_css_class;

        /// <summary>
        /// Заголовок карточки
        /// </summary>
        public string CardHeader;

        /// <summary>
        /// Тело карточки
        /// </summary>
        public List<html_dom_root> CardBody = new List<html_dom_root>();

        /// <summary>
        /// Подвал карточки
        /// </summary>
        public List<html_dom_root> CardFooter = new List<html_dom_root>();

        public Card() => set_custom_name_tag = typeof(div).Name;

        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();
            css_class += ("card " + adding_card_css_class).Trim();
            if (!string.IsNullOrEmpty(CardHeader))
                Childs.Add(new div() { css_class = ("card-header "+ adding_header_css_class).Trim(), InnerText = CardHeader });

            Childs.Add(new div() { css_class = ("card-body " + adding_body_css_class).Trim(), Childs = CardBody });

            if(CardFooter.Count>0)
                Childs.Add(new div() { css_class = ("card-footer "+ adding_footer_css_class).Trim(), Childs = CardFooter });

            return base.GetHTML(deep);
        }
    }
}
