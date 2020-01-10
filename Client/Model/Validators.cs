using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class Validators
    {
        public Validators() { }

        public Boolean validNewTask(String titleTask, String information, String status, String resolver)
        {
            return titleTask.Length > 0 && information.Length > 0 && status.Length>0&&resolver.Length>0 ? true : false;
            
        }
    }
}
