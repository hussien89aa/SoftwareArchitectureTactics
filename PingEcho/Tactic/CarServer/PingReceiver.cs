using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CarServer
{
    class PingReceiver
    {
        static Boolean IsWorking { get; set; }
        public TcpListener MYTcpListener { get; set; }
        public Socket MySocket { get; set; }
        public string TextInput { get; set; }
        public int PortNumber { get; set; }
        public Boolean BackupCheck { get; set; }
        public PingReceiver()
        {
            IsWorking = true;
            PortNumber = 9005; // for main server
            TextInput = "";
            BackupCheck = false;
        }
            
          

        public void REcivedData()
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
                        
                        //check the backup that syncronize with another server
                        //to start process new user with it
                        if(!BackupCheck)
                        ReadBackupData();
                        Console.WriteLine(TextInput);
                        File.AppendAllText("car_tracking.txt", TextInput+ Environment.NewLine);
                        //var text = File.ReadAllText(@"C:\words.txt");
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

        //reading syncrhonized data between two server
        private void ReadBackupData()
        {
            BackupCheck = true;
            try
            {

   
                string[] lines = File.ReadAllLines("car_tracking.txt");
                Console.WriteLine("------------------------------");
                foreach (string line in lines)
                { 
                Console.WriteLine("Backup data from other server");
                  
                    Console.WriteLine(line);
               
                }
                Console.WriteLine("------------------------------");

            }
            catch (Exception ex) { }
        }
    }
}
