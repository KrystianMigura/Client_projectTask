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

        public Form1()
        {
            InitializeComponent();
            Client.Options.ConnectToServer createConnect = new Client.Options.ConnectToServer();         
            createConnect.createConnect();
            clnt = createConnect;

        }
        private TcpClient tcpclnt { get;set;} 


        private void button1_Click_1(object sender, EventArgs e)
        {
            
            Client.Users.RegisterNewUser registerUser = new Client.Users.RegisterNewUser();


            registerUser.catchData(textBox1.Text, textBox2.Text, clnt);


        }


    }
}
