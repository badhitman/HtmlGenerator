﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov
// Описание HTML объектов позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;

namespace HtmlGenerator.html5.forms;

/// <summary>
/// Тег [form] устанавливает форму на веб-странице. Форма предназначена для обмена данными между пользователем и сервером.
/// Область применения форм не ограничена отправкой данных на сервер, с помощью клиентских скриптов можно получить доступ к любому элементу формы, изменять его и применять по своему усмотрению.
/// 
/// Документ может содержать любое количество форм, но одновременно на сервер может быть отправлена только одна форма.По этой причине данные форм должны быть независимы друг от друга.
/// 
/// Для отправки формы на сервер используется кнопка Submit, того же можно добиться, если нажать клавишу Enter в пределах формы.
/// Если кнопка Submit отсутствует в форме, клавиша Enter имитирует ее использование.
/// 
/// Когда форма отправляется на сервер, управление данными передается программе, заданной атрибутом [action] тега [form].
/// Предварительно браузер подготавливает информацию в виде пары «имя= значение», где имя определяется атрибутом name тега [input], а значение введено пользователем или установлено в поле формы по умолчанию.
/// Если для отправки данных используется метод GET, то адресная строка может принимать следующий вид.
/// </summary>
public class form : base_dom_root
{
    /// <summary>
    /// Атрибут сообщает браузеру, каким методом следует передавать данные формы на сервер. 
    /// </summary>
    public MethodsFormEnum? method_form = MethodsFormEnum.POST;

    /// <summary>
    /// Способ кодирования данных формы.
    /// </summary>
    public EncTypesEnum? EncType = null;

    /// <summary>
    /// Адрес программы или документа, который обрабатывает данные формы. 
    /// </summary>
    public string? form_action;

    /// <summary>
    /// Устанавливает кодировку, в которой сервер может принимать и обрабатывать данные (по умолчанию: utf-8)
    /// </summary>
    public string accept_charset = "utf-8";

    /// <summary>
    /// Имя окна или фрейма, куда обработчик будет загружать возвращаемый результат.
    /// В качестве значения используется имя окна или фрейма, заданное атрибутом name. Если установлено несуществующее имя, то будет открыто новое окно.
    /// В качестве зарезервированных имен можно указывать следующие:
    /// _blank - Загружает страницу в новое окно браузера. 
    /// _self - Загружает страницу в текущее окно.
    /// _parent - Загружает страницу во фрейм-родитель, если фреймов нет, то это значение работает как _self.
    /// _top - Отменяет все фреймы и загружает страницу в полном окне браузера, если фреймов нет, то это значение работает как _self.
    /// </summary>
    public TargetsEnum? target = TargetsEnum._self;

    /// <summary>
    /// Отменяет встроенную проверку данных введенных пользователем в форме на корректность.
    /// Такая проверка осуществляется браузером автоматически при отправке формы на сервер и происходит для полей [input type="email"], [input type="url"], а также при наличии атрибута pattern или required.
    /// </summary>
    public bool novalidate = false;

    /// <summary>
    /// Управляет автозаполнением полей форм. Значение может быть перекрыто атрибутом autocomplete у конкретных элементов формы.
    /// </summary>
    public bool? autocomplete = null;

    /// <inheritdoc/>
    public override string GetHTML(int deep = 0)
    {
        if (method_form is not null)
            SetAttribute("method", method_form?.ToString("g"));

        if (!string.IsNullOrEmpty(form_action))
            SetAttribute("action", form_action);

        if (!string.IsNullOrEmpty(accept_charset))
            SetAttribute("accept-charset", accept_charset);

        if (target is not null)
            SetAttribute("target", target?.ToString("g"));

        if (EncType is not null)
            SetAttribute("enctype", GetEnctypeHtmlForm(EncType));

        if (novalidate)
            SetAttribute("novalidate", null);

        if (autocomplete is not null)
            SetAttribute("autocomplete", autocomplete == true ? "on" : "off");

        return base.GetHTML(deep);
    }
}