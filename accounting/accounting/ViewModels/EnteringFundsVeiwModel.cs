using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Realms;
using System.Linq;
using accounting.Models;
using accounting.Views;

namespace accounting.ViewModels
{
    class EnteringFundsVeiwModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Random rand = new Random();


        public string Sum { get; set; }
        public object EnteringSourcePicker { get; set; }
        public string EnteringComent { get; set; }
        public string ThisMonth { get; set; }

        int tempId=0;


        public EnteringFundsVeiwModel()
        {

        }

        public EnteringFundsVeiwModel(int id)
        {
            tempId = id;
            var realm = Realm.GetInstance();
            var tempDate = realm.All<CurrentIncome>().Where(d => d.Income_Id == tempId);
            foreach (var t in tempDate)
            {
                Sum = t.IncomeSum.ToString();
                EnteringSourcePicker = t.IncomeSources.SourceName;
                ThisMonth = t.IncomeDate;
                EnteringComent = t.IncomeSources.SourceComment;
            }
        }
        
        public void Save()
        {
            var realm = Realm.GetInstance();
            SourcesOfIncome income = new SourcesOfIncome
            {
                SourceOfIncome_Id = rand.Next(1, 100000),
                SourceName = (string)EnteringSourcePicker,
                SourceComment = EnteringComent
            };
            
            CurrentIncome currentIncome = new CurrentIncome
            {
                Income_Id = rand.Next(1, 100000),
                IncomeDate = System.DateTime.Now.ToString(),
                IncomeSources = income,
                IncomeSum = Convert.ToDouble(Sum)
            };

            if (tempId == 0)
            {
                realm.Write(() =>
                {
                    realm.Add(currentIncome);
                });
            }
            else
            {
                var tempDate = realm.All<CurrentIncome>().First(d=>d.Income_Id==tempId);
                realm.Write(() =>
                {
                    tempDate.IncomeDate = System.DateTime.Now.ToString();
                    tempDate.IncomeSources = income;
                    tempDate.IncomeSum = Convert.ToDouble(Sum);
                    tempDate.IncomeSources.SourceName = (string)EnteringSourcePicker;
                    tempDate.IncomeSources.SourceComment = EnteringComent;
                });
            }
            EnteringFundsVeiw.calculateSum = 0;
        }

        public void Delete()
        {
            var realm = Realm.GetInstance();
              if (tempId!=0)
            {
                var tempFunds = realm.All<CurrentIncome>().First(d => d.Income_Id == tempId);
                realm.Write(() =>
                {
                    realm.Remove(tempFunds);
                    
                });
            }
            EnteringFundsVeiw.calculateSum = 0;
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
