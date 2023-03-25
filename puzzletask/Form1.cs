using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace puzzletask
{
    public partial class Form1 : Form
    {
        Point EmptyPoint;
        ArrayList images = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            EmptyPoint.X = 360;
            EmptyPoint.Y= 360;


        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }
       
        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MoveButton((Button)sender);
        }

        private void MoveButton(Button btn)
        {
           if (((btn.Location.X==EmptyPoint.X-120||btn.Location.X==EmptyPoint.X+120)&&btn.Location.Y==EmptyPoint.Y)||
                (btn.Location.Y == EmptyPoint.Y-120 || btn.Location.Y == EmptyPoint.Y + 120) && btn.Location.X == EmptyPoint.X)
            {
                Point swap = btn.Location;
                btn.Location = EmptyPoint;
                EmptyPoint = swap;
            }
            if (EmptyPoint.X == 360 && EmptyPoint.Y == 360)
                checkvalid();
        }

        private void checkvalid()
        {
            int count = 0, index;
            foreach(Button btn in panel1.Controls)
            {
                index = (btn.Location.Y / 120)* 4 + btn.Location.X / 120;
                if (images[index] == btn.Image)
                    count++;
            }
            if (count == 15)
                MessageBox.Show("Congratulation YOU WIN !");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            foreach (Button b in panel1.Controls)
            b.Enabled = true;

            Image original = Image.FromFile(@"C:\Users\Zainab Harraz\Desktop\original.jpg");

            cropImageTomages(original, 500, 500);

            AddImagesToButtons(images);

         
        }

        private void AddImagesToButtons(ArrayList images)
        {
            int i = 0;
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, };
            arr = shuffle(arr);

            foreach (Button b in panel1.Controls)
            {
                if(i<arr.Length)
                {
                    b.Image =(Image)images[arr[i]];
                    i++;

                }
            }
        }

        private int[] shuffle(int[] arr)
        {
            Random rand = new Random();
            arr = arr.OrderBy(x => rand.Next()).ToArray();
            return arr;
        }

        private void cropImageTomages(Image original, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);
            Graphics graghic = Graphics.FromImage(bmp);
            graghic.DrawImage(original, 0, 0, w, h);

            graghic.Dispose();

            int movr = 0, movd = 0;

            for( int x=0; x<15; x++)
            {
                Bitmap piece = new Bitmap(120, 120);
                for (int i = 0; i < 120; i++)
                    for (int z = 0; z < 120; z++) 
                piece.SetPixel(i, z,
                    bmp.GetPixel(i + movr, z + movd))
;
                images.Add(piece);
                movr += 120;
                if (movr == 480)
                {
                    movr = 0;
                    movd += 120;

                }
            }
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
