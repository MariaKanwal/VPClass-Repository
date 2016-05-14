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

        // Values Used In Encryption 
        static int Prime_Number_1;
        static int Prime_Number_2;
        static int Value_of_E;

        //Values Used In Decryption 
        static int Value_of_D;
        static int Value_of_N;

        static string Load_and_Save_Image = "";
        static string Load_and_Save_TextFile = "";


        int n;




        public Crytography_Form()
        {
            InitializeComponent();
        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ENC_Assign_Values_Button3.Text == "Assign Values")
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
                    int VALUE_OF_PHI = Cryptography.RSA_Algorithm_Implementation.Value_Of_N_Calculator((Prime_Number_1 - 1), (Prime_Number_2 - 1));


                    //If e was coprime of n
                    if (Cryptography.Checker.CoPrime_Checker(VALUE_OF_PHI, (int.Parse(textBox_Value_of_E.Text))))
                    {
                        Value_of_E = int.Parse(textBox_Value_of_E.Text);
                    }
                    // if e was not coprime of n
                    else
                    {
                        textBox_Value_of_E.Text = "";
                        MessageBox.Show("Please Enter a Relative Prime Number");
                        return;
                    }

                    //To show that All the Values are assgined for Encryption 
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
            // For Loading TextFile and Reading From Text File
            Load_and_Save_TextFile = File.ReadAllText(Textfile_textBox.Text);


            MessageBox.Show("TextFile Selected was Saved For Decryption ");

        }

        private void Select_button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog OPENIMAGE = new OpenFileDialog();
            OPENIMAGE.Filter = "ImageFile(*.JPG)|*.JPG";      // only accepts JPG Files

            if (OPENIMAGE.ShowDialog() == DialogResult.OK)
            {
                Image_Source_textbox.Text = OPENIMAGE.FileName; // For Taking Image from User
                encrytion_PictureBox.Image = Image.FromFile(Image_Source_textbox.Text); //shows image in the Picture Box

            }

            else
            {
                Image_Source_textbox.Text = "";
            }


        }

        private void SaveImage_Bbutton2_Click(object sender, EventArgs e)
        {
            Load_and_Save_Image = BitConverter.ToString(Conversion.Conversion_To_BYTE_ARRAY(encrytion_PictureBox.Image));
            //For Calling the bitmap image to byte converter function from implementation class with help of BITCONVERTER library 

            MessageBox.Show("Image Selected was Saved For Encryption ");

        }



        private void Store_Location_button4_Click(object sender, EventArgs e)
        {
            //To Display a Save Dialouge so User Can Save Encrypted Image in form Of TextFile
            SaveFileDialog Object_For_TextFile= new SaveFileDialog();

            //File Type allocated here
            Object_For_TextFile.Filter = "Text|*.txt";

            //Assign a Location for Document to be Saved 
            if (Object_For_TextFile.ShowDialog() == DialogResult.OK)
            {
                Save_Image_Location_textBox.Text = Object_For_TextFile.FileName;
            }

            // Else show the TextBox as Empty
            else
            {
                Save_Image_Location_textBox.Text = "";
            }


        }

        private void Save_Location_textBox_TextChanged(object sender, EventArgs e)
        {

        }


        //Incomplete
        private void button6_Click(object sender, EventArgs e)
        {
            //Deccrytion of TextFile function called on Load and Save object that has textfile 

            String decrypt_textfile;

            // Decrytion Function called to decrypt the Text Document 
            decrypt_textfile = Decryption_Of_TextFile(Load_and_Save_TextFile);

            
            // Converting Image Back to Bitmap from Byte 
            // Also Fuunction called to handle the # Sign 
            decryption_pictureBox.Image = Cryptography.Conversion.Conversion_To_BITMAP_IMAGE(Cryptography.Handler.HASH_SIGN_HANDLER(decrypt_textfile));

            MessageBox.Show("Decryption  Successfully Performed ");
        }

        //In complete 

        // Function for Decrytion Of TextFile
        public string Decryption_Of_TextFile( String input)
        {
            // Value for secound array to be used globally 
            int nested = 0 ;

            int Holder , i = 0;

            string temp = "";

            string Funtion_Call_Value = "" ;


          // Input TextFile Recieved Assigned and Converted To Char Array 
           char[]  Arr= input.ToCharArray();

           // to Show user how much decryption  has been done
           DECRYTION_progressBar.Maximum = Arr.Length;


            try
            { 
            // To Decrypt Values Conveted in Char One By One in 
                for (; i < Arr.Length; i++)
                {
                    Application.DoEvents();

                    temp = "";

                    //Value Increased in Progress Bar
                    DECRYTION_progressBar.Value = i;




                    // If their is an actual Value and not # that was used as a seprator this is implemented 
                    for (nested = i; Arr[nested] != '#'; nested++)
                    {
                        temp = temp + Arr[nested];
                    }

                    i = nested;

                    // Converting String Value Calculated in Integer to Apply Formula 
                    Holder = int.Parse(temp);


                    // Main function to produce Decrypted value 
                    Funtion_Call_Value = Funtion_Call_Value + (Cryptography.RSA_Algorithm_Implementation.Generator(Holder, Value_of_D, Value_of_N));
                }
            }

            catch (Exception eee)
            {

            }

            return Funtion_Call_Value;
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

            n = Cryptography.RSA_Algorithm_Implementation.Value_Of_N_Calculator(Prime_Number_1, Prime_Number_2);


            //Encrytion of Image function called on Load and Save object that has image stored in form of bitmap 
            String encrypt_image;
            encrypt_image = Encryption_Of_Image(Load_and_Save_Image);

            // To Create A new File Write that Specific String to that File and then Close that File
            File.WriteAllText(Save_Image_Location_textBox.Text, encrypt_image);

            MessageBox.Show("Encryption Successfully Performed ");

        }




        // Function for Encrytion of Image 
        // Calls the Generation function and gets the finle value to be depicted in file from it 
        public string Encryption_Of_Image(string Input_Image)
        {
            String temp = "";

            // Input Image Recieved Assigned to Converted_Image Object
            string Converted_Image_To_ByteArray = Input_Image;

            //String Converted To Char Array 
            char[] Arr = Converted_Image_To_ByteArray.ToCharArray();

            // to Show user how much encrytion has been done
            ENCRYTION_progressBar.Maximum = Arr.Length;


            for (int i = 0; i < Arr.Length; i++)
            {
                //Value Increased in Progress Bar
                ENCRYTION_progressBar.Value = i;

                // Main function to produce encrypted value bit by bit 
                if (temp == "")
                {
                    temp = temp + Cryptography.RSA_Algorithm_Implementation.Generator(Arr[i], Value_of_E, n);

                }

                // just to seprate the numbers converted 
                else
                {
                    temp = temp + "#" + Cryptography.RSA_Algorithm_Implementation.Generator(Arr[i], Value_of_E, n);
                }

            }
            return temp;
        }

        private void Select_File_button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPEN_TEXT = new OpenFileDialog();
            OPEN_TEXT.Filter = "Text |*.txt";                          //Only Accepts .txt Files

            if (OPEN_TEXT.ShowDialog() == DialogResult.OK)
            {
                Textfile_textBox.Text = OPEN_TEXT.FileName;      //ForTaking Input File From User
            }

            else
            {
                Textfile_textBox.Text = "";
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void DEC_AssignValues_button8_Click(object sender, EventArgs e)
        {

            if (DEC_AssignValues_button8.Text == "Assign Values")
            {

                // To take Input From User and Make sure that all of the textboxes had values

                if (textBox_Value_of_D.Text == "" || textBox_Value_Of_N.Text == "")
                {
                    MessageBox.Show("Please Fill All The Assocaited Feilds");
                }


                else
                {
                    // Assigning value Of D


                    //If number entered is greater than 0  it is assigned 
                    if (int.Parse(textBox_Value_of_D.Text) > 0)
                    {
                        Value_of_D = int.Parse(textBox_Value_of_D.Text);
                    }


                   // Else user is informed 
                    else
                    {
                        textBox_Value_of_D.Text = "";
                        MessageBox.Show("You didn't Enter A Number Greater Than Zero  , Please TRY AGAIN");
                        return;
                    }

                    // Assigning value Of N

                    //If number entered is greater than 0  it is assigned 
                    if (int.Parse(textBox_Value_Of_N.Text) > 0)
                    {
                        Value_of_N = int.Parse(textBox_Value_Of_N.Text);
                    }


                    // Else user is informed
                    else
                    {
                        textBox_Value_Of_N.Text = "";
                        MessageBox.Show("You didn't Enter A Number Greater Than Zero  , Please TRY AGAIN");
                        return;
                    }


                    //To show that All the Values are assgined for Decryption 
                    MessageBox.Show("You Have Sucessfuly Assigned all values");
                }

            }

            else
            {
                textBox_Value_of_D.Text = "";
                textBox_Value_Of_N.Text = "";
            }

        }

        private void Store_TextFile_Location_button7_Click(object sender, EventArgs e)
        {
            //To Display a Save Dialouge so User Can Save Decrypted TextFile in form Of Image
            SaveFileDialog Object_For_Image = new SaveFileDialog();

            //Image Type allocated here
            Object_For_Image.Filter = "JPG |*.JPG";

            //Assign a Location for Image to be Saved 
            if(Object_For_Image.ShowDialog() == DialogResult.OK)
            {
                Save_TextBox_Locaion_textBox.Text = Object_For_Image.FileName;
            }

            // Else show the TextBox as Empty
            else
            {
                Save_TextBox_Locaion_textBox.Text = "";
            }
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }
    }
}
