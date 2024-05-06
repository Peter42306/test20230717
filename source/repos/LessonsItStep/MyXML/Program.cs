//=========================================================================

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NLog;
using Newtonsoft.Json;

namespace MyXML
{
    [Serializable]
    // класс Album, который представляет информацию об альбоме
    public class Album
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public TimeSpan Duration { get; set; }
        public string RecordingStudio { get; set; }
    }

    // ввод и вывод информации об альбоме


    internal class Program
    {
        public static void createXmlProduct(string path)
        {
            // Создание нового документа XML
            XmlDocument xmlDoc = new XmlDocument();  // Создание нового экземпляра класса XmlDocument
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);  // Создание объявления XML-версии
            xmlDoc.AppendChild(xmlDeclaration);  // Добавление объявления в документ XML

            // Создание корневого элемента
            XmlElement rootElement = xmlDoc.CreateElement("products");  // Создание корневого элемента с тегом "products"
            xmlDoc.AppendChild(rootElement);  // Добавление корневого элемента в документ

            // Создание дочерних элементов
            XmlElement productElement = xmlDoc.CreateElement("product");  // Создание дочернего элемента с тегом "product"
            XmlAttribute idAttribut = xmlDoc.CreateAttribute("id");  // Создание атрибута "id"
            Console.Write("Enter attribute: ");
            idAttribut.Value = Console.ReadLine();  // Считывание значения для атрибута "id" с консоли
            productElement.SetAttributeNode("id", idAttribut.Value);  // Установка атрибута "id" для элемента "product"
            XmlElement titleElement = xmlDoc.CreateElement("title");  // Создание дочернего элемента с тегом "title"
            Console.Write("Enter title: ");
            titleElement.InnerText = Console.ReadLine();  // Считывание значения для элемента "title" с консоли
            productElement.AppendChild(titleElement);  // Добавление дочернего элемента "title" в элемент "product"
            rootElement.AppendChild(productElement);  // Добавление дочернего элемента "product" в корневой элемент

            XmlElement priceElement = xmlDoc.CreateElement("price");  // Создание дочернего элемента с тегом "price"
            Console.Write("Enter price: ");
            priceElement.InnerText = Console.ReadLine();  // Считывание значения для элемента "price" с консоли
            productElement.AppendChild(priceElement);  // Добавление дочернего элемента "price" в элемент "product"

            xmlDoc.Save(path);  // Сохранение документа в файл с именем "products.xml"
            Console.WriteLine("XML document was created");  // Вывод сообщения о создании XML-документа
        }
        public static void readXmlProduct(string path)
        {
            // Код загружает XML - документ из файла "products.xml" и проходит через его структуру, выводя значения
            // элементов "title" и "price".Если файл "products.xml" существует, он используется для чтения данных.
            // Если файла нет или произошла ошибка при чтении, код внутри блока if (File.Exists(path)) не выполняется

            // string path = "products.xml";// Путь к файлу "products.xml"

            if (File.Exists(path))// Проверка существования файла
            {
                XmlDocument doc = new XmlDocument();// Создание нового экземпляра класса XmlDocument
                doc.Load(path);// Загрузка XML-документа из файла
                XmlElement root = doc.DocumentElement;// Получение корневого элемента документа
                foreach (XmlNode node in root)// Перебор дочерних элементов корневого элемента
                {
                    foreach (XmlNode elem in node.ChildNodes)// Перебор дочерних узлов каждого элемента
                    {
                        if (elem.Name == "title") // Проверка имени элемента
                        {
                            Console.WriteLine($"Title: {elem.InnerText}");// Вывод значения элемента "title"
                        }
                        if (elem.Name == "price")// Проверка имени элемента
                        {
                            Console.WriteLine($"Price: {elem.InnerText}");// Вывод значения элемента "price"
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Error("Data is not valid");
            logger.Info("Success");
        }
    }
}

//Title: pineapple
//Price: 29
//Press any key to continue . . .