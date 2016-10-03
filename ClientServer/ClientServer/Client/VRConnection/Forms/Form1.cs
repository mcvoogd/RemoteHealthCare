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
using VRFrom_Gijs.Program;

namespace VRFrom_Gijs.Forms
{
    public partial class Form1 : Form
    {
        private int _selectedIndex;
        private Connection _connection;
        private List<Client> _clients = new List<Client>();

        public Form1()
        {
            InitializeComponent();
            _connection = new Connection("145.48.6.10", 6666, this);
            var thread = new Thread(_connection.StartConnection);
            thread.Start();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (_connection.JsonRawData.data.Count > 0)
            {
                listBox1.Items.Clear();
                var clientId = _clients[_selectedIndex].Id;
                var name = _clients[_selectedIndex].Name;
                if (clientId != null)
                {
                    string request = "{\"id\" : \"tunnel/create\", \"data\" : { \"session\" : \"" + clientId +
                                     "\", \"key\" : \"NotConCat\" } }";
                    _connection.SendMessage(request);
                    var tunnelCommandForm = new TunnelCommandForm(_connection, name);
                    tunnelCommandForm.Show();
                }
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            _clients.Clear();
            listBox1.Items.Clear();
            string request = "{\"id\" : \"session/list\"}";

            _connection.SendMessage(request);
        }

        public void FillConnectionList()
        {
            for (int i = 0; i < _connection.JsonRawData.data.Count; i++)
            {
                _clients.Add(new Client(_connection.JsonRawData.data[i].id,
                    _connection.JsonRawData.data[i].clientinfo.user));
            }

            _clients.Sort();

            for (int i = 0; i < _clients.Count; i++)
            {
                listBox1.Items.Add(_clients[i].Name);
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedIndex = listBox1.SelectedIndex;
        }
    }

    }

