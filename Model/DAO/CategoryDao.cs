using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class CategoryDao
    {
        private PromoProduct db = null;

        public CategoryDao()
        {
            db = new PromoProduct();
        }

        public int Insert(Category category)
        {
            db.Category.Add(category);
            db.SaveChanges();
            return category.Id;
        }

        public Category ViewDetail(int id)
        {
            return db.Category.Find(id);
        }

        public bool Update(Category entity)
        {
            try
            {
                var cate = db.Category.Find(entity.Id);
                cate.Name = entity.Name;
                cate.MetaTitle = entity.MetaTitle;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Category> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Category;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
                
            }
            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }

        public IEnumerable<Category> ListAll()
        {
            IQueryable<Category> model = db.Category;
            return model.OrderByDescending(x => x.Id).ToList();
        }
        public Category GetById(string name)
        {

            return db.Category.SingleOrDefault(x => x.Name == name);
        }
        public bool Delete(int id)
        {
            try
            {
                var cate = db.Category.Find(id);
                db.Category.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Category ViewDetail(long id)
        {
            return db.Category.Find(id);
        }
        public List<Category> ListCategoryByType()
        {
            return db.Category.ToList();                     
        }
    }
}
