using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Realms;
using System.Linq;
using accounting.Models;
using accounting.Views;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace accounting.ViewModels
{
    class ExpenseFundsVeiwModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Random rand = new Random();

        public string Sum { get; set; }
        public object ExpenseSourcePicker { get; set; }
        public string ExpenseComent { get; set; }
        public string ThisMonth { get; set; }


        int tempId = 0;

        public ExpenseFundsVeiwModel()
        {
           
        }

        public ExpenseFundsVeiwModel(int id)
        {
            tempId = id;
            var realm = Realm.GetInstance();
            var tempDate = realm.All<CurrentExpense>().Where(d => d.CurrentExpense_Id == tempId);
            foreach (var t in tempDate)
            {
                Sum = t.ExpenseSum.ToString();
                ThisMonth = t.ExpenseDate;
                ExpenseComent = t.Expense.ExpenseComment;
                ExpenseSourcePicker = t.Expense.ExpenseName;
            }
        }


        public void Save()
        {
            ExpenseItems expenseItems = new ExpenseItems
            {
                Expense_Id = rand.Next(1, 100000),
                ExpenseName = (string)ExpenseSourcePicker,
                ExpenseComment = ExpenseComent
            };

            var realm = Realm.GetInstance();

          

            CurrentExpense currentExpense = new CurrentExpense
            {
                CurrentExpense_Id = rand.Next(1, 100000),
                ExpenseDate = System.DateTime.Now.ToString(),
                Expense = expenseItems,
                ExpenseSum = Convert.ToDouble(Sum)
            };

            if (tempId == 0)
            {
                realm.Write(() =>
                {
                    realm.Add(currentExpense);
                });
                currentExpense.PropertyChanged += (sender, e) =>
                {
                    Debug.WriteLine($"New value set for {e.PropertyName}");
                };
                ExpenseFundsVeiw.calculateSum = 0;
            }

            else
            {
                var tempDate = realm.All<CurrentExpense>().First(d => d.CurrentExpense_Id == tempId);
                realm.Write(() =>
                {
                    tempDate.ExpenseDate = System.DateTime.Now.ToString();
                    tempDate.Expense = expenseItems;
                    tempDate.ExpenseSum = Convert.ToDouble(Sum);
                    tempDate.Expense.ExpenseName = (string)ExpenseSourcePicker;
                    tempDate.Expense.ExpenseComment = ExpenseComent;
                });
                tempDate.PropertyChanged += (sender, e) =>
                {
                    
                    Debug.WriteLine($"New value set for {e.PropertyName}");
                };
                ExpenseFundsVeiw.calculateSum = 0;
            }
            
        }



        public void Delete()
        {
            var realm = Realm.GetInstance();
            if (tempId != 0)
            {
                var tempFunds = realm.All<CurrentExpense>().First(d => d.CurrentExpense_Id== tempId);
                realm.Write(() =>
                {
                    realm.Remove(tempFunds);
                });
                tempFunds.PropertyChanged += (sender, e) =>
                {
                    Debug.WriteLine($"New value set for {e.PropertyName}");
                };
            }

            ExpenseFundsVeiw.calculateSum = 0;
        }


        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
