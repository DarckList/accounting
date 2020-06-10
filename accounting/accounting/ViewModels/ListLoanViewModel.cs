using System.Collections.Generic;
using accounting.Models;
using Realms;
using System.ComponentModel;
using accounting.Services;
using System.Runtime.CompilerServices;
using System;

namespace accounting.ViewModels
{
    class ListLoanViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public string EndDate { get; set; }
        public string IndividualName { get; set; }
        public string IndividualSurname { get; set; }
        public string FoneNumber { get; set; }
        public string FinalySum { get; set; }

        public List<LoanViewList> MyList { get; set; }


        public ListLoanViewModel()
        {
            MyList = new List<LoanViewList>();
            GetCurrentData();
        }


        void GetCurrentData()
        {
            var realm = Realm.GetInstance();
            var giveLoansList = realm.All<GiveLoan>();
            foreach (var el in giveLoansList)
            {
                MyList.Add(new LoanViewList()
                {
                    Id = el.GiveLoan_Id,
                    EndDate = el.EndDate,
                    IndividualName = el.IndividualName,
                    IndividualSurname = el.IndividualSurname,
                    FoneNumber = el.IndividualPhoneNumber,
                    FinalySum = string.Format("{0}", el.FinalySum)
                });
            }

            var takeLoansList = realm.All<TakeLoan>();
            foreach (var el in takeLoansList)
            {
                MyList.Add(new LoanViewList()
                {
                    Id = el.TakeLoan_Id,
                    EndDate = el.EndDate,
                    IndividualName = el.IndividualName,
                    IndividualSurname = el.IndividualSurname,
                    FoneNumber = el.IndividualPhoneNumber,
                    FinalySum = string.Format("-{0}", el.FinalySum)
                });
            }
            MyList.Sort((x, y) => y.EndDate.CompareTo(x.EndDate));


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
