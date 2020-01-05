using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Controller
{
    class ServiceCodeNumber
    {
        public ServiceCodeNumber () {}

        public void codeArg(string code, string ttt)
        {
            if(code == "200")
            {
                Console.WriteLine("przeniesienie do wlasciwego miejsca zamkniecie starego okna nowy panel");
                View.ClientPanel clntPanel = new View.ClientPanel();
               
                clntPanel.Show();
                clntPanel.setLabel(ttt);


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
                Console.WriteLine("TO JEST INNA WARTOSC NIZ 200");

            }

        }
    }
}
