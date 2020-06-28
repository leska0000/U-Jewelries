using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U_Jewelries_ClassLibrary.EF;
using U_Jewelries_ClassLibrary.Servecses;

namespace U_Jewelries_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string name = UjewelriesService.GetName(156);
            Console.WriteLine("args1: {0} ", name);

            List<Costumer> newlist = UjewelriesService.AllCostumers();
            foreach (Costumer temp in newlist)
            {
                Console.WriteLine("name: {0}  ID: {1}", temp.id, temp.name);
            }
        }
    }
}
