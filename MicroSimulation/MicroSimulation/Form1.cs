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
using MicroSimulation.Entities;

namespace MicroSimulation
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthPorbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        Random rnd = new Random(49);
        
        public Form1()
        {
            InitializeComponent();

            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthPorbabilities = GetBirthPorbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");

            //dataGridView1.DataSource = DeathProbabilities;

        }


        public List<Person> GetPopulation(string path)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }
            return population;
        }

        public List<BirthProbability> GetBirthPorbabilities(string path)
        {
            List<BirthProbability> birthProb = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birthProb.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        Probability = double.Parse(line[2])

                    });
                }
            }
            return birthProb;
        }

        public List<DeathProbability> GetDeathProbabilities(string path)
        {
            List<DeathProbability> deathProb = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    deathProb.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = int.Parse(line[1]),
                        Probability = double.Parse(line[2])
                    });
                }
            }
            return deathProb;
        }
    }
}
