using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace BigDB
{
    class BigDatabase
    {
        public List<Client> ClientRegister { get; set; }

        public BigDatabase()
        {
            ClientRegister = new List<Client>();
        }

        public void addClientToRegister(Client client)
        {
            var alreadyThere = false;
            foreach (var c in ClientRegister)
            {
                if (c.Equals(client))
                {
                    alreadyThere = true;
                    break;
                }
            }

            if (!alreadyThere) { ClientRegister.Add(client); }
            //Maybe add a clienthandler on the else.
        }

        public void printFile()
        {
            StreamWriter file = new StreamWriter("C:/Users/Menno/Documents/clientlist/clients.txt", true);
            file.WriteLine(ClientRegister.Count());
            foreach (Client c in ClientRegister)
            {
                Console.WriteLine("{0}-{1}-{2}", c.name, c.tunnelID, c.uniqueID);
                file.WriteLine("{0}-{1}-{2}", c.name, c.tunnelID, c.uniqueID);
            }
            file.Dispose();
        }

        private void WriteToJsonFile<T>(string filePath, Client objectToWrite, bool append = false)
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public Client ReadFromJsonFile<Client>(string filePath)
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Client>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        //Okay, so the for loop works because of a bug... Not going to fix it right now but it's there
        //public void readFile()
        //{
        //    StreamReader file = new StreamReader("C:/Users/Menno/Documents/clientlist/clients.txt", true);
        //    Console.WriteLine(file.ReadLine());
        //    string counterString = file.ReadLine();
        //    int counterInt;
        //    int.TryParse(counterString, out counterInt);
        //    Console.WriteLine(counterInt);
        //    for (int i = 0; i < counterInt; i++)
        //    {
        //        string allInfo = file.ReadLine();
        //        Console.WriteLine(allInfo);
        //        string[] allString = allInfo.Split('-');
        //        clientRegister.Add(new Client(allString[0], allString[1], allString[2], null));
        //    }
        //    foreach(Client c in clientRegister)
        //    {
        //        Console.WriteLine("{0}-{1}-{2}", c.name, c.tunnelID, c.uniqueID);
        //    }
        //}
    }
}
