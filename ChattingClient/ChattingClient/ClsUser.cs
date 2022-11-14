using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChattingClient
{
    class ClsUser
    {
        public string NickName {get; set;}
        static private ClsUser user = null;

        private ClsUser()
        {

        }

        static public ClsUser GetInstance()
        {
            if (user == null)
            {
                user = new ClsUser();
            }

            return user;
        }
    }
}
