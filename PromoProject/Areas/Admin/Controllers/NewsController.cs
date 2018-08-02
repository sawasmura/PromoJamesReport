using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using PromoProject.Common;
namespace PromoProject.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private List<Model.EF.Category> listCate;
        // GET: Admin/News
        public ActionResult Index(string searchstring,int page = 1 , int pageSize = 10)
        {
            var dao = new NewsDao();
            var model = dao.ListAllPaging(searchstring,page, pageSize);
           
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public Boolean ChecknewCateId(int id)
        {
            var daoCate = new CategoryDao();
            listCate = new List<Category>();
            listCate = daoCate.ListAll().ToList();
            for (int i = 0; i < listCate.Count; i++)
            {
                if (id == listCate[i].Id)
                {
                    return true;
                }
            }
            return false;
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                if (ChecknewCateId(news.CategoryID))
                {
                    var dao = new NewsDao();
                    long id = dao.Insert(news);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "News");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm News Không thành công");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Thêm News Không thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
               
                var result = dao.Update(news);
                if (result)
                {
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật news thành công");
                }
            }
            return View("Index");
        }
    }
}