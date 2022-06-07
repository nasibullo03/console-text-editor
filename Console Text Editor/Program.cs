using System;
using System.Collections.Generic;
using System.Threading;

namespace Console_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
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
            userTexts.GetTexts();


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
            Console.ReadLine();
        }
    }
}
