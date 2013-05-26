using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Game_of_Thrones___The_Wall
{
    [Serializable]
    public class GMdoc
    {
        public List<WhiteWalker> lista1 { get; set; }
        public List<Night_sWatch> lista2 { get; set; }
        public List<WhiteWalker2> lista3 { get; set; }
        public List<CannonBall> lista4 { get; set; }
        
        public int poeniTopka { get; set; }
      


        public GMdoc()
        {
            lista1 = new List<WhiteWalker>();
            lista2 = new List<Night_sWatch>();
            lista3 = new List<WhiteWalker2>();
            lista4 = new List<CannonBall>();
            poeniTopka = 0;
        }


        public void Draw(Graphics g)
        {



            foreach (WhiteWalker ww in lista1)
            {
                ww.Draw(g);
            }
            foreach (Night_sWatch nw in lista2)
            {
                nw.Draw(g);
            }
            foreach (WhiteWalker2 ww2 in lista3)
            {
                ww2.Draw(g);
            }
            foreach (CannonBall cb in lista4)
            {
                cb.Draw(g);
            }


        }
        public void AddWW(WhiteWalker ww)
        {
            lista1.Add(ww);
        }
        public void AddWW(Night_sWatch nw)
        {
            lista2.Add(nw);
        }
        public void AddWW(WhiteWalker2 ww2)
        {
            lista3.Add(ww2);
        }

        public void proveriUdar()
        {
            poeniTopka = 0;

            for (int i = 0; i < lista2.Count; i++)
            {
                for (int j = 0; j < lista4.Count; j++)

                    if (lista4[j].x >= lista2[i].x && lista4[j].y >= lista2[i].y && lista4[j].x < lista2[i].x + 100 && lista4[j].y < lista2[i].y + 120)
                {
                    lista4[j].udar = true;
                    lista2[i].udar = true;
                    

                }
            }
            for (int i = lista2.Count - 1; i >= 0; i--)
            {
                if (lista2[i].udar == true)
                {
                    lista2[i].zvuk.Play();
                    lista2.RemoveAt(i);
                    poeniTopka = 1;
                    
                }
                


            }








        }

    }
}

