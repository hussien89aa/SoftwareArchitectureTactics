using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarServer
{
  
    class Program
    {

       
        static void Main(string[] args)
        {

            
            Console.WriteLine("This App will be working on the server to recive last user location");
            Console.WriteLine("Which server you use, select?\n 1-Main server\n2-Backup server\n");
            int ServerID =Convert.ToInt32( Console.ReadLine());
            PingReceiver pingReceiver = new PingReceiver();
            if (ServerID == 2)
            {
                pingReceiver.PortNumber = 9006; // for back up server
                Console.WriteLine("back up server is started");
            }
            else
            {
                Console.WriteLine("Main server is started");
            }

            Thread myth;
            //start server
            myth = new Thread(new System.Threading.ThreadStart(pingReceiver.REcivedData));
            myth.Start();

            Console.ReadKey();
        }

        //reading car location

    }
}
