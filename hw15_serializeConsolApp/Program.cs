using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using hw15_ClassLib;

namespace hw15_serializeConsolApp
{
    class Program
    {
        static void Main(string[] args)
        {
            task1_Serialize(@"D:\pcs.txt");
            task2_Deserialize(@"D:\pcs.txt");
                                      
        }

        static void task1_Serialize(string path)
        {
            List<PC> pcs = new List<PC>();
            pcs.Add(new PC("hp", "a12345", 300000.0));
            pcs.Add(new PC("aser", "b12345", 220000.0));
            pcs.Add(new PC("asus", "c1245", 280000.0));
            pcs.Add(new PC("dell", "d12345", 255000.0));
            pcs.Add(new PC());
            FileInfo info = new FileInfo(path);
            Console.WriteLine(info.Exists ? "Файл существует и будет перезаписан" : "Создается новый файл");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, pcs);
            }
        }

        static void task2_Deserialize(string path)
        {           
            BinaryFormatter form = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<PC> pcsDes = (List<PC>)form.Deserialize(fs);
                foreach (PC item in pcsDes)
                {
                    Console.WriteLine($"Model: {item.Name}, Serial: {item.SerialNumber}, Price: {item.Price}");
                }
            } 

        }
    }
}
