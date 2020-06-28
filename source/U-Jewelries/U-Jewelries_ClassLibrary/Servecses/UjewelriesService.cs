using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U_Jewelries_ClassLibrary.EF;

namespace U_Jewelries_ClassLibrary.Servecses
{
    public class UjewelriesService
    {
        public static string GetName(int newid)
        {
           UjewelriesDBContext db = new UjewelriesDBContext();
            //Costumer b = db.Costumers.First();
                var co = db.Costumers.Where(a => newid == a.id).ToList();
            return co[0].name;
        }

        public static List<Costumer> AllCostumers()
        {
            UjewelriesDBContext db = new UjewelriesDBContext();

            return db.Costumers.ToList();
        }

        public static List<Product> AllProducts()
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            return db.Products.ToList();
        }
    }
}
