using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.View
{
    public partial class ClientPanel : Form
    {
        public String email { get; set; }
        public ClientPanel()
        {
            InitializeComponent();
            
        }
        public void setLabel (string param)
        {
            char[] separator = { '~' };
            String[] paramStr = param.Split(separator);
            this.email = paramStr[0];

            //ask query for getting more information about user!!!!!
            //displayed more information about user

            label1.Text = email;
        }
    }
}
