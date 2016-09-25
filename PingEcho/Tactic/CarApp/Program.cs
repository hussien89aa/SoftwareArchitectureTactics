using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarApp
{
    class Program
    {
       static String ServerIP = "127.0.0.1";
    

        static TcpListener MYTcpListener;
        static Socket MySocket;
        static string TextInput = "";
       static Boolean IsWorking = true;
        public static int MainServerPort = 9005;
        public static int BackupServerPort = 9006;
        public static int ServerPort;
        static void Main(string[] args)
        {
            ServerPort = MainServerPort; //defaul use main server

            Console.WriteLine("This App will be working on the Car to send car location to the server");
            Thread myth;
            //start server
            myth = new Thread(new System.Threading.ThreadStart(REcivedData));
            myth.Start();
            // start hartbeat sender
            HeartBeatSender harbean = new HeartBeatSender();
            Console.ReadKey();
        }

        //reading car location
        static public void REcivedData()
        {
            try
            {
                ManageLocation manageLocation = new ManageLocation();
                Console.WriteLine("Car App is working");
                PingSender pingSender = new PingSender();
                while (IsWorking)
                {
          
                    Random rnd = new Random();
                    double log = rnd.Next(2232, 345344533); // creates a number between 2232 and 345344533
                    double lat = rnd.Next(2232, 345344343);   // creates a number between 2232 and 345344533

                    String LastLocation = "Car Location:log:"+ log + ",lat:"+ lat;
                  Boolean IsDelivered =  pingSender.ping(ServerIP, ServerPort, LastLocation);
                   

                    Thread.Sleep(pingSender.TimeInterval);
                }
                Console.WriteLine("Car App is Stopped");
            }
            catch (Exception ex2)
            {
                //MessageBox.Show(ex2.Message);
            }
        }


    }
}
