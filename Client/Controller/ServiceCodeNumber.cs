using System;
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
            row.Cells[5].Value = dataCreated;
            row.Cells[6].Value = dataResolved;
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
            if (code == "114")
            {
                bass mm = new bass();
              //  mm.checkit(dataPanel, "aaa");

               // DataGridViewRow row = (DataGridViewRow)dataPanel.Rows[0].Clone();

                Console.WriteLine("no cos moze bedzie okeyy ale zobaczymy!" + ttt);
                 string jsonObj = "["+ttt+"]";

                //      JObject jv = (JObject)jsonObj;
                // JObject aaa = (JObject)jsonObj;
                //  string jsonObj = "[{id: 1, resolver: \"Krystian\"}]";
                var tteesstt = JsonConvert.DeserializeObject<List<test>>(jsonObj);
                dataPanel.Rows.Clear();
                foreach (test p in tteesstt)
                {
                    Console.WriteLine(p.id + " TO JEST ID!!!!");
                    // this.clntPanel.DUPA = p.id;
                    mm.checkit(dataPanel, p.id, p.resolver,p.titleTask,p.created,p.information,p.dateCreated,p.dateResolved, p.status);
                

                }

                
                //  Console.WriteLine(tteesstt + " XXXXXXXXXXXXXXXXXXXZZZZZZZZZZZZZZZZZZZZZZZZ");
                //  JObject jsonObject = JObject.Parse(aaa);
                //       Console.WriteLine("TO JEST ID       " + jv); 
            }


            if(code == "200")
            {
                Console.WriteLine("przeniesienie do wlasciwego miejsca zamkniecie starego okna nowy panel");
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
