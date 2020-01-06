using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Client.View
{
    public partial class RegisterPanel : Form
    {
        public RegisterPanel()
        {
            InitializeComponent();
        }

        private string nick { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string password { get; set; }
        private string email { get; set; }

        public TcpClient tcpclnt { get; set; }

        public Controller.ServerConnect serverObject { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {

            nick = textBox1.Text;
            firstName = textBox2.Text;
            lastName = textBox3.Text;
            password = textBox4.Text;
            email = textBox5.Text;

            Model.ConverterMD5 encode = new Model.ConverterMD5();
            string pass = encode.encodeMD5(password);
            string data = nick+"~"+ firstName + "~" + lastName + "~" + pass + "~" + email;
            sendParamToServer(data);


        }

        private void sendParamToServer(String val)
        {
            Model.Base64Converter encode = new Model.Base64Converter();
            val = encode.encodeBase64string(val);

            Controller.ServerConnect send = new Controller.ServerConnect();
            send.sendMessage("100~"+val, tcpclnt, "",null);

            foreach (Form f in Application.OpenForms)
            {

                if (f.Name == "Form1")
                {
                    Hide();
                    f.Show();
                }
            }

        }
    }
}
