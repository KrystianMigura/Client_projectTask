using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using NetworkCommsDotNet;

namespace Client
{
    public partial class Form1 : Form
    {
        

        public TcpClient connectOptions { get; set; }
        public Controller.ServerConnect a { get; set; }
        public Form1()
        {
            InitializeComponent();
            Controller.ServerConnect createConnect = new Controller.ServerConnect();
            a = createConnect;
            connectOptions = createConnect.connect();
        }
        private TcpClient tcpclnt { get;set;} 

        public void Connect()
        {
            TcpClient tcpclnt = new TcpClient();
            tcpclnt.Connect("127.0.0.1", 10000);
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a.sendMessage("rozlaczenie polaczenia! ", connectOptions);
                connectOptions.Close();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch(Exception err)
            {

                Console.WriteLine(err);
            }
                /*
            this.tcpclnt = new TcpClient();
            Console.WriteLine("Connecting.....");

            tcpclnt.Connect("127.0.0.1", 10000);
            // use the ipaddress as in the server program

            Console.WriteLine("Connected");
            Console.Write("Enter the string to be transmitted : ");

            String str = "to jest jakis moj tam text";
            

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Transmitting.....");





            Stream stm = tcpclnt.GetStream();

            stm.Write(ba, 0, ba.Length);

            byte[] bb = new byte[256];
            int k = stm.Read(bb, 0, 256);
            string test="" ;
            for (int i = 0; i < k; i++)
                test += Convert.ToChar(bb[i]);

            Console.WriteLine(test);// automatyczna odpowiedź z servera !! jupi

    */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String str = "to teraz sprawdzamy bardzo dlugi text ewentualnie jakiegos jsona" +


                "nie wiem co to da ale sprawdzic zawsze mozna bla bla bla bla";


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
