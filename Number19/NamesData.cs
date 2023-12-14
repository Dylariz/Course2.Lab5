using System.IO;
using Newtonsoft.Json;

namespace Number19;

// Класс для десериализации данных о ФИО из JSON файла
public class NamesData
{
    public string[] MaleNames { get; set; }
    public string[] MaleSurnames { get; set; }
    public string[] MalePatronymics { get; set; }
    public string[] FemaleNames { get; set; }
    public string[] FemaleSurnames { get; set; }
    public string[] FemalePatronymics { get; set; }
    
    public NamesData(string fileName)
    {
        var fileText = File.ReadAllText(fileName);
        JsonConvert.PopulateObject(fileText, this); // Десериализация полей из JSON файла в экземпляр класса
    }
}