using MyNewsPaper.Models;
using MyNewsPaper.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MyNewsPaper.Controllers
{
    public class NewsInfoApiController : ApiController
    {
        private NewsInfoContext ctx = new NewsInfoContext();
        // Get
        public IQueryable<NewsInfoVM> GetNews()
        {
            IQueryable<NewsInfoVM> news = from n in ctx.NewsInfos
                                          select new NewsInfoVM
                                          {
                                              Id = n.Id,
                                              Title = n.Title,

                                              Description = n.Description

                                          };
            return news;
        }
        // Post 
        [ResponseType(typeof(NewsInfo))]
        public IHttpActionResult Poststudent(NewsInfo student)
        {
            ctx.NewsInfos.Add(student);
            ctx.SaveChanges();
            return Ok(student);
        }

        //Put
        [ResponseType(typeof(NewsInfo))]
        public IHttpActionResult PutNews(int id, NewsInfo nw)
        {
            ctx.Entry(nw).State = EntityState.Modified;
            ctx.SaveChanges();

            return Ok(nw);
        }

        // Delete
        [ResponseType(typeof(NewsInfo))]
        public IHttpActionResult DeleteNews(int id)
        {
            var c = ctx.NewsInfos.Find(id);
            ctx.NewsInfos.Remove(c);
            ctx.SaveChanges();
            return Ok(c);
        }
    }
}
