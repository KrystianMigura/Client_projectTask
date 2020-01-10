using System;
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

            Console.WriteLine("TO JKEST KOLEJNY TEST REFERENCYJNY + " + alltask);


            Console.WriteLine("tu ma byc zapytanie do servera o wszystkie dostepne zadania !!!!");
        }

        public void myTask(TcpClient connectOptions, DataGridView panel)
        {
            Controller.ServerConnect send = new Controller.ServerConnect();
            string code = "106";

            send.sendMessage(code + "~", connectOptions, "", panel);

            Console.WriteLine("TO JKEST KOLEJNY TEST REFERENCYJNY + " + mytask);


            Console.WriteLine("tu ma byc zapytanie do servera o wszystkie dostepne zadania !!!!");
        }

        public void insertTask(TcpClient connectOptions, DataGridView panel, String param)
        {
            Controller.ServerConnect send = new Controller.ServerConnect();
            string code = "102";

            send.sendMessage(code + "~"+param, connectOptions, "", panel);

            Console.WriteLine("TO JKEST KOLEJNY TEST REFERENCYJNY + " + insTask);


            Console.WriteLine("tu ma byc zapytanie do servera o wszystkie dostepne zadania !!!!");
        }
    }
}
