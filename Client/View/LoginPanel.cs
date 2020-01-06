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
using System.Timers;

namespace Client
{
    public partial class Form1 : Form
    {
        
        public TcpClient connectOptions { get; set; }
        public Controller.ServerConnect serverObject { get; set; }
        private Model.Base64Converter convert { get; set; }
        public Form1()
        {
            InitializeComponent();
            Controller.ServerConnect createConnect = new Controller.ServerConnect();
            serverObject = createConnect;
            connectOptions = createConnect.connect();
            Model.Base64Converter converter = new Model.Base64Converter();
            convert = converter;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //try loggin to APP code 101
            String code = "101";
            String email = textBox1.Text;
            String password = textBox2.Text;

          //  string str = convert.encodeBase64string(email + "~" + password);

            Model.ConverterMD5 encode = new Model.ConverterMD5();
            string pass = encode.encodeMD5(password);
            
            string data = email + "~" + pass;

            Model.Base64Converter _encodeData = new Model.Base64Converter();
            data = _encodeData.encodeBase64string(data);

            Controller.ServerConnect send = new Controller.ServerConnect();
            send.sendMessage(code+"~" + data, connectOptions, "",null);

            /*
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(code+"~"+str);
            Console.WriteLine("Transmitting.....");

            Stream stm = connectOptions.GetStream();

            stm.Write(ba, 0, ba.Length);

            byte[] bb = new byte[256];
            int k = stm.Read(bb, 0, 256);
            string test = "";
            for (int i = 0; i < k; i++)
                test += Convert.ToChar(bb[i]);

            Console.WriteLine(test);// automatyczna odpowiedź z servera !! jupi
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View.RegisterPanel registerPanel = new View.RegisterPanel();
            Hide();
            registerPanel.tcpclnt = connectOptions;
            registerPanel.serverObject = serverObject;
            registerPanel.Show();           
        }

        
        

        private void closedApplication(object sender, FormClosedEventArgs e)
        {
            try
            {
                serverObject.sendMessage("500", connectOptions, "",null);
                connectOptions.Close();
                Console.WriteLine("application is clossed!");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
    }
}
