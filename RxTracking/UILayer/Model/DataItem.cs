namespace UILayer.Model
{
    public class DataItem
    {
        public DataItem(string fullName)
        {
            string []name = fullName.Split(' ');
            First = name[0];
            Middle = name[1];
            Last = name[2];
        }

        public string First
        {
            get;
            private set;
        }

        public string Middle
        {
            get;
            private set;
        }

        public string Last
        {
            private set;
            get;
        }
    }
}