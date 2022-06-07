using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Console_Text_Editor
{
    public class SerializeFile
    {
        public static void SerializeXML(UserTextsMemento texts)
        {
            XmlSerializer xml = new(typeof(UserTextsMemento));
            using (FileStream fs = new("../../UserTexts.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, texts);
            }
        }
        public static void SerializeBinary(UserTextsMemento texts)
        {
            //не рекомендуется использовать сериализация / десериализация формати binary
            BinaryFormatter binary = new();
            using (FileStream fs = new("../../UserTexts.dat", FileMode.OpenOrCreate))
            {
                
                binary.Serialize(fs, texts);
            }
        }
    }
}
