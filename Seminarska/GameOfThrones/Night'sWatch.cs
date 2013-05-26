using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_of_Thrones___The_Wall.Properties;
using System.Media;
using System.Drawing;

namespace Game_of_Thrones___The_Wall
{
    [Serializable]
    public class Night_sWatch
    {

        public int x;
        public int y;
        public Image slika = Resources.Crow;
        public SoundPlayer zvuk;
        public bool udar = false;
        



        public Night_sWatch(int x, int y)
        {
            this.x = x;
            this.y = y;
            zvuk = new SoundPlayer("scream.wav");
        
        }





        public void Draw(Graphics g)
        {
            g.DrawImage(slika, x, y);



        }



    }
}
