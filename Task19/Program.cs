using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Task19
{
    public class ComputerModel
    {
        public int code { get; set; }
        public string mark { get; set; }
        public string cpuname { get; set; }
        public float ghz { get; set; }
        public int ram { get; set; }
        public int disk { get; set; }
        public int vram { get; set; }
        public int cost { get; set; }
        public int copies { get; set; }

        public ComputerModel(int code, string mark, string cpunam, float ghz, int ram, int disk, int vram, int cost, int copies)
        {
            this.code = code;
            this.mark = mark;
            this.cpuname = cpunam;
            this.ghz = ghz;
            this.ram = ram;
            this.disk = disk;
            this.vram = vram;
            this.cost = cost;
            this.copies = copies;

        }

    }

    internal class Program
    {
        static void Main()
        {
            Random r = new Random();

            string[] marks = new string[3];
            marks[0] = "Asus";
            marks[1] = "Apple";
            marks[2] = "Acer";

            string[] cpus = new string[3];
            cpus[0] = "AMD";
            cpus[1] = "INTEL";
            cpus[2] = "Elbrus";

            int numOfPcs = r.Next(6, 11);

            ComputerModel[] models = new ComputerModel[numOfPcs];

            for (int i = 0; i < numOfPcs; i++)
            {
                int markIndex = r.Next(marks.Length);
                int cpuIndex = r.Next(cpus.Length);

                int code = (10 * i) + r.Next(0, 10);
                string mark = marks[markIndex];
                string cpuname = cpus[cpuIndex];
                float ghz = r.Next(700, 1000) / 1000.0f;
                int ram = r.Next(2, 9) * 2;
                int disk = r.Next(1, 6);
                int vram = r.Next(1, 7) * 2;
                int cost = r.Next(1, 100000);
                int copies = r.Next(20, 41);
                ComputerModel newModel = new ComputerModel(code, mark, cpuname, ghz, ram, disk, vram, cost, copies);

                models[i] = newModel;
            }

            List<ComputerModel> listModels = new List<ComputerModel>(models);

            Console.WriteLine("На складе могут быть модели с такими процессорами:");
            foreach (string cpuname in cpus)
            {
                Console.WriteLine(cpuname);
            }
            Console.Write("\nВывести модели с процессором: ");
            string uicpu = Console.ReadLine();

            List<ComputerModel> modelsWith_uicpu = listModels.Where(m => m.cpuname == uicpu).ToList();
            foreach(ComputerModel model in modelsWith_uicpu)
            {
                WriteAboutModel(model);
            }

            Console.Write("\nВывести модели с ОЗУ не ниже: ");
            int uiram = int.Parse(Console.ReadLine());

            List<ComputerModel> modelsWith_uiram = listModels.Where(m => m.ram >= uiram).ToList();
            foreach (ComputerModel model in modelsWith_uiram)
            {
                WriteAboutModel(model);
            }

            Console.Write("\nМодели по увеличению стоимости:\n");
            List<ComputerModel> modelsWith_ascendCost = listModels.OrderBy(m => m.cost).ToList();
            foreach (ComputerModel model in modelsWith_ascendCost)
            {
                WriteAboutModel(model);
            }

            Console.Write("\nМодели сгруппированные по типу процессору:\n");
            List<ComputerModel> modelsWith_groupByCpu = listModels.OrderBy(m => m.cpuname).ToList();
            foreach (ComputerModel model in modelsWith_groupByCpu)
            {
                WriteAboutModel(model);
            }

            Console.Write("\nСамая дорогая модель:\n");
            ComputerModel modelwith_highest= modelsWith_ascendCost.Last();
            WriteAboutModel(modelwith_highest);

            Console.Write("\nЕсть ли хотя бы одна модель в количестве 30 шт.:\n");
            bool model_containerExist = listModels.Any(m => m.copies >= 30);
            Console.WriteLine(model_containerExist ? "Да" : "Нет");

            Console.ReadKey();

        }
      
        public static void WriteAboutModel (ComputerModel model)
        {
            Console.WriteLine($"===============================");
            Console.WriteLine($"Модель с кодом {model.code}:");
            Console.WriteLine($"Марка: {model.mark}");
            Console.WriteLine($"ЦПУ: {model.cpuname}");
            Console.WriteLine($"Частота ЦПУ: {model.ghz:f1} ГГц");
            Console.WriteLine($"ОЗУ: {model.ram} ГБ");
            Console.WriteLine($"Диск: {model.disk} ТБ");
            Console.WriteLine($"Видепамять: {model.vram} ГБ");
            Console.WriteLine($"Стоимость: {model.cost} у.е.");
            Console.WriteLine($"Остаток на складе: {model.copies} шт.");
        }

       
    }
}
