﻿using System;
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
            try
            {
                connectOptions = createConnect.connect();
            }catch(Exception problemInConnect)
            {
                MessageBox.Show("Sorry you have a problem in connect to server. \n Please check your connection and try again. \n Check working server application!", "Problem in connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            Model.Base64Converter converter = new Model.Base64Converter();
            convert = converter;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //try loggin to APP code 101
            String code = "101";
            String email = textBox1.Text;
            String password = textBox2.Text;

            Model.ConverterMD5 encode = new Model.ConverterMD5();
            string pass = encode.encodeMD5(password);
            
            string data = email + "~" + pass;

            Model.Base64Converter _encodeData = new Model.Base64Converter();
            data = _encodeData.encodeBase64string(data);

            Controller.ServerConnect send = new Controller.ServerConnect();
            send.sendMessage(code+"~" + data, connectOptions, "",null);
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
