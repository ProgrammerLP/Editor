using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
     public partial class Vars : ObservableObject
    {


        [ObservableProperty]
        //public List<List_Content> list_1;
        public static ObservableCollection<List_Content> list_1;

        public Vars()
        {
            list_1 = new ObservableCollection<List_Content>();
            //list_1 = new List<List_Content>();
        }

        [RelayCommand]
        void Delete(string title)
        {
            string filepath = Path.Combine(DataHandler.path, title + ".txt");
            Console.WriteLine(title);
            for (int i = 0; i < list_1.Count; i++)
            {
                Console.WriteLine(list_1[i].title);
                if (list_1[i].title.ToLower() == title.ToLower())
                {
                    list_1.RemoveAt(i);
                    System.IO.File.Delete(filepath);
                    Console.WriteLine("Index: " + i);
                    break;
                }

            }
            Console.WriteLine("For Schleife Ende");
        }

    }
}
