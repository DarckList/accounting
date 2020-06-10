using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace accounting.Services
{
    class MovmentListColection: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _dateTransaction = String.Empty;
        public int Id { get; set; }
        public string DateTransaction
        {
            get
            {
                return _dateTransaction;
            }
            set
            {
                _dateTransaction = value;
                NotifyPropertyChanged();
                
            }
        }
        public string TypeTransaction { get; set; }
        public string SumTransaktion { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                Debug.WriteLine(propertyName);
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
