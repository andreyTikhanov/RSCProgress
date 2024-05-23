using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public Worker Worker { get; set; }
		public ObservableCollection<Detail> Details { get; set; }
		public Order() { }

	}
}
