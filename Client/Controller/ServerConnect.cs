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

            String str = "20~Ip addr: " + myIp + " Connected to server.";


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

            Stream stm = tcpclnt.GetStream();

            stm.Write(ba, 0, ba.Length);

            byte[] bb = new byte[256];
            int k = stm.Read(bb, 0, 256);
            string test = "";
            for (int i = 0; i < k; i++)
            {
                test += Convert.ToChar(bb[i]);
            }
            char[] separator = { '~' };
            String[] paramStr = test.Split(separator);

            Model.Base64Converter cnwt = new Model.Base64Converter();
            String ttt = "";

            if (paramStr.Length > 1)
            {
                ttt = cnwt.decodeBase64string(paramStr[1]);
            }

            Console.WriteLine(paramStr[0] + " XXXXXXXXXXXXXXXXXX " + ttt); // only correct value
            Client.Controller.ServiceCodeNumber codeService = new Controller.ServiceCodeNumber();
            codeService.codeArg(paramStr[0], ttt);
        }
    }
}