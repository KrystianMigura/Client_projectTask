﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;
namespace Client.Model
{
   public class ClientPanelButtons
    {
        public ClientPanelButtons () { }
        public string alltask { get; set; }

        public string mytask { get; set; }

        public string insTask { get; set; }

        public void allTask(TcpClient connectOptions, DataGridView panel)
        {
            Controller.ServerConnect send = new Controller.ServerConnect();
            string code = "104";           
            send.sendMessage(code + "~", connectOptions,"", panel);
        }

        public void myTask(TcpClient connectOptions, DataGridView panel, String email)
        {
            Controller.ServerConnect send = new Controller.ServerConnect();
            string code = "106";
            send.sendMessage(code + "~"+email, connectOptions, "", panel);
        }
    }
}
