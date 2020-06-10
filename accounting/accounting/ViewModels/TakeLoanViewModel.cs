using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Realms;
using System.Linq;
using accounting.Models;

namespace accounting.ViewModels
{
    class TakeLoanViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Realm _realm;
        Random rand = new Random();

        public string NameTakers { get; set; }
        public string SurnameTakers { get; set; }
        public string MobileNumberTakers { get; set; }
        public DateTime EndDateTakeLoan { get; set; } = DateTime.Today;
        public string SumTakers { get; set; }

        public TakeLoanViewModel()
        {
            
        }

        public void Save()
        {
            _realm = Realm.GetInstance();
            TakeLoan newLoan = new TakeLoan
            {
                TakeLoan_Id = rand.Next(1, 10000),
                IndividualName = NameTakers,
                IndividualSurname = SurnameTakers,
                IndividualPhoneNumber = MobileNumberTakers,
                EndDate = EndDateTakeLoan.ToString(),
                Persentage = 0,
                FinalySum = double.Parse(SumTakers)
            };

           
            _realm.Write(() =>
            {
                _realm.Add<TakeLoan>(newLoan);
            });
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
