using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VRConnectorForm.Program;
using VRConnectorForm.VRobjects;

namespace VRConnectorForm.Forms
{
    public partial class TunnelCommandForm : Form
    {
        private Connection _connection;
        private string name { get; set; }
        private string ID { get; set; }

        public TunnelCommandForm(Connection connection, String name)
        {
            InitializeComponent();
            this.name = name;
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
        }

        private void StatisticsButton_Click_1(object sender, EventArgs e)
        {
            if (TunnelId.Text == "")
            {
                TunnelId.Text = "User ID : " + ID;
                NameLabel.Text = "User : " + name;
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
        }

        private void GetScene_Click(object sender, EventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Node auto = new Node("car", _connection.TunnelID, "data/NetworkEngine/models/cars/white/car_white.obj", 25, 0, 0);
            Console.WriteLine(auto.SendString);
            _connection.sendMessage(auto.SendString);
            
        }
    }
}
