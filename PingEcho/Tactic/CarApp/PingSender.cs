using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CarApp
{
    class PingSender
    {
      public int ElapsedTime { get; set; } 
        public int MaxWaitingTime { get; set; }
        public int TimeInterval { get; set; }

        public PingSender()
        {
            TimeInterval = 1000; //1000 milliseconds is interval time between sending
            MaxWaitingTime = 3000;  //3000 milliseconds max waiting fr response form secrver
        }

        public bool ping(string ip_adderss, int port_number, string the_message)
        {
            try
            {
                TcpClient myclient981 = new TcpClient(ip_adderss, port_number);
                myclient981.SendTimeout = MaxWaitingTime;//Ping/Echo max waiting time
                NetworkStream myns981 = myclient981.GetStream();
                StreamWriter mysw981 = new StreamWriter(myns981);
                mysw981.Write(the_message);
                mysw981.Close();
                myns981.Close();
                myclient981.Close();

                return  true;
            }
            catch (Exception ex)
            {// miss connection to the server switch to backup server
                Console.WriteLine(ex.Message);
                // swich to backup server if there is no connection within the time
                //better to add this code here for better performance,
                //so this code willnot execute unless there is no connection
                // becuase our system alreading sending ping so we inclue this one
                //inside our sending location ping
                if (Program.ServerPort == Program.MainServerPort) // mai server
                    Program.ServerPort = Program.BackupServerPort;
                else
                    Program.ServerPort = Program.MainServerPort;

                Console.WriteLine("Switch to another server");

                return false;
            }
        }

 
}
}
