using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class ProductDao
    {
        private PromoProduct db = null;

        public ProductDao()
        {
            db = new PromoProduct();
        }
        
    }
}
