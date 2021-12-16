using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabExerciseTryCatch
{
    public partial class Confirmation : Form
    {
        public Confirmation()
        {
            InitializeComponent();
        }

        private async void Confirmation_Load(object sender, EventArgs e)
        {
            label8.Text = StudentInformationClass.SetStudentNo.ToString();
            label9.Text = StudentInformationClass.SetFullName;
            label10.Text = StudentInformationClass.SetProgram;
            label11.Text = StudentInformationClass.SetAge.ToString();
            label12.Text = StudentInformationClass.SetBirthday;
            label13.Text = StudentInformationClass.SetGender;
            label14.Text = StudentInformationClass.SetContactNo.ToString();

            await File.WriteAllLinesAsync(StudentInformationClass.SetStudentNo + ".txt", StudentInformationClass.allValues());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
