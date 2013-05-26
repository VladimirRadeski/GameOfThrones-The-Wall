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

using System.Diagnostics;




namespace Game_of_Thrones___The_Wall
{
    public partial class Form1 : Form
    {
       
        
        Image pozadina;
        
        public GMdoc gm;
        
        public int lives = 999;
      
        public int score { get; set; }
        public string poeni;


     
        public bool isHit = false;
        public bool isHit2 = false;
        public bool isHit3 = false;
        public bool isHit4 = false;
        WhiteWalker WW;
        Night_sWatch NW;
        WhiteWalker2 WW2;
        CannonBall CB;
     
        public bool lvl1 = true;
        public bool lvl2 = false;
        public bool lvl3 = false;
        public int vreme1 = 60;
        public int vreme2 = 15;
        public bool kraj = false;
       
        
       Timer t = new Timer();
       Timer t1 = new Timer();
       Timer t2 = new Timer();
       Timer t3 = new Timer();
       Timer tLvL = new Timer();
       Timer tt = new Timer();
       Timer tt1 = new Timer();
       Timer tt2 = new Timer();
       Timer tt3 = new Timer();
       Timer ttt = new Timer();
       Timer ttt1 = new Timer();
       Timer ttt2 = new Timer();
       Timer ttt3 = new Timer();
       Timer tWave = new Timer();
     
       Timer tTopka = new Timer();
       Timer topkaCrtaj = new Timer();
    
        SoundPlayer strela;
        Random rnd = new Random();
        Random topkaRnd = new Random();
   
       int brojac = 0;
   
             
        public Form1()
        {this.DoubleBuffered = true;
            InitializeComponent();
            pozadina = Resources.A_Game_of_Thrones_Genesis_03;
            gm = new GMdoc();
           
            this.BackgroundImage = pozadina;
            this.Cursor = new Cursor(Application.StartupPath + "\\Cursor.cur");
            //label1.BackColor = System.Drawing.Color.Transparent;
            //label2.BackColor = System.Drawing.Color.Transparent;
            //label3.BackColor = System.Drawing.Color.Transparent;
            //label4.BackColor = System.Drawing.Color.Transparent;
            //label5.BackColor = System.Drawing.Color.Transparent;
            //label6.BackColor = System.Drawing.Color.Transparent;
            //label7.BackColor = System.Drawing.Color.Transparent;
            //label8.BackColor = System.Drawing.Color.Transparent;
            //label9.BackColor = System.Drawing.Color.Transparent;
            //label10.BackColor = System.Drawing.Color.Transparent;
            //label11.BackColor = System.Drawing.Color.Transparent;
            //label12.BackColor = System.Drawing.Color.Transparent;

            strela = new SoundPlayer("strela.wav");
            
            score = 0;
            
          
            for (int i = 0; i < 10; i++)
            {
                WhiteWalker ww = new WhiteWalker(rnd.Next(50, 900), rnd.Next(50, 500));
                gm.lista1.Add(ww);
     
                   }

         //Тајмери//
            tLvL.Tick += new EventHandler(tLvL_Tick);
            tLvL.Interval = 60000;
            
           
            //tTopka.Tick += new EventHandler(Dvizi);
           
            t.Tick += TimerEventWW;
            t1.Tick += TimerEventNW;
            t2.Tick += TimerEventWW2;
            t3.Tick += new EventHandler(brisiNW);
            topkaCrtaj.Tick += new EventHandler(topkaCrtaj_Tick);
            topkaCrtaj.Interval = 10000;
            topkaCrtaj.Start();
            tt.Tick += TimerEventWW;
            tt1.Tick += TimerEventNW;
            tt2.Tick += TimerEventWW2;
            tt3.Tick += new EventHandler(brisiNW);
            
            
            ttt.Tick += TimerEventWW;
            ttt1.Tick += TimerEventNW;
            ttt2.Tick += TimerEventWW2;
            ttt3.Tick += new EventHandler(brisiNW);
           
            //lvl1
            t.Interval = 5000;//WW
            t1.Interval = 5000;//NW
            t2.Interval = 20000;//WW2
            t3.Interval = 5000;//BrisiNW

            //lvl2
            tt.Interval = 4000;
            tt1.Interval = 4000;
            tt2.Interval = 10000;
            tt3.Interval = 4000;
            //lvl3
            ttt.Interval = 3000;
            ttt1.Interval = 4000;
            ttt2.Interval = 8000;
            ttt3.Interval = 4000;
            label4.Text = (gm.lista1.Count + gm.lista3.Count).ToString();

            tWave.Interval = 15000;
            tWave.Tick += new EventHandler(tWave_Tick);
            t1.Start();
            t.Start();
            t2.Start();
            t3.Start();
            tLvL.Start();
           
            tWave.Start();
            tTopka.Start();
          
           


          
        }
      
      
        //функција создавање на објек од класата CannonBall повикувана на одреден интервал
        void topkaCrtaj_Tick(object sender, EventArgs e)
        {
            if (lvl1 == true)
            {
                topkaCrtaj.Interval = 10000;
                for (int i = 0; i < 1; i++)
                {
                    CannonBall cb = new CannonBall(0, topkaRnd.Next(50, 500));
                    gm.lista4.Add(cb);

                    Invalidate();
                }
            }

            else if (lvl2 == true)
            {
                topkaCrtaj.Interval = 5000;
                for (int i = 0; i < 1; i++)
                {
                    CannonBall cb = new CannonBall(0, topkaRnd.Next(50, 500));
                    gm.lista4.Add(cb);

                    Invalidate();
                }


            }
            else if (lvl3 == true)
            {
                topkaCrtaj.Interval = 4000;
                for (int i = 0; i < 1; i++)
                {
                    CannonBall cb = new CannonBall(0, topkaRnd.Next(50, 500));
                    gm.lista4.Add(cb);
                    
                    Invalidate();
                }




            }
        }



