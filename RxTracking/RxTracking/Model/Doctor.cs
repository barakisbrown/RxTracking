namespace RxTracking.Model
{
    using GalaSoft.MvvmLight;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Doctor : ObservableObject
    {
        private ObjectId _id;
        private string _name;
        private string _phone;
        private string _notes;
        private bool _primary;

        private const string IdPropertyName = "ID";
        private const string NamePropertyName = "NAME";
        private const string PhonePropertyame = "PHONE";
        private const string NotesPropertyName = "NOTES";
        private const string PrimaryPropertyName = "PRIMARY";

        public Doctor()
        {
            _name = "";
            _phone = "";
            _name = "";
            _primary = false;
        }

        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id
        {
            get { return _id;}
            set { Set(IdPropertyName, ref _id, value); }
        }

        [BsonElement("name")]
        public string Name
        {
            get { return _name; }
            set { Set(NamePropertyName, ref _name, value); }
        }

        [BsonElement("phone")]
        public string Phone
        {
            get { return _phone; }
            set { Set(PhonePropertyame, ref _phone, value); }
        }

        [BsonElement("notes")]
        public string Notes
        {
            get { return _notes; }
            set { Set(NotesPropertyName, ref _notes, value); }
        }

        [BsonElement("primary")]
        public bool Primary
        {
            get { return _primary; }
            set { Set(PrimaryPropertyName, ref _primary, value); }
        }

    }
}