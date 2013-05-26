using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Game_of_Thrones___The_Wall.Properties;
using System.Media;

namespace Game_of_Thrones___The_Wall
{
    [Serializable]
    public class WhiteWalker
    {
        public int x { get; set; }
        public int y { get; set; }
        public Image slika = Resources.WhiteWalker;
        public SoundPlayer zvuk;
        public bool udar = false;
        



        public WhiteWalker(int x,int y)
        {
            this.x = x;
            this.y = y;
            zvuk = new SoundPlayer("zombie.wav");
        
        
        }

     
        



        public void Draw(Graphics g)
        {
            g.DrawImage(slika, x, y);
            
        
        
        }
        


        


   

    }
}