        //void Dvizi(object sender, EventArgs e)
        //{   
        //    for (int i = 0; i < gm.lista4.Count; i++)
        //    {
        //        gm.lista4[i].Move(20, 60, 10, 10);
        //        gm.proveriUdar();
        //        lives = lives - gm.poeniTopka;
        //        if (lives == 0)
        //        {   
        //            tTopka.Stop();
        //            topkaCrtaj.Stop();
        //            tWave.Stop();
        //            tLvL.Stop();
        //            t.Stop();
        //            t1.Stop();
        //            t2.Stop();
        //            t3.Stop();
        //            tt.Stop();
        //            tt1.Stop();
        //            tt2.Stop();
        //            tt3.Stop();
        //            ttt.Stop();
        //            ttt1.Stop();
        //            ttt2.Stop();
        //            ttt3.Stop();
        //            this.Hide();
        //            GameOver gmo = new GameOver();
        //            gmo.ShowDialog();

        //            this.Close();


        //        }
        //        if (gm.lista4[i].x > 1000)
        //        {
        //            gm.lista4[i].kraj = true;
        //        }

            
            
        //    }
        //    for (int i = gm.lista4.Count - 1; i >= 0; i--)
        //    {
        //        if (gm.lista4[i].kraj == true)
        //        {
        //            gm.lista4.RemoveAt(i);
        //        }
          
        //    }
        //    Invalidate(true);

        //}




        //функција за создавање на нов бран на објекти 
        void tWave_Tick(object sender, EventArgs e)
        {

            if (lvl1 == true)//проверка за ниво
            {
                for (int i = 0; i < 10; i++)// изминување на листата
                {
                    WhiteWalker ww = new WhiteWalker(rnd.Next(50, 900), rnd.Next(50, 500));//креирање објект со рандом координати
                    gm.lista1.Add(ww);//додавање на објектот во листата
                    Invalidate();//прецртување

                }


            }

            else if (lvl2 == true)
            {
                for (int i = 0; i < 8; i++)
                {
                    WhiteWalker ww = new WhiteWalker(rnd.Next(50, 900), rnd.Next(50, 500));
                    gm.lista1.Add(ww);
                    Invalidate();

                }

                for (int i = 0; i < 2; i++)
                {
                    WhiteWalker2 ww = new WhiteWalker2(rnd.Next(50, 900), rnd.Next(50, 500));
                    gm.lista3.Add(ww);
                    Invalidate();

                }


            }


            else if (lvl3 == true)
            {
                for (int i = 0; i < 6; i++)
                {
                    WhiteWalker ww = new WhiteWalker(rnd.Next(50, 900), rnd.Next(50, 500));
                    gm.lista1.Add(ww);
                    Invalidate();

                }
                for (int i = 0; i < 4; i++)
                {
                    WhiteWalker2 ww = new WhiteWalker2(rnd.Next(50, 900), rnd.Next(50, 500));
                    gm.lista3.Add(ww);
                    Invalidate();

                }
            }

        }

