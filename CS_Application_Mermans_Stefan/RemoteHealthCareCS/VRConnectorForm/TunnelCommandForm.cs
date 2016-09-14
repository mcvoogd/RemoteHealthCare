using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRConnectorForm
{
    public partial class TunnelCommandForm : Form
    {
        private Connection _connection;
        private string Name { get; set; }

        public TunnelCommandForm(Connection connection, String name)
        {
            InitializeComponent();
            this.Name = name;
            ;
            ;   //  Console.WriteLine(connection.TunnelID + " <- ID");
            _connection = connection;
        }

        private void sedCommandButton_Click(object sender, EventArgs e)
        {        
            string req =
                "{ \"id\" : \"tunnel/send\", \"data\" : {\"dest\" :\"" + _connection.TunnelID +
                "\", \"data\" : { \"id\" : \"scene/node/add\", \"data\" : { \"name\" : \"car\", \"components\" : { \"transform\" : { \"position\" : [ 0, 0, 0 ], \"scale\" : 0.025 , \"rotation\" : [ 0, 0, 0 ] }, \"model\" : { \"file\" : \"data/NetworkEngine/models/cars/white/car_white.obj\" } } } } } }";
            _connection.sendMessage(req);
            Console.WriteLine(_connection.TunnelID);
            //http://pastebin.com/0Mqx8EgY
        }

        private void StatisticsButton_Click_1(object sender, EventArgs e)
        {
            if (TunnelId.Text == "")
            {
                TunnelId.Text = "User ID : " + _connection.TunnelID;
                NameLabel.Text = "User : " + Name;
            }
            else
            {
                TunnelId.Text = "";
                NameLabel.Text = "";

            }
        }

        private void NameLabel_Click(object sender, EventArgs e)
        {

        }

        private void TunnelCommandForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string req = "{ \"id\" : \"tunnel/send\", \"data\" : {\"dest\" :\"" + _connection.TunnelID +
  "\", \"data\" : { \"id\" : \"scene/node/add\", \"data\" : { \"name\" : \"panel\", \"components\" : {\"panel\" : { \"size\" : [ 1, 1 ], \"resolution\" : [ 512, 512 ], \"background\" : [ 1, 1, 1, 1] }}}}}}";
            _connection.sendMessage(req);
        }
    }
}
