using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Client.VRConnection.Forms.Program
{
    public partial class Form1 : Form
    {
        private readonly List<Client> _clients = new List<Client>();
        private readonly VrConnection _connection;
        private int _selectedIndex;
        public Tunnel Tunnel { get; set; }

        public Form1()
        {
            InitializeComponent();
            _connection = new VrConnection("145.48.6.10", 6666, this);
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
                    var request = "{\"id\" : \"tunnel/create\", \"data\" : { \"session\" : \"" + clientId +
                                  "\", \"key\" : \"NotConCat\" } }";
                    _connection.SendMessage(request);
                    this.Visible = false;
                    Tunnel = new Tunnel(_connection, name);
                    Tunnel.CreateScene();
                    //Tunnel.CreateProps();
                    this.Dispose();
                }
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            _clients.Clear();
            listBox1.Items.Clear();
            var request = "{\"id\" : \"session/list\"}";

            _connection.SendMessage(request);
        }

        public void FillConnectionList()
        {
            for (var i = 0; i < _connection.JsonRawData.data.Count; i++)
                _clients.Add(new Client(_connection.JsonRawData.data[i].id,
                    _connection.JsonRawData.data[i].clientinfo.user));

            _clients.Sort();

            for (var i = 0; i < _clients.Count; i++)
                listBox1.Items.Add(_clients[i].Name);
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedIndex = listBox1.SelectedIndex;
        }
    }
}