using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using CloudAsp.Models;
using CloudAsp.Models.News;
using CloudAspData;
using CloudAspData.Entity;

namespace CloudAsp.Controllers
{
    public class NewsController : Controller
    {
        private readonly IDataCloud _data;
        public int PageCountElement { get; set; } = 10;

        public NewsController(IDataCloud data)
        {
            _data = data;
        }
        public ActionResult Index()
        {
            int countElement;
            int pageIndex = 0;

            var news = _data.GetNews(out countElement, pageIndex, PageCountElement);

            return View(new NewsModel{ News = news.ToList(), PageInfo = new PageInfo{PageSize = PageCountElement, PageNumber = pageIndex, TotalItems = countElement}});
        }

        public ActionResult GetNews(int? index)
        {
            int countElement;
            News[] news = index.HasValue ? _data.GetNews(out countElement, index.Value - 1, PageCountElement) : _data.GetNews(out countElement, 1, PageCountElement);

            return View(new NewsModel { News = news.ToList(), PageInfo = new PageInfo { PageSize = PageCountElement, PageNumber = index ?? 0, TotalItems = countElement } });
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Create(CreateNews news)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                if (news.File != null)
                    using (var binaryReader = new BinaryReader(news.File.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(news.File.ContentLength);
                    }
                _data.AddNews(new News
                {
                    Id = Guid.NewGuid(),
                    Caption = news.Name,
                    Text = news.Text,
                    Image = imageData
                });

                return RedirectToAction("Administration");
            }
            return View();
        }

        // GET: News/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Administration");
            var news = _data.GetNewsById(id.Value);
            return View(new EditNews { Text = news.Text, Name = news.Caption, Image = news.Image, Id = news.Id });
        }

        // POST: News/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(EditNews news)
        {
            if (ModelState.IsValid)
            {
                var oldNews = _data.GetNewsById(news.Id);
                byte[] imageData = null;
                if (news.File != null)
                {
                    using (var binaryReader = new BinaryReader(news.File.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(news.File.ContentLength);
                    }
                }
                
                _data.UpdateNews(new News
                {
                    Id = news.Id,
                    Caption = news.Name,
                    Text = news.Text,
                    Image = imageData ?? oldNews.Image
                });

                return RedirectToAction("Administration");
            }
            return View();
        }

        public ActionResult Administration()
        {
            int countElement;
            return View(_data.GetNews(out countElement, 0, int.MaxValue));
        }
        public ActionResult Delete(Guid? id)
        {
            if (id.HasValue)
                _data.RemoveNews(id.Value);
            return RedirectToAction("Administration");
        }
    }
}