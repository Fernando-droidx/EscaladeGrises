using Microsoft.VisualBasic;

namespace EscaladeGrises
{
    public partial class Form1 : Form
    {
        Bitmap myPic;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG (*.jpg)|*.jpg| PNG (*.png)*.png |Todos los archivos (*.*)|*.*";
            //comprobamos si se cargo un archivo
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                //Cargo la imagen 
                myPic = new Bitmap(Image.FromFile(ofd.FileName));
                //Muestro la imagen
                pictureBox1.Image = myPic;

                 
            }


        }
    }
}