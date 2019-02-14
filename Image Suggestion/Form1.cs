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
using System.Reflection;


namespace Image_Suggestion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

   

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
    
        }

        

            Dictionary<String, String[]> myDictionary = new Dictionary<string, String[]>()   // Dictionary with key as String & values as string arrays
            {
                { "apple", new String[] { "apple1.jpg", "apple2.jpg" } },       //Key is referred to search by user and value array contains the image names               
                { "ball", new String[] {"ball1.jpg","ball2.png" } },
            };
        

     

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)                            //This action is performed after user clicks enter
            {
                String key = textBox1.Text;
                if (myDictionary.ContainsKey(key))                       //Checks if the entered key is in dictionary
                {
                    String[] res = myDictionary[key];                    //Obtains the array of image names for that term

                    String firstPic = res[0];                               
                    String secondPic = res[1];
                    var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);   //This stores the path of the output directory of the project, here it is 'Debug' folder of this project
                    var firstBox = Path.Combine(outPutDirectory, "Image\\" + firstPic);                      // Now, firstBox has the relative path of the image existing in 'Image' folder which is pasted in 'Debug' folder
                    var secondBox = Path.Combine(outPutDirectory, "Image\\" + secondPic);
                    String first_Box = new Uri(firstBox).LocalPath;
                    String second_Box = new Uri(secondBox).LocalPath;
                    pictureBox1.ImageLocation = first_Box;              
                    pictureBox2.ImageLocation = second_Box;
                } else
                {
                    MessageBox.Show("Cannot find Image for this term");                     //Message is displayed, if the term is not found in the key of dictionary
                }     
            }
        }

        
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                String boxKey = richTextBox1.Text;
                String key = boxKey.Replace("\n", "");              //replaces the new line character added to the term entered
                if (myDictionary.ContainsKey(key)) { 
                
                String[] results = myDictionary[key];
                   
                        String thirdPic = results[0];
                        String fourthPic = results[1];
                        var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                        var thirdBox = Path.Combine(outPutDirectory, "Image\\" + thirdPic);
                        var fourthBox = Path.Combine(outPutDirectory, "Image\\" + fourthPic);
                        String third_Box = new Uri(thirdBox).LocalPath;
                        String fourth_Box = new Uri(fourthBox).LocalPath;
                        pictureBox3.ImageLocation = third_Box;
                        pictureBox4.ImageLocation = fourth_Box;
                    
                }
                else
                {
                    MessageBox.Show("Cannot find Image for this term");
                }
            }
        }
    }
        }
    
