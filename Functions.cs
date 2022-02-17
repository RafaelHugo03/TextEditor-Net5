using System;
using System.IO;

namespace TextEditor
{
    class Functions
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the text editor");
            Console.WriteLine("1 - Open the file");
            Console.WriteLine("2 - Create new file");
            Console.WriteLine("0 - Exit");
            Console.Write("Exit, Open or Create? ");

            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: Console.WriteLine("Closing Program"); Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Create(); break;
                default: Menu(); break;
            }
        }
        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Wich file path? ");
            var path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine();
            Console.ReadKey();
            Menu();
        }
        static void Create()
        {
            Console.Clear();
            Console.WriteLine("type your text below (ESC para sair)");
            Console.WriteLine("--------------");

            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            ToSave(text);
        }
        static void ToSave(string text)
        {
            Console.Clear();
            Console.WriteLine("which path to save the file? ");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine($"file {path} saved successfully");
            Console.ReadKey();
            Menu();
        }
    }
}