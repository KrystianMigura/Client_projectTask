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

namespace Client.View
{
    public partial class ClientPanel : Form
    {
        public String email { get; set; }
        public Model.ClientPanelButtons clientButton { get; set; }
        public TcpClient tcpclnt { get; set; }
        public DataGridView panel { get; set; }
        public ClientPanel()
        {
            InitializeComponent();
            clientButton = new Model.ClientPanelButtons();
            panel = dataGridView1;
        }
        public void setLabel (string param)
        {
            char[] separator = { '~' };
            String[] paramStr = param.Split(separator);
            this.email = paramStr[0];
            label1.Text = email;
        }

        public void setConnector(TcpClient client)
        {
            tcpclnt = client;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clientButton.allTask(tcpclnt, panel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clientButton.myTask(tcpclnt, panel, email);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            View.addTaskPanel _addTaskPanel = new addTaskPanel();
            _addTaskPanel.Show();
            _addTaskPanel.setCreatedPerson(email, tcpclnt, clientButton,null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ClientPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Console.WriteLine("application is clossed!");
                System.Diagnostics.Process.GetCurrentProcess().Kill();

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {               
                foreach (Form f in Application.OpenForms)
                {
                    if(f.Name == "Form1")
                    {
                        f.Show();
                        Hide();
                    }
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
    }
}
