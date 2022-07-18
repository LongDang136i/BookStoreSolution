using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Utilities.Slides
{
    public class SlideVm
    {
        public int SlideId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { set; get; }

        public string Image { get; set; }

        public int SortOrder { get; set; }
    }
}