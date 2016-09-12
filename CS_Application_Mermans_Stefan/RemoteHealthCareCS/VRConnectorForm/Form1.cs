using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRConnectorForm
{
    public partial class Form1 : Form
    {
        private int _selectedIndex;


        Connection connection;
        public Form1()
        {
            InitializeComponent();
            connection = new Connection("84.24.41.72", 6666,this);
            var thread = new Thread(connection.StartConnection);
            thread.Start();

            if (connection.JsonRawData != null)
            {
               
            }
        }

        public void DataGotEvent(object sender, EventArgs e)
        {
            
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(connection.JsonRawData.data[_selectedIndex].id);
        }



        public void FillConnectionList()
        {
            Console.WriteLine("FILLING!");
            for (int i = 0; i < connection.JsonRawData.data.Count; i++)
            {
                listBox1.Items.Add(connection.JsonRawData.data[i].clientinfo.user);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedIndex = listBox1.SelectedIndex;
        }
    }
}
