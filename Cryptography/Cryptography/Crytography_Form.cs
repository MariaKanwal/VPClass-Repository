using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cryptography
{
    public partial class Crytography_Form : Form
    {


        static int Prime_Number_1;
        static int Prime_Number_2;
        static int Value_of_E;



        static string Load_and_Save = "";


        int N;


        public Crytography_Form()
        {
            InitializeComponent();
        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Assign_Values_Button3.Text == "Assign Values")
            {
                // To take Input From User and Make sure that all of the textboxes had values

                if (textBox_PrimeNO_1.Text == "" || textBox_PrimeNo_2.Text == "" || textBox_Value_of_E.Text == "")
                {
                    MessageBox.Show("Please Fill All The Assocaited Feilds");
                }



                else
                {


                    // Assigning value for First Prime Number 
                    //Calls the Prime_Number_Checker Function from Implemenattion class 

                    //If number entered is a prime Number it is assigned 
                    if (Cryptography.Checker.Prime_Number_Checker(int.Parse(textBox_PrimeNO_1.Text)))
                    {
                        Prime_Number_1 = int.Parse(textBox_PrimeNO_1.Text);
                    }
                    // If number is not a prime number user is informed 
                    else
                    {
                        textBox_PrimeNO_1.Text = "";
                        MessageBox.Show(" You didn't Enter A Prime Number , Please TRY AGAIN");
                        return;
                    }



                    //Assign Value for Secound Prime Number 
                    //Number entered by User was a Prime Number
                    if (Cryptography.Checker.Prime_Number_Checker(int.Parse(textBox_PrimeNo_2.Text)))
                    {
                        Prime_Number_2 = int.Parse(textBox_PrimeNo_2.Text);
                    }

                     // Number Entered By User was not Prime so User was Informed and the Text Box was cleared for taking new value
                    else
                    {
                        textBox_PrimeNo_2.Text = "";
                        MessageBox.Show("You didn't Enter A Prime Number , Please TRY AGAIN");
                        return;
                    }



                    //Assign Value For Value of Encryion Exponenet 
                    // Calculating Value of "n" to check co prime between n and E
                    int VALUE_OF_PHI = Cryptography.RSA_Algorithm_Implementation.Value_of_N_Calculator((Prime_Number_1 - 1), (Prime_Number_2 - 1));


                    //If e was coprime of n
                    if (Cryptography.Checker.CoPrime_Checker(VALUE_OF_PHI, (int.Parse(textBox_Value_of_E.Text))))
                    {
                        Value_of_E = int.Parse(textBox_Value_of_E.Text);
                    }
                    // if e was not coprime of n
                    else
                    {
                        textBox_Value_of_E.Text = "";
                        MessageBox.Show("Please Enter a Realitive Prime Number");
                        return;
                    }

                    //To show that All the Values are assgined for Encrytion 
                    MessageBox.Show("You Have Sucessfuly Assigned all values");
                }

            }

            else
            {
                textBox_PrimeNO_1.Text = "";
                textBox_PrimeNo_2.Text = "";
                textBox_Value_of_E.Text = "";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void Select_button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog OPENIMAGE = new OpenFileDialog();
            OPENIMAGE.Filter = "ImageFile(*.JPG)|*.JPG";      // only accepts JPG Files

            if (OPENIMAGE.ShowDialog() == DialogResult.OK)
            {
                Image_Source_textbox.Text = OPENIMAGE.FileName; // For Taking Image from User
                ImagePictureBox.Image = Image.FromFile(Image_Source_textbox.Text); //shows image in the Picture Box

            }

            else
            {

            }


        }

        private void SaveImage_Bbutton2_Click(object sender, EventArgs e)
        {
            Load_and_Save = BitConverter.ToString(Conversion.Conversion_To_BitMap(ImagePictureBox.Image));
            //For Calling the image to bit map converter function from implementation class with help of BITCONVERTER library 

            MessageBox.Show("Image Selected was Saved For Encryption ");

        }



        private void Store_Location_button4_Click(object sender, EventArgs e)
        {
            //To Display a Save Dialouge so User Can Save Image 
            SaveFileDialog Save_Location_Object = new SaveFileDialog();

            //File Type allocated here
            Save_Location_Object.Filter = "Text|*.txt";

            //Assign a Location for Document to be Saved 
            if (Save_Location_Object.ShowDialog() == DialogResult.OK)
            {
                Save_Location_textBox.Text = Save_Location_Object.FileName;
            }

            // Else show the TextBox as Empty
            else
            {
                Save_Location_textBox.Text = "";
            }


        }

        private void Save_Location_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox_PrimeNo_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }


        private void button5_Click(object sender, EventArgs e)
        {
            //Calculating Value of N by calling Function From RSA_Algorithm Implementation Class on both Prime Numbers

            N = Cryptography.RSA_Algorithm_Implementation.Value_of_N_Calculator(Prime_Number_1, Prime_Number_2);


            //Encrytion of Image function called on Load and Save object that has image stored in form of bitmap 
            String encrypt_image;
            encrypt_image = Encryption_Of_Image(Load_and_Save);

            // To Create A new File Write that Specific String to that File and then Close that File
            File.WriteAllText(Save_Location_textBox.Text, encrypt_image);

            MessageBox.Show("Encryption Successfully Performed and File was Saved at Your Specified Location");

        }



        // Incomplete
        // Function for Encrytion of Image
        public string Encryption_Of_Image(string Input_Image)
        {
            String temp = "";

           // Input Image Recieved Assigned to Converted_Image Object
            string Converted_Image_To_ByteArray = Input_Image;

            //String Converted To Char Array 
            char[] Array = Converted_Image_To_ByteArray.ToCharArray();

            // to Show user how much encrytion has been done
            ENCRYTION_progressBar.Maximum = Array.Length;


            for (int i = 1; i < Array.Length; i++ )
            {

              ENCRYTION_progressBar.Value = i;

          
              if (temp == "")
              {
                    temp = temp + Cryptography.RSA_Algorithm_Implementation.Generator(Array[i], Value_of_E, N);
              }
                

              else
              {
                  temp = temp + "#"+ Cryptography.RSA_Algorithm_Implementation.Generator(Array[i], Value_of_E, N);
              }

            }

                return temp;
        }

    }


    }


