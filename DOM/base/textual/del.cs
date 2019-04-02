////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.DOM.textual
{
    /// <summary>
    ///  Тег [del] используется для выделения текста, который был удален в новой версии документа.
    ///  Подобное форматирование позволяет отследить, какие изменения в тексте документа были сделаны. Браузеры обычно помечают текст в контейнере [del] как перечеркнутый.
    /// </summary>
    public class del : base_dom_root
    {
        /// <summary>
        /// Указывает ссылку на документ, где приведена причина редактирования текста и другие подробности.
        /// </summary>
        public string cite = null;

        /// <summary>
        /// Устанавливает дату и время редактирования текста. 
        /// </summary>
        public string datetime = null;

        public override string GetHTML(int deep = 0)
        {
            if (!string.IsNullOrEmpty(cite))
                SetAtribute("cite",cite);

            if (!string.IsNullOrEmpty(datetime))
                SetAtribute("datetime", datetime);

            return base.GetHTML(deep);
        }
    }
}
