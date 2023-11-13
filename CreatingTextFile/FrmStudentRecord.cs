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
    public partial class FrmStudentRecord : Form
    {
        public FrmStudentRecord()
        {
            InitializeComponent();
        }

        private void btnRegis_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmRegistration frmRegistration = new FrmRegistration();
            frmRegistration.ShowDialog();

            Close();
        }
        public void DisplayToList()
        {
            
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            String path = openFileDialog1.FileName;

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName;
            try
            {
                using (StreamReader streamReader = File.OpenText(path))
                { 
                string _getText = "";
                    
                while ((_getText = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(_getText);
                    lvShowText.Items.Add(_getText);
                }
            }
        }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File does not exist!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Record has been Uploaded!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lvShowText.Items.Clear();
        }
    }
}
