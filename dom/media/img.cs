﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

namespace HtmlGenerator.dom.media
{
    /// <summary>
    ///  Тег [img] предназначен для отображения на веб-странице изображений в графическом формате GIF, JPEG или PNG. Адрес файла с картинкой задаётся через атрибут [src].
    ///  Если необходимо, то рисунок можно сделать ссылкой на другой файл, поместив тег [img] в контейнер [a].
    ///  При этом вокруг изображения отображается рамка, которую можно убрать, добавив атрибут [border="0"] в тег [img].
    ///  
    ///  Рисунки также могут применяться в качестве карт-изображений, когда картинка содержит активные области, выступающие в качестве ссылок.
    ///  Такая карта по внешнему виду ничем не отличается от обычного изображения, но при этом оно может быть разбито на невидимые зоны разной формы, где каждая из областей служит ссылкой. 
    /// </summary>
    public class img : basic_html_dom
    {
        /// <summary>
        /// Путь к графическому файлу. 
        /// </summary>
        public string src = null;

        /// <summary>
        /// Альтернативный текст для изображения. 
        /// </summary>
        public string alt = null;

        /// <summary>
        /// Для изменения размеров изображения средствами HTML предусмотрены атрибуты [height] и [width].
        /// Допускается использовать значения в пикселах или процентах.
        /// Если установлена процентная запись, то размеры изображения вычисляются относительно родительского элемента — контейнера, где находится тег [img].
        /// В случае отсутствия родительского контейнера, в его качестве выступает окно браузера.
        /// Иными словами, [width="100%"] означает, что рисунок будет растянут на всю ширину веб-страницы.
        /// Добавление только одного атрибута [width] или [height] сохраняет пропорции и отношение сторон изображения.
        /// Браузер при этом ожидает полной загрузки рисунка, чтобы определить его первоначальную высоту и ширину.
        /// 
        /// Обязательно задавайте размеры всех изображений на веб-странице.
        /// Это несколько ускоряет загрузку страницы, поскольку браузеру нет нужды вычислять размер каждого рисунка после его получения.
        /// Это утверждение особенно важно для изображений, размещенных внутри таблицы.
        /// 
        /// Ширину и высоту изображения можно менять как в меньшую, так и большую сторону.
        /// Однако на скорость загрузки рисунка это никак не влияет, поскольку размер файла остается неизменным.
        /// Поэтому с осторожностью уменьшайте изображение, т.к.это может вызвать недоумение у читателей, отчего такой маленький рисунок так долго грузится.
        /// А вот увеличение размеров приводит к обратному эффекту — размер изображения велик, но файл относительно изображения аналогичного размера загружается быстрее.
        /// Но качество рисунка при этом ухудшается.
        /// </summary>
        public int height = 0;

        /// <summary>
        /// Для изменения размеров изображения средствами HTML предусмотрены атрибуты [height] и [width].
        /// Допускается использовать значения в пикселах или процентах.
        /// Если установлена процентная запись, то размеры изображения вычисляются относительно родительского элемента — контейнера, где находится тег [img].
        /// В случае отсутствия родительского контейнера, в его качестве выступает окно браузера.
        /// Иными словами, [width="100%"] означает, что рисунок будет растянут на всю ширину веб-страницы.
        /// Добавление только одного атрибута [width] или [height] сохраняет пропорции и отношение сторон изображения.
        /// Браузер при этом ожидает полной загрузки рисунка, чтобы определить его первоначальную высоту и ширину.
        /// 
        /// Обязательно задавайте размеры всех изображений на веб-странице.
        /// Это несколько ускоряет загрузку страницы, поскольку браузеру нет нужды вычислять размер каждого рисунка после его получения.
        /// Это утверждение особенно важно для изображений, размещенных внутри таблицы.
        /// 
        /// Ширину и высоту изображения можно менять как в меньшую, так и большую сторону.
        /// Однако на скорость загрузки рисунка это никак не влияет, поскольку размер файла остается неизменным.
        /// Поэтому с осторожностью уменьшайте изображение, т.к.это может вызвать недоумение у читателей, отчего такой маленький рисунок так долго грузится.
        /// А вот увеличение размеров приводит к обратному эффекту — размер изображения велик, но файл относительно изображения аналогичного размера загружается быстрее.
        /// Но качество рисунка при этом ухудшается.
        /// </summary>
        public int width = 0;

        /// <summary>
        /// Атрибут [ismap] говорит браузеру что рисунок является серверной картой-изображением.
        /// Карты-изображения позволяют привязывать ссылки к разным областям одного изображения.
        /// Реализуется в двух различных вариантах — серверном и клиентском.
        /// В случае применения серверного варианта браузер посылает запрос на сервер для получения адреса выбранной ссылки и ждет ответа с требуемой информацией.
        /// Такой подход требует дополнительного времени на ожидание результата и отдельные файлы для каждой карты-изображения.
        /// 
        /// Отправка данных на сервер происходит следующим образом.
        /// Необходимо поместить тег [img] в контейнер [a], где в качестве значения атрибута [href] указать адрес CGI-программы.
        /// Программа анализирует полученные координаты нажатия мыши, которые считаются от левого верхнего угла изображения, и возвращает требуемую веб-страницу.
        /// </summary>
        public bool ismap = false;

        /// <summary>
        /// Атрибут [usemap] связывает между собой картинку и карту-изображение, задаваемую с помощью контейнера [map].
        /// В качестве такой связи выступает имя идентификатора, которое указывается в значении атрибута [usemap], и то же имя, заданное у атрибута name тега [map].
        /// При этом в теге [img] идентификатор должен начинаться с символа решетки (#).
        /// </summary>
        public string usemap = null;

        public img()
        {
            inline = true;
            need_end_tag = false;
        }

        public override string GetHTML(int deep = 0)
        {
            if (!string.IsNullOrEmpty(src))
                SetAtribute("src", src);

            if (!string.IsNullOrEmpty(alt))
                SetAtribute("alt", alt);

            if (height > 0)
                SetAtribute("height", height);

            if (width > 0)
                SetAtribute("width", width);

            if (ismap)
                SetAtribute("ismap", null);

            if (!string.IsNullOrEmpty(usemap))
                SetAtribute("usemap", usemap);

            return base.GetHTML(deep);
        }
    }
}
