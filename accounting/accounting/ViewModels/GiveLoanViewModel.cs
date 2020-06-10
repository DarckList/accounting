using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Realms;
using System.Linq;
using accounting.Models;

namespace accounting.ViewModels
{
    class GiveLoanViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Realm _realm;
        Random rand = new Random();

        public string NameGives { get; set; }
        public string SurnameGives { get; set; }
        public string MobileNumberGives { get; set; }
        public DateTime EndDateGiveLoan { get; set; } = DateTime.Today;
        public string SumGives { get; set; }


        public GiveLoanViewModel()
        {

        }

        public void Save()
        {
            _realm = Realm.GetInstance();
            GiveLoan newGive = new GiveLoan
            {
                GiveLoan_Id = rand.Next(1, 10000),
                IndividualName = NameGives,
                IndividualSurname = SurnameGives,
                IndividualPhoneNumber = MobileNumberGives,
                EndDate = EndDateGiveLoan.ToString(),
                Persentage = 0,
                FinalySum = double.Parse(SumGives)
            };


            _realm.Write(() =>
            {
                _realm.Add<GiveLoan>(newGive);
            });
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
