using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Server.BigDB
{
    public class BigDatabase
    {
        public List<Client> Clients { get; set; }

        public BigDatabase()
        {
            Clients = new List<Client>();
        }

        public void AddClient(Client client)
        {
            var alreadyThere = Enumerable.Contains(Clients, client);
            if (!alreadyThere) { Clients.Add(client); }
        }

        #region saving and loading clients

        public void SaveClients(string filePath)
        {
            Console.WriteLine("Woehoe.!.?");
            WriteToJsonFile<Client>(filePath, Clients);
        }

        public void LoadClients(string filePath)
        {
            ReadFromJsonFile(filePath);
        } 

        #endregion

        #region GetClientById methods

        public Client GetClientById(int id)
        {
            foreach (var client in Clients)
            {
                if (!client.UniqueId.Equals(id)) continue;
                return client;
            }
            return new Client("fout.","...ookfout", null,0,null);
        }

        public bool GetClientById(int id, out Client clientOut)
        {
            foreach (var client in Clients)
            {
                if (!client.UniqueId.Equals(id)) continue;
                clientOut = client;
                return true;
            }
            clientOut = null;
            return false;
        }

        #endregion

        #region JsonWrite and Read methods

        private static void WriteToJsonFile<T>(string filePath, List<Client> clients, bool append = true)
        {
            TextWriter writer = null;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                try
                {
                    var contentsToWriteToFile = JsonConvert.SerializeObject(clients);
                    writer = new StreamWriter(filePath, append);
                    writer.WriteLine(contentsToWriteToFile);
                }
                finally
                {
                    writer?.Close();
                }
            }
            else
            {
                try
                {
                    var contentsToWriteToFile = JsonConvert.SerializeObject(clients);
                    writer = new StreamWriter(filePath, append);
                    writer.WriteLine(contentsToWriteToFile);
                }
                finally
                {
                    writer?.Close();
                }
            }
        }

        private void ReadFromJsonFile(string filePath)
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                var c = JsonConvert.DeserializeObject<List<Client>>(fileContents);
                foreach (var toAdd in c)
                {
                    if (!Clients.Contains(toAdd))
                    {
                        Clients.AddRange(c);
                    }
                }
            }
            finally
            {
                reader?.Close();
            }
        }

        #endregion
    }
}
