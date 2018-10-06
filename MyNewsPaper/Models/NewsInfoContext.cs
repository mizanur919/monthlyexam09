using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyNewsPaper.Models
{
    public class NewsInfoContext:DbContext
    {
        public NewsInfoContext() : base("NewsInfoContext")
        {
        }
        public virtual DbSet<NewsInfo> NewsInfos { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
    }
}