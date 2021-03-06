﻿using Database.NET.Relational.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud_Operations
{
    public class Item
    {
        [Key]
        [AutoGenerated]
        public int ItemId { get; set; }

        [Size(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
