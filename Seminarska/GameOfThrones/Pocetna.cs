using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Game_of_Thrones___The_Wall.Properties;
using System.Media;

namespace Game_of_Thrones___The_Wall
{
    public partial class Pocetna : Form
    {
        Image pozadina;
        SoundPlayer intro;
        public Pocetna()
        {
            InitializeComponent();
            pozadina = Resources.The_Wall_from_the_south_660;

            this.BackgroundImage = pozadina;
            intro = new SoundPlayer("game of thrones.wav");
        }

        private void Pocetna_Load(object sender, EventArgs e)
        {
            intro.PlayLooping();
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            intro.Stop();
            Form1 frm = new Form1();
            frm.ShowDialog();
           

           
            this.Close();

            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            intro.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            intro.Stop();
            HowToPlay htp = new HowToPlay();
            htp.ShowDialog();



            this.Close();

        }



    }
}
