using Realms;

namespace accounting.Models
{
    class ExpenseItems:RealmObject
    {
        [PrimaryKey]
        public int Expense_Id { get; set; }

        public string ExpenseName { get; set; }
        public string ExpenseComment { get; set; }
    }
}
