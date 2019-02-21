////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Collections.Generic;

namespace HtmlGenerator.set
{
    public class OptionItem
    {
        public string value;
        public string Tooltip;
        public string Title;
        public bool Disabled = false;
        public string Tag = "";
        //
        public List<OptionItem> Childs = new List<OptionItem>();
    }
}
