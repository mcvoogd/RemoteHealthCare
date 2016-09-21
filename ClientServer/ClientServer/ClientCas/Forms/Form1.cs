using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClientCas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void addErrorMessage(string message)
        {
            listBox.Items.Add("ERROR: " + message);
        }

        public void addNormalMessage(string message)
        {
            listBox.Items.Add(message);
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Client client = new Client(this, ipTextBox.Text);
            if (client.GetConnection())
            {
                ipLabel.Visible = false;
                ipTextBox.Visible = false;
                connectButton.Visible = false;
                errorLabel.Visible = false;
                listBox.Visible = true;
            }
            else
            {
                errorLabel.Visible = true;
                listBox.Items.Clear();
            }
        }
    }
}
