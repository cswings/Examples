using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieGenerator
{
    public partial class Form1 : Form
    {
        static int num = 14;
        private string[] categoryARange = new[] { "Action", "Adventure", "Comedy", "Crime", "Drama", "Fantasy", "Family", "Horror", "Musical", "Romance", "Sci-Fi", "Thriller", "War", "Western", "*Make Chelsea cry*" };
        private string[] categoryBRangeAction = new[] { "Adventure", "Comedy", "Crime", "Disaster", "Fantasy", "Horror", "Romance", "Sci-Fi", "Spy", "Thriller" };
        private string[] categoryBRangeAdventure = new[] { "Comedy", "Fantasy" };
        private string[] categoryBRangeComedy = new[] {"Crime","Horror","Sci-Fi","Thriller","War","Western"};
        private string[] categoryBRangeCrime = new[] { "Action", "Comedy", "Heist", "Mystery", "Thriller" };
        private string[] categoryBRangeDrama = new[] { "Comedy", "Romance" };
        private string[] categoryBRangeFantasy = new[] { "Action", "Adventure", "Comedy" };
        private string[] categoryBRangeFamily = new[] { "Action", "Adventure", "Animation", "Comedy", "Fantasy" };
        private string[] categoryBRangeHorror = new[] {"Adventure","Drama","Film Noir","Thriller","Zombie"};
        private string[] categoryBRangeMusical = new[] { "Musical" };
        private string[] categoryBRangeRomance = new[] {"Drama","Chick flick","Comedy"};
        private string[] categoryBRangeScFi = new[] { "Action", "Comedy", "Fantasy", "Monster", "Thriller" };
        private string[] categoryBRangeThriller = new[] { "Crime", "Film Noir", "Psychological", "Sci-Fi", "War" };
        private string[] categoryBRangeWar = new[] { "Comedy", "Documentary", "Submarine", "WW2" };
        private string[] categoryBRangeWestern = new[] {"Classic", "Epic" };
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            categoryA.SelectedIndexChanged += categoryA_SelectedIndexChanged;
            categoryA.Items.AddRange(categoryARange);         

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void randomBtn_Click(object sender, EventArgs e)
        {
            randomize();
        }
        public void randomize()
        {
            int catA = rnd.Next(num);
            string main = categoryARange[catA];
            categoryA.Text = main;
            int catBnum = categoryB.Items.Count;
            int catB = rnd.Next(catBnum);
            string sec = categoryB.Items[catB].ToString();
            categoryB.Text = sec;
        }
       

        private void categoryA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string main = categoryA.SelectedItem as string;

            switch (main)
            {
                case "Action":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeAction);
                    break;
                case "Adventure":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeAdventure);
                    break;
                case "Comedy":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeComedy);
                    break;
                case "Crime":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeCrime);
                    break;
                case "Drama":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeDrama);
                    break;
                case "Fantasy":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeFantasy);
                    break;
                case "Family":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeFamily);
                    break;
                case "Horror":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeHorror);
                    break;
                case "Musical":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeMusical);
                    break;
                case "Romance":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeRomance);
                    break;
                case "Sci-Fi":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeScFi);
                    break;
                case "Thriller":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeThriller);
                    break;
                case "War":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeWar);
                    break;
                case "Western":
                    categoryB.Items.Clear();
                    categoryB.Items.AddRange(categoryBRangeWestern);
                    break;
                case "*Make Chelsea cry*":
                    categoryB.Items.Clear();
                    break;
            }
        }

        private void categoryB_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void selectBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
