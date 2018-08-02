using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace PromoProject.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            var news = new NewsDao().ViewDetail(id);
            return View(news);
        }

     
    }
}