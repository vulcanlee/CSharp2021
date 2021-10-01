using HyperFullStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperFullStack.Services
{
    public class BlogPostService
    {
        public static List<BlogPost> GetBlogPosts()
        {
            var result = new List<BlogPost>()
            {
                new BlogPost{ Id = 1, Text = "內容 1", Title="文章 1"},
                new BlogPost{ Id = 2, Text = "內容 2", Title="文章 2"},
                new BlogPost{ Id = 3, Text = "內容 3", Title="文章 3"},
                new BlogPost{ Id = 4, Text = "內容 4", Title="文章 4"},
                new BlogPost{ Id = 5, Text = "內容 5", Title="文章 5"}
            };
            return result;
        }
    }
}
