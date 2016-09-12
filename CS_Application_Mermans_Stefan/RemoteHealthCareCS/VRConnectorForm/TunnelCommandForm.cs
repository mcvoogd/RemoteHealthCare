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
        private string _tunnelId;
        private Connection _connection;

        public TunnelCommandForm(string tunnelId, Connection connection)
        {
            InitializeComponent();
            TunnelId.Text = tunnelId;
            _connection = connection;
        }

        private void sedCommandButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Sending car");
            string message = "{\"id\": \"tunnel/send\",\"data\": {\"dest\": \"_tunnelId \",\"data\": {\"id\": \"scene/node/add\",\"data\": {\"name\": \"car\",\"components\": {\"transform\": {\"position\": [ 0, 0, 0 ],\"scale\": [ 1, 1, 1 ],\"rotation\": [ 0, 0, 0 ]},\"model\": { \"file\": \"data/NetworkEngine/models/cars/white/car_white.obj\" }}}}}}";
            _connection.sendMessage(message);
        }
    }
}
