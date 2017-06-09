using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Logic
{
    public class UserController
    {

        
        public bool RegisterUser(User lUser)
        {
            return lUser.CreatUser();
        }

        public List<User> GetUserlist()
        {
            return User.Getlist();         
        }
    }
}
