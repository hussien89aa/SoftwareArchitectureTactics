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
        static Boolean IsWorking = true;
        static TcpListener MYTcpListener;
        static Socket MySocket;
        static string TextInput = "";
        static int PortNumber= 9005; // for main server
        static void Main(string[] args)
        {

            
            Console.WriteLine("This App will be working on the server to recive last user location");
            Console.WriteLine("Which server you use, select?\n 1-Main server\n2-Backup server\n");
            int ServerID =Convert.ToInt32( Console.ReadLine());
            if (ServerID == 2)
            {
                PortNumber = 9006; // for back up server
                Console.WriteLine("back up server is started");
            }
            else
            {
                Console.WriteLine("Main server is started");
            }

            Thread myth;
            //start server
            myth = new Thread(new System.Threading.ThreadStart(REcivedData));
            myth.Start();

            Console.ReadKey();
        }

        //reading car location
        static public void REcivedData()
        {
            try
            {
                MYTcpListener = new TcpListener(IPAddress.Any, PortNumber);
                MYTcpListener.Start();
                Console.WriteLine("Server is working");
                while (IsWorking)
                {
                    try
                    {
                        MySocket = MYTcpListener.AcceptSocket();
                        NetworkStream MyNetworkStream = new NetworkStream(MySocket);
                        StreamReader mysr = new StreamReader(MyNetworkStream);
                        TextInput = mysr.ReadToEnd();
                        Console.WriteLine(TextInput);

                    }
                    catch (Exception ex)
                    {
                        //  MessageBox.Show(ex.Message);
                    }
                }
                Console.WriteLine("Server is Stopped");
            }
            catch (Exception ex2)
            {
                //MessageBox.Show(ex2.Message);
            }
        }
    }
}
