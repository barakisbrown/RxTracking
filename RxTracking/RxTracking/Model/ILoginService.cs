using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxTracking.Model
{
    public interface ILoginService
    {
        bool userExist(string usrname );
        bool createUser(Logins usr);
        bool loginOkay(Logins usr);

    }

}