            // функција за променување на ниво на одреден интервал
        void tLvL_Tick(object sender, EventArgs e)
        {
            brojac++;
            if (brojac == 1)
            {
                label8.Text = "2";
                lvl1 = false;
                lvl2 = true;
               // MessageBox.Show("lvl2");
            }
            else if (brojac == 2)
            {
                label8.Text = "3";
                lvl2 = false;
                lvl3 = true;
               // MessageBox.Show("lvl3");
            }
            else if (brojac == 3)
            {
                lvl3 = false;
                kraj = true;
                MessageBox.Show("Congratulations.You Won!");
                this.Close();
            }
            
            
        }
        //фунцкија за одстранување на објекти од класата Night'sWatch на одреден интервал
        void brisiNW(object sender, EventArgs e)
        {
            if (lvl1 == true)
            {
                if (gm.lista2.Count > 2)
                {

                    gm.lista2.Clear();
                    Invalidate();
                }
            }


            if (lvl2 == true)
            {
                if (gm.lista2.Count > 4)
                {

                    gm.lista2.Clear();
                    Invalidate();
                }
            }
            if (lvl3 == true)
            {
                if (gm.lista2.Count > 6)
                {

                    gm.lista2.Clear();
                    Invalidate();
                }
            }



        }


        //функција за создавање на објект од класата WhiteWalker повикувана на одреден интервал
        private void TimerEventWW(Object myObject, EventArgs myEventArgs)
        {
            if (lvl1 == true)
            {
                WhiteWalker ww = new WhiteWalker(rnd.Next(50, 900), rnd.Next(50, 450));
                gm.lista1.Add(ww);

               
             
                if (((gm.lista1.Count) + (gm.lista3.Count)) > 15)
                {
                    t.Stop();
                    t2.Stop();
                    tWave.Stop();
                    tLvL.Stop();
                    this.Hide();
                    GameOver gmo = new GameOver();
                    gmo.ShowDialog();
                     
                    this.Close();
                    

                }


                Invalidate();
            }


            else if (lvl2 == true)
            {
                t.Stop();
                tt.Start();
                WhiteWalker ww = new WhiteWalker(rnd.Next(50, 900), rnd.Next(50, 450));
                gm.lista1.Add(ww);

                
                if (((gm.lista1.Count) + (gm.lista3.Count)) > 15)
                {
                    tt.Stop();
                    tt2.Stop();
                    tWave.Stop();
                    tLvL.Stop();
                    this.Hide();
                    GameOver gmo = new GameOver();
                    gmo.ShowDialog();

                    this.Close();

                }


                Invalidate();
            }



            else if (lvl3 == true)
            {
                tt.Stop();
                ttt.Start();
                WhiteWalker ww = new WhiteWalker(rnd.Next(50, 900), rnd.Next(50, 450));
                gm.lista1.Add(ww);

               
                
                if (((gm.lista1.Count) + (gm.lista3.Count)) > 15)
                {
                    ttt.Stop();
                    ttt2.Stop();
                    tWave.Stop();
                    tLvL.Stop();
                    this.Hide();
                    GameOver gmo = new GameOver();
                    gmo.ShowDialog();

                    this.Close();

                }


                Invalidate();
            }
        }

        //Функција за создавање на објект од класата Night'sWatch повикувана на одреден интервал
        private void TimerEventNW(Object myObject, EventArgs myEventArgs)
        {

            if (lvl1 == true)
            {
                Night_sWatch tmp2 = new Night_sWatch(rnd.Next(50, 900), rnd.Next(50, 450));
                gm.lista2.Add(tmp2);
            }

            else    if (lvl2 == true)
            {
                t1.Stop();
                tt1.Start();
                Night_sWatch tmp2 = new Night_sWatch(rnd.Next(50, 900), rnd.Next(50, 450));
                gm.lista2.Add(tmp2);
            }

            else       if (lvl3 == true)
            {
                tt1.Stop();
                ttt1.Start();
                Night_sWatch tmp2 = new Night_sWatch(rnd.Next(50, 900), rnd.Next(50, 450));
                gm.lista2.Add(tmp2);
               
            }


            


 }
       
        
        
