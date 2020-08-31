using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using U_Jewelries_ClassLibrary.EF;
using U_Jewelries_ClassLibrary.DTO;

namespace U_Jewelries_ClassLibrary.Servecses
{
    public class UjewelriesService
    {

        public static List<Costumer> AllCostumers()
        {
            UjewelriesDBContext db = new UjewelriesDBContext();

            return db.Costumers.ToList();
        }

        public static List<ProductDTO> AllProductsDTO()
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            List<ProductDTO> tempProductList = new List<ProductDTO>();
            foreach(Product temp in db.Products.Where(a=>a.is_active == true).ToList())
            {
                tempProductList.Add(new ProductDTO
                {
                    price = temp.price.ToString(),
                    id = temp.id.ToString(),
                    inv = temp.inv.ToString(),
                    is_active = temp.is_active.ToString(),
                    name = temp.name,
                    supplier_id = temp.supplier_id.ToString(),
                    category = temp.category,
                    cost = temp.cost.ToString()
                });

            }
            return tempProductList;
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

        public static LoginDto ChackPasswordCustomer(int id, string password)
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            LoginDto dto = new LoginDto();
            try
            {
                Costumer Selected = db.Costumers.Where(a => a.id == id).ToList().First();
                dto.password = Selected.name;
                if (Selected.password == password)
                {
                    if (Selected.is_manager == true)
                    {
                        dto.id = "Admin";
                        return dto;
                    }
                    else
                    { 
                        dto.id = "Client";
                        return dto;
                    }
                    
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Password or Username wrong!!");
            }
            dto.id = "false";
            dto.id = "";
            return dto;
        }

        public static bool CreateProduct(string id, string name, double price, double cost, int inv, int supplier_id, string category, bool is_active)
        {
            UjewelriesDBContext db = new UjewelriesDBContext();

            Product NewProduct = new Product();

            NewProduct.name = name;
            NewProduct.price = price;
            NewProduct.id = id;
            NewProduct.cost = cost;
            NewProduct.inv = inv;
            NewProduct.category = category;
            NewProduct.is_active = is_active;
            NewProduct.supplier_id = supplier_id;
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

        public static ProductDTO GetProductByID(ProductDTO product)
        {
            try
            {
                UjewelriesDBContext db = new UjewelriesDBContext();
                Product temp = db.Products.Where(a => a.id == product.id).ToList()[0];
                return new ProductDTO
                {
                    price = temp.price.ToString(),
                    id = temp.id.ToString(),
                    inv = temp.inv.ToString(),
                    is_active = temp.is_active.ToString(),
                    name = temp.name,
                    supplier_id = temp.supplier_id.ToString(),
                    category = temp.category,
                    cost = temp.cost.ToString()
                };
            }
            catch
            {
                return product;
            }
        }
        public static bool UpdateProduct(ProductDTO data)
        {
            try
            {
                UjewelriesDBContext db = new UjewelriesDBContext();
                if (data.name != "")
                {
                    db.Products.Where(a => a.id == data.id).ToList()[0].name = data.name;
                }
                if (data.price != "")
                {
                    db.Products.Where(a => a.id == data.id).ToList()[0].price = double.Parse(data.price);
                }
                if (data.cost != "")
                {
                    db.Products.Where(a => a.id == data.id).ToList()[0].cost = double.Parse(data.cost);
                }
                if (data.inv != "")
                {
                    db.Products.Where(a => a.id == data.id).ToList()[0].inv = Int32.Parse(data.inv);
                }
                if (data.supplier_id != "")
                {
                    db.Products.Where(a => a.id == data.id).ToList()[0].supplier_id = Int32.Parse(data.supplier_id);
                }
                if (data.category != "")
                {
                    db.Products.Where(a => a.id == data.id).ToList()[0].category = data.category;
                }
                if (data.is_active != "")
                {
                    db.Products.Where(a => a.id == data.id).ToList()[0].is_active = bool.Parse(data.is_active);
                }
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("ERROR update failed");
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
        public static bool UCTM(LoginDto data)// set admin account
        {
            try { 
                    UjewelriesDBContext db = new UjewelriesDBContext();
                    int id = Int32.Parse(data.id);
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

        public static bool UpdateCustomer(AdminRegisterationDTO data)
        {
            int tempId = Int32.Parse(data.id);
             try
            {
                UjewelriesDBContext db = new UjewelriesDBContext();
                if (data.name != null & data.name != "")
                {
                    db.Costumers.Where(a => a.id == tempId).ToList()[0].name = data.name;
                }
                if (data.password != null & data.password!="")
                {
                    db.Costumers.Where(a => a.id == tempId).ToList()[0].password = data.password;
                }
                if (data.Admin != null & data.Admin!="")
                {
                    db.Costumers.Where(a => a.id == tempId).ToList()[0].is_manager = bool.Parse(data.Admin);
                }
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("ERROR update failed");
                return false;
            }
            return true;

        }

        public static List<SupplierDTO> GetSuppliersList()
        {
            List<Supplier> temp = AllSuppliers();
            List<SupplierDTO> Req = new List<SupplierDTO>();
            SupplierDTO tempsuppd = new SupplierDTO();
            int j = 0;
            foreach (Supplier i in temp)
            {
                Req.Add(new SupplierDTO
                {
                    name = i.name,
                    phone = i.phone,
                    supplier_id = i.supplier_id
                });
            }
            return Req;
        }

        public static List<PurchaseDTO> GetHistoryById(string id)
        {
            UjewelriesDBContext db = new UjewelriesDBContext();
            int CId = Int32.Parse(id);
            List<Purchase> temp = db.Purchases.Where(a => a.costumer_id == CId).ToList();
            List<PurchaseDTO> SenArr = new List<PurchaseDTO>();
            foreach(Purchase i in temp)
            {
                SenArr.Add(new PurchaseDTO
                {
                    costumer_id = i.costumer_id.ToString(),
                    product_id = i.product_id.ToString(),
                    amount = i.amount.ToString(),
                    purchase_date = i.purchase_date.ToString(),
                    purchase_id = i.purchase_id.ToString(),
                    product_name = db.Products.Where(a => a.id == i.product_id).ToList()[0].name

                });
            }
            return SenArr;
        }
    }
}
