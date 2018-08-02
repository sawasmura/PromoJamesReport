using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class UserDao
    {
        private PromoProduct db = null;

        public UserDao()
        {
            db = new PromoProduct();
        }
        public int Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.Id;
        }

        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.Id);
                user.Name = entity.Name;
                user.Phone = entity.Phone;
                user.Email = entity.Email;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //lay ra cac ban ghi
        public IEnumerable<User> ListAllPaging(string searchString,int page ,int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.UserName).ToPagedList(page,pageSize);
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x=>x.UserName == userName);
        }
        public Int16 Login(string userName, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName );
            if (result  == null)
            {
                return 0;
            }
            else
            {
                if (result.Password == password)
                    return 1;
                else
                {
                    return 2;
                }
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
