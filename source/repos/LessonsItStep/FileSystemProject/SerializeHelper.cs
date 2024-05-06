using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemProject
{
    public class SerializeHelper
    {
        public static void DoSerialize(string path, Player obj)
        {            
            using(FileStream fs=new FileStream(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
            }
        }

        public static Object DoDeserialize(string path)
        {
            if(File.Exists(path))
            {
                using(FileStream fs=new FileStream(path,FileMode.Open))
                {
                    BinaryFormatter bf=new BinaryFormatter();
                    Object obj=bf.Deserialize(fs);
                    return obj;
                }
            }
            else
            {
                Console.WriteLine("File is not found");
                return new object();
            }
        }
    }
}
