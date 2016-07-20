namespace RxTracking.Model
{
    using System.Collections.ObjectModel;
    using GalaSoft.MvvmLight;

    public class US_STATES : ObservableObject
    {
        private string _long;
        private string _short;

        public string LONG
        {
            get { return _long; }
            set { Set("LONG", ref _long, value); }
        }

        public string SHORT
        {
            get { return _short; }
            set { Set("SHORT", ref _short, value); }
        }

        public static ObservableCollection<US_STATES> GetAllStates()
        {
            ObservableCollection<US_STATES> ALL = new ObservableCollection<US_STATES>
            {
                 new US_STATES {LONG="ALABAMA",SHORT="AL" },
                new US_STATES {LONG="Alaska", SHORT = "AK"},
                new US_STATES {LONG = "Arizona", SHORT = "AZ"},
                new US_STATES {LONG = "Arkansas", SHORT = "AR"},
                new US_STATES {LONG = "California", SHORT = "CA"},
                new US_STATES {LONG = "Colorado", SHORT = "CO"},
                new US_STATES {LONG = "Connecticut", SHORT = "CT"},
                new US_STATES {LONG = "Delaware", SHORT = "DE"},
                new US_STATES {LONG = "Florida", SHORT = "FL"},
                new US_STATES {LONG = "Georgia", SHORT = "GA"},
                new US_STATES {LONG = "Hawaii", SHORT = "HI"},
                new US_STATES {LONG = "IDAHO", SHORT = "ID"},
                new US_STATES {LONG = "Illinois", SHORT = "IL"},
                new US_STATES {LONG = "Indiana", SHORT = "IN"},
                new US_STATES {LONG = "Iowa", SHORT = "IA"},
                new US_STATES {LONG = "Kansas", SHORT = "KS"},
                new US_STATES {LONG = "Kentucky", SHORT = "KY"},
                new US_STATES {LONG = "Louisiana", SHORT = "LA"},
                new US_STATES {LONG = "Maine", SHORT = "ME"},
                new US_STATES {LONG = "Maryland", SHORT = "MD"},
                new US_STATES {LONG = "Massachusetts", SHORT = "MA"},
                new US_STATES {LONG = "Michigan", SHORT = "MI"},
                new US_STATES {LONG = "Minnesota", SHORT = "MN"},
                new US_STATES {LONG = "Mississippi", SHORT = "MS"},
                new US_STATES {LONG = "Missouri", SHORT = "MO"},
                new US_STATES {LONG = "Montana", SHORT = "MT"},
                new US_STATES {LONG = "Nebraska", SHORT = "NE"},
                new US_STATES {LONG = "Nevada", SHORT = "NV"},
                new US_STATES {LONG = "New Hampshire", SHORT = "NH"},
                new US_STATES {LONG = "New Jersey", SHORT = "NJ"},
                new US_STATES {LONG = "New Mexico", SHORT = "NM"},
                new US_STATES {LONG = "New York", SHORT = "NY"},
                new US_STATES {LONG = "North Carolina", SHORT = "NC"},
                new US_STATES {LONG = "North Dakota", SHORT = "ND"},
                new US_STATES {LONG = "Ohio", SHORT = "OH"},
                new US_STATES {LONG = "Oklahoma", SHORT = "OK"},
                new US_STATES {LONG = "Oregon", SHORT = "OR"},
                new US_STATES {LONG = "Pennsylvania", SHORT = "PA"},
                new US_STATES {LONG = "Rhode Island", SHORT = "RI"},
                new US_STATES {LONG = "South Carolina", SHORT = "SC"},
                new US_STATES {LONG = "South Dakota", SHORT = "SD"},
                new US_STATES {LONG = "Tennessee", SHORT = "TN"},
                new US_STATES {LONG = "Texas", SHORT = "TX"},
                new US_STATES {LONG = "Utah", SHORT = "UT"},
                new US_STATES {LONG = "Vermont", SHORT = "VT"},
                new US_STATES {LONG = "Virginia", SHORT = "VA"},
                new US_STATES {LONG = "Washington", SHORT = "WA"},
                new US_STATES {LONG = "West Virginia", SHORT = "WV"},
                new US_STATES {LONG = "Wisconsin", SHORT = "WI"},
                new US_STATES {LONG = "Wyoming",SHORT = "WY"}
            };

            return ALL;
        }

        public override string ToString()
        {
            return LONG;
        }
    }   
}