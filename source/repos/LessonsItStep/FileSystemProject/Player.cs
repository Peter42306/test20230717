using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemProject
{
    [Serializable]
    public class Player
    {
        public string Name { get; set; } = "John";
        public string Description { get; set; } = "This is";

        public int Level { get; set; } = 10;
    }
}
