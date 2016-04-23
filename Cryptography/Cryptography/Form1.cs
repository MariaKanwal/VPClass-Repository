﻿using System;
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
                // To take Input From User and Make sure that all of the textboxes had values

                if(textBox_PrimeNO_1.Text=="" || textBox_PrimeNo_2.Text=="" || textBox_Value_of_E.Text=="")
                {
                    MessageBox.Show("Please Fill All The Assocaited Feilds");
                }

                else
                {
                    
                    // Assigning value for First Prime Number 
                    //Calls the Prime_Number_Checker Function from Implemenattion class 

                    //If number entered is a prime Number it is assigned 
                    if (Cryptography.Implementation.Prime_Number_Checker(int.Parse(textBox_PrimeNO_1.Text)))
                    {
                        Prime_Number_1 = int.Parse(textBox_PrimeNO_1.Text);
                    }
                    // If number is not a prime number user is informed 
                    else
                    {
                        textBox_PrimeNO_1.Text= "";
                        MessageBox.Show(" You didn't Enter A Prime Number , Please TRY AGAIN");
                        return;
                    }



                    //Assign Value for Secound Prime Number 
                    //Number entered by User was a Prime Number
                    if (Cryptography.Implementation.Prime_Number_Checker(int.Parse(textBox_PrimeNo_2.Text)))
                    {
                        Prime_Number_2=int.Parse(textBox_PrimeNo_2.Text);
                    }

                     // Number Entered By User was not Prime so User was Informed and the Text Box was cleared for taking new value
                    else
                    {
                        textBox_PrimeNo_2.Text = "";
                        MessageBox.Show("You didn't Enter A Prime Number , Please TRY AGAIN");
                        return;
                    }



                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void Select_button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog OPENIMAGE = new OpenFileDialog();
            OPENIMAGE.Filter = "ImageFile(*.JPG)|*.JPG";

            if (OPENIMAGE.ShowDialog() == DialogResult.OK)
            {
                ImageSourceTB.Text = OPENIMAGE.FileName; // For Taking Image from User
                ImagePictureBox.Image = Image.FromFile(ImageSourceTB.Text); //shows image in the Picture Box
                SaveImage_Button2.Enabled = true; // Now Button Enabled for loading Image

            }

            else
            {
                SaveImage_Button2.Enabled = false; // Button Disabled by default 
            }


        }

        private void SaveImage_Bbutton2_Click(object sender, EventArgs e)
        {
            Load_and_Save = BitConverter.ToString(Implementation.Conversion_To_BitMap(ImagePictureBox.Image));
            //For Calling the image to bit map converter function from implementation class with help of BITCONVERTER library 

            MessageBox.Show("Image Selected was Saved For Encryption ");

            inputgroupbox.Enabled = true;

        }

    }
}

