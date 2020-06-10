using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using Realms;
using accounting.Models;

using Entry = Microcharts.Entry;

namespace accounting.Views
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportsVeiw : ContentPage
	{
        public List<Entry> entries;

        float diagramTextSize;
           
        public ReportsVeiw()
        {
            InitializeComponent();
            if (Device.Idiom == TargetIdiom.Desktop) diagramTextSize = 15f; //windows
            else diagramTextSize = 40f;
            GetDate();
        }


        public void GetDate()
        {
            var realm = Realm.GetInstance();
            var eat = realm.All<CurrentExpense>();
            float eatSum = 0;
            float FunSum = 0;
            float publicTrunsportSum = 0;
            float privatetransportSum = 0;
            float homePeatSum = 0;
            float clothingSum = 0;
            float medicineSum = 0;
            float residenceSum = 0;
            float otherSum = 0;
            
            float chekEntryes = 0;
            foreach (var s in eat)
            {
                if(s.Expense.ExpenseName=="Їжа") eatSum +=float.Parse(s.ExpenseSum.ToString());
                else if(s.Expense.ExpenseName=="Розваги")FunSum += float.Parse(s.ExpenseSum.ToString());
                else if (s.Expense.ExpenseName == "Громадський транспорт") publicTrunsportSum += float.Parse(s.ExpenseSum.ToString());
                else if (s.Expense.ExpenseName == "Особистий транспорт") privatetransportSum += float.Parse(s.ExpenseSum.ToString());
                else if (s.Expense.ExpenseName == "Домашній улюбленець") homePeatSum += float.Parse(s.ExpenseSum.ToString());
                else if (s.Expense.ExpenseName == "Одяг") clothingSum += float.Parse(s.ExpenseSum.ToString());
                else if (s.Expense.ExpenseName == "Медицина") medicineSum += float.Parse(s.ExpenseSum.ToString());
                else if (s.Expense.ExpenseName == "Проживання") residenceSum += float.Parse(s.ExpenseSum.ToString());
                else if (s.Expense.ExpenseName == "Інше") otherSum += float.Parse(s.ExpenseSum.ToString());
            }

            entries = new List<Entry>()
            {
                 new Entry(eatSum)
                {
                    Label = "Їжа",
                    ValueLabel = eatSum.ToString(),
                    Color = SKColor.Parse("#ff001e")
                },

                  new Entry(FunSum)
                {
                    Label = "Розваги",
                    ValueLabel = FunSum.ToString(),
                    Color = SKColor.Parse("#ffa200")
                },

                   new Entry(publicTrunsportSum)
                {
                    Label = "Громадський транспорт",
                    ValueLabel = publicTrunsportSum.ToString(),
                    Color = SKColor.Parse("#0088ff")
                },

                    new Entry(privatetransportSum)
                {
                    Label = "Особистий транспорт",
                    ValueLabel = privatetransportSum.ToString(),
                    Color = SKColor.Parse("#00ff00")
                },

                     new Entry(homePeatSum)
                {
                    Label = "Домашній улюбленець",
                    ValueLabel = homePeatSum.ToString(),
                    Color = SKColor.Parse("#00fbff")
                },

                      new Entry(clothingSum)
                {
                    Label = "Одяг",
                    ValueLabel = clothingSum.ToString(),
                    Color = SKColor.Parse("#002aff")
                },

                       new Entry(medicineSum)
                {
                    Label = "Медицина",
                    ValueLabel = medicineSum.ToString(),
                    Color = SKColor.Parse("#d000ff")
                },

                        new Entry(residenceSum)
                {
                    Label = "Проживання",
                    ValueLabel = residenceSum.ToString(),
                    Color = SKColor.Parse("#ff0090")
                },

                         new Entry(otherSum)
                {
                    Label = "Інше",
                    ValueLabel = otherSum.ToString(),
                    Color = SKColor.Parse("#0099ff")
                },
            };

            int tempIterator = 0;
            List<Entry> tempEntries = new List<Entry>();
            foreach (var e in entries)
            {
                if (e.Value != chekEntryes)
                {
                    tempEntries.Add(e);
                }
                tempIterator++;
            }

            entries = tempEntries;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           
            var chart = new DonutChart() { Entries = entries };
            chart.LabelTextSize = diagramTextSize;
            chart.HoleRadius = 0.4f;
            this.chartView.Chart = chart;
        }

        private void TypeOutlay_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TypeOutlay.SelectedIndex)
            {
                case 0:
                    var chart0 = new DonutChart() { Entries = entries };
                    chart0.LabelTextSize = diagramTextSize;
                    chart0.HoleRadius = 0.3f;
                    this.chartView.Chart = chart0;
                    break;
                case 1:
                    var chart1 = new RadialGaugeChart() { Entries = entries };
                    chart1.LabelTextSize = diagramTextSize;
                    this.chartView.Chart = chart1;
                    break;
                case 2:
                    var chart2 = new PointChart() { Entries = entries };
                    chart2.LabelTextSize = diagramTextSize;
                    this.chartView.Chart = chart2;
                    break;
                case 3:
                    var chart3 = new BarChart() { Entries = entries };
                    chart3.LabelTextSize = diagramTextSize;
                    this.chartView.Chart = chart3;
                    break;
            }
                
        }
    }
}