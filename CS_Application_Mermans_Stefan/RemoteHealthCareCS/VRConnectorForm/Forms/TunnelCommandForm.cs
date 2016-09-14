using System;
using System.Windows.Forms;
using VRConnectorForm.Program;
using VRConnectorForm.VRobjects;

namespace VRConnectorForm.Forms
{
    public partial class TunnelCommandForm : Form
    {
        private Connection _connection;
        private new string Name { get; set; }

        public TunnelCommandForm(Connection connection, String name)
        {
            InitializeComponent();
            this.Name = name;
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

        private void GetScene_Click(object sender, EventArgs e)
        {
            string req = "{ \"id\" : \"tunnel/send\", \"data\" : {\"dest\" :\"" + _connection.TunnelID +
  "\", \"data\" : { \"id\":\"scene/get\"}}}";
            _connection.sendMessage(req);

        }

        private void button3_Click(object sender, EventArgs e)
        {
          Node auto = new Node("car", _connection.TunnelID);
              
            _connection.sendMessage(RequestCreater.AddNode(_connection.TunnelID, "car", "data/NetworkEngine/models/cars/white/car_white.obj",
                50, 0, 0));
        }
    }
}
