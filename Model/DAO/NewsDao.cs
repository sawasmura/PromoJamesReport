using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class NewsDao
    {
        private PromoProduct db = null;

        public NewsDao()
        {
            db = new PromoProduct();

        }

        public int Insert(News news)
        {
            news.Date = DateTime.Now;
            db.News.Add(news);
            db.SaveChanges();
            return news.Id;
        }

        public News ViewDetail(int id)
        {
            return db.News.Find(id);
        }

        public bool Update(News entity)
        {
            try
            {
                var news = db.News.Find(entity.Id);
                news.Content = entity.Content;
                news.Description = entity.Description;
                if (!string.IsNullOrEmpty(entity.Images))
                {
                    news.Images = entity.Images;
                }
                news.Detail = entity.Detail;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<News> ListAllPaging(string searchString,int page, 
            int pageSize)
        {
            IQueryable<News> model = db.News;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Content.Contains(searchString) || 
                x.Content.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }
        public List<News> ListAllNews()
        {
            return db.News.ToList();
        }
        public List<News> ListNewsByType(int type)
        {
            if (type == 0)
            {
                return db.News.ToList();
            }
            else
            {
                return db.News.Where(x => x.CategoryID == type).ToList();
            }
            
        }
        public News GetById(string content)
        {
            return db.News.SingleOrDefault(x => x.Content == content);
        }
    }
}
