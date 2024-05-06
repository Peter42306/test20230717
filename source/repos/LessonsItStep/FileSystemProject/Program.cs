using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//=========================================================================

namespace FileSystemProject
{
    internal class Program
    {
        //=================================================================
        // Метод для чтения содержимого файла
        static void readFile(string path)
        {
            // Читаем содержимое файла построчно и сохраняем в массив строк
            string[] fileContent = File.ReadAllLines(path);

            // выводит данные из файла построчно
            // Выводим первую строку файла на консоль
            Console.WriteLine(fileContent[0]);

            // Выводим вторую строку файла на консоль
            Console.WriteLine(fileContent[1]);

            // Ожидаем нажатия клавиши пользователем для завершения программы
            Console.ReadKey();
        }

        //=================================================================
        // Метод для записи сообщения в файл
        static void writeFile(string path, string message)
        {
            // Записываем переданное сообщение в указанный файл
            File.WriteAllText(path, message);
        }

        //=================================================================
        // Метод для записи сообщения в файл по указанному пути
        static void writeFileStream(string path)
        {
            // Выводим сообщение с просьбой ввести имя файла
            Console.Write("Enter the message: ");

            // Читаем введенное имя файла из консоли
            string message = Console.ReadLine();

            // Кодируем сообщение в байтовый массив
            byte[] bytes = Encoding.UTF8.GetBytes(message);

            // Создаем файловый поток для указанного пути с режимом добавления (append)
            FileStream fs = new FileStream($"{path}", FileMode.Append);

            // Записываем байтовый массив в файловый поток
            fs.Write(bytes, 0, bytes.Length);

            // Закрываем файловый поток
            fs.Close();
        }

        static void writeFileStreamWriter(string path)
        {
            using (var stream = new StreamWriter(path, true, Encoding.UTF8))
            {
                // Выводим сообщение с просьбой ввести имя файла
                Console.Write("Enter the message: ");

                // Читаем введенное имя файла из консоли
                string message = Console.ReadLine();

                stream.WriteLine(message);
                stream.WriteLine(message);
            }
        }

        //=================================================================
        //=================================================================
        static void Main(string[] args)
        {
            Console.Write("Enter the path: ");

            // Читаем введенный путь к файлу из консоли
            string path =Console.ReadLine();

            SerializeHelper.DoSerialize(path, new Player());

            Console.WriteLine();
        }
    }
}
