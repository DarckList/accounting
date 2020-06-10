using System;
using System.Collections.Generic;
using System.Text;
using accounting.Models;
using System.ComponentModel;
using Realms;
using System.Runtime.CompilerServices;

namespace accounting.ViewModels
{
    public class HomeVeiwModel : INotifyPropertyChanged
    {
        Realm realm;


        private string thisMonth;
        private string income;
        private string expense;
        private string balance;


        public string ThisMonth
        {
            get { return thisMonth; }
            set
            {
                thisMonth = value;
                OnPropertyChanged("ThisMonth");
            }
        }
        public string Income
        {
            get { return income; }
            set
            {
                income = value;
                OnPropertyChanged("Income");
            }
        }
        public string Expense
        {
            get { return expense; }
            set
            {
                expense = value;
                OnPropertyChanged("Expense");
            }
        }
        public string Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
}
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public HomeVeiwModel()
        {
          GetCurentValue();
        }

        private void GetCurentValue()
        {
            ThisMonth = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month);
            
             

            realm = Realm.GetInstance();
            double currentIncome = 0;

            var temp1 = realm.All<CurrentIncome>();
            foreach (var t in temp1)
            {
                currentIncome += t.IncomeSum;
            }
            Income = String.Format("+ {0}", currentIncome);

            double currentExpense = 0;
            var temp2 = realm.All<CurrentExpense>();
            foreach (var t in temp2)
            {
                currentExpense += t.ExpenseSum;
            }
            Expense = String.Format("- {0}", currentExpense);

            Balance = String.Format("+ {0}", currentIncome - currentExpense);
        }


        protected void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
