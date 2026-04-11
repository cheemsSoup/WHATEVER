using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationApplication
{
    public partial class Form1 : Form
    {
       public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DisplayInfo(string fullName, string gender, string dob, string program)
        {
            MessageBox.Show("Student Name: " + fullName + "\nGender: " + gender + "\nDate of Birth: " + dob + "\nProgram: " + program);
        }
        private void DisplayInfo(string fullName, string program)
        {
            MessageBox.Show("Student Name: " + fullName + "\nProgram: " + program);
        }
        private void DisplayInfo(string firstName, string lastName, string program)
        {
            MessageBox.Show("Student Name: " + firstName + " " + lastName + "\nProgram: " + program);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;

            string gender = "";
            if (rbMale.Checked)
                gender = "Male";
            else if (rbFemale.Checked)
                gender = "Female";

            string day = cmbDay.SelectedItem != null ? cmbDay.SelectedItem.ToString() : "";
            string month = cmbMonth.SelectedItem != null ? cmbMonth.SelectedItem.ToString() : "";
            string year = cmbYear.SelectedItem != null ? cmbYear.SelectedItem.ToString() : "";
            string program = cmbProgram.SelectedItem != null ? cmbProgram.SelectedItem.ToString() : "";

            string dob = day + " / " + month + " / " + year;
            string fullname = firstName + " " + middleName + " " + lastName;
            
            DisplayInfo(fullname, gender, dob, program);
            DisplayInfo(fullname, program);
            DisplayInfo(firstName,lastName, program);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int day = 1; day <= 31; day++)
            {
                cmbDay.Items.Add(day);
            }

            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August",
                                "September", "October", "November", "December" };
            foreach (string month in months)
                cmbMonth.Items.Add(month);

            for (int year = 1900; year <= DateTime.Now.Year; year++)
            {
                cmbYear.Items.Add(year);
            }

            ArrayList programs = new ArrayList();
            programs.Add("Bachelor of Science in Computer Science");
            programs.Add("Bachelor of Science in Information Technology");
            programs.Add("Bachelor of Science in Information Systems");
            programs.Add("Bachelor of Science in Computer Engineering");

            foreach (string program in programs)
                cmbProgram.Items.Add(program);

            cmbProgram.Items.Insert(0, "-Select Program-");
            cmbProgram.SelectedIndex = 0;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) { 
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select a Student Profile Picture";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(selectedImagePath);
                }
            }  
        }
    }
}
