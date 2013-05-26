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
    public class WhiteWalker2
    {
         public int x { get; set; }
        public int y { get; set; }
        public Image slika = Resources.WhiteWalker2;
        public SoundPlayer zvuk;
        
        



        public WhiteWalker2(int x,int y)
        {
            this.x = x;
            this.y = y;
            zvuk = new SoundPlayer("ww2.wav");
        
        
        }

     
        



        public void Draw(Graphics g)
        {
            g.DrawImage(slika, x, y);
            
        
        
        }
        
    }
}
