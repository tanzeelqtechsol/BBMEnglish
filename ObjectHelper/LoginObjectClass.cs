using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;

namespace ObjectHelper
{
    public class LoginObjectClass : EntityBase
    {
        public string UName { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string Notes { get; set; }

        public DateTime NotesDate { get; set; }
        public string LastUser { get; set; }

        public int LastUserId { get; set; }





        public bool chkShowTip { get; set; }

        public string[] Tips { get; set; }
    }

   

}