        //функција за создавање на објект од класата WhiteWalker2 повикувана на одреден интервал
        private void TimerEventWW2(Object myObject, EventArgs myEventArgs)
        {
            if (lvl1 == true)
            {
                WhiteWalker2 tmp3 = new WhiteWalker2(rnd.Next(50, 900), rnd.Next(50, 450));
                gm.lista3.Add(tmp3);
            }
            else if (lvl2 == true)
            {
                t2.Stop();
                tt2.Start();
                WhiteWalker2 tmp3 = new WhiteWalker2(rnd.Next(50, 900), rnd.Next(50, 450));
                gm.lista3.Add(tmp3);
            }
            else if (lvl3 == true)
            {
                tt2.Stop();
                ttt2.Start();
                WhiteWalker2 tmp3 = new WhiteWalker2(rnd.Next(50, 900), rnd.Next(50, 450));
                //WhiteWalker2 tmp4 = new WhiteWalker2(rnd.Next(50, 900), rnd.Next(50, 450));
                gm.lista3.Add(tmp3);
                //gm.lista3.Add(tmp4);
            }
        }



        


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            gm.Draw(g);
       
            
               
            
        }
       





    
        


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {


            strela.Play();
            //if (e.X >= eden.x && e.Y >= eden.y && e.X < eden.x + eden.slika.Width && e.Y < eden.y + eden.slika.Height)


            foreach (WhiteWalker los in (gm.lista1))
            {
                if (e.X >= los.x && e.Y >= los.y && e.X < los.x + 60 && e.Y < los.y + 100)
                {   
                    WW = los;
                    isHit = true;
                    los.zvuk.Play();
                    score++;

               
                }



            }

            if (isHit)
            {

               
                gm.lista1.Remove(WW);
                Invalidate();
            

            }
           
            foreach (Night_sWatch nw in gm.lista2)
            {
                if (e.X >= nw.x && e.Y >= nw.y && e.X < nw.x + 100 && e.Y < nw.y + 80)
                {
                    NW = nw;
                    isHit2 = true;
                    nw.zvuk.Play();
                    score = score - 5;
                   
                   
                    lives--;

                   
                    if (lives == 0)
                    {
                        tTopka.Stop();
                        topkaCrtaj.Stop();
                        tWave.Stop();
                        tLvL.Stop();
                        t.Stop();
                        t1.Stop();
                        t2.Stop();
                        t3.Stop();
                        tt.Stop();
                        tt1.Stop();
                        tt2.Stop();
                        tt3.Stop();
                        ttt.Stop();
                        ttt1.Stop();
                        ttt2.Stop();
                        ttt3.Stop();
                        this.Hide();
                        GameOver gmo = new GameOver();
                        gmo.ShowDialog();

                        this.Close();
                     

                    }
                }

               

            }
            if (isHit2)
            {

                
                gm.lista2.Remove(NW);

                Invalidate();
                

            }
            foreach (CannonBall cb in (gm.lista4))
            {
                if (e.X >= cb.x && e.Y >= cb.y && e.X < cb.x + 65 && e.Y < cb.y + 60)
                {
                    CB = cb;
                    isHit3 = true;
                    //cb.zvuk.Play();
                    score=score+2;

               
                }



            }

            if (isHit3)
            {


                gm.lista4.Remove(CB);
                Invalidate();
          

            }
         


        }









       
          




