using System;
using UILayer.Model;

namespace UILayer.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Matthew Jason Brown");
            callback(item, null);
        }
    }
}