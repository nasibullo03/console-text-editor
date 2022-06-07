using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace Console_Text_Editor
{
    class Program
    {
        static void Main(string[] args) {

            ConsoleWindow.QuickEditMode(true);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Edit-> ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string text = $"1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/" +
               $"30/31/32/33/34/35/36/37/38/39/40/41/42/43/44/45/46/47/48/49/50/51/52/53/54/55/56/57/58/59/60/61/62/63/64/65";
            //string text = $"1/2/3/4/5/6/7/8/9/10/11/12/13";
            text = ReadLine(text);
            Console.WriteLine("       "+text);
            /* ConsoleWindow.QuickEditMode(true);
             //новый список  для хранение текстов
             List<UserText> list = new();
             //первый текст
             var text1 = new UserText()
             {
                 AddedText = "First text",
                 DateOfChange = $"{DateTime.Now}",
                 DateOfCreation = $"{DateTime.Now}"
             };
             //второй текст
             var text2 = new UserText()
             {
                 AddedText = "Second text",
                 DateOfChange = $"{DateTime.Now}",
                 DateOfCreation = $"{DateTime.Now}"
             };
             // добавление текста на list
             list.Add(text1);
             list.Add(text2);

             //добавляем текст в исходном состояние
             UserTexts userTexts = new UserTexts(list);

             //выделим памят и передаем ссылку на наш список текст
             Memory memory = new(userTexts);
             //Вывод текст
             userTexts.GetTexts();
             Thread.Sleep(2000);

             //изменение текста
             Console.ForegroundColor = ConsoleColor.Green;
             Console.WriteLine("-----------Изменяем тект в текушем-----------");
             Console.ForegroundColor = ConsoleColor.White;
             Thread.Sleep(2000);
             userTexts.EditTexts();
             //вывод текста после изменение
             userTexts.GetTexts();
             Console.ForegroundColor=ConsoleColor.Green;
             Console.WriteLine("-----------Сохраняем тект в текушем состояное-----------");
             Thread.Sleep(2000);
             Console.ForegroundColor =ConsoleColor.White;
             memory.Backup();

             Console.ForegroundColor = ConsoleColor.Green;
             Console.WriteLine("-----------Изменяем тект в текушем-----------");
             Thread.Sleep(2000);
             Console.ForegroundColor = ConsoleColor.White;
             userTexts.EditTexts();
             memory.Backup();
             //вывод текста после изменение
             userTexts.GetTexts();

             Console.ForegroundColor = ConsoleColor.Green;
             Console.WriteLine("-----------Востановление состояние текста-----------");
             Thread.Sleep(2000);
             Console.ForegroundColor = ConsoleColor.White;
             memory.Undo();
             userTexts.GetTexts();*/


            /* UserTextsMemento texts = new();


             texts.GetTexts().Add(text1);
             texts.GetTexts().Add(text2);

             SerializeFile.SerializeXML(texts);
             SerializeFile.SerializeBinary(texts);

             var DeserializeXMLText = DeserializeFile.DeserializeXML();
             var DeserializeBinaryText = DeserializeFile.DeserializeBinary();

             Console.WriteLine("------------DeserializeXMLText---------------");
             foreach (UserText userText in DeserializeXMLText.GetTexts())
             {
                 Console.WriteLine($"Text : '{userText.AddedText}'\nDate of creation : {userText.DateOfCreation}\nDate of change : {userText.DateOfChange}");
             }
             Console.WriteLine("------------DeserializeBinaryText---------------");
             foreach (UserText userText in DeserializeBinaryText.GetTexts())
             {
                 Console.WriteLine($"Text : '{userText.AddedText}'\nDate of creation : {userText.DateOfCreation}\nDate of change : {userText.DateOfChange}");
             }*/
            /*Console.ReadLine();*/
        }
        private static void GoToDefautPosition(List<char> chars, int defPosX, int startPosition, int defPosY = 0)
        {
            if (defPosY == 0)
            {
                if (startPosition < 0) startPosition = 0;
                if (startPosition < chars.Count)
                {
                    for (int i = startPosition; i < chars.Count; ++i)
                        Console.Write(chars[i]);
                }

            }
            else
            {
                int textBuferSize = Console.BufferWidth * (defPosY+1);
                int lastColumnFilledSpace = (chars.Count + 7) % Console.BufferWidth;
                int lastColumnEmptySpace = Console.BufferWidth - lastColumnFilledSpace;
                int lastColumnEndTextPosiotion = textBuferSize - lastColumnEmptySpace;

                startPosition = lastColumnEndTextPosiotion-(lastColumnFilledSpace - startPosition);
                if (startPosition < chars.Count)
                {
                    for (int i = startPosition; i < chars.Count; ++i)
                        Console.Write(chars[i]);
                }
            }

            
     
            Console.SetCursorPosition(++defPosX, defPosY);
 
        }

        static string ReadLine(string Default)
        {
            int pos = Console.CursorLeft, defPos = Console.CursorLeft;
            bool CursorLeftZero = false;
            Console.Write(Default);
            ConsoleKeyInfo info;
            List<Char> chars = new List<char>();
            if (string.IsNullOrEmpty(Default) == false)
            {
                chars.AddRange(Default.ToCharArray());
            }
            while (true)
            {

                info = Console.ReadKey();

                if ((info.Key == ConsoleKey.Backspace) && (Console.CursorLeft >= 0) && chars.Count != 0 && ((Console.CursorTop == 0 && Console.CursorLeft > 6) || Console.CursorTop>0))
                {
                    if (Console.CursorLeft == 0 && !CursorLeftZero)
                    {
                        chars.RemoveAt(chars.Count - 1);
                        Console.Write(' ');
                        Console.CursorLeft -= 1;
                        CursorLeftZero = true;
                    }
                    else if (Console.CursorLeft == 0)
                    {
                        chars.RemoveAt(chars.Count - 1);
                        Console.CursorTop -= 1;
                        Console.CursorLeft = Console.BufferWidth - 1;
                        Console.Write(' ');
                        Console.CursorLeft = Console.BufferWidth - 1;
                        Console.CursorTop -= 1;
                        CursorLeftZero = false;

                    }
                    else
                    {
                        chars.RemoveAt(chars.Count - 1);
                        Console.Write(' ');
                        Console.CursorLeft -= 1;
                    }

                }
                else if ((info.Key == ConsoleKey.Backspace) && (Console.CursorTop >= 0 && Console.CursorLeft < 7))
                {
                    Console.CursorLeft += 1;
                }
                else if (info.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(Console.BufferWidth-1, (int)((chars.Count + 7) / Console.BufferWidth));
                    Console.Write(Environment.NewLine);
                    break;
                }

                else if (info.Key == ConsoleKey.RightArrow)
                {
                    void GoDown()
                    {
                        Console.CursorLeft = 0;
                        defPos = Console.CursorLeft;
                        GoToDefautPosition(chars, defPos - 1, defPos - 7, defPosY: Console.CursorTop);
                        Console.CursorTop = ((int)((chars.Count + 7) / Console.BufferWidth) > Console.CursorTop) ? Console.CursorTop : Console.CursorTop;
                        defPos = Console.CursorLeft;
                        GoToDefautPosition(chars, defPos - 1, defPos - 7, defPosY: Console.CursorTop);
                        --Console.CursorLeft;
                    }
                    if (Console.CursorLeft < chars.Count+8)
                    {
                        try
                        {
                            Console.CursorLeft -= 1;
                        } catch
                        {
                            Console.CursorLeft = 0;
                            Console.CursorTop = ((int)((chars.Count + 7) / Console.BufferWidth) > Console.CursorTop) ? Console.CursorTop : Console.CursorTop;
                        } finally
                        {
                            defPos = Console.CursorLeft;
                            GoToDefautPosition(chars, defPos-1, defPos - 7, defPosY: Console.CursorTop);
                            if (Console.CursorLeft + 1 >= 80) GoDown();
                            else ++Console.CursorLeft;
                        }

                    }
                    else
                    {
                        defPos = Console.CursorLeft-1;
                        GoToDefautPosition(chars, defPos, defPos - 7, defPosY: Console.CursorTop);
                        --Console.CursorLeft;
                    }
                    
                }
                else if (info.Key == ConsoleKey.LeftArrow )
                {
                    void GoToUP()
                    {
                        Console.CursorLeft = Console.BufferWidth - 1;
                        Console.CursorTop -= (Console.CursorTop > 0) ? 1 : 0;
                        defPos = Console.CursorLeft;
                        GoToDefautPosition(chars, defPos - 1, defPos - 7, defPosY: Console.CursorTop);
                        --Console.CursorLeft;
                    }
                    if (Console.CursorLeft > 8 && Console.CursorTop == 0)
                    {
                        Console.CursorLeft -= (Console.CursorLeft - 2 <= 0) ? 0 : 2;
                        defPos = Console.CursorLeft;
                        GoToDefautPosition(chars, defPos-1, defPos - 7, defPosY: Console.CursorTop);

                    }
                    else if (Console.CursorTop > 0)
                    {
                        if (Console.CursorLeft == 0)
                        {
                            GoToUP();
                        }
                        else
                        {
                            try
                            {
                                Console.CursorLeft -= 1;
                            }
                            catch
                            {

                                Console.CursorLeft = Console.BufferWidth - 1;
                                Console.CursorTop -= (Console.CursorTop > 0) ? 1 : 0;
                            }
                            finally
                            {
                                defPos = Console.CursorLeft;
                                GoToDefautPosition(chars, defPos - 1, defPos - 7, defPosY: Console.CursorTop);

                                if (Console.CursorLeft - 1 < 0) GoToUP();
                                else --Console.CursorLeft;
                            }
                        }

                    }
                    else
                    {
                        Console.CursorLeft -= 1;
                        defPos = Console.CursorLeft;
                        GoToDefautPosition(chars, defPos-1, defPos - 7, defPosY: Console.CursorTop);
                    }

                }
                else if (info.Key == ConsoleKey.UpArrow)
                {
                    int CursorTop = Console.CursorTop;
                    if (CursorTop == 0)
                    {
                        defPos = --Console.CursorLeft;
                        GoToDefautPosition(chars, defPos, defPos - 7, defPosY: Console.CursorTop);
                    }
                    else
                    {
                        --Console.CursorTop;
                        defPos = Console.CursorLeft;
                        GoToDefautPosition(chars, defPos-2, defPos - 7, defPosY: Console.CursorTop);
                    }
                    if (Console.CursorLeft < 7 && Console.CursorTop==0)
                    {
                        Console.CursorLeft = 7;
                    }

                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    int CursorTop = Console.CursorTop;
                    if (CursorTop == 0)
                    {
                        defPos = --Console.CursorLeft;
                        GoToDefautPosition(chars, defPos - 1, defPos - 7, defPosY: Console.CursorTop);
                    }
                    else
                    {

                        Console.SetCursorPosition(--Console.CursorLeft, --Console.CursorTop);
                        defPos = --Console.CursorLeft;
                        GoToDefautPosition(chars, defPos, defPos - 7, defPosY: Console.CursorTop);
                    }

                }
                else if (char.IsLetterOrDigit(info.KeyChar) || 
                    char.IsWhiteSpace(info.KeyChar) || 
                    char.IsSeparator(info.KeyChar) ||
                    char.IsSymbol(info.KeyChar)||
                    char.IsPunctuation(info.KeyChar)||
                    char.IsSurrogate(info.KeyChar))
                {
                    int letterPosition = Console.CursorLeft;
                    GoToDefautPosition(chars, letterPosition-1, letterPosition - 8, defPosY: Console.CursorTop);
                   
                    if (Console.CursorTop == 0) chars.Insert(letterPosition-8, info.KeyChar);
                    else {

                        int textBuferSize = Console.BufferWidth * (Console.CursorTop + 1);
                        int lastColumnFilledSpace = (chars.Count + 7) % Console.BufferWidth;
                        int lastColumnEmptySpace = Console.BufferWidth - lastColumnFilledSpace;
                        int lastColumnEndTextPosiotion = textBuferSize - lastColumnEmptySpace;

                        letterPosition -= 8;
                        letterPosition = lastColumnEndTextPosiotion - (lastColumnFilledSpace - letterPosition);
                        chars.Insert(letterPosition, info.KeyChar);
                    }
                    //chars.Add(info.KeyChar);
                }

               /* Console.WriteLine($"  {chars.Count}  {Console.BufferWidth}   ");*/
                
            }
            
            return new string(chars.ToArray());
        }
    }
}
