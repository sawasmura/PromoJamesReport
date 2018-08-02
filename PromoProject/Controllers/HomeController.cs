using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace PromoProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var newsDao = new NewsDao();
            //ViewBag.News = newsDao.ListAllNews();
            var cateDao = new CategoryDao();
            ViewBag.Categories = cateDao.ListCategoryByType();
            ViewBag.NewsStyle = newsDao.ListNewsByType(1);
            ViewBag.NewsTravel = newsDao.ListNewsByType(2);
            ViewBag.NewsVehicle = newsDao.ListNewsByType(3);
            ViewBag.AllNews = newsDao.ListAllNews();
            var menuDao = new MenuDao();
            ViewBag.Menu = menuDao.ListByGroup();
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroup();

            return PartialView(model);
        }
    }
}