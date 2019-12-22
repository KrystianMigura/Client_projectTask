using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace Client.Options
{
    class ConnectToServer
    {
        public ConnectToServer() { }

        protected TcpClient tcpclnt { get; set; }
        protected string myIpAddr { get; set; }
        public void myIp()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            myIpAddr = myIP;
        }

        public void createConnect()
        {
            //kod 100
            tcpclnt = new TcpClient();
            tcpclnt.Connect("127.0.0.1", 10000);

            myIp();
            DateTime localDate = DateTime.Now;

            String str = "#100~ " + localDate + " -> connect from :" + myIpAddr; ;


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
        }

        public void sendMessage(string text)
        {

            String str = text;
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
        }

    }
}
