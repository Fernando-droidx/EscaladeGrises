using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace EscaladeGrises
{
    public partial class Form1 : Form
    {
        Bitmap myPic, final1, final2, final3;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG (*.jpg)|*.jpg|JPEG (*.jpeg)|*.jpeg| PNG (*.png)|*.png|Todos los archivos (*.*)|*.*";
            //comprobamos si se cargo un archivo
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                //Cargo la imagen 
                myPic = new Bitmap(Image.FromFile(ofd.FileName));
                //Muestro la imagen
                pictureBox1.Image = myPic;

                 
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int w = myPic.Width , h= myPic.Height;
            //Este bucle recorre cada pixel del bitmap
            Color actual1, actual2, actual3, newC1, newC2, newC3;
            final1 = new Bitmap(w, h);
            final2 = new Bitmap(w, h);
            final3 = new Bitmap(w, h);
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    //Primer picbox
                    actual1 = myPic.GetPixel(x, y);
                    int average = (actual1.R + actual1.G + actual1.B) / 3;
                    newC1 = Color.FromArgb(average, average, average);
                    final1.SetPixel(x,y,newC1);


                    //Segundo picbox
                    actual2 = myPic.GetPixel(x, y);
                    int Hsl = ((actual1.R + actual1.G + actual1.B) / 3);
                    newC2 = Color.FromArgb(Hsl, Hsl, Hsl);
                    final2.SetPixel(x, y, newC2);


                    //Tercero picbox
                    actual3 = myPic.GetPixel(x, y);
                    double  Luminosity = 0.299* (actual3.R) + 0.587*(actual3.G) + 0.114*(actual3.B);
                    int intValue = (int)Luminosity;//We get a parse 
                    newC3 = Color.FromArgb(intValue, intValue, intValue);
                    final3.SetPixel(x, y, newC3);
                }

            }
            pictureBox2.Image = final1;//primer picture box
            pictureBox3.Image = final2;
            pictureBox4.Image = final3;

        }

       
    }
}