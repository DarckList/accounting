using System;
using System.Collections.Generic;
using System.Linq;
using accounting.Models;
using Realms;
using System.ComponentModel;
using accounting.Services;

namespace accounting.ViewModels
{
    class ListLoanSelectedViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string NameGives { get; set; }
        public string SurnameGives { get; set; }
        public string MobileNumberGives { get; set; }
        public DateTime EndDateGiveLoan { get; set; } 
        public string SumGives { get; set; }

        public int indexId;

        bool typeDb;

        public ListLoanSelectedViewModel(bool table, int id)
        {
            indexId = id;
            typeDb = table;
            var realm = Realm.GetInstance();
            if (typeDb)
            {
                var giveLoansList = realm.All<GiveLoan>().Where(d=> d.GiveLoan_Id==indexId);
                foreach(var t in giveLoansList)
                {
                    NameGives = t.IndividualName;
                    SurnameGives = t.IndividualSurname;
                    MobileNumberGives = t.IndividualPhoneNumber;
                    EndDateGiveLoan = DateTime.Parse(t.EndDate);
                    SumGives = t.FinalySum.ToString();
                }
            }
            else
            {
                var takeLoansList = realm.All<TakeLoan>().Where(d => d.TakeLoan_Id == indexId);
                foreach (var t in takeLoansList)
                {
                    NameGives = t.IndividualName;
                    SurnameGives = t.IndividualSurname;
                    MobileNumberGives = t.IndividualPhoneNumber;
                    EndDateGiveLoan = DateTime.Parse(t.EndDate);
                    SumGives = t.FinalySum.ToString();
                }
            }
        }

        public void Save()
        {
            var realm = Realm.GetInstance();
            if (typeDb)
            {
                var tempGive = realm.All<GiveLoan>().First(d => d.GiveLoan_Id == indexId);
                realm.Write(() =>
                {
                    tempGive.IndividualName = NameGives;
                    tempGive.IndividualSurname = SurnameGives;
                    tempGive.IndividualPhoneNumber = MobileNumberGives;
                    tempGive.EndDate = EndDateGiveLoan.ToString();
                    tempGive.FinalySum = double.Parse(SumGives);
                });
            }
            else
            {
                var tempGive = realm.All<TakeLoan>().First(d => d.TakeLoan_Id == indexId);
                realm.Write(() =>
                {
                    tempGive.IndividualName = NameGives;
                    tempGive.IndividualSurname = SurnameGives;
                    tempGive.IndividualPhoneNumber = MobileNumberGives;
                    tempGive.EndDate = EndDateGiveLoan.ToString();
                    tempGive.FinalySum = double.Parse(SumGives);
                });
            }
        }

        public void Delet()
        {
           var realm = Realm.GetInstance();
            if (typeDb)
            {
                var tempGive = realm.All<GiveLoan>().First(d => d.GiveLoan_Id == indexId);
                realm.Write(() =>
                {
                    realm.Remove(tempGive);
                });
               
            }
            else
            {
                var tempGive = realm.All<TakeLoan>().First(d => d.TakeLoan_Id == indexId);
                realm.Write(() =>
                {
                    realm.Remove(tempGive);
                });
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
