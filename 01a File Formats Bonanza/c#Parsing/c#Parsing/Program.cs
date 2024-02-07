using BenchmarkDotNet.Exporters.Csv;
using System;
using System.Globalization;
using System.Xml;


class Program
{
    static void Main()
    {
        // Load XML file
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("C:\\Users\\frede\\source\\repos\\System_integration_2024\\01a File Formats Bonanza\\c#Parsing\\c#Parsing\\me.xml");

        // Get elements from XML
        XmlNode personNode = xmlDoc.SelectSingleNode("//person");
        string name = personNode.SelectSingleNode("navn").InnerText;
        int age = int.Parse(personNode.SelectSingleNode("alder").InnerText);
        string hobby = personNode.SelectSingleNode("fritid").InnerText;

        // Display parsed data
        Console.WriteLine($"xml Name: {name}, Age: {age}, Hobby: {hobby}");

        // Read JSON file
        string jsonData = System.IO.File.ReadAllText("C:\\Users\\frede\\source\\repos\\System_integration_2024\\01a File Formats Bonanza\\c#Parsing\\c#Parsing\\me.json");

        // Deserialize JSON data
        var jsonParsed = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonData>(jsonData);

        // Check if deserialization was successful
        if (jsonParsed != null)
        {
            // Access parsed data
            string jsonName = jsonParsed.navn;
            int jsonAge = jsonParsed.alder;
            string[] jsonHobbies = jsonParsed.fritid;

            // Display parsed data
            Console.WriteLine($"JSON Name: {jsonName}, JSON Age: {jsonAge}, JSON Hobbies: {string.Join(", ", jsonHobbies)}");
        }
        else
        {
            Console.WriteLine("Failed to deserialize JSON data.");
        }



        
    }
}

class JsonData
{
    public string navn { get; set; }
    public int alder { get; set; }
    public string[] fritid { get; set; }
}

