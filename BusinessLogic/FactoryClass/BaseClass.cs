using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLogic.FactoryClass
{
   public class BaseClass
    {
        public Verve_AdminEntities db = null;

        protected BaseClass()
        {
            if (db == null)
                db = new Verve_AdminEntities();
        }
    }
}
