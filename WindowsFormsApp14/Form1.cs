using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //kullanacağımız resimleri bir image dizisi oluşturup içine atıyoruz.
        Image[] resim =
        {
            Properties.Resources._1,
            Properties.Resources._2,
            Properties.Resources._3,
            Properties.Resources._4,
            Properties.Resources._5,
            Properties.Resources._6,
            Properties.Resources._7,
            Properties.Resources._8,
            Properties.Resources._9,
            Properties.Resources._10,
            Properties.Resources._11,
            Properties.Resources._12,
            Properties.Resources._13,
            Properties.Resources._14,
            Properties.Resources._15,
            Properties.Resources._16,
        };
        //resimlere rastgele ulaşmak için 16 tane indisli dizi oluşturuyoruz.
        int[] resim_indeks = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        
        PictureBox ilk;//ilk tıkladığımız picturebox ı tutacak bir değişken oluşturuyoruz.
        int ilk_indeks;//ilk picturebox ın indeksini tutacak değişkeni oluşturuyoruz.
        int sayac=0;//kazandığını belirtmek için sayaç oluşturuyoruz.

        private void resim_atama()//resimleri rastgele oluşturmak için fonksiyon oluşturuyoruz.
        {
            Random rastgele = new Random();//random fonksiyonunu çağırıyoruz.

            for (int i = 0; i < resim_indeks.Length-1; i++)
            {
                int rstgl = rastgele.Next(0,16);//değişkene 0dan 16ya kadar rastgele sayı atıyoruz.
                //resimlerin yerlerini değiştiren kodu yazıyoruz.
                int yedek = resim_indeks[i];
                resim_indeks[i] = resim_indeks[rstgl];
                resim_indeks[rstgl] = yedek;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)//picturebox lara tıklama özelliği veriyoruz.
        {
            timer1.Enabled = true;//picturboxa tıkladığında süreyi başlatıyoruz.
            PictureBox kutular = (PictureBox)sender;//tıklanan picturebox üzerinde işlem yapmak için sender özelliğini kullanıyoruz.
            int numara = Convert.ToInt32(kutular.Name.Substring(10))-1;//picturebox ın numarasını almak için ismini kullanıyoruz.
            int indeks_numara = resim_indeks[numara];//resimlerin indislerini bir değişkende tutuyoruz.
            kutular.Image= resim[indeks_numara];//oluşturduğumuz resim dizisindeki bir tane resmi tıkladığımız picturebox a atıyoruz.
            kutular.Refresh();//aynı anda tıklanan iki pictureboxı da göstermek için gerekli kod.
            if(ilk==null)//ilk değer boş ilk tıklanan buton bu olmuş oluyor.
            {
                ilk = kutular;//tıkladığımız picturebox ı ilk değişkenine atıyoruz.
                ilk_indeks = indeks_numara;//indeks numarasını değişkene atıyoruz.
            }
            else//eğer ikinci tıkladığımız picturebox ise bu koşula giriyor.
            {
                System.Threading.Thread.Sleep(1000);//2. picturebox a tıklandığı zaman 1 saniye bekleten kod.
                ilk.Image = null;//ilk değişkeninin resimini boşa atıyoruz.
                kutular.Image = null; //picturebox ın resmini boş atıyoruz.
                if(ilk_indeks==indeks_numara+8|| ilk_indeks == indeks_numara - 8)//tıkladığımıziki resim de eşitse bu koşula giriyoruz.
                {
                    sayac++;//sayacı arttırıyoruz. Çünkü oyunun bittiğini buna bağlı olarak belirleyeceğiz.
                    kutular.Image = resim[indeks_numara];//tıklanan picturebox ın resmini göründüğü resim yapıyoruz.
                    ilk.Image = resim[indeks_numara];//ilk tıklanan resmi de aynı şekilde yapıyoruz.
                    kutular.Enabled = false;//ikinci tıklanan picturebox ın tıklama özelliğini devredışı bırakıyoruz.
                    ilk.Enabled = false;//ilk tıklanan picturebox ın tıklama özelliğini devredışı bırakıyoruz.

                    if (sayac==8)//8 tane resmin de eşi bulunduğu zaman sayacımız 8 oluyor.(oyunu kazandıran ve yeniden başlatan kod)
                    {
                        timer1.Enabled = false;//zamanı durduruyoruz.
                        MessageBox.Show(dakika.ToString()+" dakika "+saniye+" saniye içerisinde buldunuz","Tebrikler");//kaç dakika kaç saniyede bitirdiğini ekrana yazıyoruz.
                        sayac = 0;//sayacı sıfırlıyoruz.
                        dakika = 0;//dadikayı sıfırlıyoruz.
                        saniye = 0;//saniyeyi sıfırlıyoruz.
                        //picturebox ların hepsinin resmini boşaltıyoruz.
                        pictureBox1.Image = null;
                        pictureBox2.Image = null;
                        pictureBox3.Image = null;
                        pictureBox4.Image = null;
                        pictureBox5.Image = null;
                        pictureBox6.Image = null;
                        pictureBox7.Image = null;
                        pictureBox8.Image = null;
                        pictureBox9.Image = null;
                        pictureBox10.Image = null;
                        pictureBox11.Image = null;
                        pictureBox12.Image = null;
                        pictureBox13.Image = null;
                        pictureBox14.Image = null;
                        pictureBox15.Image = null;
                        pictureBox16.Image = null;
                        //picturebox ların hepsini tıklanabilir hale getiriyoruz.
                        pictureBox1.Enabled = true;
                        pictureBox2.Enabled = true;
                        pictureBox3.Enabled = true;
                        pictureBox4.Enabled = true;
                        pictureBox5.Enabled = true;
                        pictureBox6.Enabled = true;
                        pictureBox7.Enabled = true;
                        pictureBox8.Enabled = true;
                        pictureBox9.Enabled = true;
                        pictureBox10.Enabled = true;
                        pictureBox11.Enabled = true;
                        pictureBox12.Enabled = true;
                        pictureBox13.Enabled = true;
                        pictureBox14.Enabled = true;
                        pictureBox15.Enabled = true;
                        pictureBox16.Enabled = true;

                        resim_atama();//resimlerin yerlerini değiştirmek için tekrar resim_atama fomksiyonunu çağırıyoruz.
                    }
                }
                ilk = null;//tıklanan iki picturebox ın resimleri eşit değilse ilk değere yine null atıyoruz.
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //form ilk açıldığında süre 1 saniye artsın istiyoruz ve resimleri karıştırsın istiyoruz.
            timer1.Interval = 1000;
            resim_atama();
        }

        int dakika = 0;
        int saniye = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((saniye == 59))//saniye 59  olduğunda koşula giriyor.
            {
                saniye = 0;//saniyeyi sıfırlıyor.
                dakika = dakika + 1;//dakikayı 1 arttırıyor.
                
            }
            saniye = saniye + 1;//her seferinde saniye 1 artıyor.
        }
    }
}
