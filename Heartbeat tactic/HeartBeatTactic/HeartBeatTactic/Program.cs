using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeartBeatTactic
{
    class Program
    {
        static Boolean IsWorking = true;
        static TcpListener MYTcpListener;
        static Socket MySocket;
        static string TextInput = "";
        static DateTime LastUpdateTime;
        static int CheckingInterval = 3000;//we chekc every 3 sec
        static int ExpireTime = 5; // expire after 5 sec
        static void Main(string[] args)
        {
            LastUpdateTime = DateTime.Now;
            string startupPath = Environment.CurrentDirectory;
           // Console.WriteLine(startupPath);
           Console.WriteLine("This App will be harbeat that monitor  car app, \n it user port 9004");
            Thread myth;
            //start server
            myth = new Thread(new System.Threading.ThreadStart(HeartBeatReciver));
            myth.Start();

            Thread myth1 = new Thread(new System.Threading.ThreadStart(CheckAlive));
            myth1.Start();

            Console.ReadKey();
        }

        //update last time we recive car location  
        static void UpdateTheTime()
        {
            LastUpdateTime = DateTime.Now;
        }
        // check if the car is alive
        static void CheckAlive()
        {
            while (IsWorking)
            {
                Thread.Sleep(CheckingInterval);
                // rerun the user app
                TimeSpan span = DateTime.Now.Subtract(LastUpdateTime);
                if (span.TotalSeconds> ExpireTime)
                {
                    Console.WriteLine("Re-Run the App again");
                    //  Process.Start("C:\\Users\\ASUS S550C\\Desktop\\SoftwareArticlureExample\\HeartBeatTactic\\CarApp\\bin\\Debug\\CarApp.exe");
                    Process.Start("CarApp.exe");


                }



            }
        }
        //reading car location
        static public void HeartBeatReciver()
        {
            try
            {
                MYTcpListener = new TcpListener(IPAddress.Any, 9004);
                MYTcpListener.Start();
                Console.WriteLine("heartbeat is working");
                while (IsWorking)
                {
                    try
                    {
                        MySocket = MYTcpListener.AcceptSocket();
                        NetworkStream MyNetworkStream = new NetworkStream(MySocket);
                        StreamReader mysr = new StreamReader(MyNetworkStream);
                        TextInput = mysr.ReadToEnd();
                        Console.WriteLine(TextInput);
                        UpdateTheTime();

                    }
                    catch (Exception ex)
                    {
                        //  MessageBox.Show(ex.Message);
                    }
                }
                Console.WriteLine("heartbeat is Stopped");
            }
            catch (Exception ex2)
            {
                //MessageBox.Show(ex2.Message);
            }
        }
    }
}
