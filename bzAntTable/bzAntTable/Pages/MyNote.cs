﻿using System;
using System.ComponentModel.DataAnnotations;

namespace bzAntTable.Pages
{
    public class MyNote : ICloneable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "事項標題不可為空白")]
        public string Title { get; set; }
        // 使用淺層複製的方式，產生出相同屬性值的物件
        public MyNote Clone()
        {
            return ((ICloneable)this).Clone() as MyNote;
        }
        // 這裡為使用明確方式來實作 ICloneable 介面
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
