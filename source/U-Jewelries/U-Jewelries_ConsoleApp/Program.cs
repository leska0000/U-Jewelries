using System;
using System.Collections.Generic;
using U_Jewelries_ClassLibrary.EF;
using U_Jewelries_ClassLibrary.Servecses;
using U_Jewelries_ClassLibrary.DTO;
using System.Web.Helpers;

namespace U_Jewelries_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // LoginDto temp = new LoginDto();
            // temp.id = "156";
            //Console.WriteLine(UjewelriesService.CreateProduct("123462", "TestoviyHERNYA", 10, 3, 5, 6, "kolco", true));
            //var temp1 = UjewelriesService.UCTM(temp);
            // LoginDto temp = new LoginDto();
            //temp.id = "8";

            //Console.WriteLine(UjewelriesService.AllProductsDTO());
            List<PurchaseDTO> temp = UjewelriesService.GetHistoryById("189");
           
        }
    }
}
