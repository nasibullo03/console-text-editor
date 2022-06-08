using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace Console_Text_Editor
{
    class Program
    {
        static void Main(string[] args) {

            /* ConsoleKeyInfo keyInfo;
             keyInfo = Console.ReadKey();*/
            
            
            while (true)
            {
                Menu.Show.MainMenu();
                Menu.PerformKey(Menu.GetKey());

               
            }
            
            
          /*  ConsoleWindow.QuickEditMode(true);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Edit-> ");
            Console.ForegroundColor = ConsoleColor.Gray;
            *//*string text = $"1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/" +
               $"30/31/32/33/34/35/36/37/38/39/40/41/42/43/44/45/46/47/48/49/50/51/52/53/54/55/56/57/58/59/60/61/62/63/64/65";*//*
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";


            text = TextEditor.Edit(text);
            Console.WriteLine("       "+text);*/
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
       
    }
}
