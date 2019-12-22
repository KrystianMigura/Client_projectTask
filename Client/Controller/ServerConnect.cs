using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace Client.Controller
{
   public class ServerConnect
    {
        public ServerConnect() { }

        private String myIp { get; set; }

        protected void getMyIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    myIp = ip.ToString();
                }

            }
        }

        public TcpClient connect()
        {
            getMyIp();

            TcpClient tcpclnt = new TcpClient();
            tcpclnt.Connect("127.0.0.1", 10000);

            Console.WriteLine("Connecting.....");

            // use the ipaddress as in the server program



            Console.WriteLine("Connected");
            Console.Write("Enter the string to be transmitted : ");

            String str = "Ip addr: " + myIp + " Connected to server.";


            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Transmitting.....");

            Stream stm = tcpclnt.GetStream();

            stm.Write(ba, 0, ba.Length);
            byte[] bb = new byte[256];
            int k = stm.Read(bb, 0, 256);
            string test = "";
            for (int i = 0; i < k; i++)
                test += Convert.ToChar(bb[i]);

            Console.WriteLine(test);// automatyczna odpowiedź z servera !! jupi

            return tcpclnt;
        }


        public void sendMessage(String str, TcpClient tcpclnt)
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Transmitting.....");

            for (var j = 0; j < 2; j++)
            {
                Stream stm = tcpclnt.GetStream();

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[256];
                int k = stm.Read(bb, 0, 256);
                string test = "";
                for (int i = 0; i < k; i++)
                    test += Convert.ToChar(bb[i]);
                if(j == 1)
                    if(test == "200")
                    {
                        MessageBox.Show("You have access!!", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("You DONT have access!!", "ERR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
            }
            }
    }
}