using System;
using System.Collections.Generic;
using U_Jewelries_ClassLibrary.EF;
using U_Jewelries_ClassLibrary.Servecses;

namespace U_Jewelries_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

             Console.WriteLine(UjewelriesService.ChackPasswordCustomer(Int32.Parse("12345"), "qwert123456"));
             Console.WriteLine(UjewelriesService.ChackPasswordCustomer(12333345, "qwert123456"));
             Console.WriteLine(UjewelriesService.ChackPasswordCustomer(Int32.Parse("12345"), "qwert456"));

             Console.WriteLine(UjewelriesService.UpdateCustomerToManager(447));

        }
    }
}
