using BookStore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Entities
{
    public class Slide
    {
        public int SlideId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { set; get; }

        public string Image { get; set; }

        public int SortOrder { get; set; }

        public Status Status { get; set; }
    }
}