    //уништување на објект од класата WhiteWalker2 со двоен клик
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (WhiteWalker2 ww2 in gm.lista3)
            {
                if (e.X >= ww2.x && e.Y >= ww2.y && e.X < ww2.x + 60 && e.Y < ww2.y + 100)
                {
                    WW2 = ww2;
                    isHit3 = true;
                    WW2.zvuk.Play();
                    score += 5;
                    
                   
                }



            }
            if (isHit3)
            {

                
                gm.lista3.Remove(WW2);
                Invalidate();


            }
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            BackgroundWorker bw2 = new BackgroundWorker();
            BackgroundWorker bw3 = new BackgroundWorker();
            BackgroundWorker bw4 = new BackgroundWorker();
            BackgroundWorker bw5 = new BackgroundWorker();
            BackgroundWorker bw6 = new BackgroundWorker();
             //this allows our worker to report progress during work
            bw.WorkerReportsProgress = true;
            bw2.WorkerReportsProgress = true;
            bw3.WorkerReportsProgress = true;
            bw4.WorkerReportsProgress = true;
            bw5.WorkerReportsProgress = true;
            bw6.WorkerReportsProgress = true;
            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;

           
                while (bw.WorkerReportsProgress == true)
                {
                    b.ReportProgress(1);
                    System.Threading.Thread.Sleep(500);
                }


            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {
                if (((gm.lista1.Count) + (gm.lista3.Count)) > 15)//проверка за број на негативни ликови
                {

                    bw.WorkerReportsProgress = false;
                    t.Stop();
                    t2.Stop();
                    tWave.Stop();
                    tTopka.Stop();
                    topkaCrtaj.Stop();
                    tWave.Stop();
                    
                    tLvL.Stop();
                    this.Hide();
                    GameOver gmo = new GameOver();
                    gmo.ShowDialog();

                    this.Close();
                    //ако бројот е поголем од 15 се стопираат сите тајмери и нитки и се отвара формата Game over

                }
                for (int i = 0; i < gm.lista4.Count; i++)
            {
                gm.lista4[i].Move(20, 60, 10, 10);//движење на топката
                gm.proveriUdar();//проверка за удар со објект од Night'sWatch
                lives = lives - gm.poeniTopka;
                //ако имало удар gm.poeniTopka ке биде 1(види класа GMdoc) и бројот на животи ке се намали за 1,а ако немало удар gm.poeniTopka ке биде 0
                if (lives == 0)
                {
                    
                    bw.WorkerReportsProgress = false;
                         
                    tTopka.Stop();
                    topkaCrtaj.Stop();
                    tWave.Stop();
                    tLvL.Stop();
                    t.Stop();
                    t1.Stop();
                    t2.Stop();
                    t3.Stop();
                    tt.Stop();
                    tt1.Stop();
                    tt2.Stop();
                    tt3.Stop();
                    ttt.Stop();
                    ttt1.Stop();
                    ttt2.Stop();
                    ttt3.Stop();
                    this.Hide();
                    GameOver gmo = new GameOver();
                    gmo.ShowDialog();

                    this.Close();
                    
                    //проверка на бројот на животи.Ако е 0 стопирање на сите тајмери и отварање на формата GameOver

                }
                if (gm.lista4[i].x > 1000)
                {
                    gm.lista4[i].kraj = true;
                    //порверка дали топката ја пречекорила границата на формата
                }

            
            
            }
            for (int i = gm.lista4.Count - 1; i >= 0; i--)
            {
                if (gm.lista4[i].kraj == true)
                {
                    gm.lista4.RemoveAt(i);
                    //ако ја пречекорила избриши ја
                }
          
            }
            Invalidate(true);

        
                
                
            });


            bw2.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;


                while (bw2.WorkerReportsProgress == true)
                {
                    b.ReportProgress(1);
                    System.Threading.Thread.Sleep(100);
                }


            });

            // what to do when progress changed (update the progress bar for example)
            bw2.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {

                label6.Text = lives.ToString();

            });


            bw3.DoWork += new DoWorkEventHandler(
           delegate(object o, DoWorkEventArgs args)
           {
               BackgroundWorker b = o as BackgroundWorker;


               while (bw3.WorkerReportsProgress == true)
               {
                   b.ReportProgress(1);
                   System.Threading.Thread.Sleep(100);
               }


           });

            // what to do when progress changed (update the progress bar for example)
            bw3.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {

                label2.Text = score.ToString();

            });




            bw3.DoWork += new DoWorkEventHandler(
      delegate(object o, DoWorkEventArgs args)
      {
          BackgroundWorker b = o as BackgroundWorker;


          while (bw3.WorkerReportsProgress == true)
          {
              b.ReportProgress(1);
              System.Threading.Thread.Sleep(100);
          }


      });

            // what to do when progress changed (update the progress bar for example)
            bw3.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {

                label4.Text = ((gm.lista1.Count) + (gm.lista3.Count)).ToString();

            });


            bw5.DoWork += new DoWorkEventHandler(
    delegate(object o, DoWorkEventArgs args)
    {
     BackgroundWorker b = o as BackgroundWorker;


        while (bw5.WorkerReportsProgress == true)
        {
         b.ReportProgress(1);
         System.Threading.Thread.Sleep(1000);
         }


 });

            // what to do when progress changed (update the progress bar for example)
            bw5.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {



                if (vreme1 == 0)
                { vreme1 = 60; }
                if (vreme1 != 0)
                {
                    vreme1--;

                    label11.Text = vreme1.ToString();
                    
                }
                if (vreme2 == 0)
                { vreme2 = 15; }
                if (vreme2 != 0)
                {
                    vreme2--;

                    label12.Text = vreme2.ToString();

                }

            });



            
            bw3.RunWorkerAsync();
            bw2.RunWorkerAsync();
            bw.RunWorkerAsync();
            bw4.RunWorkerAsync();
            bw5.RunWorkerAsync();
            bw6.RunWorkerAsync();
        }

        

  

      
        
      

       
       

      

    }
}


