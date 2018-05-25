using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GosExamSharp
{
    public partial class Form1 : Form
    {
        BindingList<Animal> animals = new BindingList<Animal>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<Animal>));


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var stream = new FileStream("SerializeResult.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, animals.ToList());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            animals.Add(new Animal(1,"koshka", 123, "bla bla"));
            animals.Add(new Animal(2,"sobaka", 123, "bla bla"));
            animals.Add(new Animal(3, "delfin", 123, "bla bla"));
            animals.Add(new Animal(4,"kek", 123, "bla bla"));
            this.dataGridView1.DataSource = animals;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            animals.Add(new Animal());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                animals.RemoveAt(Convert.ToInt32(this.textBox1.Text));
            }catch(Exception ex)
            {
                MessageBox.Show("coudnt remove");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using(StreamReader streamReader = new StreamReader("SerializeResult.xml"))
            {
                animals = new BindingList<Animal>((List<Animal>)serializer.Deserialize(streamReader));
                dataGridView1.DataSource = animals;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var selectedAnimals = from animal in animals // определяем каждый объект из teams как t
                                where animal.Name.ToUpper().StartsWith("K") //фильтрация по критерию
                                orderby animal.Name  // упорядочиваем по возрастанию
                                select animal; // выбираем объект
            animals = new BindingList<Animal> (selectedAnimals.ToList());
            this.dataGridView1.DataSource = animals;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var selectedAnimals = from animal in animals // определяем каждый объект из teams как t
                                  where animal.Age >= 5 //фильтрация по критерию
                                  orderby animal.Age descending // упорядочиваем по убыванию
                                  select animal; // выбираем объект
            animals = new BindingList<Animal>(selectedAnimals.ToList());
            this.dataGridView1.DataSource = animals;
        }
    }
}
