using System;
using DAL;
using DAL.Context;
using DAL.Models;
using DAL.Services;

namespace UILayer.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service
            using (var db = new DbContext())
            {
                LoginService service = LoginService.GetInstance(db);
                // CREATE USERINFO for my default Admin Class
                UserInfo adminUser = new UserInfo
                {
                    FirstName  = "Matthew",
                    LastName = "Brown",
                    Address = "123 Test Street",
                    City = "Some City",
                    State = "TX",
                    ZipCode = "78664",
                    PhoneNumber = "000-000-0000",
                    Email = "example@example.com"
                };

                var item = new DataItem("Matthew Jason Brown");
                callback(item, null);

            }
        }
    }
}