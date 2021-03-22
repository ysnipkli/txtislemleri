using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace txtislemleri
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opn = new OpenFileDialog();
            opn.Filter = "TXT|*.txt|NC|*.nc"; //sadece txt dosyalarına erişim sağlamak için.
            if (opn.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) //dosya windows formuna uygunsa iptal et değilse else işlemi ile devam et.
            {
                return;
            }
            else
            { //seçtiğimiz dosyanın içeriğini okumak için
                StreamReader oku = new StreamReader(opn.FileName); //girilen dosya ismini okuyor ve açıyor.
                richTextBox1.Text = oku.ReadToEnd();
                oku.Close();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {


            int indeks = 0;
            string t = richTextBox1.Text; //richttextboxtaki bulma ve boyama işlemi yapılacak, o işaretleme devamlı olmasın diye
            richTextBox1.Text = "";  //işaretlenen ifadeyi clearladık.
            richTextBox1.Text = t;

            //string txtparameter_1 = @".\-$";
            // bool istxt1 = Regex.IsMatch(textBox1.Text, txtparameter_1);

            string _String = textBox1.Text;  //bu kısımda girilen kelimede * veya - varmı kntrolü yapmak için kontrol değerleri oluşturduk.
            string _Kontrol = "-";
            string _Stringg = textBox1.Text;
            string _Kontroll = "*";

            
           

            if ((_String.StartsWith(_Kontrol)) && (_String.EndsWith(_Kontrol)))  //eğer ilk veya son stringi - ise
            {
                string sorun = textBox1.Text;
                string cozum = sorun.Substring(1, sorun.Length - 1).Substring(0, sorun.Length - 2);  //textboxtaki ifadenin başından ve sonundan eksilterek aramaya geçeceğiz.
                textBox1.Text = cozum;
                

                int sayac = 0;
                while (indeks <= richTextBox1.Text.ToLower().LastIndexOf(textBox1.Text))  //son stringe kadar git.
                {
                    
                 
                    richTextBox1.Find(textBox1.Text, indeks, richTextBox1.TextLength, RichTextBoxFinds.None); //aranan kelimeyi bul
                    richTextBox1.SelectionBackColor = Color.Yellow; //arka planı sarıya çevirki bulduğun belli olsun
                    indeks = richTextBox1.Text.ToLower().IndexOf(textBox1.Text, indeks) + 1; //aynı kelimeden fazlası varsa onları da tek tek bulmak için
                    sayac++; //kac tane olduğunu ekrana yazdırmak için

                }
                

                MessageBox.Show(sayac + "Adet bulundu");
            }

            else if ((_Stringg.StartsWith(_Kontroll)) && (_Stringg.EndsWith(_Kontroll)))
            {
                string sorun = textBox1.Text;
                string cozum = sorun.Substring(1, sorun.Length - 1).Substring(0, sorun.Length - 2);
                textBox1.Text = cozum;

                int sayac = 0;
                while (indeks <= richTextBox1.Text.ToLower().LastIndexOf(textBox1.Text))
                {


                    richTextBox1.Find(textBox1.Text, indeks, richTextBox1.TextLength, RichTextBoxFinds.None);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    indeks = richTextBox1.Text.ToLower().IndexOf(textBox1.Text, indeks) + 1;
                    sayac++;

                }
                MessageBox.Show(sayac + "Adet bulundu");
            }

            else
            {
                int sayac = 0;
                while (indeks <= richTextBox1.Text.ToLower().LastIndexOf(textBox1.Text))
                {

                    richTextBox1.Find(textBox1.Text, indeks, richTextBox1.TextLength, RichTextBoxFinds.None);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    indeks = richTextBox1.Text.ToLower().IndexOf(textBox1.Text, indeks) + 1;
                    sayac++;

                }


                MessageBox.Show(sayac + "Adet bulundu");
            }


        }
        //bulduğu kelimeleri sarıyla, değiştirdiklerini kırmızı highlight ile belirtecek şekilde kodlandı.
        private void button3_Click(object sender, EventArgs e) //bul  
        {
            
            string t_1 = richTextBox1.Text;
            richTextBox1.Text = "";
            richTextBox1.Text = t_1;
            string _String_1 = textBox3.Text;
            string _Kontrol_1 = "-";
            string _Stringg_1 = textBox3.Text;
            string _Kontroll_1 = "*";
            int indeks_1 = 0;


            if ((_String_1.StartsWith(_Kontrol_1)) && (_String_1.EndsWith(_Kontrol_1)))
            {
                string sorun = textBox3.Text;
                string cozum = sorun.Substring(1, sorun.Length - 1).Substring(0, sorun.Length - 2);
                textBox3.Text = cozum;


                
                while (indeks_1 <= richTextBox1.Text.ToLower().LastIndexOf(textBox3.Text))
                {
                    richTextBox1.Find(textBox3.Text, indeks_1, richTextBox1.TextLength, RichTextBoxFinds.None);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    indeks_1 = richTextBox1.Text.ToLower().IndexOf(textBox3.Text, indeks_1) + 1;
                    //richTextBox1.Find(textBox3.Text, 0, RichTextBoxFinds.None); //aranan kelimeyi bulma işlemi bitene kadar ara.
                    //richTextBox1.Focus(); //yazılan kelimeyi belli etmesi için
                }

            }

            else if ((_Stringg_1.StartsWith(_Kontroll_1)) && (_Stringg_1.EndsWith(_Kontroll_1)))
            {
                
                string sorun = textBox3.Text;
                string cozum = sorun.Substring(1, sorun.Length - 1).Substring(0, sorun.Length - 2); 
                textBox3.Text = cozum;

                
                while (indeks_1 <= richTextBox1.Text.ToLower().LastIndexOf(textBox3.Text))
                {


                    richTextBox1.Find(textBox3.Text, indeks_1, richTextBox1.TextLength, RichTextBoxFinds.None);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    indeks_1 = richTextBox1.Text.ToLower().IndexOf(textBox3.Text, indeks_1) + 1;
                    

                }
                
            }

            else
            {
                
                while (indeks_1 <= richTextBox1.Text.ToLower().LastIndexOf(textBox3.Text))
                {

                    richTextBox1.Find(textBox3.Text, indeks_1, richTextBox1.TextLength, RichTextBoxFinds.None);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    indeks_1 = richTextBox1.Text.ToLower().IndexOf(textBox3.Text, indeks_1) + 1;
                    

                }
            }

            

        }
        private void button2_Click_1(object sender, EventArgs e) //degistir
        {
            int temp = 0;
            while(temp<= richTextBox1.Text.ToLower().LastIndexOf(textBox3.Text)) //aradığımız son kelimeyi textin sonuna kadar arıcak ilk kelimeye kadar tarıcak.
            {
                richTextBox1.Find(textBox3.Text, temp, richTextBox1.TextLength, RichTextBoxFinds.None);
                richTextBox1.SelectionBackColor = Color.Red;
                temp = richTextBox1.Text.ToLower().IndexOf(textBox3.Text, temp) + 1;
                richTextBox1.SelectedText = textBox2.Text; // yazılan kelimeyi texte tek tıkla istenilen hale çevirecek. //değistri kısmında yazılan ifadeyi değiştirmesi için ata.
            }

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string t_2 = richTextBox1.Text;
            richTextBox1.Text = "";
            richTextBox1.Text = t_2;
            string _String_2 = textBox4.Text;
            string _Kontrol_2 = "-";
            string _Stringg_2 = textBox4.Text;
            string _Kontroll_2 = "*";
            int indeks_2 = 0;

            
            {
                if ((_String_2.StartsWith(_Kontrol_2)) && (_String_2.EndsWith(_Kontrol_2)))
                {
                    string sorun = textBox4.Text;
                    string cozum = sorun.Substring(1, sorun.Length - 1).Substring(0, sorun.Length - 2);
                    textBox4.Text = cozum;



                    while (indeks_2 <= richTextBox1.Text.ToLower().LastIndexOf(textBox4.Text))
                    {
                        richTextBox1.Find(textBox4.Text, indeks_2, richTextBox1.TextLength, RichTextBoxFinds.None);
                        indeks_2 = richTextBox1.Text.ToLower().IndexOf(textBox4.Text, indeks_2) + 1;
                        richTextBox1.SelectionBackColor = Color.White;
                        richTextBox1.SelectedText = " ";
                    }

                }

                else if ((_Stringg_2.StartsWith(_Kontroll_2)) && (_Stringg_2.EndsWith(_Kontroll_2)))
                {

                    string sorun = textBox4.Text;
                    string cozum = sorun.Substring(1, sorun.Length - 1).Substring(0, sorun.Length - 2);
                    textBox4.Text = cozum;


                    while (indeks_2 <= richTextBox1.Text.ToLower().LastIndexOf(textBox4.Text))
                    {


                        richTextBox1.Find(textBox4.Text, indeks_2, richTextBox1.TextLength, RichTextBoxFinds.None);
                        indeks_2 = richTextBox1.Text.ToLower().IndexOf(textBox4.Text, indeks_2) + 1;
                        richTextBox1.SelectionBackColor = Color.White;
                        richTextBox1.SelectedText = " ";


                    }

                }
                else
                {

                    while (indeks_2 <= richTextBox1.Text.ToLower().LastIndexOf(textBox4.Text))
                    {

                        richTextBox1.Find(textBox4.Text, indeks_2, richTextBox1.TextLength, RichTextBoxFinds.None);
                        indeks_2 = richTextBox1.Text.ToLower().IndexOf(textBox4.Text, indeks_2) + 1;
                        richTextBox1.SelectionBackColor = Color.White;
                        richTextBox1.SelectedText = " ";


                    }
                }




            }
        }
    }
    }


      



