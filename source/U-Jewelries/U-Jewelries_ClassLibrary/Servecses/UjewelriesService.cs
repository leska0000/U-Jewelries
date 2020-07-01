using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using U_Jewelries_ClassLibrary.EF;

namespace U_Jewelries_ClassLibrary.Servecses
{
    public class UjewelriesService
    {
       
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

        public static List<Purchase> AllPruchase()
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            return db.Purchases.ToList();
        }

        public static List<Supplier> AllSuppliers()
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            return db.Suppliers.ToList();
        }

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

        public static bool CreateCustomer(int id, string name, string password, bool is_maneger = false)
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            Costumer NewCustomer = new Costumer();
            NewCustomer.name = name;
            NewCustomer.password = password;
            NewCustomer.id = id;
            NewCustomer.is_manager = is_maneger;
            try
            {
                db.Costumers.Add(NewCustomer);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

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

        public static bool ChackPasswordCustomer(int id, string password)
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            try
            {
                Costumer Selected = db.Costumers.Where(a => a.id == id).ToList().First();

                if (Selected.password == password)
                {
                    return true;
                } 
            }
            catch(System.Exception e)
            {
                Console.WriteLine("Password or Username wrong!!");
            }

            return false;
        }

        public static bool CreateProduct(string id, string name, double price, double cost , int inv, int supplier_id, string category, bool is_active)
        {
            UjewelriesDBContext db = new UjewelriesDBContext();

        Product NewProduct = new Product();
            NewProduct.name = name;
            NewProduct.price = price;
            NewProduct.id = id;
            NewProduct.cost = cost;
            NewProduct.inv = inv;
            NewProduct.supplier_id =supplier_id;
            NewProduct.category = category;
            NewProduct.is_active = is_active;
            try
            {
                db.Products.Add(NewProduct);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public static bool DeleteProduct(string id)
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            Product SelectedProduct = (Product)db.Products.Where(a => a.id == id).First();

            try
            {
                db.Products.Remove(SelectedProduct);
                db.SaveChanges();
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Deleting false");
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public static bool UpdateCustomerToManager(int id)
        {
            try
            {
                UjewelriesDBContext db = new UjewelriesDBContext();
                db.Costumers.Where(a => a.id == id).ToList()[0].is_manager = true;
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("ERROR update failed");
                return false;
            }
            return true;
        }


    }

}
