////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlGenerator.bootstrap
{
    public enum Alignment { Left, Center, Right }
    public enum Sizing { Small, Medium, Big }

    public class HtmlPaginationClass
    {
        public static ul GetListSizes
        {
            get
            {
                ul ret_list = new ul();
                ret_list.Childs.Add(ret_list.GetLi("10", "10", "По 10 элементов на странице"));
                ret_list.Childs.Add(ret_list.GetLi("30", "30", "По 30 элементов на странице"));
                ret_list.Childs.Add(ret_list.GetLi("50", "50", "По 50 элементов на странице"));
                ret_list.Childs.Add(ret_list.GetLi("100", "100", "По 100 элементов на странице"));
                return ret_list;
            }
        }

        li PaginationItem(int i)
        {
            a.a_set set = new a.a_set();
            set.href = UrlTmpl + i.ToString();
            set.text = i.ToString();
            a a_tag = new a(set) { css_class = "page-link" };

            li li_tag = new li(null) { css_class = "page-item" };

            if (i < 0)
            {
                a_tag.SetTagName(typeof(span).Name.ToLower());
                a_tag.css_style = "padding-left: 4px; padding-right: 4px;";
                a_tag.InnerText = "⁞";
                a_tag.set.href = string.Empty;
                li_tag.css_class += " disabled";
            }
            else if (i == 0)
            {
                a_tag.InnerText = "<span  class='glyphicon glyphicon-chevron-left'></span>";
                if (PageNum == 1)
                {
                    a_tag.SetTagName(typeof(span).Name.ToLower());
                    a_tag.set.href = string.Empty;
                    li_tag.css_class += " disabled";
                    //li.css_style += " color: #d2d2d2;";
                }
                else
                    a_tag.set.href = UrlTmpl + (PageNum - 1).ToString();
            }
            else if (i <= CountPages)
            {
                if (i == PageNum)
                {
                    a_tag.SetTagName(typeof(span).Name.ToLower());
                    li_tag.css_class += " active";
                    a_tag.set.href = string.Empty;
                }
            }
            else
            {
                a_tag.InnerText = "<span class='glyphicon glyphicon-chevron-right'></span>";
                if (PageNum == CountPages)
                {
                    a_tag.SetTagName(typeof(span).Name.ToLower());
                    a_tag.set.href = string.Empty;
                    li_tag.css_class += " disabled";
                }
                else
                    a_tag.set.href = UrlTmpl + (PageNum + 1).ToString();
            }

            li_tag.Childs.Add(a_tag);

            return li_tag;
        }

        public Alignment AlignmentPagination = Alignment.Right;
        public Sizing SizingPagination = Sizing.Medium;

        /// <summary>
        /// Номер страницы "постраничного/разбитого" документа
        /// </summary>
        public int PageNum { get; private set; } = 0;
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

        /// <summary>
        /// Шаблон href
        /// </summary>
        private string UrlTmpl = "#";
        
        public void ReloadDataList<T>(ref List<T> data_list, int page_num, int page_size, string url_tmpl)
        {
            UrlTmpl = url_tmpl;
            CountAllElements = data_list.Count();
            PageSize = ParsePageSize(page_size);
            PageNum = ParsePageNum(page_num);

            if (PageNum == 1)
                data_list = new List<T>(data_list.Take(PageSize));
            else
                data_list = new List<T>(data_list.Skip(Skip).Take(PageSize));

        }

        int ParsePageNum(int page_num)
        {
            if (page_num <= 0)
                return 1;

            if (CountPages < page_num) // Convert.ToInt16(Math.Ceiling((double)CountAllElements / (double)PageSize));
                page_num = CountPages;
            
            return page_num;
        }

        int ParsePageSize(int page_size)
        {
            int min_pagesize = int.Parse(GetListSizes.Childs[0].GetAtribute("value"));
            int max_pagesize = int.Parse(GetListSizes.Childs[GetListSizes.Childs.Count - 1].GetAtribute("value"));

            if (min_pagesize > page_size)
                return min_pagesize;

            if (max_pagesize < page_size)
                return max_pagesize;

            if (CountAllElements < page_size)
                page_size = CountAllElements;

            return page_size;
        }

        public int Skip { get { return (PageNum - 1) * PageSize; } }

        public nav GetBarPagination
        {
            get
            {
                nav ret_element = new nav() { prew_block_coment = "pagination" };
                if (CountAllElements == 0)
                    return ret_element;


                ret_element.SetAtribute("aria-label", "Page navigation");

                ul ul_block = new ul { css_class = "pagination" };

                #region Formatting pagination (aligment + sizing)
                if (SizingPagination == Sizing.Big)
                    ul_block.css_class += " pagination-lg";
                else if (SizingPagination == Sizing.Small)
                    ul_block.css_class += " pagination-sm";

                if (AlignmentPagination == Alignment.Center)
                    ul_block.css_class += "  justify-content-center";
                else if (AlignmentPagination == Alignment.Right)
                    ul_block.css_class += "  justify-content-end";
                #endregion

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

                ret_element.Childs.Add(ul_block);
                return ret_element;
            }
        }
    }
}