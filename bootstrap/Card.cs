////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.html5;
using HtmlGenerator.html5.areas;
using System.Collections.Generic;

namespace HtmlGenerator.bootstrap
{
    /// <summary>
    /// Карточки Bootstrap - предоставляют собой гибкий и расширяемый контейнер контента в различных вариантамах и с разными опциями.
    /// Карточки включает в себя опции для верхних и нижних колонтитулов, широкий спектр контента, контекстные цвета фона и мощные параметры отображения.
    /// Если вы знакомы с Bootstrap 3, карточки заменяют наши старые панели, колодцы и эскизы.
    /// Аналогичная функциональность этих компонентов доступна в качестве классов модификаторов для карточек.
    /// </summary>
    public class Card : safe_base_dom_root
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
        public List<base_dom_root> CardBody = new List<base_dom_root>();

        /// <summary>
        /// Подвал карточки
        /// </summary>
        public List<base_dom_root> CardFooter = new List<base_dom_root>();

        public Card() => tag_custom_name = typeof(div).Name;

        public override string GetHTML(int deep = 0)
        {
            Childs.Clear();
            AddCSS("card");
            if (!string.IsNullOrEmpty(adding_card_css_class))
                AddCSS(adding_card_css_class);

            if (!string.IsNullOrEmpty(CardHeader))
            {
                using (div card_header = new div() { InnerText = CardHeader })
                {
                    card_header.AddCSS("card-header");
                    card_header.AddCSS(adding_header_css_class);
                    Childs.Add(card_header);
                }
            }

            using (div card_body = new div())
            {
                card_body.AddCSS("card-body");
                card_body.AddCSS(adding_body_css_class);

                card_body.AddRange(CardBody);
                Childs.Add(card_body);
            }
            if (CardFooter.Count > 0)
                using (div card_footer = new div())
                {
                    card_footer.AddCSS("card-footer");
                    card_footer.AddCSS(adding_footer_css_class);
                    card_footer.AddRange(CardFooter);
                    Childs.Add(card_footer);
                }

            return base.GetHTML(deep);
        }
    }
}
