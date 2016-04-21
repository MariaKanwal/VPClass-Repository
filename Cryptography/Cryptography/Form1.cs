using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptography
{
    public partial class Form1 : Form
    {


        static int Prime_Number_1;
        static int Prime_Number_2;
        static int Value_of_E;


        static string Load_and_Save = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Assign_Values_Button3.Text == "Assign Values")
            {
                //is prime function needed for acceptance or denail 
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog OPENIMAGE = new OpenFileDialog();
            OPENIMAGE.Filter = "ImageFile(*.JPG)|*.JPG";

            if (OPENIMAGE.ShowDialog() == DialogResult.OK)
            {
                ImageSourceTB.Text = OPENIMAGE.FileName; // For Taking Image from User
                ImagePictureBox.Image = Image.FromFile(ImageSourceTB.Text); //shows image in the Picture Box
                SaveImage_Bbutton2.Enabled = true; // Now Button Enabled for loading Image

            }

            else
            {
                SaveImage_Bbutton2.Enabled = false; // Button Disabled by default 
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Load_and_Save = BitConverter.ToString(Implementation.Conversion_To_BitMap(ImagePictureBox.Image));
            //For Calling the image to bit map converter function from implementation class with help of BITCONVERTER library 

            MessageBox.Show("Image Selected was Saved For Encryption ");

            inputgroupbox.Enabled = true;

        }
    }
}

