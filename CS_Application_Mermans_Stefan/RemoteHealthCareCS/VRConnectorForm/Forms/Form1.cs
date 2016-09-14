﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using VRConnectorForm.Program;

namespace VRConnectorForm.Forms
{
    public partial class Form1 : Form
    {
        private int _selectedIndex;
        private Connection _connection;
        private List<Client> clients = new List<Client>();

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
                string clientID = clients[_selectedIndex].ID;
                string name = clients[_selectedIndex].name;
                if (clientID != null)
                {
                    string request = "{\"id\" : \"tunnel/create\", \"data\" : { \"session\" : \"" + clientID +
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
                clients.Add(new Client(_connection.JsonRawData.data[i].id, _connection.JsonRawData.data[i].clientinfo.user));
            }

            clients.Sort();

            for (int i = 0; i < clients.Count; i++)
            {
                listBox1.Items.Add(clients[i].name);
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedIndex = listBox1.SelectedIndex;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            clients.Clear();
            listBox1.Items.Clear();
            string request = "{\"id\" : \"session/list\"}";

            _connection.sendMessage(request);
        }
    }
}