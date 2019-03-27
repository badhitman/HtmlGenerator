﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;
using System.Collections.Generic;

namespace HtmlGenerator.dom
{
    /// <summary>
    /// Тег [iframe] создает плавающий фрейм, который находится внутри обычного документа, он позволяет загружать в область заданных размеров любые другие независимые документы.
    /// 
    /// Тег [iframe] является контейнером, содержание которого игнорируется браузерами, не поддерживающими данный тег.
    /// Для таких браузеров можно указать альтернативный текст, который увидят пользователи. Он должен располагаться между элементами [iframe] и [/iframe].
    /// </summary>
    public class iframe : basic_html_dom
    {
        /// <summary>
        /// Для изменения размеров фрейма средствами HTML предусмотрены атрибуты [width] и [height].
        /// Допускается использовать значения в пикселах или процентах. 
        /// Если установлена процентная запись, то размеры фрейма вычисляются относительно родительского элемента — контейнера, где находится тег [iframe].
        /// В случае отсутствия родительского контейнера, в его качестве выступает окно браузера.
        /// Иными словами, [width="100%"] означает, что фрейм будет занимать всю ширину веб-страницы.
        /// 
        /// Если значение высоты или ширины не заданы, то фрейм автоматически принимает размер 300х150 пикселов.
        /// </summary>
        public int height = 0;

        /// <summary>
        /// Для изменения размеров фрейма средствами HTML предусмотрены атрибуты [width] и [height].
        /// Допускается использовать значения в пикселах или процентах.
        /// Если установлена процентная запись, то размеры фрейма вычисляются относительно родительского элемента — контейнера, где находится тег [iframe].
        /// В случае отсутствия родительского контейнера, в его качестве выступает окно браузера.
        /// Иными словами, [width="100%"] означает, что фрейм будет занимать всю ширину веб-страницы.
        /// 
        /// Если значение высоты или ширины не заданы, то фрейм автоматически принимает размер 300х150 пикселов.
        /// </summary>
        public int width = 0;

        /// <summary>
        /// Атрибут [sandbox] позволяет установить ряд ограничений на контент загружаемый во фрейме, к примеру, блокировать формы и скрипты.
        /// Это позволяет повысить безопасность текущего документа, особенно в том случае, когда во фрейм загружается документ из непроверенного источника.
        /// 
        /// Допустимо писать несколько значений в любом порядке через пробел. Если указано пустое значение, то устанавливаются все возможные ограничения.
        /// 
        /// При одновременном использовании значений [allow-scripts] и [allow-same-origin], когда исходный и загружаемый документ одного происхождения, атрибут [sandbox] игнорируется.
        /// </summary>
        public List<SandboxModesEnum> sandbox = new List<SandboxModesEnum>();

        /// <summary>
        /// Устанавливает, что содержимое фрейма должно отображаться так, словно оно является частью документа. При этом соблюдается ряд условий:
        /// 
        /// игнорируется атрибут sandbox, если содержимое фрейма и родительского документа взяты из одного источника;
        /// ссылки во фрейме открываются не внутри фрейма, а в текущем документе;
        /// стили родительского документа применяются и к содержимому фрейма;
        /// фрейм считается блочным элементом, у которого ширина задана как auto;
        /// высота формируется автоматически на основе содержимого.
        /// </summary>
        public bool seamless = false;

        /// <summary>
        /// Указывает адрес файла (URL), который будет загружаться во фрейм. Это может быть HTML-документ, изображение или серверная программа.
        /// Допустимо использовать не только путь к файлу, но также имя функции JavaScript, которое возвращает значение. 
        /// </summary>
        public string src = null;

        /// <summary>
        /// Позволяет установить содержимое фрейма непосредственно в атрибуте.
        /// Значение должно иметь корректный синтаксис HTML, по желанию содержать [!DOCTYPE] и [html], а также любое количество пробелов, переносов строк, комментариев и других элементов.
        /// При одновременном использовании атрибутов [src] и [srcdoc], атрибут [src] игнорируется. 
        /// </summary>
        public string srcdoc = null;

        public override string HTML(int deep = 0)
        {
            if (height > 0)
                SetAtribute("height", height.ToString());

            if (width > 0)
                SetAtribute("width", width.ToString());

            if (sandbox.Count > 0)
            {
                string sandbox_as_string = "";
                foreach (SandboxModesEnum s in sandbox)
                    sandbox_as_string += " " + s.ToString("g").Replace("_", "-");

                SetAtribute("sandbox", sandbox_as_string.Trim());
            }

            if (seamless)
                SetAtribute("seamless", null);

            if (!string.IsNullOrEmpty(src))
                SetAtribute("src", src);

            if (!string.IsNullOrEmpty(srcdoc))
                SetAtribute("srcdoc", srcdoc);

            return base.HTML(deep);
        }
    }
}
