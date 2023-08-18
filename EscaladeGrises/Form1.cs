using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace EscaladeGrises
{
    public partial class Form1 : Form
    {
        Bitmap myPic, final;
       
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
            Color actual, newC;
            final = new Bitmap(w, h);
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    actual = myPic.GetPixel(x, y);
                    newC = Color.FromArgb(actual.R, actual.R, actual.R);
                    final.SetPixel(x,y,newC);   

                }

            }
            pictureBox2.Image = final;

        }
    }
}