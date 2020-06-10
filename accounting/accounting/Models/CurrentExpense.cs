using Realms;

namespace accounting.Models
{

    class CurrentExpense : RealmObject
    {
        [PrimaryKey]
        public int CurrentExpense_Id { get; set; }

        public string ExpenseDate { get; set; }
        public ExpenseItems Expense {get;set;}
        public double ExpenseSum { get; set; }
    }
}
