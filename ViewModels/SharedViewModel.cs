using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.ViewModels
{
    public class SharedViewModel : BaseViewModel
    {
        private User user;
        public User User
        {
            get
            {
                return AppData.User;
            }
        }
    }
}
