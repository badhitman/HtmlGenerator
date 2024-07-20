////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov
// Описание позаимствовано с сайта http://htmlbook.ru
////////////////////////////////////////////////

using HtmlGenerator.set;

namespace HtmlGenerator.html5.textual;

/// <summary>
///  Элемент [a] (от англ. anchor — якорь) является одним из важных в HTML и предназначен для создания ссылок.
///  Для этого необходимо сообщить браузеру, что является ссылкой, а также указать адрес документа, на который следует сделать ссылку.
///  В качестве значения атрибута href используется адрес документа, на который происходит переход. Адрес ссылки может быть абсолютным и относительным.
///  Абсолютные адреса работают везде и всюду независимо от имени сайта или веб-страницы, где прописана ссылка.
///  Относительные ссылки, как следует из их названия, построены относительно текущего документа или корня сайта.
/// </summary>
public class a : base_dom_root
{
    /// <summary>
    /// Задает адрес документа, на который следует перейти. 
    /// </summary>
    public string href = "#";

    /// <summary>
    /// Устанавливает MIME-тип документа, на который указывает ссылка.
    /// Этот атрибут носит рекомендательный характер и может использоваться для стилизации ссылок с заданным типом документа.
    /// Атрибут [type] должен добавляться только при наличии атрибута [href].
    /// </summary>
    public string? mimetype;

    /// <summary>
    /// Имя окна или фрейма, куда браузер будет загружать документ. 
    /// </summary>
    public TargetsEnum? target = null;

    /// <summary>
    /// Отношения между ссылаемым и текущим документами.
    /// </summary>
    public RelationsEnum? rel = null;

    /// <summary>
    /// При наличии атрибута [download] браузер не переходит по ссылке, а предложит скачать документ, указанный в адресе ссылки.
    /// </summary>
    public bool download = false;
    
    public override string GetHTML(int deep = 0)
    {
        if (href is not null)
        {
            SetAttribute("href", href);
            //
            if (!string.IsNullOrEmpty(mimetype))
                SetAttribute("type", mimetype);
        }

        if (target != null)
            SetAttribute("target", target?.ToString("g"));

        if (rel is not null)
            SetAttribute("rel", rel?.ToString("g"));

        if (download)
            SetAttribute("download", null);

        return base.GetHTML(deep);
    }
}