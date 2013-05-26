
Семинарска работа по предметот Визуелно програмирање



Тема:Game of Thrones-The Wall



  Изработиле:
   Владимир Радески	Ангела Трпковска
    


		
“Game of Thrones-The Wall” е игра со тема и ликови од истоимената серија.Во текот на играта се појавуваат добри и негативни ликови, а целта на играчот е да ги убива лошите ликови, притоа внимавајќи да не го убие добриот лик. Постојат два типа на лоши ликови,едните се убиваат со клик на маус,а другите со двоклик на маус.На определено време се појавува нов бран на ликови,со што се создава поголема динамичност на играта. Играчот може да изгуби доколку три пати го погоди добриот лик или пак доколку дозволи на екранот да има 15 лоши ликови. Одвреме навреме се појавуваат движечки топовски топки кои, ако го погодат добриот лик, го убиваат и притоа се губат животни поени. За да се избегне ова, потребно е топките да се уништат со клик на маусот пред да стигнат до добриот лик.Играта има 3 нивоа , и секое ниво трае 60 секунди. Секое ниво е за нијанса потешко од претходното. За да победиш треба да ги поминеш сите 3 нивоа. 
 
 

Решение

	classWhiteWalker2

	classNight_sWatch

	classWhiteWalker

	class CannonBall


За секој лик се пишува посебна класа,а во секоја од класите се чуваат податоци за X и Y координатите на ликот ,променлива за сликата и звукот за ликот.Во секоја класа потребно да се напише Draw метод,за исцртување на соодветниот лик.

   
   
   public class WhiteWalker
   
   {
   
	public int x { get; set; }
	public int y { get; set; }
	public Image slika = Resources.WhiteWalker;
	public SoundPlayer zvuk;


public WhiteWalker(int x,int y)
        
        {
        
	this.x = x;
	this.y = y;
        zvuk = newSoundPlayer("zombie.wav");

}

publicvoid Draw(Graphics g)
        {
            g.DrawImage(slika, x, y);

}

}



//Во класата GMdoc се чуваат листи од четирите објекти,
    public class GMdoc
    {
        public List<WhiteWalker> lista1 { get; set; }
        public List<Night_sWatch> lista2 { get; set; }
        public List<WhiteWalker2> lista3 { get; set; }
        public List<CannonBall> lista4 { get; set; }
        
//метод за исцртување на објектите од листите,

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
//како и метод за проверка дали објект од класата CannonBall дошол во допир со објект од класата Night’sWatch
	
	public void proveriUdar()
        
        {
            poeniTopka = 0;

            for (int i = 0; i < lista2.Count; i++)
            {
                for (int j = 0; j < lista4.Count; j++)

                    if (lista4[j].x >= lista2[i].x && lista4[j].y >= lista2[i].y && lista4[j].x < lista2[i].x + 100 && lista4[j].y < lista2[i].y + 100)
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
Повеќето функции се повикуваат на одреден интервал со помош на тајмер.
Пример - функцијата која создава нов бран на негативни ликови:
Timer tWave = new Timer();
tWave.Interval = 15000;
tWave.Tick += new EventHandler(tWave_Tick);

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
Понатака се проверува кое ниво  е и во зависност од нивото се додаваат и објекти од другите класи за да биде потешко
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

Првично со тајмер ги повикувавме и функциите за менување на лабелите(време,бр. на ликови,поени и тн.) и функцијата за движење на топовската топка, но наидовме на проблем. Проблемот беше тоа што тие функции не се извршуваа паралелно и доаѓаше до кочење и закаснување, па затоа искористивме еден вид на нитки поточно BackgroundWorker.
Функција за движење на топката повикана со BackgroundWorker
private void Form1_Load(object sender, EventArgs e)
        {BackgroundWorker bw = new BackgroundWorker();

            bw.WorkerReportsProgress = true;

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
  bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {
                if (((gm.lista1.Count) + (gm.lista3.Count)) > 15) //проверка за број на негативни ликови

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
                    topkaCrtaj.Stop();
                    ...
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
}

