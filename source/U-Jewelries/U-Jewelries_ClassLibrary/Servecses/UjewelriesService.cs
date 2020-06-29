using System;
using System.Collections.Generic;
using System.Linq;
using U_Jewelries_ClassLibrary.EF;

namespace U_Jewelries_ClassLibrary.Servecses
{
    public class UjewelriesService
    {
        public static string GetCostumerName(int id)
        {
           UjewelriesDBContext db = new UjewelriesDBContext();
           return db.Costumers.Where(a => id == a.id).ToList()[0].name;
        }

        public static Costumer GetCustumer(int id)
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            return db.Costumers.Where(a => a.id == id).ToList()[0];
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

        public static bool CreateCustomer(int id, string name, string password, bool is_maneger = false)
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            Costumer NewCustomer = new Costumer();
            NewCustomer.name = name;
            NewCustomer.password = password;
            NewCustomer.id = id;
            NewCustomer.is_manager = is_maneger;

            db.Costumers.Add(NewCustomer);
            db.SaveChanges();

            return true;
        }
        /*
        public static bool DeleteCustomer(int id)
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            Costumer SelectedCustomer = GetCustumer(id);

            
            try
            {
                db.Costumers.Remove(SelectedCustomer);
                db.SaveChanges();
            }
            catch(System.Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
            return true;
        }

        */
        public static bool DeleteCustomer(int id)
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            Costumer SelectedCustomer = (Costumer)db.Costumers.Where(a => a.id == id).First();


            try
            {
                db.Costumers.Remove(SelectedCustomer);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

    }
}
