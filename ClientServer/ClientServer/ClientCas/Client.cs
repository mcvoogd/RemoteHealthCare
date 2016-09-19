using System;
using System.Collections;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace ClientCas
{
    class Client
    {
        private Form1 form;
        private string ip;
        private bool connected;
        private TcpClient client;
        private SslStream stream;

        public Client(Form1 form, string ip)
        {
            this.form = form;
            this.ip = ip;

            try {
                client = new TcpClient(ip, 6969);
                stream = new SslStream(client.GetStream());
                connected = client.Connected;
                if (connected)
                {
                    form.addNormalMessage("Connected to server with IP: " + ip);
                }                
            }
            catch(SocketException ex) {
                Console.WriteLine(ex.ToString());
            }
            catch(Exception ex){
                Console.WriteLine(ex.ToString());
            }
        }

        public bool getConnection(){
            return connected;
        }
    }
}
