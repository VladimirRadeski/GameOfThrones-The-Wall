using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using Game_of_Thrones___The_Wall.Properties;

namespace Game_of_Thrones___The_Wall
{
    public partial class GameOver : Form
    {

        Image pozadina;
        SoundPlayer evilLaugh;
        SoundPlayer intro;
        public GameOver()
        {
            InitializeComponent();
            pozadina = Resources.GameOver;

            this.BackgroundImage = pozadina;
            evilLaugh = new SoundPlayer("EvilLaugh.wav");
            intro = new SoundPlayer("game of thrones.wav");
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Pocetna pct = new Pocetna();
            pct.ShowDialog();
            
            
            evilLaugh.Stop();
            intro.PlayLooping();
            

            this.Close();
        }
 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            evilLaugh.PlayLooping();
        }
    }
}
