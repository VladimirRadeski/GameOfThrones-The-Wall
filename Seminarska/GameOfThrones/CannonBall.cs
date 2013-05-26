using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Game_of_Thrones___The_Wall.Properties;

namespace Game_of_Thrones___The_Wall
{
    public class CannonBall
    {
        public Image slika = Resources.CannonBall;
    
        public int  x { get; set; }
        public int y { get; set; }
        public double Velocity { get; set; }
        public double Angle { get; set; }
        public bool udar = false;
        public bool kraj = false;

        private float velocityX;
        private float velocityY;


        public CannonBall(int x,int y)
        {
            this.x = x;
            this.y = y;
           
            Velocity = 100;
            Random r = new Random();
           
            velocityX = 50;
            velocityY = 0;
        }
        public void Move(int left, int top, int width, int height)
        {
           
                float nextX = x + velocityX;
                float nextY = y + velocityY;
               
            
            x = (int)(x + velocityX);
            y = (int)(y + velocityY);
            
        }
        public void Draw(Graphics g)
        {
            g.DrawImage(slika, x, y);



        }
    }

  
}
