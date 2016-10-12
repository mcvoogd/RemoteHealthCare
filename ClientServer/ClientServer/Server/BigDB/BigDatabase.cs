using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Server.Server;

namespace Server.BigDB
{
    public class BigDatabase
    {
        public BigDatabase()
        {
            Clients = new List<Client>();
        }

        public List<Client> Clients { get; set; }

        public void AddClient(Client client)
        {
            var alreadyThere = Enumerable.Contains(Clients, client);
            Console.WriteLine($"Adding client: {!alreadyThere}");
            if (!alreadyThere) Clients.Add(client);
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
            return null;
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
                    writer.WriteLine(StringCipher.Encrypt(contentsToWriteToFile, "Password"));
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
                    writer.WriteLine(StringCipher.Encrypt(contentsToWriteToFile, "Password"));
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
                fileContents = StringCipher.Decrypt(fileContents, "Password");
                var c = JsonConvert.DeserializeObject<List<Client>>(fileContents);
                foreach (var toAdd in c)
                    if (!Clients.Contains(toAdd))
                        Clients.AddRange(c);
            }
            finally
            {
                reader?.Close();
            }
        }

        #endregion
    }
}