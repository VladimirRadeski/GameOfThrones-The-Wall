using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Game_of_Thrones___The_Wall
{
    public partial class HowToPlay : Form
    {
        SoundPlayer intro;
        public HowToPlay()
        {
            InitializeComponent();
            intro = new SoundPlayer("game of thrones.wav");
        }

        private void HowToPlay_Load(object sender, EventArgs e)
        {  
            intro.PlayLooping();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pocetna pct = new Pocetna();
            pct.ShowDialog();


           
            intro.PlayLooping();


            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pocetna pct = new Pocetna();
            pct.ShowDialog();


            
            intro.PlayLooping();


            this.Close();
        }

        private void HowToPlay_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        



    }
}
