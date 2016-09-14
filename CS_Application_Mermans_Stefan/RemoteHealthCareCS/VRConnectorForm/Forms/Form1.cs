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
using VRConnectorForm.Forms;

namespace VRConnectorForm
{
    public partial class Form1 : Form
    {
        private int _selectedIndex;
        private Connection _connection;

        public Form1()
        {
            InitializeComponent();
            _connection = new Connection("84.24.41.72", 6666, this);
            var thread = new Thread(_connection.StartConnection);
            thread.Start();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (_connection.JsonRawData.data.Count > 0)
            {
                listBox1.Items.Clear();
                string clientId = _connection.JsonRawData.data[_selectedIndex].id;
                string name = _connection.JsonRawData.data[_selectedIndex].clientinfo.user;
                if (clientId != null)
                {
                    string request = "{\"id\" : \"tunnel/create\", \"data\" : { \"session\" : \"" + clientId +
                                     "\", \"key\" : \"NotConCat\" } }";
                    _connection.sendMessage(request);
                    TunnelCommandForm tunnelCommandForm = new TunnelCommandForm(_connection, name);
                    tunnelCommandForm.Show();
                }
            }
        
    }

        public void FillConnectionList()
        {
            for (int i = 0; i < _connection.JsonRawData.data.Count; i++)
            {
                listBox1.Items.Add(_connection.JsonRawData.data[i].clientinfo.user);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedIndex = listBox1.SelectedIndex;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string request = "{\"id\" : \"session/list\"}";

            _connection.sendMessage(request);
        }
    }
}
