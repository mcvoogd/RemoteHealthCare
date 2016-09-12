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

        public TunnelCommandForm(Connection connection)
        {
            InitializeComponent();
            TunnelId.Text = connection.TunnelID;
            _connection = connection;
        }

        private void sedCommandButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Sending car");
//            string message = "{\"id\": \"tunnel/send\",\"data\": {\"dest\": \"_tunnelId \",\"data\": {\"id\": \"scene/node/add\",\"data\": {\"name\": \"car\",\"components\": {\"transform\": {\"position\": [ 0, 0, 0 ],\"scale\": [ 1, 1, 1 ],\"rotation\": [ 0, 0, 0 ]},\"model\": { \"file\": \"data/NetworkEngine/models/cars/white/car_white.obj\" }}}}}}";
//            _connection.sendMessage(message);

            string req =
                "{ \"id\" : \"tunnel/send\", \"data\" : {\"dest\" :\""+_connection.TunnelID + "\", \"data\" : { \"id\" : \"scene/node/add\", \"data\" : { \"name\" : \"car\", \"components\" : { \"transform\" : { \"position\" : [ 0, 0, 0 ], \"scale\" : 0.025 , \"rotation\" : [ 0, 0, 0 ] }, \"model\" : { \"file\" : \"data/NetworkEngine/models/cars/white/car_white.obj\" } } } } } }";
            _connection.sendMessage(req);
            Console.WriteLine(_connection.TunnelID);

        }
    }
}
