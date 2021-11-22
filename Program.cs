using System;

namespace WareHS_console
{
    class Program
    {
        static void Main(string[] args)
        {
            WareHouse warehouse = new WareHouse(false);
            warehouse.AddWare("box", 100, new DateTime(2021, 10, 10), new DateTime(2021, 11, 10), new DateTime(2021, 11, 11));
            warehouse.AddWare("box_2", 200, new DateTime(2021, 10, 10), new DateTime(2021, 11, 10), new DateTime(2021, 11, 11));
            warehouse.Serialize("wareList.json");

            foreach(Ware ware in warehouse.AllWare)
            {
                Console.WriteLine(ware);
            }
            Console.WriteLine("После удаление всех элементов\n");
            warehouse.RemoveById(1);
            warehouse.RemoveById(2);
            Console.WriteLine("Удаление завершено\n");

            warehouse.AllWare= warehouse.Deserialize("wareList.json");
            Console.WriteLine("Загрузили все объекты из файла\n");
            foreach (Ware ware in warehouse.AllWare)
            {
                Console.WriteLine(ware);
            }
        }
    }
}
