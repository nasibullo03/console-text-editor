using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Console_Text_Editor
{
    public class DeserializeFile
    {
        public static UserTextsMemento DeserializeXML()
        {
            XmlSerializer xml = new(typeof(UserTextsMemento));
            using (FileStream fs = new("../../UserTexts.xml", FileMode.OpenOrCreate))
            {
                return (UserTextsMemento)xml.Deserialize(fs);
            }
        }
        public static UserTextsMemento DeserializeBinary()
        {
            BinaryFormatter binary = new();
            using (FileStream fs = new("../../UserTexts.dat", FileMode.OpenOrCreate))
            {
                return (UserTextsMemento)binary.Deserialize(fs);
            }
        }
    }
}
