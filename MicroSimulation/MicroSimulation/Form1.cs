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

            for (int year = 2005; year <= 2024; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SimulationStep(year, Population[i]);
                }

                int nbrOfMales = (from x in Population 
                                  where x.Gender == Gender.Male && x.IsAlive 
                                  select x).Count();
                int nbrOfFemales = (from x in Population 
                                    where x.Gender == Gender.Female && x.IsAlive 
                                    select x).Count();
                Console.WriteLine(string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));
            }

        }

        private void SimulationStep(int year, Person person)
        {
            if (!person.IsAlive) return;

            byte age = (byte)(year - person.BirthYear);

            double probDeath = (from x in DeathProbabilities
                                where x.Gender == person.Gender && x.Age == age
                                select x.Probability).FirstOrDefault();
            
            if (rnd.NextDouble() <= probDeath) person.IsAlive = false;

            if(person.IsAlive && person.Gender == Gender.Female)
            {
                double probBirth = (from x in BirthPorbabilities
                                    where x.Age == age
                                    select x.Probability).FirstOrDefault();

                if (rnd.NextDouble() <= probBirth)
                {
                    Person newborn = new Person() { BirthYear = year, NbrOfChildren = 0, Gender = (Gender)rnd.Next(1, 3) };
                    Population.Add(newborn);
                }
            }
        }

        #region LoadFiles
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
        #endregion
    }
}
