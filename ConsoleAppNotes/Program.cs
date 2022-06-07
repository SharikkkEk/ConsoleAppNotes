using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static List<string> Notes = new List<string>();
        public static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {

            Console.WriteLine("Напишите номер действия, которое хотите совершить:");
            Console.WriteLine("1 - Вывод всех заметок");
            Console.WriteLine("2 - Добавление новой заметки в список");
            Console.WriteLine("3 - Удаление существующей заметки из списка");
            Console.WriteLine("4 - Удаление заметок");
            Console.WriteLine("5 - Изменение существующей заметки");
            Console.WriteLine("6 - Сохранить все заметки в файл");
            Console.WriteLine("7 - Загрузить заметки из файла");

            int Action = Convert.ToInt32(Console.ReadLine());

            switch (Action)
            {
                case 1:
                    OutputNotes();
                    break;
                case 2:
                    Notes.Add(Console.ReadLine());
                    break;
                case 3:
                    DeleteOneNote();
                    break;
                case 4:
                    ClearNote();
                    break;
                case 5:
                    ChangeNote();
                    break;
                case 6:
                    SaveNote();
                    break;
                case 7:
                    DownloadNote();
                    break;
                default:
                    Console.WriteLine("Вы ввели необрабатываемое значение");
                    break;
            }
            Menu();
        }
        public static void OutputNotes()
        {
            for (int i = 0; i < Notes.Count; i++)
            {
                Console.WriteLine("Заметка " + i + " - " + Notes[i]);
            }
        }
        public static void DeleteOneNote()
        {
            Console.WriteLine("Введите индекс заметки, которую хотите удалить");
            int remove = Convert.ToInt32(Console.ReadLine());
            Notes.RemoveAt(remove);
        }
        public static void ClearNote()
        {
            Notes.Clear();
        }
        public static void ChangeNote()
        {
            Console.WriteLine("Введите индекс заметки, которую хотите изменить");
            int onenote = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Notes[onenote]);
            Console.WriteLine("Введите изменённую заметку");
            string changednote = Console.ReadLine();
            Notes.RemoveAt(onenote);
            Notes.Insert(onenote, changednote);
        }
        public static void SaveNote()
        {
            try
            {
                System.IO.File.WriteAllLines("C:\\test.txt ", Notes);
                Console.WriteLine("Сохранено в C:\\test.txt");
            }
            catch
            {
                Console.WriteLine("Ошибка!");
            }
            
        }
        public static void DownloadNote()
        {
            try
            {
                FileStream stream = new FileStream("C:\\test.txt ", FileMode.Open);
                StreamReader reader = new StreamReader(stream);
                string str = reader.ReadToEnd();
                stream.Close();
                Notes.Add(str);
            }
            catch
            {
                Console.WriteLine("Ошибка!!!");
            }
        }
    }
}