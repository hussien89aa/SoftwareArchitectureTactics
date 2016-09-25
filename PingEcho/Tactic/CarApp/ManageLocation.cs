using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace CarApp
{
    class ManageLocation
    {  //This class Deprecaited with Ping Eco tactics
       //send mesg
       /* public void send_Data(string ip_adderss, int port_number, string the_message)
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
                // swich to backup
                if (Program.ServerPort ==Program.MainServerPort) // mai server
                    Program.ServerPort = Program.BackupServerPort;
                else
                    Program.ServerPort = Program.MainServerPort;

                Console.WriteLine("Switch to another server"); 
            }
        }

    */
        public void  send_Data(string ip_adderss, int port_number, string the_message)
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
