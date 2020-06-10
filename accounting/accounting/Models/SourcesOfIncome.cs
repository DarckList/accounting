using Realms;

namespace accounting.Models
{
    class SourcesOfIncome: RealmObject
    {
        [PrimaryKey]
        public int SourceOfIncome_Id { get; set; }

        public string SourceName { get; set; } //істочник якого типу кошти (карточка чи налічка)
        public string SourceComment { get; set; } // опис за що поступили кошти (зп на карточку, повернення боргу налічними...)
    }
}
