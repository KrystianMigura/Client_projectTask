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
    public partial class addTaskPanel : Form
    {
        public String createdPerson { get; set; }
        public String nowTime { get; set; }
        private String status { get; set; }
        private String information { get; set; }
        private String titleTask { get; set; }
        private String resolver { get; set; }
        private TcpClient connect { get; set; }
        public DataGridView panel { get; set; }

        public Model.ClientPanelButtons clientButton { get; set; }
        public addTaskPanel()
        {
            InitializeComponent();
            nowTime = DateTime.Now.ToString();
            nowTime = nowTime.Remove(11);
            
        }
        public void setCreatedPerson(String param, TcpClient connectOptions,  Model.ClientPanelButtons CB, DataGridView pnl )
        {
            createdPerson = param;
            label2.Text = createdPerson;
            label4.Text = nowTime;
            connect = connectOptions;
            clientButton = CB;
            panel = pnl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resolver = textBox1.Text;
            titleTask = textBox2.Text;
            information = textBox3.Text;
            status = textBox4.Text;

            Model.Validators valid = new Model.Validators();
            Boolean flag = valid.validNewTask(titleTask, information, status, resolver);
            if (flag == true)
            {
                string param = createdPerson+"/"+nowTime+"/"+status+"/"+information+"/"+titleTask + "/"+resolver;

                string code = "102";
                string data = param;

                Model.Base64Converter _encodeData = new Model.Base64Converter();
                data = _encodeData.encodeBase64string(data);
                Controller.ServerConnect send = new Controller.ServerConnect();
                send.sendMessage(code + "~" + data, connect, "", null);

                Close();
            }
            else
            {
                MessageBox.Show("Probably any value is incorrect!.","Error in input value.",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }




    }
}
