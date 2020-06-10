using Realms;

namespace accounting.Models
{
    class User : RealmObject
    {
        [PrimaryKey]
        public int User_Id { get; set; }

        public string UserName { get; set; }
        public string UserSurname { get; set; }
        //public IList<СurrentIncome> Incomes { get; } // доходи
        //public IList<CurrentExpense> Expenses { get;}// витрати
        //public IList<GiveLoan> Gives { get;} // дав кошти 
        //public IList<TakeLoan> Takes{ get; } // позичив кошти
    }
}
