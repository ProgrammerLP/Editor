using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    internal class DataHandler
    {


        public static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLP_LightWriter");
        public static void Create()
        {

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
                Console.WriteLine("Erfolg");
            }
            else
            {
                Console.WriteLine("Kein Erfolg");
            }
            Console.WriteLine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLP_LightWriter"));
        }

        public static void LoadList()
        {
            try
            {
                Vars.list_1.Clear();
                string[] files = Directory.GetFiles(path, "*.txt");

                for (int i = 0; i < files.Length; i++)
                {
                    Vars.list_1.Add(new List_Content { title = System.IO.Path.GetFileNameWithoutExtension(files[i].ToString()), date = System.IO.File.GetCreationTime(files[i]) });
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        public static void CreateFile(string title)
        {
            try
            {
                string filepath = Path.Combine(path, title + ".txt");

                if (!System.IO.File.Exists(filepath))
                {
                    System.IO.File.Create(filepath);
                    Console.WriteLine("Title Erfolg");
                }
                else
                {
                    Console.WriteLine("Title Kein Erfolg");
                }
;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void Save(string title, string msg)
        {
            string filepath = Path.Combine(path, title + ".txt");

            StreamWriter sw = new StreamWriter(filepath, false);

            sw.Write(msg);

            sw.Close();
        }

    }
}
