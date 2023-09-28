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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public static Bitmap ConvertToLBP(Bitmap grayImage)
    {
        
        int neighborhoodSize = 3;

        
        Bitmap lbpImage = new Bitmap(grayImage.Width - 2, grayImage.Height - 2);

        for (int y = 1; y < grayImage.Height - 1; y++)
        {
            for (int x = 1; x < grayImage.Width - 1; x++)
            {
                byte centerPixelValue = grayImage.GetPixel(x, y).R;
                int pattern = 0;

               
                for (int dy = -1; dy <= 1; dy++)
                {
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        if (dx == 0 && dy == 0)
                            continue;

                        byte neighborPixelValue = grayImage.GetPixel(x + dx, y + dy).R;
                        if (neighborPixelValue >= centerPixelValue)
                            pattern = (pattern << 1) | 1;
                        else
                            pattern = (pattern << 1);
                    }
                }

             
                lbpImage.SetPixel(x - 1, y - 1, Color.FromArgb(pattern, pattern, pattern));
            }
        }

        return lbpImage;
    }


        private void label4_Click(object sender, EventArgs e)
        {

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
            
            Color actual1, actual2, actual3, newC1, newC2, newC3;
            final1 = new Bitmap(w, h);
            final2 = new Bitmap(w, h);
            final3 = new Bitmap(w, h);
            //Este bucle recorre cada pixel del bitmap
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
                    int Hsl = ((actual2.R + actual2.G + actual2.B) / 3);
                    newC2 = Color.FromArgb(Hsl, Hsl, Hsl);
                    final2.SetPixel(x, y, newC2);


                    //Tercero picbox
                    actual3 = myPic.GetPixel(x, y);
                    double  Luminosity = (0.299* (actual3.R) + 0.587*(actual3.G) + 0.114*(actual3.B));
                    int intValue = (int)Luminosity;//We get a parse 
                    newC3 = Color.FromArgb(intValue, intValue, intValue);
                    final3.SetPixel(x, y, newC3);
                }

            }
            

            // Mostrar la imagen LBP en pictureBox1
           
            pictureBox2.Image = final1;//primer picture box
            pictureBox3.Image = final2;//segundo picture box
            pictureBox4.Image = final3;//tercero picture box
            //Final
            Bitmap lbpImage = Form1.ConvertToLBP(final3);
            pictureBox5.Image = lbpImage;




        }

       
    }
}