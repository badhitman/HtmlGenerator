////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using HtmlGenerator.dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HtmlGenerator.bootstrap
{
    public enum Alignment { Left, Center, Right }
    public enum Sizing { Small, Medium, Big }

    public class HtmlPaginationClass
    {
        public Alignment AlignmentPagination = Alignment.Right;
        public Sizing SizingPagination = Sizing.Medium;
        string page_num;
        string page_size;
        public HtmlPaginationClass(string _page_num, string _page_size)
        {
            page_num = _page_num;
            page_size = _page_size;
        }

        /// <summary>
        /// Сколько всего элементов для разбивки на страницы
        /// </summary>
        public int CountAllElements = 0;

        /// <summary>
        /// Количество элементов на страницу
        /// </summary>
        public int CountElementsOfPage = 10;

        /// <summary>
        /// Номер текущей страницы
        /// </summary>
        public int PageNum = 1;

        private int CountPages
        {
            get
            {
                if (CountAllElements == 0 && 0 == CountElementsOfPage)
                    return 0;

                return Convert.ToInt16(Math.Ceiling((double)CountAllElements / (double)CountElementsOfPage));
            }
        }

        /// <summary>
        /// Шаблон href
        /// </summary>
        public string url_tmpl = "#";

        public void ReloadDataList<T>(ref List<T> data_list)
        {
            CountAllElements = data_list.Count();
            CountElementsOfPage = ParsePageSize(page_size);

            if (CountAllElements < CountElementsOfPage)
                CountElementsOfPage = CountAllElements;

            if (string.IsNullOrEmpty(page_num) || !Regex.IsMatch(page_num, @"^\d+$") || !int.TryParse(page_num, out PageNum))
                PageNum = 1;

            if (PageNum > CountPages)
                PageNum = CountPages;

            if (PageNum == 1)
                data_list = new List<T>(data_list.Take(CountElementsOfPage));
            else
                data_list = new List<T>(data_list.Skip(Skip).Take(CountElementsOfPage));


        }

        public int Skip { get { return (PageNum - 1) * CountElementsOfPage; } }

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

        private li PaginationItem(int i)
        {
            a.a_set set = new a.a_set();
            set.href = url_tmpl + i.ToString();
            set.text = i.ToString();
            a a_tag = new a(set) { css_class = "page-link" };

            li li_tag = new  li() { css_class = "page-item" };

            if (i < 0)
            {
                a_tag.SetTagName(typeof(span).Name.ToLower());
                a_tag.css_style = "padding-left: 4px; padding-right: 4px;";
                a_tag.inner_html = "⁞";
                a_tag.set.href = string.Empty;
                li_tag.css_class += " disabled";
            }
            else if (i == 0)
            {
                a_tag.inner_html = "<span  class='glyphicon glyphicon-chevron-left'></span>";
                if (PageNum == 1)
                {
                    a_tag.SetTagName(typeof(span).Name.ToLower());
                    a_tag.set.href = string.Empty;
                    li_tag.css_class += " disabled";
                    //li.css_style += " color: #d2d2d2;";
                }
                else
                    a_tag.set.href = url_tmpl + (PageNum - 1).ToString();
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
                a_tag.inner_html = "<span class='glyphicon glyphicon-chevron-right'></span>";
                if (PageNum == CountPages)
                {
                    a_tag.SetTagName(typeof(span).Name.ToLower());
                    a_tag.set.href = string.Empty;
                    li_tag.css_class += " disabled";
                }
                else
                    a_tag.set.href = url_tmpl + (PageNum + 1).ToString();
            }

            li_tag.Childs.Add(a_tag);

            return li_tag;
        }

        public static ul GetListSizes
        {
            get
            {
                ul ret_list = new ul();
                ret_list.Childs.Add(ret_list.GetLi("10", "10", "По 10 элементов на странице"));
                ret_list.Childs.Add(ret_list.GetLi("30", "30", "По 30 элементов на странице"));
                ret_list.Childs.Add(ret_list.GetLi("50", "50", "По 50 элементов на странице"));
                ret_list.Childs.Add(ret_list.GetLi("999999", "Все", "Все элементы на странице"));
                return ret_list;
            }
        }

        public static int ParsePageSize(string item)
        {
            if (item is null)
                item = "";

            if (string.IsNullOrEmpty(item) || !Regex.IsMatch(item, @"^\d+$"))
                return int.Parse(GetListSizes.Childs[0].GetAtribute("value"));

            int ret_val = 0;
            if (!int.TryParse(item, out ret_val))
                return 0;

            if (int.Parse(GetListSizes.Childs[0].GetAtribute("value")) > ret_val)
                return int.Parse(GetListSizes.Childs[0].GetAtribute("value"));

            if (int.Parse(GetListSizes.Childs[GetListSizes.Childs.Count - 1].GetAtribute("value")) < ret_val)
                return int.Parse(GetListSizes.Childs[GetListSizes.Childs.Count - 1].GetAtribute("value"));

            return ret_val;
        }
    }
}