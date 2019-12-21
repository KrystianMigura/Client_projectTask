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

        private Client.Options.ConnectToServer clnt { get; set; }

        


        public TcpClient connectOptions { get; set; }
        public Controller.ServerConnect a { get; set; }
        public Form1()
        {
            InitializeComponent();

            Client.Options.ConnectToServer createConnect = new Client.Options.ConnectToServer();         
            createConnect.createConnect();
            clnt = createConnect;

        }
        private TcpClient tcpclnt { get;set;} 

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
                a.sendMessage("500", connectOptions);
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



        private void button1_Click_1(object sender, EventArgs e)
        {
            
            Client.Users.RegisterNewUser registerUser = new Client.Users.RegisterNewUser();



            registerUser.catchData(textBox1.Text, textBox2.Text, clnt);


        }


    */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String str = "to teraz sprawdzamy bardzo dlugi text ewentualnie jakiegos jsona" +


                "nie wiem co to da ale sprawdzic zawsze mozna bla bla bla bla";


            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Transmitting.....");




    }
}
