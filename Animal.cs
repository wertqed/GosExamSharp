using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GosExamSharp
{
    [Serializable]
    [XmlRoot(ElementName = "Animal")]
    public class Animal
    {
        private int id;
        private string name;
        private int age;
        private string type;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Type { get => type; set => type = value; }
        public int Id { get => id; set => id = value; }

        public Animal()
        {

        }

        public Animal(int id, string name, int age, string type)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.type = type;
        }
    }
}
