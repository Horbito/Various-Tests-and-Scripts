using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("DialogueIdStorage")]
public class My_xml_DialogueContainer {

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(My_xml_DialogueContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static My_xml_DialogueContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(My_xml_DialogueContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as My_xml_DialogueContainer;
        }
    }

    public static My_xml_DialogueContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(My_xml_DialogueContainer));
        return serializer.Deserialize(new StringReader(text)) as My_xml_DialogueContainer;
    }
    
}

