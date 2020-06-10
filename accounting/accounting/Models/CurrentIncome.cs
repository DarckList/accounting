using Realms;
namespace accounting.Models
{
    class CurrentIncome : RealmObject
    {
        [PrimaryKey]
        public int Income_Id { get; set; }

        public string IncomeDate { get; set; }
        public SourcesOfIncome IncomeSources { get; set; }
        public double IncomeSum { get; set; }
    }
}

