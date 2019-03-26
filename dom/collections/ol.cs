﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.collections
{
    public class ol : basic_html_dom
    {
        /// <summary>
        /// Устанавливает вид маркера.
        /// </summary>
        public enum TypesOL
        {
            /// <summary>
            /// Без указания типа
            /// </summary>
            None,

            /// <summary>
            /// арабские цифры.
            /// </summary>
            Numb,

            /// <summary>
            /// заглавные латинские буквы;
            /// </summary>
            A,

            /// <summary>
            /// строчные латинские буквы;
            /// </summary>
            a,

            /// <summary>
            /// заглавные римские цифры;
            /// </summary>
            I,

            /// <summary>
            /// строчные римские цифры;
            /// </summary>
            i
        }

        /// <summary>
        /// Тип списка
        /// </summary>
        public TypesOL TypeOL;

        public ol(TypesOL in_TypeOL = TypesOL.Numb)
        {
            TypeOL = in_TypeOL;
        }

        public override string HTML(int deep = 0)
        {
            if (TypeOL == TypesOL.Numb)
                SetAtribute("type", "1");
            else if (TypeOL != TypesOL.None)
                SetAtribute("type", TypeOL.ToString("g"));
            else
                RemoveAtribute("type");

            return base.HTML(deep);
        }

        /// <summary>
        ///  Тег "li" определяет отдельный элемент списка. Внешний тег "ul" или "ol" устанавливает тип списка — маркированный или нумерованный. 
        /// </summary>
        public li GetLi()
        {
            li ret_val = new li(null);
            if (TypeOL != TypesOL.None)
                ret_val.SetAtribute("type", TypeOL.ToString("g"));
            else
                ret_val.RemoveAtribute("type");
            return ret_val;
        }
    }
}