using System.Collections.ObjectModel;

namespace RSCProgerss.Model
{
    public class Order
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int countDetails;

        public int CountDetails
        {
            get { return countDetails; }
            set { countDetails = value; }
        }

        public Worker Worker { get; set; }
        public ObservableCollection<Detail> Details { get; set; }
        public Order() { }

    }
}
