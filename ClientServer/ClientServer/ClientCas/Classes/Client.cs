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
        private readonly Form1 _form;
        private string _ip;
        private readonly bool _connected;
        private readonly TcpClient _client;
        private readonly SslStream _stream;
        private SerialPort _serialPort;

        private static bool ValidateServerCertificate(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }

        public Client(Form1 form, string ip)
        {
            this._form = form;
            this._ip = ip;

            try {
                _client = new TcpClient(ip, 6969);
                _stream = new SslStream(_client.GetStream(),false,new RemoteCertificateValidationCallback(ValidateServerCertificate),null);
                _stream.AuthenticateAsClient("RemoteHealthCare");
                _connected = _client.Connected;
                if (_connected)
                {
                    Console.WriteLine("Connected!");
                    form.addNormalMessage("Connected to server with IP: " + ip);
                    form.addNormalMessage("Waiting for connection with the bike...");
                }
                    Console.WriteLine("Connected: " + _client.Connected);
            }
            catch(SocketException ex) {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Some error 1");
            }
            catch(Exception ex){
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Some error 2");
            }
            ReadThread();
        }

        public bool GetConnection(){
            return _connected;
        }

        public void ReadThread()
        {
            while (true)
            {
                byte[] buffer = new byte[4];
                do
                {
                    int read = _stream.Read(buffer, 0, buffer.Length);
                    _form.addNormalMessage("ReadMessage: " + read);
                } while (_client.GetStream().DataAvailable);
            }
        }
    }
}
