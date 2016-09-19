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
using System.IO.Ports;

namespace ClientCas
{
    class Client
    {
        private Form1 form;
        private string ip;
        private bool connected;
        private TcpClient client;
        private SslStream stream;
        private SerialPort SerialPort;

        public Client(Form1 form, string ip)
        {
            this.form = form;
            this.ip = ip;

            try {
                client = new TcpClient(ip, 6969);
                stream = new SslStream(client.GetStream());
                stream.AuthenticateAsClient("Stefan Mermans");
                connected = client.Connected;
                if (connected)
                {
                    Console.WriteLine("Connected!");
                    form.addNormalMessage("Connected to server with IP: " + ip);
                    form.addNormalMessage("Waiting for connection with the bike...");
                }
                    Console.WriteLine("Connected: " + client.Connected);
            }
            catch(SocketException ex) {
                Console.WriteLine(ex.ToString());
            }
            catch(Exception ex){
                Console.WriteLine(ex.ToString());
            }
            readThread();
        }

        public bool getConnection(){
            return connected;
        }

        public void readThread()
        {
            while (true)
            {
                byte[] buffer = new byte[4];
                do
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    form.addNormalMessage("ReadMessage: " + read);
                } while (client.GetStream().DataAvailable);
            }
        }
    }
}
