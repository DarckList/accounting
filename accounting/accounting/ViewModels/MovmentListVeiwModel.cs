using System;
using System.Collections.Generic;
using System.Text;
using accounting.Models;
using Realms;
using System.ComponentModel;
using System.Linq;
using accounting.Services;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace accounting.ViewModels
{
    class MovmentListVeiwModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Realm _realm;

        public string DateTransaction { get; set; }
        public string TypeTransaction { get; set; }
        public string SumTransaktion { get; set; }

        public List<MovmentListColection> MyList { get; set; }


        public MovmentListVeiwModel()
        {
            
            MyList = new List<MovmentListColection>();
            Debug.WriteLine(MyList.ToString());
            GetCurrentData();
        }

        public void GetCurrentData()
        {
            _realm = Realm.GetInstance();
            var expenseList = _realm.All<CurrentExpense>();
            foreach (var el in expenseList)
            {
                MyList.Add(new MovmentListColection()
                {   Id = el.CurrentExpense_Id,
                    DateTransaction = el.ExpenseDate,
                    TypeTransaction = el.Expense.ExpenseName,
                    SumTransaktion = String.Format("- {0}",el.ExpenseSum)
                });
            }

            var incomeList = _realm.All<CurrentIncome>();
            foreach (var il in incomeList)
            {
                MyList.Add(new MovmentListColection()
                {   Id = il.Income_Id,
                    DateTransaction = il.IncomeDate,
                    TypeTransaction = il.IncomeSources.SourceName,
                    SumTransaktion = String.Format("+ {0}", il.IncomeSum)
                });
            }
            MyList.Sort((x, y) => y.DateTransaction.CompareTo(x.DateTransaction));

            foreach( MovmentListColection list in MyList)
            {
                Debug.WriteLine(list.Id);
                Debug.WriteLine(list.DateTransaction);
                Debug.WriteLine(list.SumTransaktion);
                Debug.WriteLine(list.TypeTransaction);
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
