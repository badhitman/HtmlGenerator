////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using HtmlGenerator.html5;
using HtmlGenerator.html5.areas;
using HtmlGenerator.html5.collections;
using HtmlGenerator.html5.textual;
using HtmlGenerator.set;
using HtmlGenerator.set.bootstrap;
using HtmlGenerator.set.entities;

namespace HtmlGenerator.bootstrap;

public class Paginations : safe_base_dom_root
{
    public static List<DataTreeItem> GetListSizes
    {
        get
        {
            return
            [
                new DataTreeItem() { Value = "10", Title = "10", Tooltip = "По 10 элементов на странице"},
                new DataTreeItem() { Value = "30", Title = "30", Tooltip = "По 30 элементов на странице" },
                new DataTreeItem() { Value = "50", Title = "50", Tooltip = "По 50 элементов на странице" },
                new DataTreeItem() { Value = "100", Title = "100", Tooltip = "По 100 элементов на странице" }
            ];
        }
    }

    public AlignmentEnum AlignmentPagination = AlignmentEnum.right;

    public SizingBootstrap? SizePagination = null;

    /// <summary>
    /// Шаблон href
    /// </summary>
    private string UrlTmpl = "#";

    /// <summary>
    /// Номер страницы "постраничного/разбитого" документа
    /// </summary>
    public int PageNum { get; private set; } = 1;

    /// <summary>
    /// Размер строк "постраничного/разбитого" документа
    /// </summary>
    public int PageSize { get; private set; } = 10;

    /// <summary>
    /// Сколько всего элементов для разбивки на страницы
    /// </summary>
    public int CountAllElements { get; private set; } = 0;

    /// <summary>
    /// Количество страниц в постраничном документе
    /// </summary>
    private int CountPages
    {
        get
        {
            if (CountAllElements <= 0 || PageSize <= 0)
                return 0;

            return Convert.ToInt16(Math.Ceiling((double)CountAllElements / (double)PageSize));
        }
    }

    private int CheckPageNum(int page_num)
    {
        if (page_num <= 0)
            return 1;

        if (CountPages < page_num)
            page_num = CountPages;

        return page_num;
    }

    /// <summary>
    /// Вычислить количество строк данных, которые нужно пропустить исходя из номера текущей страницы
    /// </summary>
    public int Skip { get { return (PageNum - 1) * PageSize; } }

    private int CheckPageSize(int page_size)
    {
        int min_pagesize = int.Parse(GetListSizes[0].Value);
        int max_pagesize = int.Parse(GetListSizes[^1].Value);

        if (min_pagesize > page_size)
            return min_pagesize;

        if (max_pagesize < page_size)
            return max_pagesize;

        if (CountAllElements < page_size)
            page_size = CountAllElements;

        return page_size;
    }

    /// <summary>
    /// Перезагрузить состояние "пагинатора" для формирования постраничного вывода данных.
    /// ВНИМАНИЕ! Переданный список будет усечён до "актуального состояния" в зависимости от запрошенного номера страницы и настроек размера страницы
    /// </summary>
    /// <param name="data_list">Многострочные данные для формирования постраничного документа. Переданный список будет "усечён до актуального состояния" в зависимости от запрошенного номера страницы и настроек размера страницы</param>
    /// <param name="page_num">Номер запрашиваемой страницы</param>
    /// <param name="page_size">Размер каждой страницы (в строках коллекции) для постраничного вывода</param>
    /// <param name="url_tmpl">Шаблон ссылки для формирования навигационных ссылок</param>
    public void ReloadDataList<T>(ref List<T> data_list, int page_num, int page_size, string url_tmpl)
    {
        UrlTmpl = url_tmpl;
        CountAllElements = data_list.Count;
        PageSize = CheckPageSize(page_size);
        PageNum = CheckPageNum(page_num);

        if (PageNum == 1)
            data_list = new List<T>(data_list.Take(PageSize));
        else
            data_list = new List<T>(data_list.Skip(Skip).Take(PageSize));
    }

