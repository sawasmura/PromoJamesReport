﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class MenuDao
    {
        PromoProduct db = null;

        public MenuDao()
        {
            db = new PromoProduct();
        }

        public List<Menu> ListByGroup()
        {
            return db.Menus.ToList();
        }
      
    }
}
