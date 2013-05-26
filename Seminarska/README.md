




���������� ������ �� ��������� �������� ������������



����:Game of Thrones-The Wall




��������:                                                                             ����������:
			�������� �������
�-� ����� ��������						������ ���������
��������:    
M-p ����� �����
���� �� ������
		
�Game of Thrones-The Wall� � ���� �� ���� � ������ �� ����������� ������.�� ����� �� ������ �� ���������� ����� � ��������� ������, � ����� �� ������� � �� �� ����� ������ ������, ������ ������༝� �� �� �� ���� ������� ���. �������� ��� ���� �� ���� ������,������ �� ������� �� ���� �� ����,� ������� �� ������� �� ����.�� ���������� ����� �� �������� ��� ���� �� ������,�� ��� �� ������� �������� ����������� �� ������. ������� ���� �� ������ ������� ��� ���� �� ������ ������� ��� ��� ��� ������� ������� �� ������� �� ��� 15 ���� ������. ������� ������� �� ���������� �������� �������� ����� ���, ��� �� ������� ������� ���, �� ������� � ������ �� ����� ������� �����. �� �� �� ������� ���, �������� � ������� �� �� ������� �� ���� �� ������ ���� �� ������� �� ������� ���.������ ��� 3 ����� , � ����� ���� ���� 60 �������. ����� ���� � �� ������� ������� �� �����������. �� �� ������� ����� �� �� ������� ���� 3 �����. 
 
 

�������

classWhiteWalker2
classNight_sWatch
classWhiteWalker
class CannonBall

�� ����� ��� �� ������ ������� �����,� �� ������ �� ������� �� ������ �������� �� X � Y ������������ �� ����� ,���������� �� ������� � ������ �� �����.�� ������ ����� �������� �� �� ������ Draw �����,�� ���������� �� ����������� ���.
publicclassWhiteWalker
    {
publicint x { get; set; }
publicint y { get; set; }
publicImage slika = Resources.WhiteWalker;
publicSoundPlayer zvuk;


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
�� ������� GMdoc �� ������ ����� �� �������� �������,
public class GMdoc
    {
        public List<WhiteWalker> lista1 { get; set; }
        public List<Night_sWatch> lista2 { get; set; }
        public List<WhiteWalker2> lista3 { get; set; }
        public List<CannonBall> lista4 { get; set; }
        
����� �� ���������� �� ��������� �� �������,
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
���� � ����� �� �������� ���� ������ �� ������� CannonBall ����� �� ����� �� ������ �� ������� Night�sWatch

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
�������� ������� �� ���������� �� ������� �������� �� ����� �� ������.
������ - ���������� ���� ������� ��� ���� �� ��������� ������:


		Timer tWave = new Timer();
		tWave.Interval = 15000;
		tWave.Tick += new EventHandler(tWave_Tick);

	void tWave_Tick(object sender, EventArgs e)
	
        {

            if (lvl1 == true)//�������� �� ����
            {
                for (int i = 0; i < 10; i++)// ���������� �� �������
                {
	
	WhiteWalker ww = new WhiteWalker(rnd.Next(50, 900), rnd.Next(50, 500));//�������� ������ �� ������ ����������
                    gm.lista1.Add(ww);//�������� �� �������� �� �������
                    Invalidate();//�����������


                }
�������� �� ��������� ��� ����  � � �� ��������� �� ������ �� �������� � ������� �� ������� ����� �� �� ���� �������
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

������� �� ������ �� ����������� � ��������� �� �������� �� ��������(�����,��. �� ������,����� � ��.) � ���������� �� ������� �� ���������� �����, �� �������� �� �������. ��������� ���� ��� ��� ��� ������� �� �� ��������� ��������� � ������� �� ������ � �����������, �� ����� ������������ ���� ��� �� ����� ������� BackgroundWorker.
�������� �� ������� �� ������� �������� �� BackgroundWorker
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
                if (((gm.lista1.Count) + (gm.lista3.Count)) > 15) //�������� �� ���� �� ��������� ������

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
//��� ������ � ������� �� 15 �� ��������� ���� ������� � ����� � �� ������ ������� Game over
}
                for (int i = 0; i < gm.lista4.Count; i++)
            {
                gm.lista4[i].Move(20, 60, 10, 10);//������� �� �������
                gm.proveriUdar();//�������� �� ���� �� ������ �� Night'sWatch
                lives = lives - gm.poeniTopka;
                //��� ����� ���� gm.poeniTopka �� ���� 1(���� ����� GMdoc) � ������ �� ������ �� �� ������ �� 1,� ��� ������ ���� gm.poeniTopka �� ���� 0

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
                    //�������� �� ������ �� ������.��� � 0 ��������� �� ���� ������� � �������� �� ������� GameOver

                }
                if (gm.lista4[i].x > 1000)
                {
                    gm.lista4[i].kraj = true;
//�������� ���� ������� �� ����������� ��������� �� �������

                }       
            
            }
            for (int i = gm.lista4.Count - 1; i >= 0; i--)
            {
                if (gm.lista4[i].kraj == true)
                {
                    gm.lista4.RemoveAt(i);
//��� �� ����������� ������� ��

                } 
            }
            Invalidate(true);

        
            });