    /// <summary>
    /// Получить навигационную кнопку-ссылку пагинатора.
    /// </summary>
    private li PaginationItem(int i)
    {
        a a_tag = new() { href = UrlTmpl + i.ToString(), InnerText = i.ToString() };
        a_tag.AddCSS("page-link");
        li li_tag = new();
        li_tag.AddCSS("page-item");
        if (i < 0)
        {
            a_tag.tag_custom_name = typeof(span).Name.ToLower();
            a_tag.css_style = "padding-left: 4px; padding-right: 4px;";
            a_tag.InnerText = "⁞";
            a_tag.href = string.Empty;
            li_tag.AddCSS("disabled");
        }
        else if (i == 0)
        {
            a_tag.InnerText = "<span  class='glyphicon glyphicon-chevron-left'></span>";
            if (PageNum == 1)
            {
                a_tag.tag_custom_name = typeof(span).Name.ToLower();
                a_tag.href = string.Empty;
                li_tag.AddCSS("disabled");
            }
            else
                a_tag.href = UrlTmpl + (PageNum - 1).ToString();
        }
        else if (i <= CountPages)
        {
            if (i == PageNum)
            {
                a_tag.tag_custom_name = typeof(span).Name.ToLower();
                li_tag.AddCSS("active");
                a_tag.href = string.Empty;
            }
        }
        else
        {
            a_tag.InnerText = "<span class='glyphicon glyphicon-chevron-right'></span>";
            if (PageNum == CountPages)
            {
                a_tag.tag_custom_name = typeof(span).Name.ToLower();
                a_tag.href = string.Empty;
                li_tag.AddCSS("disabled");
            }
            else
                a_tag.href = UrlTmpl + (PageNum + 1).ToString();
        }

        li_tag.Childs ??= [];
        li_tag.Childs.Add(a_tag);

        return li_tag;
    }

    public override string GetHTML(int deep = 0)
    {
        if (Childs is null)
            Childs = [];
        else
            Childs.Clear();

        tag_custom_name = typeof(nav).Name;
        before_comment_block = "pagination";
        if (CountAllElements == 0)
            goto end;

        SetAttribute("aria-label", "Page navigation");
        ul ul_block = new();
        ul_block.AddCSS("pagination");

        #region Formatting pagination (aligment + sizing)
        if (SizePagination == SizingBootstrap.Lg)
            ul_block.AddCSS("pagination-lg");
        else if (SizePagination == SizingBootstrap.Sm)
            ul_block.AddCSS("pagination-sm");

        if (AlignmentPagination == AlignmentEnum.center)
            ul_block.AddCSS("justify-content-center");
        else if (AlignmentPagination == AlignmentEnum.right)
            ul_block.AddCSS("justify-content-end");
        #endregion

        ul_block.Childs ??= [];
        ul_block.Childs.Add(PaginationItem(0));

        for (int i = 1; CountPages >= i; i++)
        {
            if (CountPages > 7)
            {
                if (PageNum < 5)
                {
                    if (i == CountPages - 1)
                        ul_block.Childs.Add(PaginationItem(-1));
                    else if (i <= 5 || i == CountPages)
                        ul_block.Childs.Add(PaginationItem(i));
                    else
                        continue;
                }
                else if (PageNum > (CountPages - 4))
                {
                    if (i == 2)
                        ul_block.Childs.Add(PaginationItem(-1));
                    else if (i == 1 || i >= (CountPages - 4))
                        ul_block.Childs.Add(PaginationItem(i));
                    else
                        continue;
                }
                else
                {
                    if (i == 2 || i == CountPages - 1)
                        ul_block.Childs.Add(PaginationItem(-1));
                    else if ((i == 1 || i == CountPages) || (i == PageNum - 1 || i == PageNum || i == PageNum + 1))
                        ul_block.Childs.Add(PaginationItem(i));
                    else
                        continue;
                }
            }
            else
                ul_block.Childs.Add(PaginationItem(i));
        }
        ul_block.Childs.Add(PaginationItem(CountPages + 1));
        Childs.Add(ul_block);

    end:
        return base.GetHTML(deep);
    }
}