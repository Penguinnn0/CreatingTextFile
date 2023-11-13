using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatingTextFile
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        public static String FileName;
        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                "BS in Information Technology",
                "BS in Computer Engineering",
                "BS in Computer Science",
                "BS in Hospitality Management",
                "BS in Culinary Management",
                "Bachelor of Multimedia Arts"
            };

            for (int i = 0; i < 6; i++)
            {
                cbProgram.Items.Add(ListOfProgram[i].ToString());
            }

            string[] Gender = new string[]
            {
                "Female","Male", "Other"
            };

            for (int i = 0; i < 3; i++)
            {
                cbGender.Items.Add(Gender[i].ToString());
            }

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            String LastName, FirstName, MiddleInitial, Program, Gender, Birthday, Name;
            int StudNum, Age;
            long ContactNum;

            LastName = tbLastName.Text;
            FirstName = tbFirstName.Text;
            MiddleInitial = tbMiddleInitial.Text;
            Program = cbProgram.Text;
            Gender = cbGender.Text;
            Birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");

            StudNum = Convert.ToInt32(tbStudNum.Text);
            Age = Convert.ToInt32(tbAge.Text);
            ContactNum = long.Parse(tbContactNum.Text);

            Name = "Name";

            string[] RegistrationPrint =
            {
                lblStudNum.Text.ToString() + ": " + StudNum, Name + ": " + LastName + ", " + FirstName + " " + MiddleInitial,
                lblProgram.Text.ToString() + ": " + Program,
                lblGender.Text.ToString() + ": " + Gender,
                lblAge.Text.ToString() + ": " + Age,
                lblBirthday.Text.ToString() + ": " + Birthday,
                lblContactNum.Text.ToString() + ": " + ContactNum,
            };

            FileName = StudNum + ".txt";
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, FileName)))
            {
                foreach (var content in RegistrationPrint)
                {
                    outputFile.WriteLine(content);
                }
            }

            MessageBox.Show ("You are now Registered!", "Registered!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tbStudNum.Clear();
            tbLastName.Clear();
            tbFirstName.Clear();
            tbMiddleInitial.Clear();
            tbAge.Clear();
            tbContactNum.Clear();
            cbGender.SelectedIndex = -1;
            cbProgram.SelectedIndex = -1;
            dtpBirthday.Value = DateTime.Now;

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmStudentRecord frmStudentRecord = new FrmStudentRecord();
            frmStudentRecord.ShowDialog();

            Close();
        }
    }
}
