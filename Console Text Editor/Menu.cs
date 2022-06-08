using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Text_Editor
{
    internal class Menu
    {
        public enum Operation { Open, Create, OpenAndEdit, FileIndexing, MainMenu, MenuOpenFile, MenuFileIndexing, Edit, Save, Back }
        
        public static Operation CurrentOperation { get; set; }

        public class Show
        {
            public static void MainMenu()
            {
                PrintColorText("Вводите команду:\n", ConsoleColor.Green);
                PrintColorText($"O - открыть файл\n"
                    + $"С - создать файл\n"
                    + $"E - открыть и редактировать файл\n"
                    + $"I - выпольнить индексатсию файлов по ключевым словам\n"
                    , ConsoleColor.Yellow, ConsoleColor.Red
                    );
                Clear();

            }
            static void Menu_OpenFile()
            {
                Clear();
                PrintColorText("Введите путь к файлу.\n" +
                    "Например: D:/FileName.FileFormat\n" +
                    "Path: ",
                    ConsoleColor.Green);
                DefaultConsoleColor();



            }
            static void Menu_CreateFile()
            {

            }
            static void Menu_OpenAndCreate()
            {

            }
            static void Menu_FileIndexing()
            {

            }


        }
        
        public static ConsoleKeyInfo GetKey()
        {
            return Console.ReadKey();
        }


        #region PerformOperation
        public static void PerformKey(Operation operation, ConsoleKeyInfo keyInfo)
        {
            switch (operation)
            {
                case Operation.Open:
                    break;
                case Operation.Create:
                    break;
                case Operation.OpenAndEdit:
                    break;
                case Operation.FileIndexing:
                    break;
                case Operation.MainMenu:
                    break;
                case Operation.MenuOpenFile:
                    break;
                case Operation.MenuFileIndexing:
                    break;
                case Operation.Edit:
                    break;
                case Operation.Save:
                    break;
                case Operation.Back:
                    break;
                default:
                    break;

            }



        }
        private static void PerformOperation_Open(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.O:
                    break;
                case ConsoleKey.C:
                    break;
                case ConsoleKey.E:
                    break;
                case ConsoleKey.I:
                    break;
            }
        }
        private static void PerformOperation_Create(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.O:
                    break;
                case ConsoleKey.C:
                    break;
                case ConsoleKey.E:
                    break;
                case ConsoleKey.I:
                    break;
            }
        }
        private static void PerformOperation_MainMenu(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.O:
                    break;
                case ConsoleKey.C:
                    break;
                case ConsoleKey.E:
                    break;
                case ConsoleKey.I:
                    break;
            }
        }
        private static void PerformOperation_OpenAndEdit(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.O:
                    break;
                case ConsoleKey.C:
                    break;
                case ConsoleKey.E:
                    break;
                case ConsoleKey.I:
                    break;
            }
        }
        private static void PerformOperation_FileIndexing(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.O:
                    break;
                case ConsoleKey.C:
                    break;
                case ConsoleKey.E:
                    break;
                case ConsoleKey.I:
                    break;
            }
        }
        private static void PerformOperation_Edit(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.O:
                    break;
                case ConsoleKey.C:
                    break;
                case ConsoleKey.E:
                    break;
                case ConsoleKey.I:
                    break;
            }
        }
        private static void PerformOperation_Save(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.O:
                    break;
                case ConsoleKey.C:
                    break;
                case ConsoleKey.E:
                    break;
                case ConsoleKey.I:
                    break;
            }
        }
        private static void PerformOperation_Back(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.O:
                    break;
                case ConsoleKey.C:
                    break;
                case ConsoleKey.E:
                    break;
                case ConsoleKey.I:
                    break;
            }
        }
        #endregion 

        
        #region Output Management
        private static void PrintColorText(
            string text,
            ConsoleColor foregroundColor = ConsoleColor.Gray,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(text);
        }
        private static void DefaultConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void Clear()
        {
            Console.Clear();
            DefaultConsoleColor();
        }
        #endregion

    }
}
