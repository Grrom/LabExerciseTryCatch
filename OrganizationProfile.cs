using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExerciseTryCatch
{
    public partial class OrganizationProfile : Form
    {
        public OrganizationProfile()
        {
            InitializeComponent();
        }

        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        private string _FullName;

        private void OrganizationProfile_Load(object sender, EventArgs e)
        {

            string[] ListOfProgram = {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management",
            };

            for (int i = 0; i < 6; i++)
            {
                comboBox2.Items.Add(ListOfProgram[i].ToString());
            }
        }
        public long? StudentNumber(string studNum)
        {
            try
            {
                _StudentNo = long.Parse(studNum);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                return null;
            }
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }

            return _Age;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(textBox2.Text, textBox5.Text, textBox6.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(textBox1.Text);
                StudentInformationClass.SetProgram = comboBox2.SelectedItem.ToString();
                StudentInformationClass.SetGender = comboBox1.SelectedItem.ToString();
                StudentInformationClass.SetContactNo = ContactNo(textBox7.Text);
                StudentInformationClass.SetAge = Age(textBox3.Text);
                StudentInformationClass.SetBirthday = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                if (StudentInformationClass.SetContactNo == 0)
                {
                    MessageBox.Show("Invalid Contact No");
                }
                else if (StudentInformationClass.SetAge == 0)
                {
                    MessageBox.Show("Invalid Age");
                }
                else
                {
                    new Confirmation().ShowDialog();
                }
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception);

                String errors = "Check your inputs \n";

                if (StudentInformationClass.SetFullName == null) errors += "Name \n";
                if (StudentInformationClass.SetProgram == null) errors += "Program \n";
                if (StudentInformationClass.SetStudentNo == null) errors += "Student No \n";
                if (StudentInformationClass.SetGender == null) errors += "Gender \n";
                if (StudentInformationClass.SetContactNo == null) errors += "ContactNo \n";
                if (StudentInformationClass.SetAge == null) errors += "Age \n";
                if (StudentInformationClass.SetBirthday == null) errors += "BirthDay \n";

                MessageBox.Show(errors);
            }
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            new FrmStudentRecord().Show();
        }
    }
}
