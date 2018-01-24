using UILayer.Model;

namespace UILayer.ViewModel
{
    public class LoginViewModel
    {
        private readonly IDataService _dataService;
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }

        public LoginViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // report err here
                        return;
                    }
                    First = item.First;
                    Middle = item.Middle;
                    Last = item.Last;
                });
        }
    }
}