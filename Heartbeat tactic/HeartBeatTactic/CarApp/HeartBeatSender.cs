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
    class HeartBeatSender
    {
       TcpListener MYTcpListener;
        Socket MySocket;
        string TextInput = "";
         Boolean IsWorking = true;
        static String ServerIPheartbeat = "127.0.0.1";
        public HeartBeatSender()
        {
           
          
                Thread myth;
                //start the  heartbeat sender
                myth = new Thread(new System.Threading.ThreadStart(REcivedData));
                myth.Start();

                Console.ReadKey();
            
        }

          public void REcivedData()
        {
            try
            {

                Console.WriteLine("Car heartbeat is working");
                ManageLocation manageLocation = new ManageLocation();

                while (IsWorking)
                {
                   
                    String LastLocation = "I am a live";
                    manageLocation.send_Data(ServerIPheartbeat, 9004, LastLocation);
                    Thread.Sleep(2000);
                }
                Console.WriteLine("Car heartbeat is Stopped");
            }
            catch (Exception ex2)
            {
                //MessageBox.Show(ex2.Message);
            }
        }

        public void send_Data(string ip_adderss, int port_number, string the_message)
        {
            try
            {
                TcpClient myclient981 = new TcpClient(ip_adderss, port_number);
                NetworkStream myns981 = myclient981.GetStream();
                StreamWriter mysw981 = new StreamWriter(myns981);
                mysw981.Write(the_message);
                mysw981.Close();
                myns981.Close();
                myclient981.Close();


            }
            catch (Exception ex)
            {// miss connection to the server switch to backup server
                Console.WriteLine(ex.Message);
            }
        }
    }
}
