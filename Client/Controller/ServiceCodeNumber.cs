﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Client.Controller
{
    class test
    {
        test() { }

        public string id { get; set; }
        public string resolver { get; set; }

        public string titleTask { get; set; }
        public string created { get; set; }
        public string information { get; set; }
        public string dateCreated { get; set; }
        public string dateResolved { get; set; }
        public string status { get; set; }


    }

    public class bass
    {
        public bass() { }

        public void checkit(DataGridView dataPanel, String id, String resolver,String created, String title, String information, String dataCreated, String dataResolved, String status)
        {
            DataGridViewRow row = (DataGridViewRow)dataPanel.Rows[0].Clone();
            row.Cells[0].Value = id;
            row.Cells[1].Value = resolver;
            row.Cells[2].Value = title;
            row.Cells[3].Value = created;
            row.Cells[4].Value = information;
            row.Cells[5].Value = dataCreated.Remove(11);
            row.Cells[6].Value = dataResolved.Length > 1 ?dataResolved.Remove(11):dataResolved;
            row.Cells[7].Value = status;
            dataPanel.Rows.Add(row);
        }
    }
    class ServiceCodeNumber 
    {
        View.ClientPanel clntPanel { get; set; }
        public ServiceCodeNumber () {}

        public void codeArg(string code, string ttt, TcpClient tcpclnt, DataGridView panel)
        {

            DataGridView dataPanel = panel;
            if(code == "112")
            {
                Console.WriteLine("CHYBA JEST OKEYYY!!");
                
            }


            if (code == "114")
            {
                 bass mm = new bass();
                 string jsonObj = "["+ttt+"]";

                var tteesstt = JsonConvert.DeserializeObject<List<test>>(jsonObj);
                dataPanel.Rows.Clear();
                foreach (test p in tteesstt)
                {
                    mm.checkit(dataPanel, p.id, p.resolver,p.titleTask,p.created,p.information,p.dateCreated,p.dateResolved, p.status);
                }
            }

            if (code == "116")
            {
                bass mm = new bass();
                string jsonObj = "[" + ttt + "]";
                var tteesstt = JsonConvert.DeserializeObject<List<test>>(jsonObj);
                dataPanel.Rows.Clear();
                foreach (test p in tteesstt)
                {
                    mm.checkit(dataPanel, p.id, p.resolver, p.titleTask, p.created, p.information, p.dateCreated, p.dateResolved, p.status);
                }

            }


            if (code == "200")
            {
                View.ClientPanel clntPanel1 = new View.ClientPanel();
                clntPanel = clntPanel1;
                clntPanel1.Show();
                clntPanel1.setLabel(ttt);
                clntPanel1.setConnector(tcpclnt);


                foreach (Form f in Application.OpenForms)
                {

                    if (f.Name == "Form1")
                    {
                        f.Hide();
                    }
                }


            }
            else
            {
                Console.WriteLine("TO JEST INNA WARTOSC NIZ 200" + code);

            }

        }
    }
}
