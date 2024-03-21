// See https://aka.ms/new-console-template for more information
using System;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using CsvHelper;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using Newtonsoft.Json.Linq;
using CsvHelper.Configuration;

class Program
{
    static void Main()
    {
        // Reading and parsing XML file
        Console.WriteLine("XML File Content:");
        using (var xmlReader = XmlReader.Create("me.xml"))
        {
            XDocument xmlDocument = XDocument.Load(xmlReader);
            foreach (var element in xmlDocument.Root.Elements())
            {
                Console.WriteLine($"{element.Name}: {element.Value}");
            }
        }


        Console.WriteLine("\ncsv file content:");
        using (var reader = new StreamReader("me.csv"))
        using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture) { Delimiter = "," }))
        {
            // Manually read the header
            if (csv.Read())
            {
                // Læs header record
                csv.ReadHeader();

                // Læs records en efter en
                while (csv.Read())
                {
                    // Brug csv.GetField<T>() til at hente værdier fra hver kolonne
                    string navn = csv.GetField<string>("name");
                    int alder = csv.GetField<int>("age");
                    string fritid = csv.GetField<string>("fritid");

                    // Skriv data til konsolen
                    Console.WriteLine($"Navn: {navn}, Alder: {alder}, Fritid: {fritid}");
                }
            }
        }
    


        // Angiv stien til de forkslige filer
        string jsonFilePath = "me.json";
        string yamlFilePath = "me.yml";

        // Læs JSON-filen og parse data
        string jsonContent = File.ReadAllText(jsonFilePath);
        JObject jsonData = JObject.Parse(jsonContent);

        // Skriv data til konsolen
        Console.WriteLine("\nJSON File Content:");
        foreach (var property in jsonData.Properties())
        {
            Console.WriteLine($"{property.Name}: {property.Value}");
        }

        // Læs YAML-filen og parse data
        string yamlContent = File.ReadAllText(yamlFilePath);
        var deserializer = new DeserializerBuilder().Build();
        var yamlData = deserializer.Deserialize<dynamic>(yamlContent);

        // Skriv data til konsolen
        Console.WriteLine("\nYAML File Content:");
        foreach (var property in yamlData)
        {
            Console.WriteLine($"{property.Key}: {property.Value}");
        }
    }
}


