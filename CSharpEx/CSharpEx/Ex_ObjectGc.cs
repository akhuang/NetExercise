using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpEx
{
    public class Ex_ObjectGc
    {
        public static void TestGc()
        {
            TestGc1();
            TestGc2();
        }
        public static void TestGc1()
        {
            User model = ClientService.Current.UserInfo;

            User model1 = ClientService.Current.UserInfo;

            ClientService cs = new ClientService();
            User model2 = cs.UserInfo;
        }

        public static void TestGc2()
        {
            User model3 = ClientService.Current.UserInfo;
        }
    }

    public class ClientService
    {
        public ClientService()
        {
            Console.WriteLine("ClientService constructor");
        }

        private static Lazy<ClientService> _clientService = new Lazy<ClientService>(() => new ClientService());
        public static ClientService Current
        {
            get
            {
                return _clientService.Value;
            }
        }

        private User _userInfo;
        public User UserInfo
        {
            get
            {
                if (_userInfo == null)
                {
                    _userInfo = GetUserInfo();
                }
                return _userInfo;
            }
            set
            {
                _userInfo = value;
            }
        }

        public User GetUserInfo()
        {
            Console.WriteLine("GetUserInfo");
            User model = new User();
            model.UserName = "phoenix";
            return model;
        }
    }
}
