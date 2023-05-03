using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sticky_Tool
{
    public partial class gui : Form
    {
        public gui()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (textBox1.Text != "")
            {
                button1.Enabled = true;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var oldEXE = comboBox1.Text.Split(' ')[0];
                var newEXE = FileSelector.FileName;
                Methods.Stick(oldEXE, newEXE);
                string title = "Success!";
                string message = $"{oldEXE} has been restored successfully.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                string title = "Failed!";
                string message = err.Message;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                var oldEXE = comboBox1.Text.Split(' ')[0];
                Methods.Restore(oldEXE);
                string title = "Success!";
                string message = $"{oldEXE} has been restored successfully.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                string title = "Failed!";
                string message = err.Message;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileSelector.ShowDialog();
            textBox1.Text = FileSelector.FileName;
            if (comboBox1.Text != "" && textBox1.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void FileSelector_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
