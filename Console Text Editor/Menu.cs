using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Text_Editor
{
    class Menu
    {
        public enum Operation { Open, Create, OpenAndEdit, FileIndexing, MainMenu, MenuOpenFile, MenuFileIndexing, Edit, Save, Back }
        public static Operation CurrentOperation { get; set; }

        private static class Show
        {
            public static void MainMenu()
            {
                PrintColorText("Вводите команду:\n", ConsoleColor.Green);
                PrintColorText($"O", ConsoleColor.Yellow);
                PrintColorText($" - открыть файл\n");
                PrintColorText($"С", ConsoleColor.Yellow);
                PrintColorText($" - создать файл\n");
                PrintColorText($"E", ConsoleColor.Yellow);
                PrintColorText($" - открыть и редактировать файл\n");
                PrintColorText($"I", ConsoleColor.Yellow);
                PrintColorText($" - выпольнить индексатсию файлов по ключевым словам\n");
                PrintColorText("-> ", ConsoleColor.Green);
                DefaultConsoleColor();
            }
            public static void Menu_OpenFile()
            {
                string path;
                List<char> pathChar = new();
                PrintColorText("Введите путь к файлу.\n", ConsoleColor.Green);
                PrintColorText("Например:", ConsoleColor.Yellow);
                PrintColorText(" D:/FileName.FileFormat\n");
                PrintColorText("Path: ", ConsoleColor.Yellow);

                Console.SetCursorPosition(0, Console.WindowHeight-1);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetBufferSize(Console.BufferWidth, Console.WindowHeight);
                
                for (int i = 0; i < Console.BufferWidth-1; ++i)
                {
                    Console.Write(' ');
                }
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write("ENTER - подтвердит | F8 - назад");
                Console.SetCursorPosition(6, 2);
                DefaultConsoleColor();
                Console.Write(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                ConsoleKeyInfo info;
                while (true)
                {
                    info = Console.ReadKey();
                    if (info.Key == ConsoleKey.Enter)
                    {
                        Console.Write(Environment.CommandLine);
                        break;
                    }
                    else if (char.IsLetterOrDigit(info.KeyChar) ||
                char.IsWhiteSpace(info.KeyChar) ||
                char.IsSeparator(info.KeyChar) ||
                char.IsSymbol(info.KeyChar) ||
                char.IsPunctuation(info.KeyChar) ||
                char.IsSurrogate(info.KeyChar))
                    {
                        int letterPosition = Console.CursorLeft;
                        TextEditor.GoToDefautPosition(pathChar, letterPosition - 1, letterPosition - 8, defPosY: Console.CursorTop);

                        if (Console.CursorTop == 0) pathChar.Insert(letterPosition - 8, info.KeyChar);
                        else
                        {

                            int textBuferSize = Console.BufferWidth * (Console.CursorTop + 1);
                            int lastColumnFilledSpace = (pathChar.Count + 7) % Console.BufferWidth;
                            int lastColumnEmptySpace = Console.BufferWidth - lastColumnFilledSpace;
                            int lastColumnEndTextPosiotion = textBuferSize - lastColumnEmptySpace;

                            letterPosition -= 8;
                            letterPosition = lastColumnEndTextPosiotion - (lastColumnFilledSpace - letterPosition);
                            pathChar.Insert(letterPosition, info.KeyChar);
                        }
                    }
                }
                

                
            }
            public static void Menu_CreateFile()
            {

            }
            public static void Menu_OpenAndEdit()
            {

            }
            public static void Menu_FileIndexing()
            {

            }
        }
        public static ConsoleKeyInfo GetKey() => Console.ReadKey();

        public static void ShowCurrentMenu()
        {
            Clear();
            switch (CurrentOperation)
            {
                case Operation.Open:
                    Show.Menu_OpenFile();
                    break;
                case Operation.Create:
                    Show.Menu_CreateFile();
                    break;
                case Operation.OpenAndEdit:
                    Show.Menu_OpenAndEdit();
                    break;
                case Operation.FileIndexing:
                    Show.Menu_FileIndexing();
                    break;
                case Operation.MainMenu:
                    Show.MainMenu();
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


        #region PerformOperation
        public static void PerformKey(Operation operation, ConsoleKeyInfo keyInfo)
        {
            switch (operation)
            {
                case Operation.Open:
                    PerformOperation_Open(keyInfo);
                    break;
                case Operation.Create:
                    PerformOperation_Create(keyInfo);
                    break;
                case Operation.OpenAndEdit:
                    PerformOperation_OpenAndEdit(keyInfo);
                    break;
                case Operation.FileIndexing:
                    PerformOperation_FileIndexing(keyInfo);
                    break;
                case Operation.MainMenu:
                    PerformOperation_MainMenu(keyInfo);
                    break;
                case Operation.MenuOpenFile:
                    PerformOperation_MenuOpenFile(keyInfo);
                    break;
                case Operation.Edit:
                    PerformOperation_Open(keyInfo);
                    break;
                case Operation.Save:
                    PerformOperation_Open(keyInfo);
                    break;
                case Operation.Back:
                    PerformOperation_Open(keyInfo);
                    break;
                default:
                    PrintColorText("Такой операции не существует!!", ConsoleColor.Red);
                    DefaultConsoleColor();
                    break;
            }

        }

        private static void PerformOperation_Open(ConsoleKeyInfo keyInfo)
        {
            CurrentOperation = Operation.Open;
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
            CurrentOperation = Operation.Create;
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
                    CurrentOperation = Operation.Open;
                    ShowCurrentMenu();
                    break;
                case ConsoleKey.C:
                    CurrentOperation = Operation.Create;
                    ShowCurrentMenu();
                    break;
                case ConsoleKey.E:
                    CurrentOperation = Operation.OpenAndEdit;
                    ShowCurrentMenu();
                    break;
                case ConsoleKey.I:
                    CurrentOperation = Operation.MenuFileIndexing;
                    ShowCurrentMenu();
                    break;
            }
        }
        private static void PerformOperation_OpenAndEdit(ConsoleKeyInfo keyInfo)
        {
            CurrentOperation = Operation.OpenAndEdit;
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
            CurrentOperation = Operation.FileIndexing;
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
            CurrentOperation = Operation.Edit;
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
            CurrentOperation = Operation.Save;
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
            CurrentOperation = Operation.Back;
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
        private static void PerformOperation_MenuOpenFile(ConsoleKeyInfo keyInfo)
        {
            CurrentOperation = Operation.MenuOpenFile;
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
