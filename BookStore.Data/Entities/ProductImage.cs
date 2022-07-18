﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Entities
{
    public class ProductImage
    {
        public int ProductImgId { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DateCreated { get; set; }
        public int SortOrder { get; set; }
        public long FileSize { get; set; }
        public Product Product { get; set; }
    }
}