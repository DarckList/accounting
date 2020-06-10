using Realms;

namespace accounting.Models
{
    class TakeLoan:RealmObject
    {
        [PrimaryKey]
        public int TakeLoan_Id { get; set; }

        public string IndividualName { get; set; }
        public string IndividualSurname { get; set; }
        public string IndividualPhoneNumber { get; set; }
        public string EndDate { get; set; }
        public short Persentage { get; set; }
        public double FinalySum { get; set; }
    }
}
