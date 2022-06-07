using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Console_Text_Editor
{

    [Serializable]
    public class UserTextsMemento : IMemento
    {
        private List<UserText> TextsList { get; set; }
        
       /* public UserTextsMemento() { }*/
        public UserTextsMemento(List<UserText> TextsList) => this.TextsList = TextsList;
        
        public List<UserText> GetTexts() => TextsList;
    }
     
    [Serializable]
    public class UserText
    {
        [XmlElement("text")]
        public string AddedText { get; set; }
        [XmlElement("date_of_creation")]
        public string DateOfCreation { get; set; }
        [XmlElement("date_of_change")]
        public string DateOfChange { get; set; }
        public UserText() { }
        public UserText(string AddedText) => this.AddedText = AddedText;
    }

    public class UserTexts
    {
        private List<UserText> userTexts { get; set; } = new List<UserText>();
        public UserTexts(List<UserText> userTexts) => this.userTexts = userTexts;
        public void EditTexts() {
            foreach (UserText text in userTexts)
            {
                text.AddedText += " 1001012 ";
                text.DateOfChange = $"{DateTime.Now}";
            }
        }
        public void GetTexts()
        {
            //Console.WriteLine("----------|--DeserializeXMLText---------------");
            foreach (UserText userText in userTexts) 
            {
                Console.WriteLine($"Text : '{userText.AddedText}'\nDate of creation : {userText.DateOfCreation}\nDate of change : {userText.DateOfChange}");
            }
        }
        public UserTextsMemento Save() => new(userTexts);
             
        public void Restore(IMemento memento)
        {
            userTexts = memento.GetTexts();
        }
    }

    public class Memory
    {
        private Stack<IMemento> history;
        UserTexts userTexts;

        public Memory(UserTexts userTexts)
        {
            this.userTexts = userTexts;
            history = new Stack<IMemento>();
        }
        public void Backup() => history.Push(userTexts.Save());
        public void Undo()
        {
            if (history.Count == 0)
            {
                Console.WriteLine("History == 0");
                return;
            }
            history.Pop();
            userTexts.Restore(history.Pop());
        }
        
    }



}
