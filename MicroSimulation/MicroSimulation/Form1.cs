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
using System.Threading;

namespace MicroSimulation
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthPorbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        List<CountOfMalesAndFemales> MalesFemalesCount = new List<CountOfMalesAndFemales>();

        Random rnd = new Random(49);

        BackgroundWorker bw = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();

            btn_Browse.Click += Btn_Browse_Click;
            btn_Start.Click += Btn_Start_Click;
            
            bw.DoWork += Bw_DoWork;
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += Bw_ProgressChanged;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Simulation completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btn_Browse.Enabled = btn_Start.Enabled = num_ClosingYear.Enabled = true;
            progressBar1.Value = 0;
            lbl_progress.Text = "0 %";
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lbl_progress.Text = e.ProgressPercentage + " %";
            DisplayResults();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Simulation();
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_PopulationPath.Text)) Population = GetPopulation(txt_PopulationPath.Text);
            else { MessageBox.Show("Population source cannot be empty", "Missing resource", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            BirthPorbabilities = GetBirthPorbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");

            bw.RunWorkerAsync();
            btn_Browse.Enabled = btn_Start.Enabled = num_ClosingYear.Enabled = false;
            MalesFemalesCount.Clear();
            richTextBox1.Text = string.Empty;
        }

        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog() {InitialDirectory = "C:\\Temp", Filter = "Csv files | *.csv" })
            {
                if (fd.ShowDialog() == DialogResult.OK) txt_PopulationPath.Text = fd.FileName;
            };
        }

        private void Simulation()
        {
            int sumValue = (int)num_ClosingYear.Value - 2005;

            for (int year = 2005; year <= (int)num_ClosingYear.Value; year++)
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
                MalesFemalesCount.Add(new CountOfMalesAndFemales { Year = year, MalePopulation = nbrOfMales, FemalePopulation = nbrOfFemales });

                //Console.WriteLine(string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));
                
                bw.ReportProgress((int)Math.Ceiling(((double)year - (double)2005) / (double)sumValue * 100));
                
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

        private void DisplayResults()
        {
            richTextBox1.Text = string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (var item in MalesFemalesCount)
            {
                sb.Append("Simulation year: " + item.Year.ToString() + "\n\tBoys: " + item.MalePopulation + "\n\tGirls: " + item.FemalePopulation + "\n\n");
            }
            richTextBox1.Text = sb.ToString();
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
