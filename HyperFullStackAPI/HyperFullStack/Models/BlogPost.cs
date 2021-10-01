using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HyperFullStack.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "文章主題 必須存在")]
        public string Title { get; set; }
        [Required(ErrorMessage = "文章內容 必須存在")]
        public string Text { get; set; }
    }
}
